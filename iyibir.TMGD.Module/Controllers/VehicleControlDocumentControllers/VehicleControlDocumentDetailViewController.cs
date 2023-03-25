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

namespace iyibir.TMGD.Module.Controllers.VehicleControlDocumentControllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class VehicleControlDocumentDetailViewController : ViewController
    {
        public VehicleControlDocumentDetailViewController()
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

        private void addProductByVehicleControl_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            VehicleControlDocument vehicleControlDocument = View.CurrentObject as VehicleControlDocument;
            IObjectSpace os = Application.CreateObjectSpace();

            string listViewId = Application.FindListViewId(typeof(Product));

            CollectionSourceBase cs = Application.CreateCollectionSource(os, typeof(Product), listViewId);
            cs.Criteria.Add("HazardousGoodsByCustomer", CriteriaOperator.Parse("Customer.Oid = ?", vehicleControlDocument.Consigner.Oid));

            e.View = Application.CreateListView(listViewId, cs, true);
            e.DialogController.AcceptAction.Execute += AcceptAction_Execute;
        }

        private void AcceptAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var selectedObjects = e.SelectedObjects;
            VehicleControlDocument vehicleControlDocument = View.CurrentObject as VehicleControlDocument;
            IObjectSpace os = Application.CreateObjectSpace();

            #region HazardousGoods
            foreach (Product item in selectedObjects)
            {
                if (!vehicleControlDocument.HazardousGoods.ToList().Exists(x => x.HazardousGoods.Oid == item.HazardousGoods.Oid))
                {
                    VehicleControlDocumentHazardousGoods hazardousGoods = View.ObjectSpace.CreateObject<VehicleControlDocumentHazardousGoods>();
                    hazardousGoods.VehicleControlDocument = View.ObjectSpace.GetObjectByKey<VehicleControlDocument>( vehicleControlDocument.Oid);
                    hazardousGoods.HazardousGoods = item.HazardousGoods != null ? View.ObjectSpace.GetObjectByKey<HazardousGoods>(item.HazardousGoods.Oid) : null;

                    foreach (LabelTransaction label in item.HazardousGoods.Labels)
                    {
                        if (!vehicleControlDocument.Labels.ToList().Exists(x => x.HazardousGoodsLabel.Oid == label.HazardousGoodsLabel.Oid))
                        {
                            VehicleControlDocumentLabel vehicleControlDocumentLabel = View.ObjectSpace.CreateObject<VehicleControlDocumentLabel>();
                            vehicleControlDocumentLabel.VehicleControlDocument = View.ObjectSpace.GetObjectByKey<VehicleControlDocument>( vehicleControlDocument.Oid);
                            vehicleControlDocumentLabel.HazardousGoodsLabel = View.ObjectSpace.GetObjectByKey<HazardousGoodsLabel>(label.HazardousGoodsLabel.Oid);

                            foreach (HazardousGoodsLabelController controller in label.HazardousGoodsLabel.Controllers)
                            {
                                if (!vehicleControlDocument.Transactions.ToList().Exists(x => x.Question == controller.Question))
                                {
                                    VehicleControlDocumentTransaction transaction = View.ObjectSpace.CreateObject<VehicleControlDocumentTransaction>();
                                    transaction.VehicleControlDocument = View.ObjectSpace.GetObjectByKey<VehicleControlDocument>(vehicleControlDocument.Oid);
                                    transaction.Question = controller.Question;

                                    vehicleControlDocument.Transactions.Add(transaction);
                                }
                            }

                            vehicleControlDocument.Labels.Add(vehicleControlDocumentLabel);
                        }
                    }


                    vehicleControlDocument.HazardousGoods.Add(hazardousGoods);
                }
            }

            //os.CommitChanges();
            //View.RefreshDataSource();
            View.Refresh();
            #endregion
        }
    }
}
