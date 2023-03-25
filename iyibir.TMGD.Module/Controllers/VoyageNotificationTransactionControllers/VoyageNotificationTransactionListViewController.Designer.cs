namespace iyibir.TMGD.Module.Controllers.VoyageNotificationTransactionControllers
{
    partial class VoyageNotificationTransactionListViewController
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
            this.cancelledTransaction = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            this.aktivatedTransaction = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.updatedTransaction = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // cancelledTransaction
            // 
            this.cancelledTransaction.AcceptButtonCaption = null;
            this.cancelledTransaction.CancelButtonCaption = null;
            this.cancelledTransaction.Caption = "cancelled Transaction";
            this.cancelledTransaction.Category = "View";
            this.cancelledTransaction.ConfirmationMessage = null;
            this.cancelledTransaction.Id = "cancelledTransaction";
            this.cancelledTransaction.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.cancelledTransaction.TargetObjectsCriteria = "Status = 1";
            this.cancelledTransaction.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.VoyageNotificationTransaction);
            this.cancelledTransaction.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.cancelledTransaction.ToolTip = null;
            this.cancelledTransaction.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.cancelledTransaction.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.cancelledTransaction_CustomizePopupWindowParams);
            // 
            // aktivatedTransaction
            // 
            this.aktivatedTransaction.Caption = "aktivated Transaction";
            this.aktivatedTransaction.Category = "View";
            this.aktivatedTransaction.ConfirmationMessage = "Yük Aktif Edilecektir. Devam Etmek İstiyor Musunuz ?";
            this.aktivatedTransaction.Id = "aktivatedTransaction";
            this.aktivatedTransaction.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.aktivatedTransaction.TargetObjectsCriteria = "Status = 2";
            this.aktivatedTransaction.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.VoyageNotificationTransaction);
            this.aktivatedTransaction.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.aktivatedTransaction.ToolTip = null;
            this.aktivatedTransaction.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.aktivatedTransaction.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.aktivatedTransaction_Execute);
            // 
            // updatedTransaction
            // 
            this.updatedTransaction.AcceptButtonCaption = null;
            this.updatedTransaction.CancelButtonCaption = null;
            this.updatedTransaction.Caption = "updated Transaction";
            this.updatedTransaction.Category = "View";
            this.updatedTransaction.ConfirmationMessage = "Seçili yük düzenlenecektir. Devam etmek istiyor musunuz ?";
            this.updatedTransaction.Id = "updatedTransaction";
            this.updatedTransaction.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.updatedTransaction.TargetObjectsCriteria = "Status = 1";
            this.updatedTransaction.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.VoyageNotificationTransaction);
            this.updatedTransaction.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.updatedTransaction.ToolTip = null;
            this.updatedTransaction.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.updatedTransaction.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.updatedTransaction_CustomizePopupWindowParams);
            // 
            // VoyageNotificationTransactionListViewController
            // 
            this.Actions.Add(this.cancelledTransaction);
            this.Actions.Add(this.aktivatedTransaction);
            this.Actions.Add(this.updatedTransaction);
            this.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.VoyageNotificationTransaction);
            this.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction cancelledTransaction;
        private DevExpress.ExpressApp.Actions.SimpleAction aktivatedTransaction;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction updatedTransaction;
    }
}
