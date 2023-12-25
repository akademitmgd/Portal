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

namespace iyibir.TMGD.Module.Controllers.AllViewControllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class AllViewController : ViewController
    {
        public AllViewController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }

        ListView listView;
        protected override void OnActivated()
        {
            base.OnActivated();

            if (View is ListView && View.IsRoot)
            {
                
                //if (count > 0)
                //{
                //    IObjectSpace os = Application.CreateObjectSpace();
                //    string listViewId = Application.FindListViewId(typeof(Announcement));

                //    CollectionSourceBase cs = Application.CreateCollectionSource(os, typeof(Announcement), listViewId);

                //    cs.Criteria.Add("AnnouncementByEmployee", CriteriaOperator.Parse("Users[Employee.Oid = ? and IsRead = False]", SecuritySystem.CurrentUserId));

                //    listView = Application.CreateListView(listViewId, cs, false);

                //    Application.ShowViewStrategy.ShowViewInPopupWindow(listView, OkDelegate, CancelDelegate, "Oku", "Kapat");

                //}
            }
        }

        private void CancelDelegate()
        {
            // place the code for the 'Cancel' button here
        }

        private void OkDelegate()
        {
            IObjectSpace os = Application.CreateObjectSpace();

            ShowViewParameters svp = new ShowViewParameters();
            svp.CreatedView = Application.CreateListView(os, typeof(Announcement), true);
            Application.ShowViewStrategy.ShowView(svp, new ShowViewSource(null, null));

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

        private void showAnnouncement_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            //e.ShowViewParameters.CreatedView = Application.CreateListView(typeof(Announcement), true);
        }
    }
}
