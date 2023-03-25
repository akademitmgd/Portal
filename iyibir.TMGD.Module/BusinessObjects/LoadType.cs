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
    [DefaultProperty("Name")]
    [Appearance("LoadType Delete", AppearanceItemType = "Action", TargetItems = "Delete", Visibility = ViewItemVisibility.Hide)]
    [Appearance("LoadType Edit", AppearanceItemType = "Action", TargetItems = "Edit", Visibility = ViewItemVisibility.Hide)]
    [Appearance("LoadType New", AppearanceItemType = "Action", TargetItems = "New", Visibility = ViewItemVisibility.Hide)]
    public class LoadType : BaseObject
    {
        private LoadOfTheType _loadOfThe;
        private string _code;
        private string _name;
        public LoadType(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        [Browsable(false)]
        public LoadOfTheType LoadOfTheType { get => _loadOfThe; set => SetPropertyValue(nameof(LoadOfTheType), ref _loadOfThe, value); }

        [RuleRequiredField("RuleRequiredField for LoadType.Code", DefaultContexts.Save)]
        [RuleUniqueValue("RuleUniqueValue for LoadType.Code", DefaultContexts.Save)]
        public string Code { get => _code; set => SetPropertyValue(nameof(Code), ref _code, value); }

        [RuleRequiredField("RuleRequiredField for LoadType.Name", DefaultContexts.Save)]
        public string Name { get => _name; set => SetPropertyValue(nameof(Name), ref _name, value); }
    }
}