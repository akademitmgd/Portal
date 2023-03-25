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

namespace iyibir.TMGD.Module.Controllers.AllViewControllers.CustomerControllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class CustomerViewController : ViewController
    {
        public CustomerViewController()
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

        private void documentList_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            Customer customer = View.CurrentObject as Customer;
            if (customer != null)
            {
                DetailView detailView;
                IObjectSpace os = Application.CreateObjectSpace();

                switch (e.SelectedChoiceActionItem.Id)
                {
                    case "adrDenetimTespit":
                        AuditDeterminationForm auditDeterminationForm = os.CreateObject<AuditDeterminationForm>();
                        auditDeterminationForm.Customer = os.GetObjectByKey<Customer>(customer.Oid);
                        detailView = Application.CreateDetailView(os, auditDeterminationForm);

                        e.ShowViewParameters.CreatedView = detailView;
                        e.ShowViewParameters.Context = TemplateContext.View;
                        e.ShowViewParameters.NewWindowTarget = NewWindowTarget.Default;
                        e.ShowViewParameters.TargetWindow = TargetWindow.Current;
                        break;
                    case "aracKontrolFormu":
                        VehicleControlDocument vehicleControlDocument = os.CreateObject<VehicleControlDocument>();
                        vehicleControlDocument.Consigner = os.GetObjectByKey<Customer>(customer.Oid);
                        detailView = Application.CreateDetailView(os, vehicleControlDocument);

                        e.ShowViewParameters.CreatedView = detailView;
                        e.ShowViewParameters.Context = TemplateContext.View;
                        e.ShowViewParameters.NewWindowTarget = NewWindowTarget.Default;
                        e.ShowViewParameters.TargetWindow = TargetWindow.Current;
                        break;
                    case "gorevDagilimFormu":
                        DistributionOfTask distributionOfTask = os.CreateObject<DistributionOfTask>();
                        distributionOfTask.Customer = os.GetObjectByKey<Customer>(customer.Oid);
                        detailView = Application.CreateDetailView(os, distributionOfTask);

                        e.ShowViewParameters.CreatedView = detailView;
                        e.ShowViewParameters.Context = TemplateContext.View;
                        e.ShowViewParameters.NewWindowTarget = NewWindowTarget.Default;
                        e.ShowViewParameters.TargetWindow = TargetWindow.Current;
                        break;
                    case "kazaRaporu":
                        ReportOnOccurrence reportOnOccurrence = os.CreateObject<ReportOnOccurrence>();
                        //reportOnOccurrence. = os.GetObjectByKey<Customer>(customer.Oid);
                        detailView = Application.CreateDetailView(os, reportOnOccurrence);

                        e.ShowViewParameters.CreatedView = detailView;
                        e.ShowViewParameters.Context = TemplateContext.View;
                        e.ShowViewParameters.NewWindowTarget = NewWindowTarget.Default;
                        e.ShowViewParameters.TargetWindow = TargetWindow.Current;
                        break;
                    case "tasimaEvraki":
                        TransportDocument transportDocument = os.CreateObject<TransportDocument>();
                        transportDocument.Consigner = os.GetObjectByKey<Customer>(customer.Oid);
                        detailView = Application.CreateDetailView(os, transportDocument);

                        e.ShowViewParameters.CreatedView = detailView;
                        e.ShowViewParameters.Context = TemplateContext.View;
                        e.ShowViewParameters.NewWindowTarget = NewWindowTarget.Default;
                        e.ShowViewParameters.TargetWindow = TargetWindow.Current;
                        break;
                    case "tatbikatDegerlendirme":
                        DrillForm drillForm = os.CreateObject<DrillForm>();
                        drillForm.Customer = os.GetObjectByKey<Customer>(customer.Oid);
                        detailView = Application.CreateDetailView(os, drillForm);

                        e.ShowViewParameters.CreatedView = detailView;
                        e.ShowViewParameters.Context = TemplateContext.View;
                        e.ShowViewParameters.NewWindowTarget = NewWindowTarget.Default;
                        e.ShowViewParameters.TargetWindow = TargetWindow.Current;
                        break;
                    case "tesisZiyaret":
                        Activity activity = os.CreateObject<Activity>();
                        activity.Customer = os.GetObjectByKey<Customer>(customer.Oid);
                        detailView = Application.CreateDetailView(os, activity);

                        e.ShowViewParameters.CreatedView = detailView;
                        e.ShowViewParameters.Context = TemplateContext.View;
                        e.ShowViewParameters.NewWindowTarget = NewWindowTarget.Default;
                        e.ShowViewParameters.TargetWindow = TargetWindow.Current;
                        break;

                }
            }
        }
    }
}
