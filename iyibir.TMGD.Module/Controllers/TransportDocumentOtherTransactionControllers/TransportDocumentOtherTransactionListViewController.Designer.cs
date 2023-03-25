namespace iyibir.TMGD.Module.Controllers.TransportDocumentOtherTransactionControllers
{
    partial class TransportDocumentOtherTransactionListViewController
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
            this.sefereYukEkle = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // sefereYukEkle
            // 
            this.sefereYukEkle.AcceptButtonCaption = null;
            this.sefereYukEkle.CancelButtonCaption = null;
            this.sefereYukEkle.Caption = "sefere Yuk Ekle";
            this.sefereYukEkle.Category = "View";
            this.sefereYukEkle.ConfirmationMessage = "Sefere Yük Eklenecektir. Devam Etmek İstiyor Musunuz ?";
            this.sefereYukEkle.Id = "sefereYukEkle";
            this.sefereYukEkle.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.sefereYukEkle.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.TransportDocumentOtherTransaction);
            this.sefereYukEkle.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.sefereYukEkle.ToolTip = null;
            this.sefereYukEkle.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            // 
            // TransportDocumentOtherTransactionListViewController
            // 
            this.Actions.Add(this.sefereYukEkle);
            this.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.TransportDocumentOtherTransaction);
            this.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction sefereYukEkle;
    }
}
