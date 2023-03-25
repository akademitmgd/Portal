namespace iyibir.TMGD.Module.Controllers.VehicleControllers
{
    partial class VehicleListViewController
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
            this.vehicleInspectionQuestioning = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.documentValidityQuestioning = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // vehicleInspectionQuestioning
            // 
            this.vehicleInspectionQuestioning.Caption = "vehicle Inspection Questioning";
            this.vehicleInspectionQuestioning.Category = "View";
            this.vehicleInspectionQuestioning.ConfirmationMessage = "Araç Muayene Bilgileri Sorgulanacaktır. Devam Etmek İstiyor Musunuz ?";
            this.vehicleInspectionQuestioning.Id = "vehicleInspectionQuestioning";
            this.vehicleInspectionQuestioning.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.vehicleInspectionQuestioning.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.Vehicle);
            this.vehicleInspectionQuestioning.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.vehicleInspectionQuestioning.ToolTip = null;
            this.vehicleInspectionQuestioning.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.vehicleInspectionQuestioning.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.vehicleInspectionQuestioning_Execute);
            // 
            // documentValidityQuestioning
            // 
            this.documentValidityQuestioning.Caption = "document Validity Questioning";
            this.documentValidityQuestioning.Category = "View";
            this.documentValidityQuestioning.ConfirmationMessage = null;
            this.documentValidityQuestioning.Id = "documentValidityQuestioning";
            this.documentValidityQuestioning.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.documentValidityQuestioning.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.Vehicle);
            this.documentValidityQuestioning.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.documentValidityQuestioning.ToolTip = null;
            this.documentValidityQuestioning.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.documentValidityQuestioning.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.documentValidityQuestioning_Execute);
            // 
            // VehicleListViewController
            // 
            this.Actions.Add(this.vehicleInspectionQuestioning);
            this.Actions.Add(this.documentValidityQuestioning);
            this.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.Vehicle);
            this.TargetViewId = "Customer_Vehicles_ListView";
            this.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction vehicleInspectionQuestioning;
        private DevExpress.ExpressApp.Actions.SimpleAction documentValidityQuestioning;
    }
}
