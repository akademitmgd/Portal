
namespace iyibir.TMGD.Module.Controllers.ProductControllers
{
    partial class ProductDetailViewController
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
            this.addCASNumberByProduct = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // addCASNumberByProduct
            // 
            this.addCASNumberByProduct.AcceptButtonCaption = null;
            this.addCASNumberByProduct.CancelButtonCaption = null;
            this.addCASNumberByProduct.Caption = "add CASNumber By Product";
            this.addCASNumberByProduct.Category = "View";
            this.addCASNumberByProduct.ConfirmationMessage = null;
            this.addCASNumberByProduct.Id = "addCASNumberByProduct";
            this.addCASNumberByProduct.ImageName = "BO_Transition";
            this.addCASNumberByProduct.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.Product);
            this.addCASNumberByProduct.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.addCASNumberByProduct.ToolTip = null;
            this.addCASNumberByProduct.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
            this.addCASNumberByProduct.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.addCASNumberByProduct_CustomizePopupWindowParams);
            // 
            // ProductDetailViewController
            // 
            this.Actions.Add(this.addCASNumberByProduct);
            this.TargetObjectType = typeof(iyibir.TMGD.Module.BusinessObjects.Product);
            this.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction addCASNumberByProduct;
    }
}
