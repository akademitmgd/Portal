
namespace iyibir.TMGD.Module.Controllers.ProductControllers
{
    partial class ProductListViewController
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
            this.newDocumentByProduct = new DevExpress.ExpressApp.Actions.SingleChoiceAction(this.components);
            this.addHazardousGoodsByProduct = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // newDocumentByProduct
            // 
            this.newDocumentByProduct.Caption = "new Document By Product";
            this.newDocumentByProduct.Category = "View";
            this.newDocumentByProduct.ConfirmationMessage = null;
            this.newDocumentByProduct.Id = "newDocumentByProduct";
            choiceActionItem1.Caption = "Araç Kontrol Formu Oluştur";
            choiceActionItem1.Id = "aracKontrol";
            choiceActionItem1.ImageName = "BO_List";
            choiceActionItem1.Shortcut = null;
            choiceActionItem1.ToolTip = null;
            choiceActionItem2.Caption = "Taşıma Evrakı Oluştur";
            choiceActionItem2.Id = "tasimaEvraki";
            choiceActionItem2.ImageName = "BO_List";
            choiceActionItem2.Shortcut = null;
            choiceActionItem2.ToolTip = null;
            this.newDocumentByProduct.Items.Add(choiceActionItem1);
            this.newDocumentByProduct.Items.Add(choiceActionItem2);
            this.newDocumentByProduct.ItemType = DevExpress.ExpressApp.Actions.SingleChoiceActionItemType.ItemIsOperation;
            this.newDocumentByProduct.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.Product);
            this.newDocumentByProduct.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.newDocumentByProduct.ToolTip = null;
            this.newDocumentByProduct.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.newDocumentByProduct.Execute += new DevExpress.ExpressApp.Actions.SingleChoiceActionExecuteEventHandler(this.newDocumentByProduct_Execute);
            // 
            // addHazardousGoodsByProduct
            // 
            this.addHazardousGoodsByProduct.AcceptButtonCaption = null;
            this.addHazardousGoodsByProduct.CancelButtonCaption = null;
            this.addHazardousGoodsByProduct.Caption = "add Hazardous Goods By Product";
            this.addHazardousGoodsByProduct.Category = "View";
            this.addHazardousGoodsByProduct.ConfirmationMessage = null;
            this.addHazardousGoodsByProduct.Id = "addHazardousGoodsByProduct";
            this.addHazardousGoodsByProduct.ImageName = "BO_ProductGroup";
            this.addHazardousGoodsByProduct.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.Product);
            this.addHazardousGoodsByProduct.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.addHazardousGoodsByProduct.ToolTip = null;
            this.addHazardousGoodsByProduct.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.addHazardousGoodsByProduct.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.addHazardousGoods_CustomizePopupWindowParams);
            // 
            // ProductListViewController
            // 
            this.Actions.Add(this.newDocumentByProduct);
            this.Actions.Add(this.addHazardousGoodsByProduct);
            this.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.Product);
            this.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SingleChoiceAction newDocumentByProduct;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction addHazardousGoodsByProduct;
    }
}
