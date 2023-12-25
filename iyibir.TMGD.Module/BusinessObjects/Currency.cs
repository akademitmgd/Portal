using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Editors;

namespace iyibir.TMGD.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("BO_Sale_Item")]
    [DefaultProperty("Name")]
    [Appearance("Currency Delete", AppearanceItemType = "Action", TargetItems = "Delete", Visibility = ViewItemVisibility.Hide)]
    [Appearance("Currency Edit", AppearanceItemType = "Action", TargetItems = "Edit", Visibility = ViewItemVisibility.Hide)]
    [Appearance("Currency New", AppearanceItemType = "Action", TargetItems = "New", Visibility = ViewItemVisibility.Hide)]
    [NavigationItem("Settings")]
    public class Currency : BaseObject
    {
        private int _referenceId;
        private string _symbol;
        private string _name;
        private string _code;
        public Currency(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        [ModelDefault("AllowEdit", "False")]
        public string Code
        {
            get { return _code; }
            set { SetPropertyValue("Code", ref _code, value); }
        }

        [ModelDefault("AllowEdit", "False")]
        public string Name
        {
            get { return _name; }
            set { SetPropertyValue("Name", ref _name, value); }
        }

        [ModelDefault("AllowEdit", "False")]
        public string Symbol
        {
            get { return _symbol; }
            set { SetPropertyValue("Symbol", ref _symbol, value); }
        }

        [ModelDefault("AllowEdit", "False")]
        [Browsable(false)]
        public int ReferenceId
        {
            get { return _referenceId; }
            set { SetPropertyValue("ReferenceId", ref _referenceId, value); }
        }
    }
}