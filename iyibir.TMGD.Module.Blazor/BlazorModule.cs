using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Blazor.Templates;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl;
using System.ComponentModel;

namespace iyibir.TMGD.Module.Blazor;

[ToolboxItemFilter("Xaf.Platform.Blazor")]
// For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ModuleBase.
public sealed partial class BlazorModule : ModuleBase {

    private void Application_CreateCustomUserModelDifferenceStore(Object sender, CreateCustomModelDifferenceStoreEventArgs e)
    {
        e.Store = new ModelDifferenceDbStore((XafApplication)sender, typeof(ModelDifference), false, "Blazor");
        e.Handled = true;
    }

    public BlazorModule() {

        InitializeComponent();
       
        //DataAccessModeHelper.RegisterEditorSupportedModes(typeof(TreeListEditor), new[] { CollectionSourceDataAccessMode.Client });
        //DataAccessModeHelper.RegisterEditorSupportedModes(typeof(SchedulerListEditor), new[] { CollectionSourceDataAccessMode.Client });

    }
    public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB) {
        ModuleUpdater updater = new DatabaseUpdate.Updater(objectSpace, versionFromDB);
        return new ModuleUpdater[] { updater };
    }
    public override void Setup(XafApplication application) {
        base.Setup(application);
        application.CustomizeTemplate += Application_CustomizeTemplate;
        //application.CreateCustomModelDifferenceStore += Application_CreateCustomModelDifferenceStore;
        application.CreateCustomUserModelDifferenceStore += Application_CreateCustomUserModelDifferenceStore;
        // Manage various aspects of the application UI and behavior at the module level.
    }
    public override void CustomizeTypesInfo(ITypesInfo typesInfo) {
        base.CustomizeTypesInfo(typesInfo);
        CalculatedPersistentAliasHelper.CustomizeTypesInfo(typesInfo);
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
