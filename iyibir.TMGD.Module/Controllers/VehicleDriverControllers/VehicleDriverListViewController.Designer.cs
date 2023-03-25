namespace iyibir.TMGD.Module.Controllers.VehicleDriverControllers
{
    partial class VehicleDriverListViewController
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
            this.getCompetenceCertificate = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // getCompetenceCertificate
            // 
            this.getCompetenceCertificate.Caption = "get Competence Certificate";
            this.getCompetenceCertificate.Category = "View";
            this.getCompetenceCertificate.ConfirmationMessage = "Sürücü Mesleki Yeterlilik Belgeleri Güncellenecektir. Devam Etmek İstiyor Musunuz" +
    " ?";
            this.getCompetenceCertificate.Id = "getCompetenceCertificate";
            this.getCompetenceCertificate.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.getCompetenceCertificate.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.VehicleDriver);
            this.getCompetenceCertificate.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.getCompetenceCertificate.ToolTip = null;
            this.getCompetenceCertificate.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.getCompetenceCertificate.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.getCompetenceCertificate_Execute);
            // 
            // VehicleDriverListViewController
            // 
            this.Actions.Add(this.getCompetenceCertificate);
            this.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.VehicleDriver);
            this.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction getCompetenceCertificate;
    }
}
