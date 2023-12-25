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
    [NavigationItem("Settings")]
    public class DrillTypeControlList : BaseObject
    {
        private DrillType _drillType;
        private string _controlName;
        public DrillTypeControlList(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        [Association("DrillType-ControlList")]
        public DrillType DrillType { get=> _drillType; set=> SetPropertyValue(nameof(DrillType),ref _drillType,value); }

        [RuleRequiredField("RuleRequiredField for DrillTypeControlList.ControlName", DefaultContexts.Save)]
        public string ControlName { get=> _controlName; set=> SetPropertyValue(nameof(ControlName),ref _controlName,value); }
    }
}