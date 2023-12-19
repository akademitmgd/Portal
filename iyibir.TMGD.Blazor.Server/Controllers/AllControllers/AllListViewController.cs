using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Blazor.Editors;

namespace iyibir.TMGD.Blazor.Server.Controllers.AllControllers;


public partial class AllListViewController : ViewController<ListView>
{
    public AllListViewController()
    {
        InitializeComponent();
    }
    protected override void OnActivated()
    {
        base.OnActivated();
    }
    protected override void OnViewControlsCreated()
    {
        base.OnViewControlsCreated();
        if (View.Editor is DxGridListEditor gridListEditor)
        {
            //Obtain the Component Adapter
            IDxGridAdapter dataGridAdapter = gridListEditor.GetGridAdapter();
            //Access grid component properties and specify how exactly a user can resize columns
            dataGridAdapter.GridModel.ColumnResizeMode = DevExpress.Blazor.GridColumnResizeMode.ColumnsContainer;
        }
    }
    protected override void OnDeactivated()
    {
        base.OnDeactivated();
    }
}
