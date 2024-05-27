using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using iyibir.TMGD.Module.BusinessObjects;
using iyibir.TMGD.Module.KersiaHelper.Model;
using iyibir.TMGD.Module.NonPersistentObjects;

namespace iyibir.TMGD.Module.Controllers.TransportDocumentControllers;


public partial class TransportDocumentDetailViewController : ViewController
{
    private PopupWindowShowAction kersiaGetERP;
    public TransportDocumentDetailViewController()
    {
        InitializeComponent();

        kersiaGetERP = new PopupWindowShowAction(this, nameof(kersiaGetERP), PredefinedCategory.View);
        kersiaGetERP.CustomizePopupWindowParams += KersiaGetERP_CustomizePopupWindowParams;

        this.Actions["kersiaGetERP"].Active.SetItemValue("Hide", false);
    }

    private void KersiaGetERP_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
    {
        IObjectSpace os = Application.CreateObjectSpace(typeof(NP_DispatchList));

        string listViewId = Application.FindListViewId(typeof(NP_DispatchList));

        CollectionSourceBase cs = Application.CreateCollectionSource(os, typeof(NP_DispatchList), listViewId);

        

        //ListView listView = Application.CreateListView(listViewId, cs, true);


        e.View = Application.CreateListView(listViewId, cs, true);
        e.DialogController.AcceptAction.Execute += getERPData_AcceptAction_Execute;
    }

    protected override void OnActivated()
    {
        base.OnActivated();
        this.Actions["addHazardousGoods"].Active.SetItemValue("Hide", false);
    }
    protected override void OnViewControlsCreated()
    {
        base.OnViewControlsCreated();
        // Access and customize the target View control.
    }
    protected override void OnDeactivated()
    {
        // Unsubscribe from previously subscribed events and release other references and resources.
        base.OnDeactivated();
    }

    private void addHazardousGoods_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
    {
        TransportDocument transportDocument = View.CurrentObject as TransportDocument;
        if (transportDocument != null)
        {
            IObjectSpace os = Application.CreateObjectSpace();
            string listView = string.Empty;
            CollectionSourceBase cs;

            switch (transportDocument.TransportDocumentType)
            {
                case TransportDocumentType.Product:
                    listView = "Product_ListView";
                    cs = Application.CreateCollectionSource(os, typeof(Product), listView);
                    cs.Criteria.Add("ConsignerByProduct", CriteriaOperator.Parse("Customer.Oid = ? and ProductGroupType = ?", transportDocument.Consigner.Oid, 0));

                    e.View = Application.CreateListView(typeof(Product), true);
                    e.DialogController.AcceptAction.Execute += Product_AcceptAction_Execute;

                    break;
                case TransportDocumentType.Waste:
                    listView = "Product_ListView_Waste";
                    cs = Application.CreateCollectionSource(os, typeof(Product), listView);
                    cs.Criteria.Add("ConsignerByProduct", CriteriaOperator.Parse("Customer.Oid = ?", transportDocument.Consigner.Oid));

                    e.View = Application.CreateListView(typeof(Product), true);
                    e.DialogController.AcceptAction.Execute += Product_AcceptAction_Execute;
                    break;
                default:
                    throw new UserFriendlyException("Lütfen Önce Gönderici Seçiniz..");
            }
        }
    }

