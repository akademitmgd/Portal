using System.ComponentModel;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.Model.DomainLogics;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Xpo;
using DevExpress.ExpressApp.Blazor.Templates;
using DevExpress.ExpressApp.Utils;
using iyibir.TMGD.Module.Blazor.Editors;

namespace iyibir.TMGD.Module.Blazor;

[ToolboxItemFilter("Xaf.Platform.Blazor")]
public sealed partial class BlazorModule : ModuleBase {
    private void Application_CreateCustomUserModelDifferenceStore(Object sender, CreateCustomModelDifferenceStoreEventArgs e)
    {
        e.Store = new ModelDifferenceDbStore((XafApplication)sender, typeof(ModelDifference), false, "Blazor");
        e.Handled = true;
    }
    public BlazorModule()
    {
        InitializeComponent();

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
