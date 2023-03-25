using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;

namespace iyibir.TMGD.Module.Controllers.CustomControllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppWindowControllertopic.aspx.
    public partial class MyDetailsWindowController : WindowController
    {
        public MyDetailsWindowController()
        {
            TargetWindowType = WindowType.Main;
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            string ActionItemId = "MyDetails";
            MyDetailsController myDetailsController = Frame.GetController<MyDetailsController>();
            if (myDetailsController != null)
            {
                myDetailsController.Actions[ActionItemId].PaintStyle = ActionItemPaintStyle.CaptionAndImage;
                myDetailsController.Actions[ActionItemId].Caption = SecuritySystem.CurrentUserName;
            }
            //Optionally, customize the corresponding navigation item.  
            ShowNavigationItemController showNavigationItemController = Frame.GetController<ShowNavigationItemController>();
            if (showNavigationItemController != null)
            {
                //showNavigationItemController.ShowNavigationItemAction.Items.Find(
                //    ActionItemId, ChoiceActionItemFindType.Recursive, ChoiceActionItemFindTarget.Leaf
                //).Caption = SecuritySystem.CurrentUserName;
            }
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
