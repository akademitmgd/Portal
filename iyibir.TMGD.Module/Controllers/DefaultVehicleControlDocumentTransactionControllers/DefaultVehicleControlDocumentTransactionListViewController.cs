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

namespace iyibir.TMGD.Module.Controllers.DefaultVehicleControlDocumentTransactionControllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class DefaultVehicleControlDocumentTransactionListViewController : ViewController
    {
        public DefaultVehicleControlDocumentTransactionListViewController()
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

        private void createDefaultControlList_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            Customer customer = View.CurrentObject as Customer;
            IList<DefaultVehicleDocumentControl> data;

            switch (e.SelectedChoiceActionItem.Id)
            {
                case "ambalajli":

                    data = View.ObjectSpace.GetObjects<DefaultVehicleDocumentControl>(CriteriaOperator.Parse("VControlOption = ?", 0));
                    
                    foreach (DefaultVehicleDocumentControl item in data)
                    {
                        DefaultVehicleControlDocumentTransaction defaultVehicleControlDocumentTransaction = View.ObjectSpace.CreateObject<DefaultVehicleControlDocumentTransaction>();
                        defaultVehicleControlDocumentTransaction.Customer = customer;
                        defaultVehicleControlDocumentTransaction.VControlOption = VehicleControlOption.Packaged;
                        defaultVehicleControlDocumentTransaction.Question = item.Question;

                        ((ListView)View).CollectionSource.Add(defaultVehicleControlDocumentTransaction);
                    }

                    View.Refresh();

                    break;
                case "tanker":

                    data = View.ObjectSpace.GetObjects<DefaultVehicleDocumentControl>(CriteriaOperator.Parse("VControlOption = ?", 1));

                    foreach (DefaultVehicleDocumentControl item in data)
                    {
                        DefaultVehicleControlDocumentTransaction defaultVehicleControlDocumentTransaction = View.ObjectSpace.CreateObject<DefaultVehicleControlDocumentTransaction>();
                        defaultVehicleControlDocumentTransaction.Customer = customer;
                        defaultVehicleControlDocumentTransaction.VControlOption = VehicleControlOption.Tanker;
                        defaultVehicleControlDocumentTransaction.Question = item.Question;

                        ((ListView)View).CollectionSource.Add(defaultVehicleControlDocumentTransaction);
                    }

                    View.Refresh();

                    break;
                case "sinirliMiktar":

                    data = View.ObjectSpace.GetObjects<DefaultVehicleDocumentControl>(CriteriaOperator.Parse("VControlOption = ?", 2));

                    foreach (DefaultVehicleDocumentControl item in data)
                    {
                        DefaultVehicleControlDocumentTransaction defaultVehicleControlDocumentTransaction = View.ObjectSpace.CreateObject<DefaultVehicleControlDocumentTransaction>();
                        defaultVehicleControlDocumentTransaction.Customer = customer;
                        defaultVehicleControlDocumentTransaction.VControlOption = VehicleControlOption.LimitedQuantity;
                        defaultVehicleControlDocumentTransaction.Question = item.Question;

                        ((ListView)View).CollectionSource.Add(defaultVehicleControlDocumentTransaction);
                    }

                    View.Refresh();

                    break;
                case "istisnaiMiktar":

                    data = View.ObjectSpace.GetObjects<DefaultVehicleDocumentControl>(CriteriaOperator.Parse("VControlOption = ?", 3));

                    foreach (DefaultVehicleDocumentControl item in data)
                    {
                        DefaultVehicleControlDocumentTransaction defaultVehicleControlDocumentTransaction = View.ObjectSpace.CreateObject<DefaultVehicleControlDocumentTransaction>();
                        defaultVehicleControlDocumentTransaction.Customer = customer;
                        defaultVehicleControlDocumentTransaction.VControlOption = VehicleControlOption.ExceptionalQuantity;
                        defaultVehicleControlDocumentTransaction.Question = item.Question;

                        ((ListView)View).CollectionSource.Add(defaultVehicleControlDocumentTransaction);
                    }

                    View.Refresh();

                    break;
                default:
                    break;
            }
        }
    }
}
