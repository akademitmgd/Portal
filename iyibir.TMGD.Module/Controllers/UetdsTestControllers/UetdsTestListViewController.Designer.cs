namespace iyibir.TMGD.Module.Controllers.UetdsTestControllers
{
    partial class UetdsTestListViewController
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
            this.uetdsTest = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // uetdsTest
            // 
            this.uetdsTest.Caption = "uetds Test";
            this.uetdsTest.Category = "View";
            this.uetdsTest.ConfirmationMessage = null;
            this.uetdsTest.Id = "uetdsTest";
            this.uetdsTest.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.City);
            this.uetdsTest.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.uetdsTest.ToolTip = null;
            this.uetdsTest.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.uetdsTest.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.uetdsTest_Execute);
            // 
            // UetdsTestListViewController
            // 
            this.Actions.Add(this.uetdsTest);
            this.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.City);
            this.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction uetdsTest;
    }
}
