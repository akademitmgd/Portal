using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Blazor.Editors.Grid;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iyibir.TMGD.Module.Blazor.Controllers.AllControllers
{
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

                    //dataGridAdapter.DataGridModel.EditMode = DevExpress.Blazor.DataGridEditMode.PopupEditForm;
                    //dataGridAdapter.DataGridModel.ColumnResizeMode = DevExpress.Blazor.DataGridColumnResizeMode.Component;
                    //dataGridAdapter.DataGridModel.AllowSort = true;
                    //dataGridAdapter.DataGridModel.ShowFilterRow = true;
                    //dataGridAdapter.DataGridModel.ShowGroupPanel = true;
                    //dataGridAdapter.DataGridModel.AutoCollapseDetailRow = true;
                    //dataGridAdapter.DataGridModel.AllowColumnDragDrop = true;
                    //dataGridAdapter.DataGridSelectionColumnModel.ShowInColumnChooser = true;
                }

            } 
        }
        protected override void OnDeactivated()
        {
            base.OnDeactivated();
        }
    }
}
