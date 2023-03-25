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

namespace iyibir.TMGD.Module.Controllers.CustomerControllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class CustomerListViewController : ViewController
    {
        public CustomerListViewController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            if (View is ListView)
            {
                Employee employee = (SecuritySystem.CurrentUser as Employee);
                if (employee != null)
                {
                    if (!new Helpers.Helper().IsAdministrator(employee))
                    {
                        switch (employee.EmployeeType)
                        {
                            case EmployeeType.Employee:
                                if (employee.IsManager)
                                    ((ListView)View).CollectionSource.Criteria.Remove("FilterMyConsultant");
                                else
                                {
                                    ((ListView)View).CollectionSource.Criteria.Clear();
                                    ((ListView)View).CollectionSource.Criteria.Add("FilterMyConsultant", CriteriaOperator.Parse("Consultant.Oid = ? ", SecuritySystem.CurrentUserId));
                                    ((ListView)View).RefreshDataSource();
                                    ((ListView)View).Refresh();
                                }
                                break;
                            case EmployeeType.Customer:
                                ((ListView)View).CollectionSource.Criteria.Clear();
                                ((ListView)View).CollectionSource.Criteria.Add("FilterCustomer", CriteriaOperator.Parse("Oid = ? ", employee.Customer != null ? employee.Customer.Oid : Guid.Empty));
                                ((ListView)View).RefreshDataSource();
                                ((ListView)View).Refresh();
                                break;
                            default:
                                break;
                        }
                    }


                }


            }
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
    }
}
