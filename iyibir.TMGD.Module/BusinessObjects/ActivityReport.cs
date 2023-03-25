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
    public class ActivityReport : BaseObject
    {
        private string _code;
        private Employee _colsultant;
        private DateTime _createdOn;
        private Customer _customer;
        private string _description;

        public ActivityReport(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (Session.IsNewObject(this))
            {
                int count = Session.GetObjects(Session.GetClassInfo<ActivityReport>(), null, null, 0, true, true).Count;
                count = count + 1;
                this.Code = string.Format("{0}", count.ToString().PadLeft(4, '0'));
                this.Colsultant = Session.GetObjectByKey<Employee>(SecuritySystem.CurrentUserId);
            }
        }

        [RuleRequiredField("RuleRequiredField for ActivityReport.Code", DefaultContexts.Save)]
        public string Code { get=> _code; set=> SetPropertyValue(nameof(Code),ref _code,value); }

        [RuleRequiredField("RuleRequiredField for ActivityReport.Colsultant", DefaultContexts.Save)]
        [ImmediatePostData]
        public Employee Colsultant { get=> _colsultant; set=> SetPropertyValue(nameof(Colsultant),ref _colsultant,value); }

        [ModelDefault("AllowEdit","False")]
        public string TMGDCertificate { get => Colsultant != null ? Colsultant.TMGDCertificate : string.Empty; }

        [RuleRequiredField("RuleRequiredField for ActivityReport.CreatedOn", DefaultContexts.Save)]
        public DateTime CreatedOn { get=> _createdOn; set=> SetPropertyValue(nameof(CreatedOn),ref _createdOn,value); }

        [RuleRequiredField("RuleRequiredField for ActivityReport.Customer", DefaultContexts.Save)]
        [ImmediatePostData]
        [Association("Customer-ActivityReports")]
        public Customer Customer { get=> _customer; set=> SetPropertyValue(nameof(Customer),ref _customer,value); }


        [ModelDefault("AllowEdit", "False")]
        public string ActivityCertificateCode { get => Customer != null ? Customer.ActivityCertificateCode : string.Empty; }

        [Size(-1)]
        public string Description { get=> _description; set=> SetPropertyValue(nameof(Description),ref _description,value); }


        [Association("ActivityReport-Transactions"),DevExpress.Xpo.Aggregated]
        public XPCollection<ActivityReportTransaction> Transactions => GetCollection<ActivityReportTransaction>(nameof(Transactions));
    }
}