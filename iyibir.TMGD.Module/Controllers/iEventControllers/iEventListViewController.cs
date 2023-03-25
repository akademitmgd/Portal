using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.Scheduler;
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

namespace iyibir.TMGD.Module.Controllers.iEventControllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class iEventListViewController : ViewController
    {
        private SchedulerListEditorBase schedulerEditor;
        public iEventListViewController()
        {
            InitializeComponent();
            this.TargetViewType = ViewType.ListView;
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            //schedulerEditor = ((ListView)View).Editor as SchedulerListEditorBase;
            //if (schedulerEditor != null)
            //{
            //    schedulerEditor.ExceptionEventCreated += new EventHandler<ExceptionEventCreatedEventArgs>(schedulerEditor_ExceptionEventCreated);
            //}
        }

        void schedulerEditor_ExceptionEventCreated(object sender, ExceptionEventCreatedEventArgs e)
        {
            if (e.PatternEvent is iEvent && e.ExceptionEvent is iEvent)
            {
                ((iEvent)e.ExceptionEvent).Description = ((iEvent)e.PatternEvent).Description;
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
