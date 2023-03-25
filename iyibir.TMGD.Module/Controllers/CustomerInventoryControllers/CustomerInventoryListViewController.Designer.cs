namespace iyibir.TMGD.Module.Controllers.CustomerInventoryControllers
{
    partial class CustomerInventoryListViewController
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
            this.showDataByInventory = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            this.newDocumentByInventory = new DevExpress.ExpressApp.Actions.SingleChoiceAction(this.components);
            // 
            // showDataByInventory
            // 
            this.showDataByInventory.AcceptButtonCaption = null;
            this.showDataByInventory.CancelButtonCaption = null;
            this.showDataByInventory.Caption = "show Data By Inventory";
            this.showDataByInventory.Category = "View";
            this.showDataByInventory.ConfirmationMessage = null;
            this.showDataByInventory.Id = "showDataByInventory";
            this.showDataByInventory.ImageName = "BO_Product";
            this.showDataByInventory.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.CustomerInventory);
            this.showDataByInventory.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.showDataByInventory.ToolTip = null;
            this.showDataByInventory.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.showDataByInventory.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.showDataByInventory_CustomizePopupWindowParams);
            // 
            // newDocumentByInventory
            // 
            this.newDocumentByInventory.Caption = "new Document By Inventory";
            this.newDocumentByInventory.Category = "View";
            this.newDocumentByInventory.ConfirmationMessage = null;
            this.newDocumentByInventory.Id = "newDocumentByInventory";
            this.newDocumentByInventory.ImageName = "BO_List";
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
            this.newDocumentByInventory.Items.Add(choiceActionItem1);
            this.newDocumentByInventory.Items.Add(choiceActionItem2);
            this.newDocumentByInventory.ItemType = DevExpress.ExpressApp.Actions.SingleChoiceActionItemType.ItemIsOperation;
            this.newDocumentByInventory.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.CustomerInventory);
            this.newDocumentByInventory.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.newDocumentByInventory.ToolTip = null;
            this.newDocumentByInventory.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.newDocumentByInventory.Execute += new DevExpress.ExpressApp.Actions.SingleChoiceActionExecuteEventHandler(this.newDocumentByInventory_Execute);
            // 
            // CustomerInventoryListViewController
            // 
            this.Actions.Add(this.showDataByInventory);
            this.Actions.Add(this.newDocumentByInventory);
            this.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.CustomerInventory);
            this.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction showDataByInventory;
        private DevExpress.ExpressApp.Actions.SingleChoiceAction newDocumentByInventory;
    }
}
