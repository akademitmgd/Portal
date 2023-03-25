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

namespace iyibir.TMGD.Module.Controllers.AnnouncementControllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class AnnouncementDetailViewController : ViewController
    {
        IObjectSpace os;
        public AnnouncementDetailViewController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();

            if ((View.CurrentObject as Announcement).CreatedBy != null)
            {
                if ((View.CurrentObject as Announcement).CreatedBy.Oid != (SecuritySystem.CurrentUser as Employee).Oid)
                {
                    if (((DetailView)View).ViewEditMode == ViewEditMode.Edit)
                    {
                        ((DetailView)View).ViewEditMode = ViewEditMode.View;
                        Actions["addEmployee"].Active.SetItemValue("Hide", false);
                    }
                }
            }


            AnnouncementReadControl();
        }
        private void AnnouncementReadControl()
        {
            Announcement announcement = View.CurrentObject as Announcement;

            AnnouncementUser announcementUser = announcement.Users.FirstOrDefault(x => x.Employee.Oid == (Guid)SecuritySystem.CurrentUserId);

            if (announcementUser != null)
            {
                announcementUser.IsRead = true;
                announcementUser.ReadDate = DateTime.Now;
                View.ObjectSpace.CommitChanges();
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

        private void addEmployee_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            if (os == null)
                os = Application.CreateObjectSpace();

            string listViewId = Application.FindLookupListViewId(typeof(Employee)); //"Employee_ListView_Custom";
            CollectionSourceBase cs = Application.CreateCollectionSource(os, typeof(Employee), listViewId);
            cs.Criteria.Add("employees", CriteriaOperator.Parse("IsActive = ?", true));
            e.View = Application.CreateListView(listViewId, cs, true);
            e.DialogController.AcceptAction.Execute += AddEmployee_Execute;
        }

        private void AddEmployee_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            Announcement announcement = View.CurrentObject as Announcement;
            var selectedEmployees = e.SelectedObjects;
            if (announcement != null && selectedEmployees.Count > 0)
            {
                if (os == null)
                    os = Application.CreateObjectSpace();

                foreach (Employee emp in selectedEmployees)
                {
                    AnnouncementUser announcementUser = View.ObjectSpace.CreateObject<AnnouncementUser>();
                    announcementUser.Employee = View.ObjectSpace.GetObjectByKey<Employee>(emp.Oid);
                    announcementUser.IsRead = false;

                    announcement.Users.Add(announcementUser);
                    announcement.Employees.Add(View.ObjectSpace.GetObjectByKey<Employee>(emp.Oid));
                }

                os.CommitChanges();
            }
        }
    }
}
