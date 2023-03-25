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
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppWindowControllertopic.aspx.
    public partial class AllWindowController : WindowController
    {
        IObjectSpace os;
        public AllWindowController()
        {
            InitializeComponent();
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            os = Window.Application.CreateObjectSpace();
            int count = os.GetObjects<AnnouncementUser>(CriteriaOperator.Parse("Employee.Oid = ? and IsRead = false", SecuritySystem.CurrentUserId)).Count;
            this.shAnno.Caption = string.Format("{0}", count);
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        private void shAnno_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            e.ShowViewParameters.CreatedView = Application.CreateListView(typeof(Announcement), true);
        }
    }
}
