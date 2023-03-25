namespace iyibir.TMGD.Module.Controllers.CustomFileControllers
{
    partial class CustomFileListViewController
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
            this.createCustomFile = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // createCustomFile
            // 
            this.createCustomFile.AcceptButtonCaption = null;
            this.createCustomFile.CancelButtonCaption = null;
            this.createCustomFile.Caption = "New";
            this.createCustomFile.Category = "ObjectsCreation";
            this.createCustomFile.ConfirmationMessage = null;
            this.createCustomFile.Id = "createCustomFile";
            this.createCustomFile.ImageName = "New";
            this.createCustomFile.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.CustomFile);
            this.createCustomFile.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.createCustomFile.ToolTip = null;
            this.createCustomFile.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.createCustomFile.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.createCustomFile_CustomizePopupWindowParams);
            // 
            // CustomFileListViewController
            // 
            this.Actions.Add(this.createCustomFile);
            this.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.CustomFile);
            this.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction createCustomFile;
    }
}
