namespace iyibir.TMGD.Module.Controllers.VoyageNotificationControllers
{
    partial class VoyageNotificationListViewController
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
            this.updatedVoyageNotification = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            this.aktivatedVoyageNotification = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.cancelledVoyageNotification = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            this.approveVoyageNotification = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // updatedVoyageNotification
            // 
            this.updatedVoyageNotification.AcceptButtonCaption = null;
            this.updatedVoyageNotification.CancelButtonCaption = null;
            this.updatedVoyageNotification.Caption = "updated Voyage Notification";
            this.updatedVoyageNotification.Category = "View";
            this.updatedVoyageNotification.ConfirmationMessage = "Sefer Güncellenecektir. Devam Etmek İstiyor musunuz ?";
            this.updatedVoyageNotification.Id = "updatedVoyageNotification";
            this.updatedVoyageNotification.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.updatedVoyageNotification.TargetObjectsCriteria = "Status = 1";
            this.updatedVoyageNotification.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.updatedVoyageNotification.ToolTip = null;
            this.updatedVoyageNotification.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.updatedVoyageNotification.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.updatedVoyageNotification_CustomizePopupWindowParams);
            // 
            // aktivatedVoyageNotification
            // 
            this.aktivatedVoyageNotification.Caption = "aktivated Voyage Notification";
            this.aktivatedVoyageNotification.Category = "View";
            this.aktivatedVoyageNotification.ConfirmationMessage = null;
            this.aktivatedVoyageNotification.Id = "aktivatedVoyageNotification";
            this.aktivatedVoyageNotification.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.aktivatedVoyageNotification.TargetObjectsCriteria = "Status = 2";
            this.aktivatedVoyageNotification.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.VoyageNotification);
            this.aktivatedVoyageNotification.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.aktivatedVoyageNotification.ToolTip = null;
            this.aktivatedVoyageNotification.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.aktivatedVoyageNotification.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.aktivatedVoyageNotification_Execute);
            // 
            // cancelledVoyageNotification
            // 
            this.cancelledVoyageNotification.AcceptButtonCaption = null;
            this.cancelledVoyageNotification.CancelButtonCaption = null;
            this.cancelledVoyageNotification.Caption = "cancelled Voyage Notification";
            this.cancelledVoyageNotification.Category = "View";
            this.cancelledVoyageNotification.ConfirmationMessage = "Seçili sefer iptal edilecektir. Devam etmek istiyor musunuz ?";
            this.cancelledVoyageNotification.Id = "cancelledVoyageNotification";
            this.cancelledVoyageNotification.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.cancelledVoyageNotification.TargetObjectsCriteria = "Status = 1";
            this.cancelledVoyageNotification.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.VoyageNotification);
            this.cancelledVoyageNotification.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.cancelledVoyageNotification.ToolTip = null;
            this.cancelledVoyageNotification.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.cancelledVoyageNotification.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.cancelledVoyageNotification_CustomizePopupWindowParams);
            // 
            // approveVoyageNotification
            // 
            this.approveVoyageNotification.Caption = "Bakanlığa Bildir";
            this.approveVoyageNotification.Category = "View";
            this.approveVoyageNotification.ConfirmationMessage = "Seçili Sefer ve Yükler Bakanlığa Bildirilecektir. İşleme Devam Etmek İstiyor musu" +
    "nuz ?";
            this.approveVoyageNotification.Id = "approveVoyageNotification";
            this.approveVoyageNotification.ImageName = "Action_Grant";
            this.approveVoyageNotification.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.approveVoyageNotification.TargetObjectsCriteria = "Status = 0";
            this.approveVoyageNotification.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.VoyageNotification);
            this.approveVoyageNotification.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.approveVoyageNotification.ToolTip = null;
            this.approveVoyageNotification.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.approveVoyageNotification.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.approveVoyageNotification_Execute);
            // 
            // VoyageNotificationListViewController
            // 
            this.Actions.Add(this.updatedVoyageNotification);
            this.Actions.Add(this.aktivatedVoyageNotification);
            this.Actions.Add(this.cancelledVoyageNotification);
            this.Actions.Add(this.approveVoyageNotification);
            this.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.VoyageNotification);
            this.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction updatedVoyageNotification;
        private DevExpress.ExpressApp.Actions.SimpleAction aktivatedVoyageNotification;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction cancelledVoyageNotification;
        private DevExpress.ExpressApp.Actions.SimpleAction approveVoyageNotification;
    }
}
