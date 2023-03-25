namespace iyibir.TMGD.Module.Controllers.AllViewControllers
{
    partial class AllWindowController
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
            this.shAnno = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // shAnno
            // 
            this.shAnno.Caption = "sh Anno";
            this.shAnno.Category = "Notifications";
            this.shAnno.ConfirmationMessage = null;
            this.shAnno.Id = "shAnno";
            this.shAnno.ImageName = "BO_Scheduler";
            this.shAnno.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.CaptionAndImage;
            this.shAnno.ToolTip = null;
            this.shAnno.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.shAnno_Execute);
            // 
            // AllWindowController
            // 
            this.Actions.Add(this.shAnno);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction shAnno;
    }
}
