namespace iyibir.TMGD.Module.Controllers.TransportDocumentControllers
{
    partial class TransportDocumentListViewController
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
            this.sendToUetdsSystem = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.yeniSeferEkle = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            this.showSeferDetay = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            this.createNewVoyage = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // sendToUetdsSystem
            // 
            this.sendToUetdsSystem.Caption = "send To Uetds System";
            this.sendToUetdsSystem.Category = "View";
            this.sendToUetdsSystem.ConfirmationMessage = "Taşıma Evrakı UETDS Sistemine Gönderilecektir. Devam Etmek İstiyor musunuz ?";
            this.sendToUetdsSystem.Id = "sendToUetdsSystem";
            this.sendToUetdsSystem.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.TransportDocument);
            this.sendToUetdsSystem.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.sendToUetdsSystem.ToolTip = null;
            this.sendToUetdsSystem.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.sendToUetdsSystem.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.sendToUetdsSystem_Execute);
            // 
            // yeniSeferEkle
            // 
            this.yeniSeferEkle.AcceptButtonCaption = null;
            this.yeniSeferEkle.CancelButtonCaption = null;
            this.yeniSeferEkle.Caption = "yeni Sefer Ekle";
            this.yeniSeferEkle.Category = "View";
            this.yeniSeferEkle.ConfirmationMessage = "Yeni Sefer Oluşturulacaktır. Devam Etmek İstiyor Musunuz ?";
            this.yeniSeferEkle.Id = "yeniSeferEkle";
            this.yeniSeferEkle.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.yeniSeferEkle.TargetObjectsCriteria = "Status = 0";
            this.yeniSeferEkle.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.TransportDocument);
            this.yeniSeferEkle.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.yeniSeferEkle.ToolTip = null;
            this.yeniSeferEkle.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.yeniSeferEkle.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.yeniSeferEkle_CustomizePopupWindowParams);
            // 
            // showSeferDetay
            // 
            this.showSeferDetay.AcceptButtonCaption = null;
            this.showSeferDetay.CancelButtonCaption = null;
            this.showSeferDetay.Caption = "show Sefer Detay";
            this.showSeferDetay.Category = "View";
            this.showSeferDetay.ConfirmationMessage = "Sefer Detayı Gösterilecektir. Devam Etmek İstiyor Musunuz ?";
            this.showSeferDetay.Id = "showSeferDetay";
            this.showSeferDetay.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.showSeferDetay.Tag = "Status = 1";
            this.showSeferDetay.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.TransportDocument);
            this.showSeferDetay.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.showSeferDetay.ToolTip = null;
            this.showSeferDetay.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.showSeferDetay.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.showSeferDetay_CustomizePopupWindowParams);
            // 
            // createNewVoyage
            // 
            this.createNewVoyage.AcceptButtonCaption = null;
            this.createNewVoyage.CancelButtonCaption = null;
            this.createNewVoyage.Caption = "create New Voyage";
            this.createNewVoyage.Category = "View";
            this.createNewVoyage.ConfirmationMessage = "Yeni Sefer Bildirmi Yapılacaktır. Devam Etmek İstiyor Musunuz ?";
            this.createNewVoyage.Id = "createNewVoyage";
            this.createNewVoyage.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.createNewVoyage.TargetObjectsCriteria = "Status = 0";
            this.createNewVoyage.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.TransportDocument);
            this.createNewVoyage.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.createNewVoyage.ToolTip = null;
            this.createNewVoyage.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.createNewVoyage.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.createNewVoyage_CustomizePopupWindowParams);
            // 
            // TransportDocumentListViewController
            // 
            this.Actions.Add(this.sendToUetdsSystem);
            this.Actions.Add(this.yeniSeferEkle);
            this.Actions.Add(this.showSeferDetay);
            this.Actions.Add(this.createNewVoyage);
            this.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.TransportDocument);
            this.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction sendToUetdsSystem;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction showSeferDetay;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction createNewVoyage;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction yeniSeferEkle;
    }
}
