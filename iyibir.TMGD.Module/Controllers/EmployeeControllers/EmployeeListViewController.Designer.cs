
namespace iyibir.TMGD.Module.Controllers.EmployeeControllers
{
    partial class EmployeeListViewController
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.showLOGOParameter = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // showLOGOParameter
            // 
            this.showLOGOParameter.AcceptButtonCaption = null;
            this.showLOGOParameter.CancelButtonCaption = null;
            this.showLOGOParameter.Caption = "show LOGOParameter";
            this.showLOGOParameter.Category = "View";
            this.showLOGOParameter.ConfirmationMessage = null;
            this.showLOGOParameter.Id = "showLOGOParameter";
            this.showLOGOParameter.ImageName = "BO_List";
            this.showLOGOParameter.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.showLOGOParameter.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.Employee);
            this.showLOGOParameter.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.showLOGOParameter.ToolTip = null;
            this.showLOGOParameter.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.showLOGOParameter.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.showLOGOParameter_CustomizePopupWindowParams);
            // 
            // EmployeeListViewController
            // 
            this.Actions.Add(this.showLOGOParameter);
            this.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.Employee);
            this.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction showLOGOParameter;
    }
}
