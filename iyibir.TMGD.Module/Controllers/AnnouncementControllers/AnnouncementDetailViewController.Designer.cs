namespace iyibir.TMGD.Module.Controllers.AnnouncementControllers
{
    partial class AnnouncementDetailViewController
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
            this.addEmployee = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // addEmployee
            // 
            this.addEmployee.AcceptButtonCaption = null;
            this.addEmployee.CancelButtonCaption = null;
            this.addEmployee.Caption = "add Employee";
            this.addEmployee.Category = "View";
            this.addEmployee.ConfirmationMessage = null;
            this.addEmployee.Id = "addEmployee";
            this.addEmployee.ImageName = "BO_User";
            this.addEmployee.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.Announcement);
            this.addEmployee.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.addEmployee.ToolTip = null;
            this.addEmployee.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
            this.addEmployee.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.addEmployee_CustomizePopupWindowParams);
            // 
            // AnnouncementDetailViewController
            // 
            this.Actions.Add(this.addEmployee);
            this.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.Announcement);
            this.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction addEmployee;
    }
}
