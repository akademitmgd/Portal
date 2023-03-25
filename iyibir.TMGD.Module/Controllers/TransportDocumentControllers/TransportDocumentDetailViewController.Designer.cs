namespace iyibir.TMGD.Module.Controllers.TransportDocumentControllers
{
    partial class TransportDocumentDetailViewController
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
            this.addHazardousGoods = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            this.showCustomerInventory = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            this.showCustomerWasteInventory = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            this.addDefaultDescription = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            this.checkLoadedStatus = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.getErpData = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // addHazardousGoods
            // 
            this.addHazardousGoods.AcceptButtonCaption = null;
            this.addHazardousGoods.CancelButtonCaption = null;
            this.addHazardousGoods.Caption = "add Hazardous Goods";
            this.addHazardousGoods.Category = "View";
            this.addHazardousGoods.ConfirmationMessage = null;
            this.addHazardousGoods.Id = "addHazardousGoods";
            this.addHazardousGoods.ImageName = "BO_Product";
            this.addHazardousGoods.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.Image;
            this.addHazardousGoods.TargetObjectsCriteria = "Consigner IS NOT NULL";
            this.addHazardousGoods.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.TransportDocument);
            this.addHazardousGoods.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.addHazardousGoods.ToolTip = null;
            this.addHazardousGoods.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
            this.addHazardousGoods.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.addHazardousGoods_CustomizePopupWindowParams);
            // 
            // showCustomerInventory
            // 
            this.showCustomerInventory.AcceptButtonCaption = null;
            this.showCustomerInventory.CancelButtonCaption = null;
            this.showCustomerInventory.Caption = "show Customer Inventory";
            this.showCustomerInventory.Category = "View";
            this.showCustomerInventory.ConfirmationMessage = null;
            this.showCustomerInventory.Id = "showCustomerInventory";
            this.showCustomerInventory.ImageName = "BO_Product";
            this.showCustomerInventory.TargetObjectsCriteria = "TransportDocumentType = 0 and Consigner IS NOT NULL";
            this.showCustomerInventory.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.TransportDocument);
            this.showCustomerInventory.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.showCustomerInventory.ToolTip = null;
            this.showCustomerInventory.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
            this.showCustomerInventory.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.showCustomerInventory_CustomizePopupWindowParams);
            // 
            // showCustomerWasteInventory
            // 
            this.showCustomerWasteInventory.AcceptButtonCaption = null;
            this.showCustomerWasteInventory.CancelButtonCaption = null;
            this.showCustomerWasteInventory.Caption = "show Customer Waste Inventory";
            this.showCustomerWasteInventory.Category = "View";
            this.showCustomerWasteInventory.ConfirmationMessage = null;
            this.showCustomerWasteInventory.Id = "showCustomerWasteInventory";
            this.showCustomerWasteInventory.ImageName = "BO_ProductGroup";
            this.showCustomerWasteInventory.TargetObjectsCriteria = "TransportDocumentType = 1 and Consigner IS NOT NULL";
            this.showCustomerWasteInventory.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.TransportDocument);
            this.showCustomerWasteInventory.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.showCustomerWasteInventory.ToolTip = null;
            this.showCustomerWasteInventory.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
            this.showCustomerWasteInventory.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.showCustomerWasteInventory_CustomizePopupWindowParams);
            // 
            // addDefaultDescription
            // 
            this.addDefaultDescription.AcceptButtonCaption = null;
            this.addDefaultDescription.CancelButtonCaption = null;
            this.addDefaultDescription.Caption = "add Default Description";
            this.addDefaultDescription.Category = "View";
            this.addDefaultDescription.ConfirmationMessage = null;
            this.addDefaultDescription.Id = "addDefaultDescription";
            this.addDefaultDescription.ImageName = "BO_List";
            this.addDefaultDescription.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.TransportDocument);
            this.addDefaultDescription.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.addDefaultDescription.ToolTip = null;
            this.addDefaultDescription.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
            this.addDefaultDescription.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.addDefaultDescription_CustomizePopupWindowParams);
            // 
            // checkLoadedStatus
            // 
            this.checkLoadedStatus.Caption = "check Loaded Status";
            this.checkLoadedStatus.Category = "View";
            this.checkLoadedStatus.ConfirmationMessage = "Karışık Yükleme Durumu Kontrol Edilecek. Devam Etmek İstiyor musunuz ?";
            this.checkLoadedStatus.Id = "checkLoadedStatus";
            this.checkLoadedStatus.ImageName = "Action_Grant";
            this.checkLoadedStatus.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.TransportDocument);
            this.checkLoadedStatus.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.checkLoadedStatus.ToolTip = "Karışık Yükleme Durumunu Kontrol Eder..";
            this.checkLoadedStatus.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
            this.checkLoadedStatus.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.checkLoadedStatus_Execute);
            // 
            // getErpData
            // 
            this.getErpData.AcceptButtonCaption = null;
            this.getErpData.CancelButtonCaption = null;
            this.getErpData.Caption = "get Erp Data";
            this.getErpData.Category = "View";
            this.getErpData.ConfirmationMessage = "ERP Verileriniz üzerinden İrsaliyeler Listelenecektir. Bu işlem bağlantı hızınıza" +
    " göre değişiklik gösterebilir. Devam etmek İstiyor musunuz ?";
            this.getErpData.Id = "getErpData";
            this.getErpData.ImageName = "BO_Sale";
            this.getErpData.TargetObjectsCriteria = "IsNewObject(this)";
            this.getErpData.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.TransportDocument);
            this.getErpData.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.getErpData.ToolTip = null;
            this.getErpData.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
            this.getErpData.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.getErpData_CustomizePopupWindowParams);
            // 
            // TransportDocumentDetailViewController
            // 
            this.Actions.Add(this.addHazardousGoods);
            this.Actions.Add(this.showCustomerInventory);
            this.Actions.Add(this.showCustomerWasteInventory);
            this.Actions.Add(this.addDefaultDescription);
            this.Actions.Add(this.checkLoadedStatus);
            this.Actions.Add(this.getErpData);
            this.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.TransportDocument);
            this.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction addHazardousGoods;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction showCustomerInventory;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction showCustomerWasteInventory;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction addDefaultDescription;
        private DevExpress.ExpressApp.Actions.SimpleAction checkLoadedStatus;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction getErpData;
    }
}