    private void Product_AcceptAction_Execute(object sender, SimpleActionExecuteEventArgs e)
    {
        TransportDocument transportDocument = View.CurrentObject as TransportDocument;
        if (transportDocument != null)
        {
            switch (transportDocument.TransportDocumentType)
            {
                case TransportDocumentType.Product:

                    foreach (Product item in e.SelectedObjects)
                    {
                        TransportDocumentTransaction transportDocumentTransaction = View.ObjectSpace.CreateObject<TransportDocumentTransaction>();
                        transportDocumentTransaction.TransportDocument = transportDocument;
                        transportDocumentTransaction.Quantity = 1;
                        transportDocumentTransaction.InventoryCode = item.Code;
                        transportDocumentTransaction.InventoryName = item.Name;
                        transportDocumentTransaction.HazardousGoods = View.ObjectSpace.GetObjectByKey<HazardousGoods>(item.HazardousGoods.Oid);
                        transportDocumentTransaction.PackagingTypes = item.PackagingTypes != null ? View.ObjectSpace.GetObjectByKey<PackagingTypes>(item.PackagingTypes.Oid) : null;
                        transportDocumentTransaction.PackingGroup = View.ObjectSpace.GetObjectByKey<PackingGroup>(transportDocumentTransaction.HazardousGoods.PackingGroups.FirstOrDefault().Oid);
                        transportDocumentTransaction.TunnelCode = View.ObjectSpace.GetObjectByKey<HazardousGoodsTunnelCode>(transportDocumentTransaction.HazardousGoods.TunnelCodes.FirstOrDefault().Oid);
                        transportDocumentTransaction.TransportCategory = View.ObjectSpace.GetObjectByKey<HazardousGoodsTransportCategory>(transportDocumentTransaction.HazardousGoods.TransportCategory.FirstOrDefault().Oid);
                        transportDocumentTransaction.HazardousGoodsLabel = View.ObjectSpace.GetObjectByKey<HazardousGoodsLabel>(transportDocumentTransaction.HazardousGoods.Labels.OrderBy(x => x.LineNumber).FirstOrDefault().HazardousGoodsLabel.Oid);

                        transportDocument.Transactions.Add(transportDocumentTransaction);

                        View.Refresh();
                    }

                    break;
                case TransportDocumentType.Waste:

                    foreach (Product item in e.SelectedObjects)
                    {
                        TransportDocumentOtherTransaction transportDocumentOtherTransaction = View.ObjectSpace.CreateObject<TransportDocumentOtherTransaction>();
                        transportDocumentOtherTransaction.TransportDocument = transportDocument;
                        transportDocumentOtherTransaction.Quantity = 1;
                        transportDocumentOtherTransaction.WasteCode = View.ObjectSpace.GetObjectByKey<WasteList>(item.WasteCode.Oid);
                        transportDocumentOtherTransaction.HazardousGoods = View.ObjectSpace.GetObjectByKey<HazardousGoods>(item.HazardousGoods.Oid);
                        transportDocumentOtherTransaction.PackagingTypes = item.PackagingTypes != null ? View.ObjectSpace.GetObjectByKey<PackagingTypes>(item.PackagingTypes.Oid) : null;
                        transportDocumentOtherTransaction.PackingGroup = View.ObjectSpace.GetObjectByKey<PackingGroup>(transportDocumentOtherTransaction.HazardousGoods.PackingGroups.FirstOrDefault().Oid);
                        transportDocumentOtherTransaction.TunnelCode = View.ObjectSpace.GetObjectByKey<HazardousGoodsTunnelCode>(transportDocumentOtherTransaction.HazardousGoods.TunnelCodes.FirstOrDefault().Oid);
                        transportDocumentOtherTransaction.HazardousGoodsLabel = View.ObjectSpace.GetObjectByKey<HazardousGoodsLabel>(transportDocumentOtherTransaction.HazardousGoods.Labels.OrderBy(x => x.LineNumber).FirstOrDefault().HazardousGoodsLabel.Oid);

                        transportDocument.OtherTransactions.Add(transportDocumentOtherTransaction);

                        View.Refresh();
                    }

                    break;
                default:
                    break;
            }
        }
    }

    private void showCustomerInventory_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
    {
        TransportDocument transportDocument = View.CurrentObject as TransportDocument;
        if (transportDocument != null)
        {
            string listViewId = "Product_ListView";
            IObjectSpace os = Application.CreateObjectSpace(typeof(Product));
            CollectionSourceBase cs = Application.CreateCollectionSource(os, typeof(Product), listViewId);
            cs.Criteria.Add("productFilterByTransport", CriteriaOperator.Parse("Customer.Oid = ? and ProductGroupType = ?", transportDocument.Consigner.Oid, 0));

            e.View = Application.CreateListView(listViewId, cs, true);
            e.DialogController.AcceptAction.Execute += Inventory_AcceptAction_Execute;
        }
    }

