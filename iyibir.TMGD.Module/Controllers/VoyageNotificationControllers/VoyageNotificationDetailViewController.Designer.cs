
namespace iyibir.TMGD.Module.Controllers.VoyageNotificationControllers
{
    partial class VoyageNotificationDetailViewController
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
            this.approveVoyageNotificationTransactions = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // approveVoyageNotificationTransactions
            // 
            this.approveVoyageNotificationTransactions.Caption = "Sefere Yük Bildir";
            this.approveVoyageNotificationTransactions.Category = "View";
            this.approveVoyageNotificationTransactions.ConfirmationMessage = "Sefere yük bildirimi gerçekleştirilecektir. Devam etmek istiyor musunuz ? İşlem b" +
    "iraz zaman alabilir.";
            this.approveVoyageNotificationTransactions.Id = "approveVoyageNotificationTransactions";
            this.approveVoyageNotificationTransactions.TargetObjectsCriteria = "Status = 1 and ReferenceId > 0";
            this.approveVoyageNotificationTransactions.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.VoyageNotification);
            this.approveVoyageNotificationTransactions.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.approveVoyageNotificationTransactions.ToolTip = null;
            this.approveVoyageNotificationTransactions.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
            this.approveVoyageNotificationTransactions.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.approveVoyageNotificationTransactions_Execute);
            // 
            // VoyageNotificationDetailViewController
            // 
            this.Actions.Add(this.approveVoyageNotificationTransactions);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction approveVoyageNotificationTransactions;
    }
}
