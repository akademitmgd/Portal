
namespace iyibir.TMGD.Module.Controllers.VehicleControlDocumentControllers
{
    partial class VehicleControlDocumentDetailViewController
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
            this.addProductByVehicleControl = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // addProductByVehicleControl
            // 
            this.addProductByVehicleControl.AcceptButtonCaption = null;
            this.addProductByVehicleControl.CancelButtonCaption = null;
            this.addProductByVehicleControl.Caption = "add Product By Vehicle Control";
            this.addProductByVehicleControl.Category = "View";
            this.addProductByVehicleControl.ConfirmationMessage = null;
            this.addProductByVehicleControl.Id = "addProductByVehicleControl";
            this.addProductByVehicleControl.ImageName = "BO_ProductGroup";
            this.addProductByVehicleControl.TargetObjectsCriteria = "Consigner IS NOT NULL";
            this.addProductByVehicleControl.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.VehicleControlDocument);
            this.addProductByVehicleControl.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.addProductByVehicleControl.ToolTip = null;
            this.addProductByVehicleControl.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
            this.addProductByVehicleControl.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.addProductByVehicleControl_CustomizePopupWindowParams);
            // 
            // VehicleControlDocumentDetailViewController
            // 
            this.Actions.Add(this.addProductByVehicleControl);
            this.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.VehicleControlDocument);
            this.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction addProductByVehicleControl;
    }
}