    private void Inventory_AcceptAction_Execute(object sender, SimpleActionExecuteEventArgs e)
    {
        TransportDocument transportDocument = View.CurrentObject as TransportDocument;
        if (transportDocument != null)
        {
            foreach (Product item in e.SelectedObjects)
            {
                TransportDocumentTransaction transportDocumentTransaction = View.ObjectSpace.CreateObject<TransportDocumentTransaction>();

                transportDocumentTransaction.TransportDocument = transportDocument;
                transportDocumentTransaction.Quantity = 1;
                transportDocumentTransaction.InventoryCode = item.Code;
                transportDocumentTransaction.InventoryName = item.Name;
                transportDocumentTransaction.HazardousGoods = View.ObjectSpace.GetObjectByKey<HazardousGoods>(item.HazardousGoods.Oid);
                transportDocumentTransaction.PackagingTypes = item.PackagingTypes != null ? View.ObjectSpace.GetObjectByKey<PackagingTypes>(item.PackagingTypes.Oid) : null;
                transportDocumentTransaction.PackingGroup = View.ObjectSpace.GetObjectByKey<PackingGroup>(transportDocumentTransaction.HazardousGoods.PackingGroups.FirstOrDefault().Oid);
                transportDocumentTransaction.TunnelCode = View.ObjectSpace.GetObjectByKey<HazardousGoodsTunnelCode>(transportDocumentTransaction.HazardousGoods.TunnelCodes.FirstOrDefault().Oid);
                transportDocumentTransaction.TransportCategory = View.ObjectSpace.GetObjectByKey<HazardousGoodsTransportCategory>(transportDocumentTransaction.HazardousGoods.TransportCategory.FirstOrDefault().Oid);
                transportDocumentTransaction.HazardousGoodsLabel = View.ObjectSpace.GetObjectByKey<HazardousGoodsLabel>(transportDocumentTransaction.HazardousGoods.Labels.OrderBy(x => x.LineNumber).FirstOrDefault().HazardousGoodsLabel.Oid);

                transportDocument.Transactions.Add(transportDocumentTransaction);
            }

            View.Refresh();
        }
    }

    private void showCustomerWasteInventory_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
    {
        TransportDocument transportDocument = View.CurrentObject as TransportDocument;
        if (transportDocument != null)
        {
            string listViewId = "Product_ListView_Waste";
            IObjectSpace os = Application.CreateObjectSpace(typeof(Product));
            CollectionSourceBase cs = Application.CreateCollectionSource(os, typeof(Product), listViewId);
            cs.Criteria.Add("wasteProductFilterByTransport", CriteriaOperator.Parse("Customer.Oid = ? and ProductGroupType = ?", transportDocument.Consigner.Oid, 1));

            e.View = Application.CreateListView(listViewId, cs, true);
            e.DialogController.AcceptAction.Execute += WasteInventory_AcceptAction_Execute;
        }
    }

    private void WasteInventory_AcceptAction_Execute(object sender, SimpleActionExecuteEventArgs e)
    {
        TransportDocument transportDocument = View.CurrentObject as TransportDocument;
        if (transportDocument != null)
        {
            foreach (Product item in e.SelectedObjects)
            {
                TransportDocumentOtherTransaction transportDocumentTransaction = View.ObjectSpace.CreateObject<TransportDocumentOtherTransaction>();

                transportDocumentTransaction.TransportDocument = transportDocument;
                transportDocumentTransaction.Quantity = 1;
                transportDocumentTransaction.WasteCode = View.ObjectSpace.GetObjectByKey<WasteList>(item.WasteCode.Oid);
                transportDocumentTransaction.HazardousGoods = View.ObjectSpace.GetObjectByKey<HazardousGoods>(item.HazardousGoods.Oid);
                transportDocumentTransaction.PackagingTypes = item.PackagingTypes != null ? View.ObjectSpace.GetObjectByKey<PackagingTypes>(item.PackagingTypes.Oid) : null;
                transportDocumentTransaction.PackingGroup = View.ObjectSpace.GetObjectByKey<PackingGroup>(transportDocumentTransaction.HazardousGoods.PackingGroups.FirstOrDefault().Oid);
                transportDocumentTransaction.TunnelCode = View.ObjectSpace.GetObjectByKey<HazardousGoodsTunnelCode>(transportDocumentTransaction.HazardousGoods.TunnelCodes.FirstOrDefault().Oid);
                transportDocumentTransaction.TransportCategory = View.ObjectSpace.GetObjectByKey<HazardousGoodsTransportCategory>(transportDocumentTransaction.HazardousGoods.TransportCategory.FirstOrDefault().Oid);
                transportDocumentTransaction.HazardousGoodsLabel = View.ObjectSpace.GetObjectByKey<HazardousGoodsLabel>(transportDocumentTransaction.HazardousGoods.Labels.OrderBy(x => x.LineNumber).FirstOrDefault().HazardousGoodsLabel.Oid);

                transportDocument.OtherTransactions.Add(transportDocumentTransaction);
            }

            View.Refresh();
        }
    }

