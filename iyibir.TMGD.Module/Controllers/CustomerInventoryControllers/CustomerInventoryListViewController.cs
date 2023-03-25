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

namespace iyibir.TMGD.Module.Controllers.CustomerInventoryControllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class CustomerInventoryListViewController : ViewController
    {
        public CustomerInventoryListViewController()
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

        private void showDataByInventory_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
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
                CustomerInventory existItem = ((ListView)View).CollectionSource.ObjectSpace.FindObject<CustomerInventory>(CriteriaOperator.Parse("HazardousGoods.Code", item.Code));
                if (existItem == null)
                {
                    CustomerInventory obj = View.ObjectSpace.CreateObject<CustomerInventory>();
                    obj.HazardousGoods = View.ObjectSpace.GetObjectByKey<HazardousGoods>(item.Oid);
                    ((ListView)View).CollectionSource.Add(obj);
                }
            }
        }

        private void newDocumentByInventory_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
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

                        foreach (CustomerInventory item in selectedObject)
                        {
                            TransportDocumentTransaction transportDocumentTransaction = os.CreateObject<TransportDocumentTransaction>();
                            transportDocumentTransaction.TransportDocument = transportDocument;
                            transportDocumentTransaction.Quantity = 1;
                            transportDocumentTransaction.InventoryCode = item.InventoryCode;
                            transportDocumentTransaction.InventoryName = item.InventoryName;
                            transportDocumentTransaction.HazardousGoods = os.GetObjectByKey<HazardousGoods>(item.HazardousGoods.Oid);
                            transportDocumentTransaction.PackingGroup = item.PackingGroup != null ? os.GetObjectByKey<PackingGroup>(item.PackingGroup.Oid) : null;
                            transportDocument.Consigner = os.GetObjectByKey<Customer>(item.Customer.Oid);
                            transportDocumentTransaction.PackingGroup = item.PackingGroup != null ? os.GetObjectByKey<PackingGroup>(item.PackingGroup.Oid) : null;
                            transportDocumentTransaction.PackagingTypes = item.PackagingTypes != null ? os.GetObjectByKey<PackagingTypes>(item.PackagingTypes.Oid) : null;
                            transportDocumentTransaction.Unitset = item.PackagingQuantityUnit != null ? os.GetObjectByKey<Unitset>(item.PackagingQuantityUnit.Oid) : null;
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

                        foreach (CustomerInventory item in selectedObject)
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
