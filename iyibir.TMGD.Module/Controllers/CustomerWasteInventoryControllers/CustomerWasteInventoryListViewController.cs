using System;
using System.Collections.Generic;
using System.Linq;
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

namespace iyibir.TMGD.Module.Controllers.CustomerWasteInventoryControllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class CustomerWasteInventoryListViewController : ViewController
    {
        public CustomerWasteInventoryListViewController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
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

        private void showDataByWasteInventory_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace os = Application.CreateObjectSpace(typeof(HazardousGoods));

            e.View = Application.CreateListView(typeof(HazardousGoods), true);
            e.DialogController.AcceptAction.Execute += AcceptAction_Execute;
        }

        private void AcceptAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var selectedItems = e.SelectedObjects;

            foreach (HazardousGoods item in selectedItems)
            {
                CustomerWasteInventory existItem = ((ListView)View).CollectionSource.ObjectSpace.FindObject<CustomerWasteInventory>(CriteriaOperator.Parse("HazardousGoods.Code", item.Code));
                if (existItem == null)
                {
                    CustomerWasteInventory obj = View.ObjectSpace.CreateObject<CustomerWasteInventory>();
                    obj.HazardousGoods = View.ObjectSpace.GetObjectByKey<HazardousGoods>(item.Oid);
                    ((ListView)View).CollectionSource.Add(obj);
                }
            }
        }

        private void newDocumentByWasteInventory_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
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
                        transportDocument.TransportDocumentType = TransportDocumentType.Waste;

                        foreach (CustomerWasteInventory item in selectedObject)
                        {
                            TransportDocumentOtherTransaction transportDocumentTransaction = os.CreateObject<TransportDocumentOtherTransaction>();
                            transportDocumentTransaction.TransportDocument = transportDocument;
                            transportDocumentTransaction.Quantity = 1;
                            //transportDocumentTransaction.InventoryCode = item.InventoryCode;
                            //transportDocumentTransaction.InventoryName = item.InventoryName;
                            transportDocumentTransaction.HazardousGoods = os.GetObjectByKey<HazardousGoods>(item.HazardousGoods.Oid);
                            transportDocumentTransaction.PackingGroup = item.PackingGroup != null ? os.GetObjectByKey<PackingGroup>(item.PackingGroup.Oid) : null;
                            transportDocument.Consigner = os.GetObjectByKey<Customer>(item.Customer.Oid);
                            transportDocument.OtherTransactions.Add(transportDocumentTransaction);
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

                        foreach (CustomerWasteInventory item in selectedObject)
                        {
                            vehicleControlDocument.Consigner = os.GetObjectByKey<Customer>(item.Customer.Oid);
                            break;
                        }

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
    }
}
