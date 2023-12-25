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
    [ImageName("BO_Quote")]
    [NavigationItem("SalesManagement")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Quote : BaseObject
    {
        private string _code;
        private DateTime _createdOn;
        private Employee _owner;
        private QuoteCustomerType _quoteCustomerType;
        private Customer _customer;
        private Lead _lead;
        private DateTime _dateOfValidity;
        private int _serviceDay;
        private double _activityCertificatePrice;
        private double _educationPrice;
        private string _address;
        private string _telephone;
        private string _eMail;
        private string _contact;
        private string _description;
        public Quote(Session session)
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
            }
        }

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            switch (propertyName)
            {
                case "Customer":
                case "Lead":
                    switch (CustomerType)
                    {
                        case QuoteCustomerType.Lead:
                            this.Address = Lead != null ? Lead.Address : string.Empty;
                            this.Telephone = Lead != null ? Lead.Telephone : string.Empty;
                            this.EMail = Lead != null ? Lead.EMail : string.Empty;

                            this.Description = this.Description.Replace("{Müşteri}", Lead.Title);
                            this.Description = this.Description.Replace("{Adres}", this.Address);
                            this.Description = this.Description.Replace("{Telefon}", this.Telephone);
                            this.Description = this.Description.Replace("{EMail}", this.EMail);
                            this.Description = this.Description.Replace("{İlgili}", this.Contact);
                            break;
                        case QuoteCustomerType.Customer:
                            this.Address = Customer != null ? Customer.Address : string.Empty;
                            this.Telephone = Customer != null ? Customer.Telephone : string.Empty;
                            this.EMail = Customer != null ? Customer.EMail : string.Empty;

                            if (Customer != null)
                                this.Description = this.Description.Replace("{Müşteri}", Customer != null ? Customer.Title : string.Empty);

                            break;
                        default:
                            break;
                    }

                    this.RaisePropertyChangedEvent(nameof(Address));
                    this.RaisePropertyChangedEvent(nameof(Telephone));
                    this.RaisePropertyChangedEvent(nameof(EMail));
                    break;
                default:
                    break;
            }
        }

        public string Code { get => _code; set => SetPropertyValue(nameof(Code), ref _code, value); }

        [ModelDefault("AllowEdit", "False")]
        public DateTime CreatedOn { get => _createdOn; set => SetPropertyValue(nameof(CreatedOn), ref _createdOn, value); }

        [ModelDefault("AllowEdit", "False")]
        public Employee Owner { get => _owner; set => SetPropertyValue(nameof(Owner), ref _owner, value); }

        [ImmediatePostData]
        public QuoteCustomerType CustomerType { get => _quoteCustomerType; set => SetPropertyValue(nameof(CustomerType), ref _quoteCustomerType, value); }

        [Appearance("Quote Customer Hide", Criteria = "CustomerType = 0", Context = "DetailView", Visibility = ViewItemVisibility.Hide)]
        [RuleRequiredField("RuleRequiredField for Quote.Customer", DefaultContexts.Save, TargetCriteria = "CustomerType = 1")]
        [VisibleInListView(false)]
        [ImmediatePostData]
        public Customer Customer { get => _customer; set => SetPropertyValue(nameof(Customer), ref _customer, value); }


        [Appearance("Quote Lead Hide", Criteria = "CustomerType = 1", Context = "DetailView", Visibility = ViewItemVisibility.Hide)]
        [RuleRequiredField("RuleRequiredField for Quote.Lead", DefaultContexts.Save, TargetCriteria = "CustomerType = 0")]
        [VisibleInListView(false)]
        [ImmediatePostData]
        public Lead Lead { get => _lead; set => SetPropertyValue(nameof(Lead), ref _lead, value); }

        [RuleRequiredField("RuleRequiredField for Quote.Address", DefaultContexts.Save)]
        public string Address { get => _address; set => SetPropertyValue(nameof(Address), ref _address, value); }

        [RuleRequiredField("RuleRequiredField for Quote.Telephone", DefaultContexts.Save)]
        [ModelDefault("EditMaskType", "Simple")]
        [ModelDefault("EditMask", "(999) 000-0000")]
        public string Telephone { get => _telephone; set => SetPropertyValue(nameof(Telephone), ref _telephone, value); }

        [RuleRegularExpression("RuleRegularExpression for Quote.EMail", DefaultContexts.Save, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|" + @"(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")]
        [RuleRequiredField("RuleRequiredField for Quote.EMail", DefaultContexts.Save)]
        public string EMail { get => _eMail; set => SetPropertyValue(nameof(EMail), ref _eMail, value); }

        [RuleRequiredField("RuleRequiredField for Quote.Contact", DefaultContexts.Save)]
        public string Contact { get => _contact; set => SetPropertyValue(nameof(Contact), ref _contact, value); }

        [RuleRequiredField("RuleRequiredField for Quote.DateOfValidity", DefaultContexts.Save)]
        public DateTime DateOfValidity { get => _dateOfValidity; set => SetPropertyValue(nameof(DateOfValidity), ref _dateOfValidity, value); }
        public int ServiceDay { get => _serviceDay; set => SetPropertyValue(nameof(ServiceDay), ref _serviceDay, value); }
        public double ActivityCertificatePrice { get => _activityCertificatePrice; set => SetPropertyValue(nameof(ActivityCertificatePrice), ref _activityCertificatePrice, value); }
        public double EducationPrice { get => _educationPrice; set => SetPropertyValue(nameof(EducationPrice), ref _educationPrice, value); }

        [Size(-1)]
        public string Description { get => _description; set => SetPropertyValue(nameof(Description), ref _description, value); }
    }
}