namespace iyibir.TMGD.Module.Controllers.AnnualWorkPlanSubjectControllers
{
    partial class AnnualWorkPlanSubjectListViewController
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
            this.addActivity = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // addActivity
            // 
            this.addActivity.AcceptButtonCaption = null;
            this.addActivity.CancelButtonCaption = null;
            this.addActivity.Caption = "Add Activity";
            this.addActivity.Category = "View";
            this.addActivity.ConfirmationMessage = null;
            this.addActivity.Id = "addActivity";
            this.addActivity.ImageName = "BO_StateMachine";
            this.addActivity.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.Image;
            this.addActivity.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.addActivity.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.AnnualWorkPlanSubject);
            this.addActivity.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.addActivity.ToolTip = null;
            this.addActivity.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.addActivity.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.addActivity_CustomizePopupWindowParams);
            // 
            // AnnualWorkPlanSubjectListViewController
            // 
            this.Actions.Add(this.addActivity);
            this.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.AnnualWorkPlanSubject);
            this.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction addActivity;
    }
}
