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

namespace iyibir.TMGD.Module.Controllers.EmployeeControllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class EmployeeListViewController : ViewController
    {
        public EmployeeListViewController()
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

        private void showLOGOParameter_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            Employee employee = View.CurrentObject as Employee;
            if (employee != null)
            {
                IObjectSpace os = Application.CreateObjectSpace(typeof(LOGOParameter));
                LOGOParameter parameter;               

                parameter = os.FindObject<LOGOParameter>(CriteriaOperator.Parse("Employee.Oid = ? and IsActive = ?", SecuritySystem.CurrentUserId,true));
                if (parameter == null)
                {
                    parameter = os.CreateObject<LOGOParameter>();
                    parameter.Employee = os.GetObjectByKey<Employee>(SecuritySystem.CurrentUserId);
                    parameter.IsActive = true;
                }

                DetailView detailView = Application.CreateDetailView(os, parameter);
                detailView.ViewEditMode = ViewEditMode.Edit;

                e.View = detailView;
            }
        }
    }
}