    private void addDefaultDescription_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
    {
        TransportDocument transportDocument = View.CurrentObject as TransportDocument;
        IObjectSpace os = Application.CreateObjectSpace();
        string listViewId = Application.FindListViewId(typeof(DefaultTransportDescription));

        CollectionSourceBase cs = Application.CreateCollectionSource(os, typeof(DefaultTransportDescription), listViewId);
        cs.Criteria.Add("filterByIsActive", CriteriaOperator.Parse("IsActive = ?", true));

        e.View = Application.CreateListView(listViewId, cs, true);
        e.DialogController.AcceptAction.Execute += AcceptAction_Execute;
    }

    private void AcceptAction_Execute(object sender, SimpleActionExecuteEventArgs e)
    {
        var selectedItems = e.SelectedObjects;
        TransportDocument transportDocument = View.CurrentObject as TransportDocument;

        foreach (DefaultTransportDescription desc in selectedItems)
        {
            TransportDocumentDescription transportDocumentDescription = View.ObjectSpace.CreateObject<TransportDocumentDescription>();
            transportDocumentDescription.TransportDocument = transportDocument;
            transportDocumentDescription.Description = desc.Description;

            transportDocument.Descriptions.Add(transportDocumentDescription);
        }

        View.Refresh();

    }

    private void checkLoadedStatus_Execute(object sender, SimpleActionExecuteEventArgs e)
    {
        TransportDocument transportDocument = View.CurrentObject as TransportDocument;
        if (transportDocument != null)
        {
            bool result = false;

            switch (transportDocument.TransportDocumentType)
            {
                case TransportDocumentType.Product:

                    if (transportDocument.Transactions.ToList().Exists(x => x.HazardousGoods != null))
                    {
                        foreach (var item in transportDocument.Transactions)
                        {
                            HazardousGoodsLabel hazardousGoodsLabel = item.HazardousGoodsLabel;
                            foreach (var loadList in hazardousGoodsLabel.MixedLoadedList.Where(x => x.MixedLoadingType == MixedLoadingType.Denied).ToList())
                            {
                                if (transportDocument.Transactions.ToList().Exists(x => x.HazardousGoodsLabel.Code == loadList.LoadedHazardousGoodsLabel.Code))
                                {
                                    result = true;
                                    break;
                                }
                            }
                        }

                        if (result)
                        {
                            MessageOptions options = new MessageOptions();
                            options.Duration = 2000;
                            options.Message = string.Format("Bu Tehlikeli Maddeler Birlikte Yüklenemez..", e.SelectedObjects.Count);
                            options.Type = InformationType.Error;
                            options.Web.Position = InformationPosition.Right;

                            //options.Win.Caption = "Success";
                            //options.Win.Type = WinMessageType.Toast;
                            options.OkDelegate = () =>
                            {
                            };
                            Application.ShowViewStrategy.ShowMessage(options);
                        }
                        else
                        {
                            MessageOptions options = new MessageOptions();
                            options.Duration = 2000;
                            options.Message = string.Format("Bu Tehlikeli Maddeler Birlikte Yüklenebilir..", e.SelectedObjects.Count);
                            options.Type = InformationType.Success;
                            options.Web.Position = InformationPosition.Right;

                            //options.Win.Caption = "Success";
                            //options.Win.Type = WinMessageType.Toast;
                            options.OkDelegate = () =>
                            {
                            };
                            Application.ShowViewStrategy.ShowMessage(options);
                        }
                    }
                    else
                    {
                        MessageOptions options = new MessageOptions();
                        options.Duration = 2000;
                        options.Message = string.Format("Tehlikeli Maddeler de Etiket Bulunamadı.. Lütfen Kontrol Ediniz..", e.SelectedObjects.Count);
                        options.Type = InformationType.Info;
                        options.Web.Position = InformationPosition.Right;

                        //options.Win.Caption = "Success";
                        //options.Win.Type = WinMessageType.Toast;
                        options.OkDelegate = () =>
                        {
                        };
                        Application.ShowViewStrategy.ShowMessage(options);
                    }
                    break;
                case TransportDocumentType.Waste:
                    if (transportDocument.OtherTransactions.ToList().Exists(x => x.HazardousGoods != null))
                    {
                        foreach (var item in transportDocument.OtherTransactions)
                        {
                            HazardousGoodsLabel hazardousGoodsLabel = item.HazardousGoodsLabel;
                            foreach (var loadList in hazardousGoodsLabel.MixedLoadedList.Where(x => x.MixedLoadingType == MixedLoadingType.Denied).ToList())
                            {
                                if (transportDocument.OtherTransactions.ToList().Exists(x => x.HazardousGoodsLabel.Code == loadList.LoadedHazardousGoodsLabel.Code))
                                {
                                    result = true;
                                    break;
                                }
                            }
                        }

                        if (result)
                        {
                            MessageOptions options = new MessageOptions();
                            options.Duration = 2000;
                            options.Message = string.Format("Bu Tehlikeli Maddeler Birlikte Yüklenemez..", e.SelectedObjects.Count);
                            options.Type = InformationType.Error;
                            options.Web.Position = InformationPosition.Right;

                            //options.Win.Caption = "Success";
                            //options.Win.Type = WinMessageType.Toast;
                            options.OkDelegate = () =>
                            {
                            };
                            Application.ShowViewStrategy.ShowMessage(options);
                        }
                        else
                        {
                            MessageOptions options = new MessageOptions();
                            options.Duration = 2000;
                            options.Message = string.Format("Bu Tehlikeli Maddeler Birlikte Yüklenebilir.", e.SelectedObjects.Count);
                            options.Type = InformationType.Success;
                            options.Web.Position = InformationPosition.Right;

                            //options.Win.Caption = "Success";
                            //options.Win.Type = WinMessageType.Toast;
                            options.OkDelegate = () =>
                            {
                            };
                            Application.ShowViewStrategy.ShowMessage(options);
                        }
                    }
                    else
                    {
                        MessageOptions options = new MessageOptions();
                        options.Duration = 2000;
                        options.Message = string.Format("Tehlikeli Maddeler de Etiket Bulunamadı.. Lütfen Kontrol Ediniz..", e.SelectedObjects.Count);
                        options.Type = InformationType.Info;
                        options.Web.Position = InformationPosition.Right;

                        //options.Win.Caption = "Success";
                        //options.Win.Type = WinMessageType.Toast;
                        options.OkDelegate = () =>
                        {
                        };
                        Application.ShowViewStrategy.ShowMessage(options);
                    }
                    break;
                default:
                    break;
            }
        }
    }

