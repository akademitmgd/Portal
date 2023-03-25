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
    [DefaultProperty("Subject")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class AnnualWorkPlanSubject : BaseObject
    {
        private AnnualWorkPlan _annualWorkPlan;
        private AnnualWorkPlanSubjectStatus _subjectStatus;
        private string _subject;
        private Employee _authorizedPerson;
        private DateTime _dueDate;
        public AnnualWorkPlanSubject(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        [Association("AnnualWorkPlan-Subjects")]
        public AnnualWorkPlan AnnualWorkPlan { get=> _annualWorkPlan; set=> SetPropertyValue(nameof(AnnualWorkPlan),ref _annualWorkPlan,value); }

        
        public AnnualWorkPlanSubjectStatus SubjectStatus { get=> _subjectStatus; set=> SetPropertyValue(nameof(SubjectStatus),ref _subjectStatus,value); }

        [RuleRequiredField("RuleRequiredField for AnnualWorkPlanSubject.Subject", DefaultContexts.Save)]
        [Size(450)]
        public string Subject { get => _subject; set => SetPropertyValue(nameof(Subject), ref _subject, value); }

        public Employee AuthorizedPerson { get=> _authorizedPerson; set=> SetPropertyValue(nameof(AuthorizedPerson),ref _authorizedPerson,value); }

        public DateTime DueDate { get=> _dueDate; set=> SetPropertyValue(nameof(DueDate),ref _dueDate,value); }

        [Association("Subject-Transactions"),DevExpress.Xpo.Aggregated]
        [VisibleInDetailView(false)]
        public XPCollection<AnnualWorkPlanSubjectTransaction> Transactions => GetCollection<AnnualWorkPlanSubjectTransaction>(nameof(Transactions));
    }
}