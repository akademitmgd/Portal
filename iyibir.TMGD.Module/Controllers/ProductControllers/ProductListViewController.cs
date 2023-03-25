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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iyibir.TMGD.Module.Controllers.ProductControllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ProductListViewController : ViewController
    {
        public ProductListViewController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            new Helpers.Helper().FilterProductDocument(View, SecuritySystem.CurrentUser as Employee);
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

        private void newDocumentByProduct_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            var selectedObject = View.SelectedObjects;
            if (selectedObject.Count > 0)
            {
                IObjectSpace os = Application.CreateObjectSpace();
                DetailView detailView;
                switch (e.SelectedChoiceActionItem.Id)
                {
                    case "tasimaEvraki":
                        TransportDocument transportDocument = os.CreateObject<TransportDocument>();

                        foreach (Product item in selectedObject)
                        {
                            TransportDocumentTransaction transportDocumentTransaction = os.CreateObject<TransportDocumentTransaction>();
                            transportDocumentTransaction.TransportDocument = transportDocument;
                            transportDocumentTransaction.Quantity = 1;
                            transportDocumentTransaction.InventoryCode = item.Code;
                            transportDocumentTransaction.InventoryName = item.Name;
                            transportDocumentTransaction.HazardousGoods = os.GetObjectByKey<HazardousGoods>(item.HazardousGoods.Oid);
                            //transportDocumentTransaction.PackingGroup = item.HazardousGoods.PackingGroups != null ? os.GetObjectByKey<PackingGroup>(item.PackingGroup.Oid) : null;
                            transportDocument.Consigner = os.GetObjectByKey<Customer>(item.Customer.Oid);
                            transportDocumentTransaction.PackagingTypes = item.PackagingTypes != null ? os.GetObjectByKey<PackagingTypes>(item.PackagingTypes.Oid) : null;
                            transportDocumentTransaction.Unitset = item.Unitset != null ? os.GetObjectByKey<Unitset>(item.Unitset.Oid) : null;
                            transportDocumentTransaction.PackagingTypes = item.PackagingTypes != null ? os.GetObjectByKey<PackagingTypes>(item.PackagingTypes.Oid) : null;
                            transportDocumentTransaction.PackingGroup = os.GetObjectByKey<PackingGroup>(transportDocumentTransaction.HazardousGoods.PackingGroups.FirstOrDefault().Oid);
                            transportDocumentTransaction.TunnelCode = os.GetObjectByKey<HazardousGoodsTunnelCode>(transportDocumentTransaction.HazardousGoods.TunnelCodes.FirstOrDefault().Oid);
                            transportDocumentTransaction.TransportCategory = os.GetObjectByKey<HazardousGoodsTransportCategory>(transportDocumentTransaction.HazardousGoods.TransportCategory.FirstOrDefault().Oid);
                            transportDocumentTransaction.HazardousGoodsLabel = os.GetObjectByKey<HazardousGoodsLabel>(transportDocumentTransaction.HazardousGoods.Labels.OrderBy(x => x.LineNumber).FirstOrDefault().HazardousGoodsLabel.Oid);
                            transportDocument.Transactions.Add(transportDocumentTransaction);
                        }

                        detailView = Application.CreateDetailView(os, transportDocument);
                        detailView.ViewEditMode = ViewEditMode.Edit;

                        e.ShowViewParameters.CreatedView = detailView;
                        e.ShowViewParameters.Context = TemplateContext.View;
                        e.ShowViewParameters.NewWindowTarget = NewWindowTarget.Default;
                        e.ShowViewParameters.TargetWindow = TargetWindow.NewModalWindow;

                        break;
                    case "aracKontrol":

                        VehicleControlDocument vehicleControlDocument = os.CreateObject<VehicleControlDocument>();

                        #region HazardousGoods
                        foreach (Product item in selectedObject)
                        {
                            VehicleControlDocumentHazardousGoods hazardousGoods = os.CreateObject<VehicleControlDocumentHazardousGoods>();
                            hazardousGoods.VehicleControlDocument = vehicleControlDocument;
                            hazardousGoods.HazardousGoods = item.HazardousGoods != null ? os.GetObjectByKey<HazardousGoods>(item.HazardousGoods.Oid) : null;


                            vehicleControlDocument.HazardousGoods.Add(hazardousGoods);
                            //vehicleControlDocument.Consigner = os.GetObjectByKey<Customer>(item.Customer.Oid);

                        }
                        #endregion

                        #region Labels
                        foreach (VehicleControlDocumentHazardousGoods item in vehicleControlDocument.HazardousGoods)
                        {
                            foreach (LabelTransaction lbl in item.HazardousGoods.Labels)
                            {
                                if (!vehicleControlDocument.Labels.ToList().Exists(x => x.HazardousGoodsLabel.Oid == lbl.HazardousGoodsLabel.Oid))
                                {
                                    VehicleControlDocumentLabel vehicleControlDocumentLabel = os.CreateObject<VehicleControlDocumentLabel>();
                                    vehicleControlDocumentLabel.VehicleControlDocument = vehicleControlDocument;
                                    vehicleControlDocumentLabel.HazardousGoodsLabel = os.GetObjectByKey<HazardousGoodsLabel>(lbl.HazardousGoodsLabel.Oid);

                                    vehicleControlDocument.Labels.Add(vehicleControlDocumentLabel);
                                }
                            }
                        } 
                        #endregion

                        #region Label Controllers
                        foreach (VehicleControlDocumentLabel label in vehicleControlDocument.Labels)
                        {
                            foreach (HazardousGoodsLabelController controller in label.HazardousGoodsLabel.Controllers)
                            {
                                if (!vehicleControlDocument.Transactions.ToList().Exists(x => x.Question == controller.Question))
                                {
                                    VehicleControlDocumentTransaction transaction = os.CreateObject<VehicleControlDocumentTransaction>();
                                    transaction.VehicleControlDocument = vehicleControlDocument;
                                    transaction.Question = controller.Question;

                                    vehicleControlDocument.Transactions.Add(transaction);
                                }
                            }
                        }
                        #endregion

                        detailView = Application.CreateDetailView(os, vehicleControlDocument);
                        detailView.ViewEditMode = ViewEditMode.Edit;

                        e.ShowViewParameters.CreatedView = detailView;
                        e.ShowViewParameters.Context = TemplateContext.View;
                        e.ShowViewParameters.NewWindowTarget = NewWindowTarget.Default;
                        e.ShowViewParameters.TargetWindow = TargetWindow.NewModalWindow;
                        break;
                    default:
                        break;
                }
            }
        }

        private void addHazardousGoods_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {


            e.View = Application.CreateListView(typeof(HazardousGoods), true);
            e.DialogController.AcceptAction.Execute += AcceptAction_Execute;
        }

        private void AcceptAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            HazardousGoods hazardousGoods = e.CurrentObject as HazardousGoods;
            if (hazardousGoods != null)
            {
                IObjectSpace os = Application.CreateObjectSpace(typeof(Product));
                Product product = os.CreateObject<Product>();
                product.HazardousGoods = os.GetObjectByKey<HazardousGoods>(hazardousGoods.Oid);

                DetailView detailView = Application.CreateDetailView(os, product);
                detailView.ViewEditMode = ViewEditMode.Edit;

                e.ShowViewParameters.CreatedView = detailView;
                e.ShowViewParameters.Context = TemplateContext.PopupWindow;
                e.ShowViewParameters.NewWindowTarget = NewWindowTarget.Default;
                e.ShowViewParameters.TargetWindow = TargetWindow.NewModalWindow;
                e.ShowViewParameters.Controllers.Add(new DialogController());
            }

            View.Refresh();
        }
    }
}