    private void getErpData_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
    {
        IObjectSpace os = Application.CreateObjectSpace(typeof(NP_DispatchList));

        string listViewId = Application.FindListViewId(typeof(NP_DispatchList));

        CollectionSourceBase cs = Application.CreateCollectionSource(os, typeof(NP_DispatchList), listViewId);

        e.View = Application.CreateListView(listViewId, cs, true);
        e.DialogController.AcceptAction.Execute += getERPData_AcceptAction_Execute;
    }

    private void getERPData_AcceptAction_Execute(object sender, SimpleActionExecuteEventArgs e)
    {
        var selectedItems = e.SelectedObjects;
        if (selectedItems.Count > 1)
        {
            throw new UserFriendlyException("Lütfen 1 adet İrsaliye seçiniz..");
        }
        else
        {
            NP_DispatchList dispatch = e.CurrentObject as NP_DispatchList;
            TransportDocument transportDocument = View.CurrentObject as TransportDocument;

            transportDocument.Consignee = View.ObjectSpace.FindObject<Consignee>(CriteriaOperator.Parse("Customer.Oid = ? and Code = ?", transportDocument.Consigner.Oid, dispatch.ClientCode));
            transportDocument.CreatedDate = dispatch.CreatedOn;
            transportDocument.Code = dispatch.FicheNo;
            transportDocument.Shipper = View.ObjectSpace.FindObject<Consignee>(CriteriaOperator.Parse("Customer.Oid = ? and Code = ? and ConsigneeType = ?", transportDocument.Consigner.Oid, dispatch.ShipperCode,3));
            transportDocument.Vehicle = View.ObjectSpace.FindObject<Vehicle>(CriteriaOperator.Parse("Customer.Oid = ? and Plate = ?", transportDocument.Consigner.Oid, dispatch.VehiclePlate1));
            transportDocument.OtherVehicle = View.ObjectSpace.FindObject<Vehicle>(CriteriaOperator.Parse("Customer.Oid = ? and Plate = ?", transportDocument.Consigner.Oid, dispatch.VehiclePlate2));
            transportDocument.Driver = View.ObjectSpace.FindObject<VehicleDriver>(CriteriaOperator.Parse("Customer.Oid = ? and TCKN = ?", transportDocument.Consigner.Oid, dispatch.DriverTCKN1));
           
            if (transportDocument.Consignee != null)
            {
                foreach (var item in dispatch.Lines)
                {
                    Product product = View.ObjectSpace.FindObject<Product>(CriteriaOperator.Parse("Code = ?", item.ItemCode));
                    if (product != null)
                    {
                        if (transportDocument.TransportDocumentType == TransportDocumentType.Product)
                        {
                            if (product.HazardousGoods != null)
                            {
                                TransportDocumentTransaction transportDocumentTransaction = View.ObjectSpace.CreateObject<TransportDocumentTransaction>();
                                transportDocumentTransaction.TransportDocument = transportDocument;
                                transportDocumentTransaction.Quantity = item.Quantity;
                                transportDocumentTransaction.InventoryCode = item.ItemCode;
                                transportDocumentTransaction.InventoryName = item.ItemName;
                                transportDocumentTransaction.HazardousGoods = View.ObjectSpace.GetObjectByKey<HazardousGoods>(product.HazardousGoods.Oid);
                                transportDocumentTransaction.PackagingTypes = product.PackagingTypes != null ? View.ObjectSpace.GetObjectByKey<PackagingTypes>(product.PackagingTypes.Oid) : null;
                                transportDocumentTransaction.PackingGroup = View.ObjectSpace.GetObjectByKey<PackingGroup>(transportDocumentTransaction.HazardousGoods.PackingGroups.FirstOrDefault().Oid);
                                transportDocumentTransaction.TunnelCode = View.ObjectSpace.GetObjectByKey<HazardousGoodsTunnelCode>(transportDocumentTransaction.HazardousGoods.TunnelCodes.FirstOrDefault().Oid);
                                transportDocumentTransaction.TransportCategory = View.ObjectSpace.GetObjectByKey<HazardousGoodsTransportCategory>(transportDocumentTransaction.HazardousGoods.TransportCategory.FirstOrDefault().Oid);
                                transportDocumentTransaction.HazardousGoodsLabel = View.ObjectSpace.GetObjectByKey<HazardousGoodsLabel>(transportDocumentTransaction.HazardousGoods.Labels.OrderBy(x => x.LineNumber).FirstOrDefault().HazardousGoodsLabel.Oid);

                                transportDocument.Transactions.Add(transportDocumentTransaction);
                            }
                            else
                                throw new UserFriendlyException(string.Format("{0}-{1} Ürününe ait Tehlikeli Madde Kaydı Bulunamadı..", item.ItemCode, item.ItemName));

                        }
                        else
                        {
                            if (product.HazardousGoods != null)
                            {
                                TransportDocumentOtherTransaction transportDocumentOtherTransaction = View.ObjectSpace.CreateObject<TransportDocumentOtherTransaction>();
                                transportDocumentOtherTransaction.TransportDocument = transportDocument;
                                transportDocumentOtherTransaction.Quantity = item.Quantity;
                                //transportDocumentOtherTransaction.InventoryCode = item.ItemCode;
                                //transportDocumentOtherTransaction.InventoryName = item.ItemName;
                                transportDocumentOtherTransaction.HazardousGoods = View.ObjectSpace.GetObjectByKey<HazardousGoods>(product.HazardousGoods.Oid);

                                transportDocument.OtherTransactions.Add(transportDocumentOtherTransaction);
                            }
                            else
                                throw new UserFriendlyException(string.Format("{0}-{1} Ürününe ait Tehlikeli Madde Kaydı Bulunamadı..", item.ItemCode, item.ItemName));
                        }
                    }
                }

                View.Refresh();
            }
        }
    }
}
