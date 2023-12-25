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
    [NavigationItem("DocumentManagement")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class DistributionOfTask : BaseObject
    {
        private DateTime _beginDate;
        private TimeSpan _beginTime;
        private string _code;
        private string _name;
        private Sector _sector;
        private string _activityCertificate;
        private DateTime _dateOfValidity;
        private Customer _customer;
        private CustomerContact _customerContact;
        private string _address;
        private bool _consignor;
        private bool _carrier;
        private bool _consignee;
        private bool _loader;
        private bool _unloader;
        private bool _packer;
        private bool _filler;
        private bool _tankContainer;
        private string _tmgdCertificate;
        private Employee _owner;
        private DateTime _endDate;
        private TimeSpan _endTime;
        
        public DistributionOfTask(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (Session.IsNewObject(this))
            {
                BeginDate = DateTime.Now;
                BeginTime = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                Owner = Session.GetObjectByKey<Employee>(SecuritySystem.CurrentUserId);

                int count = Session.GetObjects(Session.GetClassInfo<DistributionOfTask>(), null, null, 0, true, true).Count;
                count = count + 1;
                this.Code = string.Format("{0}", count.ToString().PadLeft(4, '0'));

                var defaultTaskSubjects = Session.GetObjects(Session.GetClassInfo<DefaultDistributionOfTaskSubject>(), null, null, 0, false, true);
                foreach (DefaultDistributionOfTaskSubject defaultTask in defaultTaskSubjects)
                {
                    DistributionOfTaskSubject distributionOfTaskSubject = new DistributionOfTaskSubject(Session);
                    distributionOfTaskSubject.Subject = defaultTask.Subject;

                    foreach (DefaultDistributionOfTaskSubjectDesc desc in defaultTask.Descriptions)
                    {
                        DistributionOfTaskSubjectDetail detail = new DistributionOfTaskSubjectDetail(Session);
                        detail.DistributionOfTaskSubject = distributionOfTaskSubject;
                        detail.Description = desc.Description;
                    }

                    this.Subjects.Add(distributionOfTaskSubject);

                    this.RaisePropertyChangedEvent(nameof(Subjects));
                }
            }
        }

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            switch (propertyName)
            {
                case "Customer":
                    this.Consignor = this.Customer != null ? this.Customer.Consignor : false;
                    this.Carrier = this.Customer != null ? this.Customer.Carrier : false;
                    this.Consignee = this.Customer != null ? this.Customer.Consignee : false;
                    this.Loader = this.Customer != null ? this.Customer.Loader : false;
                    this.Unloader = this.Customer != null ? this.Customer.Unloader : false;
                    this.Packer = this.Customer != null ? this.Customer.Packer : false;
                    this.Filler = this.Customer != null ? this.Customer.Filler : false;
                    this.TankContainer = this.Customer != null ? this.Customer.TankContainer : false;
                    this.Address = this.Customer != null ? this.Customer.Address : string.Empty;
                    this.ActivityCertificate = this.Customer != null ? this.Customer.ActivityCertificateCode : string.Empty;
                    this.Sector = this.Customer != null ? this.Customer.Sector != null ? Session.GetObjectByKey<Sector>(this.Customer.Sector.Oid) : null : null;

                    if (this.Customer != null)
                        this.DateOfValidity = this.Customer.ActivityCertificateDate;


                    this.RaisePropertyChangedEvent("Consignor");
                    this.RaisePropertyChangedEvent("Carrier");
                    this.RaisePropertyChangedEvent("Consignee");
                    this.RaisePropertyChangedEvent("Loader");
                    this.RaisePropertyChangedEvent("Packer");
                    this.RaisePropertyChangedEvent("Filler");
                    this.RaisePropertyChangedEvent("TankContainer");
                    this.RaisePropertyChangedEvent("Address");
                    this.RaisePropertyChangedEvent("ActivityCertificate");
                    this.RaisePropertyChangedEvent("DateOfValidity");
                    this.RaisePropertyChangedEvent(nameof(Sector));
                    break;
                case "Owner":
                    this.TMGDCertificate = this.Owner != null ? this.Owner.TMGDCertificate : string.Empty;

                    this.RaisePropertyChangedEvent("TMGDCertificate");
                    break;
                default:
                    break;
            }
        }

        [RuleRequiredField("RuleRequiredField for DistributionOfTask.BeginDate", DefaultContexts.Save)]
        public DateTime BeginDate { get => _beginDate; set => SetPropertyValue(nameof(BeginDate), ref _beginDate, value); }

        [RuleRequiredField("RuleRequiredField for DistributionOfTask.BeginTime", DefaultContexts.Save)]
        public TimeSpan BeginTime { get => _beginTime; set => SetPropertyValue(nameof(BeginTime), ref _beginTime, value); }
        public string Code { get => _code; set => SetPropertyValue(nameof(Code), ref _code, value); }

        [Browsable(false)]
        public string Name { get => _name; set => SetPropertyValue(nameof(Name), ref _name, value); }

        [RuleRequiredField("RuleRequiredField for DistributionOfTask.Sector", DefaultContexts.Save)]
        [ModelDefault("AllowEdit", "False")]
        public Sector Sector { get => _sector; set => SetPropertyValue(nameof(Sector), ref _sector, value); }

        [RuleRequiredField("RuleRequiredField for DistributionOfTask.ActivityCertificate", DefaultContexts.Save)]
        [ModelDefault("AllowEdit", "False")]
        public string ActivityCertificate { get => _activityCertificate; set => SetPropertyValue(nameof(ActivityCertificate), ref _activityCertificate, value); }

        [RuleRequiredField("RuleRequiredField for DistributionOfTask.DateOfValidity", DefaultContexts.Save)]
        [ModelDefault("AllowEdit", "False")]
        public DateTime DateOfValidity { get => _dateOfValidity; set => SetPropertyValue(nameof(DateOfValidity), ref _dateOfValidity, value); }

        [ImmediatePostData]
        [RuleRequiredField("RuleRequiredField for DistributionOfTask.Customer", DefaultContexts.Save)]
        public Customer Customer { get => _customer; set => SetPropertyValue(nameof(Customer), ref _customer, value); }

        [DataSourceProperty("Customer.Contacts")]
        [RuleRequiredField("RuleRequiredField for DistributionOfTask.CustomerContact", DefaultContexts.Save)]
        public CustomerContact CustomerContact { get => _customerContact; set => SetPropertyValue(nameof(CustomerContact), ref _customerContact, value); }

        [ModelDefault("AllowEdit", "False")]
        public bool Consignor { get => _consignor; set => SetPropertyValue(nameof(Consignor), ref _consignor, value); }

        [ModelDefault("AllowEdit", "False")]
        public bool Carrier { get => _carrier; set => SetPropertyValue(nameof(Carrier), ref _carrier, value); }

        [ModelDefault("AllowEdit", "False")]
        public bool Consignee { get => _consignee; set => SetPropertyValue(nameof(Consignee), ref _consignee, value); }

        [ModelDefault("AllowEdit", "False")]
        public bool Loader { get => _loader; set => SetPropertyValue(nameof(Loader), ref _loader, value); }

        [ModelDefault("AllowEdit", "False")]
        public bool Unloader { get => _unloader; set => SetPropertyValue(nameof(Unloader), ref _unloader, value); }

        [ModelDefault("AllowEdit", "False")]
        public bool Packer { get => _packer; set => SetPropertyValue(nameof(Packer), ref _packer, value); }

        [ModelDefault("AllowEdit", "False")]
        public bool Filler { get => _filler; set => SetPropertyValue(nameof(Filler), ref _filler, value); }

        [ModelDefault("AllowEdit", "False")]
        public bool TankContainer { get => _tankContainer; set => SetPropertyValue(nameof(TankContainer), ref _tankContainer, value); }

        [ModelDefault("AllowEdit", "False")]
        public string Address { get => _address; set => SetPropertyValue(nameof(Address), ref _address, value); }

        [RuleRequiredField("RuleRequiredField for DistributionOfTask.TMGDCertificate", DefaultContexts.Save)]
        public string TMGDCertificate { get => _tmgdCertificate; set => SetPropertyValue(nameof(TMGDCertificate), ref _tmgdCertificate, value); }

        [ModelDefault("AllowEdit", "False")]
        public Employee Owner { get => _owner; set => SetPropertyValue(nameof(Owner), ref _owner, value); }

        [RuleRequiredField("RuleRequiredField for DistributionOfTask.EndDate", DefaultContexts.Save)]
        public DateTime EndDate { get => _endDate; set => SetPropertyValue(nameof(EndDate), ref _endDate, value); }

        [RuleRequiredField("RuleRequiredField for DistributionOfTask.EndTime", DefaultContexts.Save)]
        public TimeSpan EndTime { get => _endTime; set => SetPropertyValue(nameof(EndTime), ref _endTime, value); }

        [VisibleInListView(false),NonPersistent]
        public string Statute { get => "Tehlikeli Madde Güvenlik Danışmanlığı Hakkında Tebliğ (MADDE 23-1,MADDE 27-5-c-d)"; }

        [Association("DistributionOfTask-Subjects"),DevExpress.Xpo.Aggregated]
        public XPCollection<DistributionOfTaskSubject> Subjects => GetCollection<DistributionOfTaskSubject>(nameof(Subjects));
    }
}