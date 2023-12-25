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
    [ImageName("BO_Customer")]
    [DefaultProperty("ShortName")]
    [NavigationItem("CustomerManagement")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Consignee : BaseObject
    {
        private Customer _customer;
        private ConsigneeType _consigneeType;
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
        private bool _isPerson;
        private string _tckn;
        private string _firstName;
        private string _lastName;
        private Employee _owner;
        public Consignee(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (Session.IsNewObject(this))
            {
                int count = Session.GetObjects(Session.GetClassInfo<Consignee>(), null, null, 0, true, true).Count;
                this.Code = string.Format("{0}", (count + 1).ToString().PadLeft(6, '0'));
            }
        }

        [Association("Customer-Consignees")]
        public Customer Customer { get=> _customer; set=> SetPropertyValue(nameof(Customer),ref _customer,value); }

        [NonPersistent]
        [ModelDefault("AllowEdit", "False")]
        [VisibleInDetailView(false)]
        public string ShortName
        {
            get
            {

                if (IsPerson)
                    return string.Format("{0} {1}", FirstName, LastName);
                else
                    return Title;
            }
        }

        public ConsigneeType ConsigneeType { get=> _consigneeType; set=> SetPropertyValue(nameof(ConsigneeType),ref _consigneeType,value); }

        [RuleRequiredField("RuleRequiredField for Consignee.Code", DefaultContexts.Save)]
        [RuleUniqueValue("RuleUniqueValue for Consignee.Code", DefaultContexts.Save)]
        public string Code { get => _code; set => SetPropertyValue("Code", ref _code, value); }


        [RuleRequiredField("RuleRequiredField for Consignee.Title", DefaultContexts.Save)]
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

        [RuleRegularExpression("RuleRegularExpression for Consignee.BillingEMail", DefaultContexts.Save, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|" + @"(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")]
        public string EMail { get => _eMail; set => SetPropertyValue("EMail", ref _eMail, value); }

        [VisibleInListView(false)]
        public string Address { get => _address; set => SetPropertyValue("Address", ref _address, value); }

        [VisibleInListView(false)]
        public bool IsActive { get => _isActive; set => SetPropertyValue("IsActive", ref _isActive, value); }

        [ImmediatePostData]
        [VisibleInListView(false)]
        public bool IsPerson { get => _isPerson; set => SetPropertyValue("IsPerson", ref _isPerson, value); }

        [VisibleInListView(false)]
        [RuleRequiredField("RuleRequiredField Consignee.TCKN", DefaultContexts.Save, TargetCriteria = "IsPerson = 1")]
        [Appearance("Consignee TCKN Hide", Criteria = "IsPerson = 0", Context = "DetailView", Visibility = ViewItemVisibility.Hide)]
        [Size(11)]
        public string TCKN { get => _tckn; set => SetPropertyValue("TCKN", ref _tckn, value); }

        [Appearance("Consignee Firstname Hide", Criteria = "IsPerson = 0", Context = "DetailView", Visibility = ViewItemVisibility.Hide)]
        [RuleRequiredField("RuleRequiredField Consignee.Firstname", DefaultContexts.Save, TargetCriteria = "IsPerson = 1")]
        [VisibleInListView(false)]
        public string FirstName { get => _firstName; set => SetPropertyValue("FirstName", ref _firstName, value); }

        [Appearance("Consignee LastName Hide", Criteria = "IsPerson = 0", Context = "DetailView", Visibility = ViewItemVisibility.Hide)]
        [RuleRequiredField("RuleRequiredField Consignee.LastName", DefaultContexts.Save, TargetCriteria = "IsPerson = 1")]
        [VisibleInListView(false)]
        public string LastName { get => _lastName; set => SetPropertyValue("LastName", ref _lastName, value); }

        [RuleRequiredField("RuleRequiredField Consignee.TaxOffice", DefaultContexts.Save)]
        public string TaxOffice { get => _taxOffice; set => SetPropertyValue(nameof(TaxOffice), ref _taxOffice, value); }

        [Appearance("Consignee TaxNumber Hide", Criteria = "IsPerson = 1", Context = "DetailView", Visibility = ViewItemVisibility.Hide)]
        [RuleRequiredField("RuleRequiredField Consignee.TaxNumber", DefaultContexts.Save, TargetCriteria = "IsPerson = 0")]
        [Size(10)]
        public string TaxNumber { get => _taxNumber; set => SetPropertyValue(nameof(TaxNumber), ref _taxNumber, value); }

        [VisibleInDetailView(false),ModelDefault("AllowEdit","False")]
        public Employee Owner { get=> _owner; set=> SetPropertyValue(nameof(Owner),ref _owner,value); }
    }
}