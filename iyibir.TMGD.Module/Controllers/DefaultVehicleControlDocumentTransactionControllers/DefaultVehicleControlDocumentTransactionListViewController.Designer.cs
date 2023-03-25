namespace iyibir.TMGD.Module.Controllers.DefaultVehicleControlDocumentTransactionControllers
{
    partial class DefaultVehicleControlDocumentTransactionListViewController
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
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem3 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem4 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            this.createDefaultControlList = new DevExpress.ExpressApp.Actions.SingleChoiceAction(this.components);
            // 
            // createDefaultControlList
            // 
            this.createDefaultControlList.Caption = "create Default Control List";
            this.createDefaultControlList.Category = "View";
            this.createDefaultControlList.ConfirmationMessage = "Varsayılan Bilgiler Yüklenecektir. Devam Etmek İstiyor musunuz ?";
            this.createDefaultControlList.Id = "createDefaultControlList";
            this.createDefaultControlList.ImageName = "BO_StateMachine";
            choiceActionItem1.Caption = "Ambalajlı";
            choiceActionItem1.Id = "ambalajli";
            choiceActionItem1.ImageName = null;
            choiceActionItem1.Shortcut = null;
            choiceActionItem1.ToolTip = null;
            choiceActionItem2.Caption = "Tanker";
            choiceActionItem2.Id = "tanker";
            choiceActionItem2.ImageName = null;
            choiceActionItem2.Shortcut = null;
            choiceActionItem2.ToolTip = null;
            choiceActionItem3.Caption = "Sınırlı Miktar";
            choiceActionItem3.Id = "sinirliMiktar";
            choiceActionItem3.ImageName = null;
            choiceActionItem3.Shortcut = null;
            choiceActionItem3.ToolTip = null;
            choiceActionItem4.Caption = "İstisnai Miktar";
            choiceActionItem4.Id = "istisnaiMiktar";
            choiceActionItem4.ImageName = null;
            choiceActionItem4.Shortcut = null;
            choiceActionItem4.ToolTip = null;
            this.createDefaultControlList.Items.Add(choiceActionItem1);
            this.createDefaultControlList.Items.Add(choiceActionItem2);
            this.createDefaultControlList.Items.Add(choiceActionItem3);
            this.createDefaultControlList.Items.Add(choiceActionItem4);
            this.createDefaultControlList.ItemType = DevExpress.ExpressApp.Actions.SingleChoiceActionItemType.ItemIsOperation;
            this.createDefaultControlList.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.Image;
            this.createDefaultControlList.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.DefaultVehicleControlDocumentTransaction);
            this.createDefaultControlList.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.createDefaultControlList.ToolTip = null;
            this.createDefaultControlList.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.createDefaultControlList.Execute += new DevExpress.ExpressApp.Actions.SingleChoiceActionExecuteEventHandler(this.createDefaultControlList_Execute);
            // 
            // DefaultVehicleControlDocumentTransactionListViewController
            // 
            this.Actions.Add(this.createDefaultControlList);
            this.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.DefaultVehicleControlDocumentTransaction);
            this.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SingleChoiceAction createDefaultControlList;
    }
}
