using DevExpress.Blazor;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Blazor.Editors;

namespace iyibir.TMGD.Blazor.Server.Controllers;

public partial class AutoFitController : ViewController<ListView>
{
	private IGrid GridInstance => View.Editor is DxGridListEditor editor ? editor.GridInstance : null;

	public AutoFitController()
	{
		SimpleAction action1 = new SimpleAction(this, "Ölçekle", "Edit", (s, e) => GridInstance?.AutoFitColumnWidths());
	}
	protected override void OnViewControlsCreated()
	{
		base.OnViewControlsCreated();
		if (View.Editor is DxGridListEditor editor)
		{
			editor.GridComponentCaptured += (_, e) => e.Grid.AutoFitColumnWidths();
		}
	}
}
