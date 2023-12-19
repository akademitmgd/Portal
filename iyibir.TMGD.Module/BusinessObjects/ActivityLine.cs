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
    public class ActivityLine : BaseObject
    {
        private Activity _activity;
        private string _lineNumber;
        private ActivitySubject _subject;
        private ActivitySubjectDesc _subjectDescription;
        private AnnualWorkPlanSubject _annualWorkPlanSubject;
        private AnnualWorkPlanSubjectStatus _annualWorkPlanSubjectStatus;
        private string _description;
        private string _owner;
        private DateTime _dueDate;
        public ActivityLine(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            switch (propertyName)
            {
                case "Subject":
                    LineNumber = this.Subject != null ? this.Subject.Code : string.Empty;

                    this.RaisePropertyChangedEvent("LineNumber");
                    break;

                default:
                    break;
            }
        }

        protected override void OnSaving()
        {
            base.OnSaving();
            if (!Session.IsObjectMarkedDeleted(this))
            {
                if (this.AnnualWorkPlanSubject != null)
                {
                    AnnualWorkPlanSubject annualWorkPlanSubject = Session.GetObjectByKey<AnnualWorkPlanSubject>(this.AnnualWorkPlanSubject.Oid);
                    if (annualWorkPlanSubject != null)
                    {
                        annualWorkPlanSubject.SubjectStatus = annualWorkPlanSubjectStatus;
                    }
                }
            }
        }

        [Association("Activity-Lines")]
        public Activity Activity { get=> _activity; set=> SetPropertyValue(nameof(Activity),ref _activity,value); }

        [ModelDefault("AllowEdit","False")]
        public string LineNumber { get=> _lineNumber; set=> SetPropertyValue(nameof(LineNumber),ref _lineNumber,value); }

        [ImmediatePostData]
        [RuleRequiredField("RuleRequiredField for ActivityLine.Subject", DefaultContexts.Save)]
        public ActivitySubject Subject { get=> _subject; set=> SetPropertyValue(nameof(Subject),ref _subject,value); }

        [Browsable(false)]
        [DataSourceProperty("Subject.Descriptions")]
        //[RuleRequiredField("RuleRequiredField for ActivityLine.SubjectDescription", DefaultContexts.Save)]
        public ActivitySubjectDesc SubjectDescription { get=> _subjectDescription; set=> SetPropertyValue(nameof(Subject),ref _subjectDescription,value); }

        [Browsable(false)]
        public AnnualWorkPlanSubject AnnualWorkPlanSubject { get=> _annualWorkPlanSubject; set=> SetPropertyValue(nameof(AnnualWorkPlanSubject),ref _annualWorkPlanSubject,value); }

        [Browsable(false)]
        public AnnualWorkPlanSubjectStatus annualWorkPlanSubjectStatus { get=> _annualWorkPlanSubjectStatus; set=> SetPropertyValue(nameof(AnnualWorkPlanSubjectStatus),ref _annualWorkPlanSubjectStatus,value); }

        [Size(-1)]
        public string Description { get=> _description; set=> SetPropertyValue(nameof(Description),ref _description,value); }
        public string Owner { get=> _owner; set=> SetPropertyValue(nameof(Owner),ref _owner,value); }
        public DateTime DueDate { get=> _dueDate; set=> SetPropertyValue(nameof(DueDate),ref _dueDate,value); }

    }
}