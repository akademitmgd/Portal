namespace iyibir.TMGD.Module.Controllers.VehicleControlDocumentTransactionControllers
{
    partial class VehicleControlDocumentTransactionListViewController
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
            this.showTransactionHint = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // showTransactionHint
            // 
            this.showTransactionHint.AcceptButtonCaption = null;
            this.showTransactionHint.CancelButtonCaption = null;
            this.showTransactionHint.Caption = "show Transaction Hint";
            this.showTransactionHint.Category = "Edit";
            this.showTransactionHint.ConfirmationMessage = null;
            this.showTransactionHint.Id = "showTransactionHint";
            this.showTransactionHint.ImageName = "About";
            this.showTransactionHint.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.Image;
            this.showTransactionHint.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.showTransactionHint.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.VehicleControlDocumentTransaction);
            this.showTransactionHint.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.showTransactionHint.ToolTip = null;
            this.showTransactionHint.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.showTransactionHint.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.showTransactionHint_CustomizePopupWindowParams);
            // 
            // VehicleControlDocumentTransactionListViewController
            // 
            this.Actions.Add(this.showTransactionHint);
            this.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.VehicleControlDocumentTransaction);
            this.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction showTransactionHint;
    }
}
