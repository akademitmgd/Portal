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
using iyibir.TMGD.Module.NonPersistentObjects;

namespace iyibir.TMGD.Module.Controllers.VehicleControlDocumentTransactionControllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class VehicleControlDocumentTransactionListViewController : ViewController
    {
        public VehicleControlDocumentTransactionListViewController()
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

        private void showTransactionHint_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            VehicleControlDocumentTransaction vehicleControlDocumentTransaction = View.CurrentObject as VehicleControlDocumentTransaction;
            if (vehicleControlDocumentTransaction != null)
            {
                IObjectSpace os = Application.CreateObjectSpace(typeof(NP_TransactionHint));

                NP_TransactionHint hint = os.CreateObject<NP_TransactionHint>();
                hint.Hint = vehicleControlDocumentTransaction.Hint;

                DetailView detailView = Application.CreateDetailView(os, hint);
                detailView.ViewEditMode = ViewEditMode.View;

                e.View = detailView;
            }
        }
    }
}
