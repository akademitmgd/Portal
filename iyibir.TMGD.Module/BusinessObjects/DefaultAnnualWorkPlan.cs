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
    public class DefaultAnnualWorkPlan : BaseObject
    {
        private int _lineNumber;
        private string _planName;
        public DefaultAnnualWorkPlan(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (Session.IsNewObject(this))
            {
                int count = Session.GetObjects(Session.GetClassInfo<DefaultAnnualWorkPlan>(), null, null, 0, false, true).Count;
                
                LineNumber = count + 1;
            }
        }

        [ModelDefault("AllowEdit","False")]        
        public int LineNumber { get=> _lineNumber; set=> SetPropertyValue(nameof(LineNumber),ref _lineNumber,value); }

        [RuleRequiredField("RuleRequiredField for DefaultAnnualWorkPlan.PlanName", DefaultContexts.Save)]
        [Size(450)]
        public string PlanName { get=> _planName; set=> SetPropertyValue(nameof(PlanName),ref _planName,value); }
    }
}