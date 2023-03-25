using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using iyibir.TMGD.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iyibir.TMGD.Module.Controllers.ProductControllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ProductDetailViewController : ViewController
    {
        public ProductDetailViewController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        private void addCASNumberByProduct_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            Product product = View.CurrentObject as Product;
            if (product != null)
            {
                IObjectSpace os = Application.CreateObjectSpace();

                string listViewId = Application.FindListViewId(typeof(CASNumber));

                CollectionSourceBase cs = Application.CreateCollectionSource(os, typeof(CASNumber), listViewId);

                e.View = Application.CreateListView(os, typeof(CASNumber), true);
                e.DialogController.AcceptAction.Execute += AcceptAction_Execute;
            }
        }

        private void AcceptAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var selectedItems = e.SelectedObjects;
            Product product = View.CurrentObject as Product;
            foreach (CASNumber cAS in selectedItems)
            {
                ProductCASNumber productCAS = View.ObjectSpace.CreateObject<ProductCASNumber>();
                productCAS.Product = product;
                productCAS.CASNumber = View.ObjectSpace.GetObjectByKey<CASNumber>(cAS.Oid);
                productCAS.CASType = cAS.CASType;

                product.CASNumbers.Add(productCAS);
            }

            View.Refresh();
        }
    }
}
