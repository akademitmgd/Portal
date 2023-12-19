using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Blazor.Editors.Grid;

namespace iyibir.TMGD.Module.Blazor.Controllers.AllListViewControllers;


public partial class AllListViewController : ViewController<ListView>
{

    private GridListEditor listEditor;
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
        listEditor = View.Editor as GridListEditor;
        if (listEditor != null)
        {
            IDxDataGridAdapter dataGridAdapter = listEditor.GetDataGridAdapter();
            if (dataGridAdapter != null)
            {
                //dataGridAdapter.DataGridModel.HorizontalScrollBarMode = DevExpress.Blazor.ScrollBarMode.Auto;
                //dataGridAdapter.DataGridModel.VerticalScrollBarMode = DevExpress.Blazor.ScrollBarMode.Auto;
                //dataGridAdapter.DataGridModel.SelectionMode = DevExpress.Blazor.DataGridSelectionMode.MultipleSelectedDataRows;

                dataGridAdapter.DataGridModel.EditMode = DevExpress.Blazor.DataGridEditMode.PopupEditForm;
                dataGridAdapter.DataGridModel.ColumnResizeMode = DevExpress.Blazor.DataGridColumnResizeMode.Component;
                dataGridAdapter.DataGridModel.AllowSort = true;
                dataGridAdapter.DataGridModel.ShowFilterRow = true;
                dataGridAdapter.DataGridModel.ShowGroupPanel = true;
                dataGridAdapter.DataGridModel.AutoCollapseDetailRow = true;
                dataGridAdapter.DataGridModel.AllowColumnDragDrop = true;
                dataGridAdapter.DataGridSelectionColumnModel.ShowInColumnChooser = true;
            }

        }
    }
    protected override void OnDeactivated()
    {
        base.OnDeactivated();
    }
}
