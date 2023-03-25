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
    [ImageName("BO_Contact")]
    public class CustomerContact : BaseObject
    {
        private Customer _customer;
        private string _name;
        private Country _country;
        private City _city;
        private County _county;
        private string _telephone;
        private string _otherTelephone;
        private string _eMail;
        private string _authorizedPerson;
        private string _address;
        private bool _isActive;
        private string _tckn;
        private string _registrationNumber;
        private string _eGovernmentAuthorized;
        public CustomerContact(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            
        }

        [Association("Customer-Contacts")]
        public Customer Customer { get => _customer; set => SetPropertyValue("Customer", ref _customer, value); }

        [RuleRequiredField("RuleRequiredField for CustomerContact.Name", DefaultContexts.Save)]
        public string Name { get => _name; set => SetPropertyValue("Name", ref _name, value); }

        [ImmediatePostData]
        public Country Country { get => _country; set => SetPropertyValue("Country", ref _country, value); }

        [DataSourceProperty("Country.Cities")]
        [ImmediatePostData]
        public City City { get => _city; set => SetPropertyValue("City", ref _city, value); }

        [DataSourceProperty("City.Counties")]
        public County County { get => _county; set => SetPropertyValue("County", ref _county, value); }

        [ModelDefault("EditMaskType", "Simple")]
        [ModelDefault("EditMask", "(999) 000-0000")]
        public string Telephone { get => _telephone; set => SetPropertyValue("Telephone", ref _telephone, value); }

        [ModelDefault("EditMaskType", "Simple")]
        [ModelDefault("EditMask", "(999) 000-0000")]
        public string OtherTelephone { get => _otherTelephone; set => SetPropertyValue("OtherTelephone", ref _otherTelephone, value); }

        [RuleRegularExpression("RuleRegularExpression for CustomerContact.BillingEMail", DefaultContexts.Save, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|" + @"(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")]
        public string EMail { get => _eMail; set => SetPropertyValue("EMail", ref _eMail, value); }
        public string Address { get => _address; set => SetPropertyValue("Address", ref _address, value); }
        public bool IsActive { get => _isActive; set => SetPropertyValue("IsActive", ref _isActive, value); }

        [Size(11)]
        public string TCKN { get=> _tckn; set=> SetPropertyValue(nameof(TCKN),ref _tckn,value); }
        public string RegistrationNumber { get=> _registrationNumber; set=> SetPropertyValue(nameof(RegistrationNumber),ref _registrationNumber,value); }
        public string eGovernmentAuthorized { get=> _eGovernmentAuthorized; set=> SetPropertyValue(nameof(eGovernmentAuthorized),ref _eGovernmentAuthorized,value); }
    }
}