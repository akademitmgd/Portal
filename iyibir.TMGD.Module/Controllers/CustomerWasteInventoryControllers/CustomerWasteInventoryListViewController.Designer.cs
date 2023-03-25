namespace iyibir.TMGD.Module.Controllers.CustomerWasteInventoryControllers
{
    partial class CustomerWasteInventoryListViewController
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
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem1 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem2 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            this.showDataByWasteInventory = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            this.newDocumentByWasteInventory = new DevExpress.ExpressApp.Actions.SingleChoiceAction(this.components);
            // 
            // showDataByWasteInventory
            // 
            this.showDataByWasteInventory.AcceptButtonCaption = null;
            this.showDataByWasteInventory.CancelButtonCaption = null;
            this.showDataByWasteInventory.Caption = "show Data By Waste Inventory";
            this.showDataByWasteInventory.Category = "View";
            this.showDataByWasteInventory.ConfirmationMessage = null;
            this.showDataByWasteInventory.Id = "showDataByWasteInventory";
            this.showDataByWasteInventory.ImageName = "BO_Product";
            this.showDataByWasteInventory.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.CustomerWasteInventory);
            this.showDataByWasteInventory.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.showDataByWasteInventory.ToolTip = null;
            this.showDataByWasteInventory.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.showDataByWasteInventory.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.showDataByWasteInventory_CustomizePopupWindowParams);
            // 
            // newDocumentByWasteInventory
            // 
            this.newDocumentByWasteInventory.Caption = "new Document By Waste Inventory";
            this.newDocumentByWasteInventory.Category = "View";
            this.newDocumentByWasteInventory.ConfirmationMessage = null;
            this.newDocumentByWasteInventory.Id = "newDocumentByWasteInventory";
            this.newDocumentByWasteInventory.ImageName = "BO_List";
            choiceActionItem1.Caption = "Araç Kontrol Formu Oluştur";
            choiceActionItem1.Id = "aracKontrol";
            choiceActionItem1.ImageName = null;
            choiceActionItem1.Shortcut = null;
            choiceActionItem1.ToolTip = null;
            choiceActionItem2.Caption = "Taşıma Evrakı Oluştur";
            choiceActionItem2.Id = "tasimaEvraki";
            choiceActionItem2.ImageName = null;
            choiceActionItem2.Shortcut = null;
            choiceActionItem2.ToolTip = null;
            this.newDocumentByWasteInventory.Items.Add(choiceActionItem1);
            this.newDocumentByWasteInventory.Items.Add(choiceActionItem2);
            this.newDocumentByWasteInventory.ItemType = DevExpress.ExpressApp.Actions.SingleChoiceActionItemType.ItemIsOperation;
            this.newDocumentByWasteInventory.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.CustomerWasteInventory);
            this.newDocumentByWasteInventory.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.newDocumentByWasteInventory.ToolTip = null;
            this.newDocumentByWasteInventory.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.newDocumentByWasteInventory.Execute += new DevExpress.ExpressApp.Actions.SingleChoiceActionExecuteEventHandler(this.newDocumentByWasteInventory_Execute);
            // 
            // CustomerWasteInventoryListViewController
            // 
            this.Actions.Add(this.showDataByWasteInventory);
            this.Actions.Add(this.newDocumentByWasteInventory);
            this.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.CustomerWasteInventory);
            this.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction showDataByWasteInventory;
        private DevExpress.ExpressApp.Actions.SingleChoiceAction newDocumentByWasteInventory;
    }
}
