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
    [ImageName("BO_Lead")]
    [NavigationItem("SalesManagement")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Lead : BaseObject
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

        private bool _isPerson;
        private string _tckn;
        private string _firstName;
        private string _lastName;

        public Lead(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

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

        [RuleRequiredField("RuleRequiredField for Lead.Code", DefaultContexts.Save)]
        [RuleUniqueValue("RuleUniqueValue for Lead.Code", DefaultContexts.Save)]
        public string Code { get => _code; set => SetPropertyValue("Code", ref _code, value); }


        [RuleRequiredField("RuleRequiredField for Lead.Title", DefaultContexts.Save)]
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

        [RuleRegularExpression("RuleRegularExpression for Lead.BillingEMail", DefaultContexts.Save, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|" + @"(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")]
        public string EMail { get => _eMail; set => SetPropertyValue("EMail", ref _eMail, value); }

        [VisibleInListView(false)]
        public string Address { get => _address; set => SetPropertyValue("Address", ref _address, value); }

        [VisibleInListView(false)]
        public bool IsActive { get => _isActive; set => SetPropertyValue("IsActive", ref _isActive, value); }

        [ImmediatePostData]
        [VisibleInListView(false)]
        public bool IsPerson { get => _isPerson; set => SetPropertyValue("IsPerson", ref _isPerson, value); }

        [VisibleInListView(false)]
        [RuleRequiredField("RuleRequiredField Lead.TCKN", DefaultContexts.Save, TargetCriteria = "IsPerson = 1")]
        [Appearance("Lead TCKN Hide", Criteria = "IsPerson = 0", Context = "DetailView", Visibility = ViewItemVisibility.Hide)]
        [Size(11)]
        public string TCKN { get => _tckn; set => SetPropertyValue("TCKN", ref _tckn, value); }

        [Appearance("Lead Firstname Hide", Criteria = "IsPerson = 0", Context = "DetailView", Visibility = ViewItemVisibility.Hide)]
        [RuleRequiredField("RuleRequiredField Lead.Firstname", DefaultContexts.Save, TargetCriteria = "IsPerson = 1")]
        [VisibleInListView(false)]
        public string FirstName { get => _firstName; set => SetPropertyValue("FirstName", ref _firstName, value); }

        [Appearance("Lead LastName Hide", Criteria = "IsPerson = 0", Context = "DetailView", Visibility = ViewItemVisibility.Hide)]
        [RuleRequiredField("RuleRequiredField Lead.LastName", DefaultContexts.Save, TargetCriteria = "IsPerson = 1")]
        [VisibleInListView(false)]
        public string LastName { get => _lastName; set => SetPropertyValue("LastName", ref _lastName, value); }
    }
}