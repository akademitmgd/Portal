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
    //[ImageName("BO_Contact")]
    [DefaultProperty("Title")]
    [NavigationItem("Settings")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Company : BaseObject
    {
        private string _code;
        private string _title;
        private Country _country;
        private City _city;
        private County _county;
        private string _telephone;
        private string _otherTelephone;
        private string _eMail;
        private string _address;
        private bool _isActive;
        private string _taxOffice;
        private string _taxNumber;
        public Company(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (Session.IsNewObject(this))
            {
                IsActive = true;
            }
        }

        [RuleRequiredField("RuleRequiredField for Company.Code", DefaultContexts.Save)]
        [RuleUniqueValue("RuleUniqueValue for Company.Code", DefaultContexts.Save)]
        public string Code { get => _code; set => SetPropertyValue("Code", ref _code, value); }


        [RuleRequiredField("RuleRequiredField for Company.Title", DefaultContexts.Save)]
        [VisibleInListView(false)]
        public string Title { get => _title; set => SetPropertyValue("Title", ref _title, value); }

        [ImmediatePostData]
        public Country Country { get => _country; set => SetPropertyValue("Country", ref _country, value); }

        [ImmediatePostData]
        [DataSourceProperty("Country.Cities")]
        public City City { get => _city; set => SetPropertyValue("City", ref _city, value); }

        [DataSourceProperty("City.Counties")]
        [VisibleInListView(false)]
        public County County { get => _county; set => SetPropertyValue("City", ref _county, value); }


        [ModelDefault("EditMaskType", "Simple")]
        [ModelDefault("EditMask", "(999) 000-0000")]
        public string Telephone { get => _telephone; set => SetPropertyValue("", ref _telephone, value); }


        [ModelDefault("EditMaskType", "Simple")]
        [ModelDefault("EditMask", "(999) 000-0000")]
        [VisibleInListView(false)]
        public string OtherTelephone { get => _otherTelephone; set => SetPropertyValue("OtherTelephone", ref _otherTelephone, value); }

        [RuleRegularExpression("RuleRegularExpression for Company.BillingEMail", DefaultContexts.Save, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|" + @"(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")]
        public string EMail { get => _eMail; set => SetPropertyValue("EMail", ref _eMail, value); }

        [VisibleInListView(false)]
        public string Address { get => _address; set => SetPropertyValue("Address", ref _address, value); }

 
        [RuleUniqueValue("RuleUniqueValue for Company.IsActive", DefaultContexts.Save)]
        public bool IsActive { get => _isActive; set => SetPropertyValue("IsActive", ref _isActive, value); }


        [RuleRequiredField("RuleRequiredField Company.TaxOffice", DefaultContexts.Save)]
        public string TaxOffice { get => _taxOffice; set => SetPropertyValue(nameof(TaxOffice), ref _taxOffice, value); }


        [RuleRequiredField("RuleRequiredField Company.TaxNumber", DefaultContexts.Save)]
        [Size(10)]
        public string TaxNumber { get => _taxNumber; set => SetPropertyValue(nameof(TaxNumber), ref _taxNumber, value); }
    }
}