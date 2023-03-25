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
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class AuditDeterminationForm : BaseObject
    {
        private string _code;
        private DateTime _createdOn;
        private Employee _owner;
        private Customer _customer;
        private CustomerContact _customerContact;
        private string _taskName;
        private string _reportNo;
        private DateTime _reportDate;
        private Position _position;
        private string _tmgdCertificate;
        private string _reportSubject;
        private string _customerAddress;
        private DateTime _activityDate;

        public AuditDeterminationForm(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (Session.IsNewObject(this))
            {
                Owner = Session.GetObjectByKey<Employee>(SecuritySystem.CurrentUserId);
                CreatedOn = DateTime.Now;
                ReportDate = DateTime.Now;
                ActivityDate = DateTime.Now;

                int count = Session.GetObjects(Session.GetClassInfo<AuditDeterminationForm>(), null, null, 0, true, true).Count;
                count = count + 1;
                this.Code = string.Format("{0}", count.ToString().PadLeft(4, '0'));
            }
        }

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            switch (propertyName)
            {
                case "Customer":
                    if (Customer != null)
                    {
                        CustomerAddress = Customer.Address;

                        this.RaisePropertyChangedEvent(nameof(CustomerAddress));
                    }
                    break;

                case "Owner":
                    if (Owner != null)
                    {
                        TMGDCertificate = Owner.TMGDCertificate;
                        Position = Owner.Position != null ? Session.GetObjectByKey<Position>(Owner.Position.Oid) : null;

                        this.RaisePropertyChangedEvent(nameof(TMGDCertificate));
                        this.RaisePropertyChangedEvent(nameof(Position));
                    }
                    break;
                default:
                    break;
            }
        }

        [RuleRequiredField("RuleRequiredField for AuditDeterminationForm.Code", DefaultContexts.Save)]
        public string Code { get => _code; set => SetPropertyValue(nameof(Code), ref _code, value); }

        [RuleRequiredField("RuleRequiredField for AuditDeterminationForm.CreatedOn", DefaultContexts.Save)]
        public DateTime CreatedOn { get => _createdOn; set => SetPropertyValue(nameof(CreatedOn), ref _createdOn, value); }

        [ModelDefault("AllowEdit","False")]
        public Employee Owner { get => _owner; set => SetPropertyValue(nameof(Owner), ref _owner, value); }

        [RuleRequiredField("RuleRequiredField for AuditDeterminationForm.Customer", DefaultContexts.Save)]
        [ImmediatePostData]
        public Customer Customer { get => _customer; set => SetPropertyValue(nameof(Customer), ref _customer, value); }

        [RuleRequiredField("RuleRequiredField for AuditDeterminationForm.CustomerContact", DefaultContexts.Save)]
        [DataSourceProperty("Customer.Contacts")]
        public CustomerContact CustomerContact { get => _customerContact; set => SetPropertyValue(nameof(CustomerContact), ref _customerContact, value); }

        [RuleRequiredField("RuleRequiredField for AuditDeterminationForm.TaskName", DefaultContexts.Save)]
        public string TaskName { get => _taskName; set => SetPropertyValue(nameof(TaskName), ref _taskName, value); }

        [RuleRequiredField("RuleRequiredField for AuditDeterminationForm.ReportNo", DefaultContexts.Save)]
        public string ReportNo { get => _reportNo; set => SetPropertyValue(nameof(ReportNo), ref _reportNo, value); }

        [RuleRequiredField("RuleRequiredField for AuditDeterminationForm.ReportDate", DefaultContexts.Save)]
        public DateTime ReportDate { get => _reportDate; set => SetPropertyValue(nameof(ReportDate), ref _reportDate, value); }

        [RuleRequiredField("RuleRequiredField for AuditDeterminationForm.Position", DefaultContexts.Save)]
        public Position Position { get => _position; set => SetPropertyValue(nameof(Position), ref _position, value); }

        [ModelDefault("AllowEdit","False")]
        public string TMGDCertificate { get => _tmgdCertificate; set => SetPropertyValue(nameof(TMGDCertificate), ref _tmgdCertificate, value); }

        [RuleRequiredField("RuleRequiredField for AuditDeterminationForm.ReportSubject", DefaultContexts.Save)]
        public string ReportSubject { get => _reportSubject; set => SetPropertyValue(nameof(ReportSubject), ref _reportSubject, value); }

        [RuleRequiredField("RuleRequiredField for AuditDeterminationForm.CustomerAddress", DefaultContexts.Save)]
        public string CustomerAddress { get => _customerAddress; set => SetPropertyValue(nameof(CustomerAddress), ref _customerAddress, value); }

        [RuleRequiredField("RuleRequiredField for AuditDeterminationForm.ActivityDate", DefaultContexts.Save)]
        public DateTime ActivityDate { get => _activityDate; set => SetPropertyValue(nameof(ActivityDate), ref _activityDate, value); }


        [Association("AuditDeterminationForm-LegalStatutes"),DevExpress.Xpo.Aggregated]
        public XPCollection<AuditDeterminationLegalStatute> LegalStatutes => GetCollection<AuditDeterminationLegalStatute>(nameof(LegalStatutes));
    }
}