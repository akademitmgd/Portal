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
    [ImageName("BO_Contract")]
    [DefaultProperty("FicheNumber")]
    public class Contract : BaseObject
    {
        private string _code;
        private DateTime _createdOn;
        private Employee _owner;
        private Company _company;
        private string _companyAddress;
        private string _companyTaxOffice;
        private string _companyTaxNumber;
        private string _companyTelephone;
        private string _companyEmail;
        private string _companyFax;
        private Customer _customer;
        private string _customerAddress;
        private string _customerTaxOffice;
        private string _customerTaxNumber;
        private string _customerTelephone;
        private string _customerEmail;
        private string _customerFax;
        private int _taskDay;
        private double _processPrice;
        private double _servicePrice;
        private double _educationPrice;
        private DateTime _modificationDate;
        private string _description;
        public Contract(Session session)
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
                int count = Session.GetObjects(Session.GetClassInfo<Contract>(), null, null, 0, true, true).Count;
                count = count + 1;
                this.Code = string.Format("{0}", count.ToString().PadLeft(4, '0'));
                Company = Session.FindObject<Company>(CriteriaOperator.Parse("IsActive = ?", true));
            }
        }

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            switch (propertyName)
            {
                case "Company":
                    if (Company != null)
                    {
                        CompanyAddress = this.Company.Address;
                        CompanyEmail = this.Company.EMail;
                        CompanyTaxNumber = this.Company.TaxNumber;
                        CompanyTaxOffice = this.Company.TaxOffice;
                        CompanyTelephone = this.Company.Telephone;
                        CompanyFax = this.Company.OtherTelephone;

                        this.RaisePropertyChangedEvent(nameof(CompanyAddress));
                        this.RaisePropertyChangedEvent(nameof(CompanyEmail));
                        this.RaisePropertyChangedEvent(nameof(CompanyTaxNumber));
                        this.RaisePropertyChangedEvent(nameof(CompanyTaxOffice));
                        this.RaisePropertyChangedEvent(nameof(CompanyTelephone));
                        this.RaisePropertyChangedEvent(nameof(CompanyFax));

                    }                    
                    break;
                case "Customer":
                    if (Customer != null)
                    {
                        CustomerAddress = this.Customer.Address;
                        CustomerEmail = this.Customer.EMail;
                        CustomerTaxNumber = this.Customer.TaxNumber;
                        CustomerTaxOffice = this.Customer.TaxOffice;
                        CustomerTelephone = this.Customer.Telephone;
                        CustomerFax = this.Customer.OtherTelephone;

                        this.RaisePropertyChangedEvent(nameof(CustomerAddress));
                        this.RaisePropertyChangedEvent(nameof(CustomerEmail));
                        this.RaisePropertyChangedEvent(nameof(CustomerTaxNumber));
                        this.RaisePropertyChangedEvent(nameof(CustomerTaxOffice));
                        this.RaisePropertyChangedEvent(nameof(CustomerTelephone));
                        this.RaisePropertyChangedEvent(nameof(CustomerFax));
                    }
                    break;
                default:
                    break;
            }
        }

        [ModelDefault("AllowEdit","False")]
        public string Code { get=> _code; set=> SetPropertyValue(nameof(Code),ref _code,value); }

        [ModelDefault("AllowEdit", "False")]
        public DateTime CreatedOn { get=> _createdOn; set=> SetPropertyValue(nameof(CreatedOn),ref _createdOn,value); }

        [ModelDefault("AllowEdit", "False")]
        public Employee Owner { get=> _owner; set=> SetPropertyValue(nameof(Owner),ref _owner,value); }

        [ModelDefault("AllowEdit", "False")]
        [ImmediatePostData]
        public Company Company { get => _company; set=> SetPropertyValue(nameof(Company),ref _company,value); }

        [NonPersistent]
        [ModelDefault("AllowEdit", "False")]
        public string CompanyAddress { get=> _companyAddress; set=> SetPropertyValue(nameof(CompanyAddress),ref _companyAddress,value); }

        [NonPersistent]
        [ModelDefault("AllowEdit", "False")]
        public string CompanyTaxOffice { get=> _companyTaxOffice; set=> SetPropertyValue(nameof(CompanyTaxOffice),ref _companyTaxOffice,value); }

        [NonPersistent]
        [ModelDefault("AllowEdit", "False")]
        public string CompanyTaxNumber { get=> _companyTaxNumber; set=> SetPropertyValue(nameof(CompanyTaxNumber),ref _companyTaxNumber,value); }

        [NonPersistent]
        [ModelDefault("AllowEdit", "False")]
        public string CompanyTelephone { get=> _companyTelephone; set=> SetPropertyValue(nameof(CompanyTelephone),ref _companyTelephone,value); }

        [NonPersistent]
        [ModelDefault("AllowEdit", "False")]
        public string CompanyFax { get=> _companyFax; set=> SetPropertyValue(nameof(CompanyFax),ref _companyFax,value); }

        [NonPersistent]
        [ModelDefault("AllowEdit", "False")]
        public string CompanyEmail { get=> _companyEmail; set=> SetPropertyValue(nameof(CompanyEmail),ref _companyEmail,value); }

        [ImmediatePostData]
        public Customer Customer { get=> _customer; set=> SetPropertyValue(nameof(Customer),ref _customer,value); }

        [NonPersistent]
        [ModelDefault("AllowEdit", "False")]
        public string CustomerAddress { get=> _customerAddress; set=> SetPropertyValue(nameof(CustomerAddress),ref _customerAddress,value); }

        [NonPersistent]
        [ModelDefault("AllowEdit", "False")]
        public string CustomerTaxOffice { get=> _customerTaxOffice; set=> SetPropertyValue(nameof(CustomerTaxOffice),ref _customerTaxOffice,value); }

        [NonPersistent]
        [ModelDefault("AllowEdit", "False")]
        public string CustomerTaxNumber { get=> _customerTaxNumber; set=> SetPropertyValue(nameof(CustomerTaxNumber),ref _customerTaxNumber,value); }

        [NonPersistent]
        [ModelDefault("AllowEdit", "False")]
        public string CustomerTelephone { get=> _customerTelephone; set=> SetPropertyValue(nameof(CustomerTelephone),ref _customerTelephone,value); }

        [NonPersistent]
        [ModelDefault("AllowEdit", "False")]
        public string CustomerFax { get=> _customerFax; set=> SetPropertyValue(nameof(CustomerFax),ref _customerFax,value); }

        [NonPersistent]
        [ModelDefault("AllowEdit", "False")]
        public string CustomerEmail { get=> _customerEmail; set=> SetPropertyValue(nameof(CustomerEmail),ref _customerEmail,value); }

        public int TaskDay { get=> _taskDay; set=> SetPropertyValue(nameof(TaskDay),ref _taskDay,value); }
        public double ProcessPrice { get=> _processPrice; set=> SetPropertyValue(nameof(ProcessPrice),ref _processPrice,value); }
        public double ServicePrice { get=> _servicePrice; set=> SetPropertyValue(nameof(ServicePrice),ref _servicePrice,value); }
        public double EducationPrice { get=> _educationPrice; set=> SetPropertyValue(nameof(EducationPrice),ref _educationPrice,value); }

        [RuleRequiredField("RuleRequiredField for Contract.ModificationDate", DefaultContexts.Save)]
        public DateTime ModificationDate { get=> _modificationDate; set=> SetPropertyValue(nameof(ModificationDate),ref _modificationDate,value); }
        public string Description { get=> _description; set=> SetPropertyValue(nameof(Description),ref _description,value); }


    }
}