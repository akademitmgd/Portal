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

namespace iyibir.TMGD.Module.BusinessObjects
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class DrillType : BaseObject
    {
        private string _name;
        private string _scenario;
        private bool _isActive;
        public DrillType(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (Session.IsNewObject(this))
            {
                IsActive = true;
            }
        }

        [RuleRequiredField("RuleRequiredField for DrillType.Name", DefaultContexts.Save)]
        public string Name { get => _name; set => SetPropertyValue(nameof(Name), ref _name, value); }

        [RuleRequiredField("RuleRequiredField for DrillType.Scenario", DefaultContexts.Save)]
        [Size(-1)]
        public string Scenario { get=> _scenario; set=> SetPropertyValue(nameof(Scenario),ref _scenario,value); }
        public bool IsActive { get => _isActive; set => SetPropertyValue(nameof(IsActive), ref _isActive, value); }

        [Association("DrillType-ControlList"),DevExpress.Xpo.Aggregated]
        public XPCollection<DrillTypeControlList> ControlLists => GetCollection<DrillTypeControlList>(nameof(ControlLists));
    }
}