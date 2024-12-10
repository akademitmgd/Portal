using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Blazor.Editors.Models;

namespace iyibir.TMGD.Blazor.Server.Controllers;

public partial class AllListViewController : ViewController<ListView>
{
	private DxGridListEditor listEditor;
	public AllListViewController()
	{
		InitializeComponent();
	}
	protected override void OnViewControlsCreated()
	{
		base.OnViewControlsCreated();
		listEditor = View.Editor as DxGridListEditor;
		if (listEditor != null)
		{
			DxGridModel dataGridAdapter = listEditor.GridModel;
			if (dataGridAdapter != null)
			{
				//dataGridAdapter. = DevExpress.Blazor.ScrollBarMode.Auto;
				//dataGridAdapter.Data = DevExpress.Blazor.ScrollBarMode.Auto;
				//dataGridAdapter.DataGridModel.SelectionMode = DevExpress.Blazor.DataGridSelectionMode.MultipleSelectedDataRows;
				dataGridAdapter.AllowColumnReorder = true;
				//dataGridAdapter.EditMode = DevExpress.Blazor.GridEditMode.PopupEditForm;

				dataGridAdapter.ColumnResizeMode = DevExpress.Blazor.GridColumnResizeMode.ColumnsContainer;
				dataGridAdapter.AllowSort = true;
				dataGridAdapter.ShowFilterRow = true;
				dataGridAdapter.ShowGroupPanel = true;
				dataGridAdapter.AutoCollapseDetailRow = true;
				
			}

		}
	}
}
