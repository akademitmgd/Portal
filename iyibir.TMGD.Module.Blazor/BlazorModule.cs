using System;
using System.Linq;
using System.Text;
using System.ComponentModel;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.Model.DomainLogics;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Utils;
using iyibir.TMGD.Module.Blazor.Editors;
using DevExpress.ExpressApp.Blazor.Templates;

namespace iyibir.TMGD.Module.Blazor
{
    [ToolboxItemFilter("Xaf.Platform.Blazor")]
    // For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ModuleBase.
    public sealed partial class BeonPlusBlazorModule : ModuleBase
    {
        //private void Application_CreateCustomModelDifferenceStore(Object sender, CreateCustomModelDifferenceStoreEventArgs e) {
        //    e.Store = new ModelDifferenceDbStore((XafApplication)sender, typeof(ModelDifference), true, "Blazor");
        //    e.Handled = true;
        //}
        private void Application_CreateCustomUserModelDifferenceStore(Object sender, CreateCustomModelDifferenceStoreEventArgs e)
        {
            e.Store = new ModelDifferenceDbStore((XafApplication)sender, typeof(ModelDifference), false, "Blazor");
            e.Handled = true;
        }
        public BeonPlusBlazorModule()
        {
            InitializeComponent();
            DataAccessModeHelper.RegisterEditorSupportedModes(typeof(TreeListEditor), new[] { CollectionSourceDataAccessMode.Client });
            DataAccessModeHelper.RegisterEditorSupportedModes(typeof(SchedulerListEditor), new[] { CollectionSourceDataAccessMode.Client });
        }
        public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB)
        {
            return ModuleUpdater.EmptyModuleUpdaters;
        }
        public override void Setup(XafApplication application)
        {
            base.Setup(application);
            application.CustomizeTemplate += Application_CustomizeTemplate;
            //application.CreateCustomModelDifferenceStore += Application_CreateCustomModelDifferenceStore;
            application.CreateCustomUserModelDifferenceStore += Application_CreateCustomUserModelDifferenceStore;
            // Manage various aspects of the application UI and behavior at the module level.
        }
        private void Application_CustomizeTemplate(object sender, CustomizeTemplateEventArgs e)
        {
            if (e.Template is IPopupWindowTemplateSize size)
            {
                size.MaxWidth = "100vw";
                size.Width = "1200px";
                size.MaxHeight = "100vh";
                size.Height = "1200px";
            }
        }
    }
}
