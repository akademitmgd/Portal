namespace iyibir.TMGD.Module.Controllers.AllViewControllers.CustomerControllers
{
    partial class CustomerViewController
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
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem5 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem6 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem7 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            this.documentList = new DevExpress.ExpressApp.Actions.SingleChoiceAction(this.components);
            // 
            // documentList
            // 
            this.documentList.Caption = "document List";
            this.documentList.Category = "View";
            this.documentList.ConfirmationMessage = null;
            this.documentList.Id = "documentList";
            this.documentList.ImageName = "BO_List";
            choiceActionItem1.Caption = "ADR Denetim Tespit";
            choiceActionItem1.Id = "adrDenetimTespit";
            choiceActionItem1.ImageName = null;
            choiceActionItem1.Shortcut = null;
            choiceActionItem1.ToolTip = null;
            choiceActionItem2.Caption = "Araç Kontrol Formu";
            choiceActionItem2.Id = "aracKontrolFormu";
            choiceActionItem2.ImageName = null;
            choiceActionItem2.Shortcut = null;
            choiceActionItem2.ToolTip = null;
            choiceActionItem3.Caption = "Görev Dağılım Formu";
            choiceActionItem3.Id = "gorevDagilimFormu";
            choiceActionItem3.ImageName = null;
            choiceActionItem3.Shortcut = null;
            choiceActionItem3.ToolTip = null;
            choiceActionItem4.Caption = "Kaza Raporu";
            choiceActionItem4.Id = "kazaRaporu";
            choiceActionItem4.ImageName = null;
            choiceActionItem4.Shortcut = null;
            choiceActionItem4.ToolTip = null;
            choiceActionItem5.Caption = "Taşıma Evrakı";
            choiceActionItem5.Id = "tasimaEvraki";
            choiceActionItem5.ImageName = null;
            choiceActionItem5.Shortcut = null;
            choiceActionItem5.ToolTip = null;
            choiceActionItem6.Caption = "Tatbikat Değerlendirme";
            choiceActionItem6.Id = "tatbikatDegerlendirme";
            choiceActionItem6.ImageName = null;
            choiceActionItem6.Shortcut = null;
            choiceActionItem6.ToolTip = null;
            choiceActionItem7.Caption = "Tesis Ziyaret";
            choiceActionItem7.Id = "tesisZiyaret";
            choiceActionItem7.ImageName = null;
            choiceActionItem7.Shortcut = null;
            choiceActionItem7.ToolTip = null;
            this.documentList.Items.Add(choiceActionItem1);
            this.documentList.Items.Add(choiceActionItem2);
            this.documentList.Items.Add(choiceActionItem3);
            this.documentList.Items.Add(choiceActionItem4);
            this.documentList.Items.Add(choiceActionItem5);
            this.documentList.Items.Add(choiceActionItem6);
            this.documentList.Items.Add(choiceActionItem7);
            this.documentList.ItemType = DevExpress.ExpressApp.Actions.SingleChoiceActionItemType.ItemIsOperation;
            this.documentList.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.documentList.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.Customer);
            this.documentList.ToolTip = null;
            this.documentList.Execute += new DevExpress.ExpressApp.Actions.SingleChoiceActionExecuteEventHandler(this.documentList_Execute);
            // 
            // CustomerViewController
            // 
            this.Actions.Add(this.documentList);
            this.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.Customer);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SingleChoiceAction documentList;
    }
}
