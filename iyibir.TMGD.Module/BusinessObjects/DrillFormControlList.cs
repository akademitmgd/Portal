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
    [ImageName("BO_List")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    [NavigationItem(false)]
    public class DrillFormControlList : BaseObject
    {
        private DrillForm _drillForm;
        private string _controlName;
        private bool _isControl;
        private string _result;
        public DrillFormControlList(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }


        [Association("DrillForm-ControlList")]
        public DrillForm DrillForm { get=> _drillForm; set=> SetPropertyValue(nameof(DrillForm),ref _drillForm,value); }

        [RuleRequiredField("RuleRequiredField for DrillFormControlList.ControlName", DefaultContexts.Save)]
        public string ControlName { get=> _controlName; set=> SetPropertyValue(nameof(ControlName),ref _controlName,value); }
        public bool IsControl { get=> _isControl; set=> SetPropertyValue(nameof(IsControl),ref _isControl,value); }

        [Size(450)]
        public string Result { get=> _result; set=> SetPropertyValue(nameof(Result),ref _result,value); }
    }
}