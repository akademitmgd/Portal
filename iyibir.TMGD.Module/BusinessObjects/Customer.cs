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
    [NavigationItem("CustomerManagement")]
    [ImageName("BO_Customer")]
    public class Customer : BaseObject
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
        private bool _isPerson;
        private string _tckn;
        private string _firstName;
        private string _lastName;
        private bool _consignor;
        private bool _carrier;
        private bool _consignee;
        private bool _loader;
        private bool _unloader;
        private bool _packer;
        private bool _filler;
        private bool _tankContainer;
        private FileData _activityCertificate;
        private string _activityCertificateCode;
        private DateTime _activityCertificateDate;
        private Employee _consultant;
        private Sector _sector;
        private string _uetdsUsername;
        private string _uetdsPassword;
        private bool _isOnlineTransaction;
        public Customer(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (Session.IsNewObject(this))
            {
                int count = Session.GetObjects(Session.GetClassInfo<Customer>(), null, null, 0, true, true).Count;
                this.Code = string.Format("{0}", (count + 1).ToString().PadLeft(6, '0'));
            }
        }

        [VisibleInListView(true)]
        [ImageEditor(ListViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorFixedHeight = 350, DetailViewImageEditorFixedWidth = 350)]
        public byte[] CustomerImage
        {
            get { return GetPropertyValue<byte[]>(nameof(CustomerImage)); }
            set { SetPropertyValue<byte[]>(nameof(CustomerImage), value); }
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

        [RuleRequiredField("RuleRequiredField for Customer.Code", DefaultContexts.Save)]
        [RuleUniqueValue("RuleUniqueValue for Customer.Code", DefaultContexts.Save)]
        public string Code { get => _code; set => SetPropertyValue("Code", ref _code, value); }


        [RuleRequiredField("RuleRequiredField for Customer.Title", DefaultContexts.Save)]
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

        [RuleRegularExpression("RuleRegularExpression for Customer.BillingEMail", DefaultContexts.Save, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|" + @"(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")]
        public string EMail { get => _eMail; set => SetPropertyValue("EMail", ref _eMail, value); }

        [VisibleInListView(false)]
        public string Address { get => _address; set => SetPropertyValue("Address", ref _address, value); }

        [VisibleInListView(false)]
        public bool IsActive { get => _isActive; set => SetPropertyValue("IsActive", ref _isActive, value); }

        [ImmediatePostData]
        [VisibleInListView(false)]
        public bool IsPerson { get => _isPerson; set => SetPropertyValue("IsPerson", ref _isPerson, value); }

        [VisibleInListView(false)]
        [RuleRequiredField("RuleRequiredField Customer.TCKN", DefaultContexts.Save, TargetCriteria = "IsPerson = 1")]
        [Appearance("Customer TCKN Hide", Criteria = "IsPerson = 0", Context = "DetailView", Visibility = ViewItemVisibility.Hide)]
        [Size(11)]
        public string TCKN { get => _tckn; set => SetPropertyValue("TCKN", ref _tckn, value); }

        [Appearance("Customer Firstname Hide", Criteria = "IsPerson = 0", Context = "DetailView", Visibility = ViewItemVisibility.Hide)]
        [RuleRequiredField("RuleRequiredField Customer.Firstname", DefaultContexts.Save, TargetCriteria = "IsPerson = 1")]
        [VisibleInListView(false)]
        public string FirstName { get => _firstName; set => SetPropertyValue("FirstName", ref _firstName, value); }

        [Appearance("Customer LastName Hide", Criteria = "IsPerson = 0", Context = "DetailView", Visibility = ViewItemVisibility.Hide)]
        [RuleRequiredField("RuleRequiredField Customer.LastName", DefaultContexts.Save, TargetCriteria = "IsPerson = 1")]
        [VisibleInListView(false)]
        public string LastName { get => _lastName; set => SetPropertyValue("LastName", ref _lastName, value); }

        public bool Consignor { get => _consignor; set => SetPropertyValue(nameof(Consignor), ref _consignor, value); }
        public bool Carrier { get => _carrier; set => SetPropertyValue(nameof(Carrier), ref _carrier, value); }
        public bool Consignee { get => _consignee; set => SetPropertyValue(nameof(Consignee), ref _consignee, value); }
        public bool Loader { get => _loader; set => SetPropertyValue(nameof(Loader), ref _loader, value); }
        public bool Unloader { get => _unloader; set => SetPropertyValue(nameof(Unloader), ref _unloader, value); }
        public bool Packer { get => _packer; set => SetPropertyValue(nameof(Packer), ref _packer, value); }
        public bool Filler { get => _filler; set => SetPropertyValue(nameof(Filler), ref _filler, value); }
        public bool TankContainer { get => _tankContainer; set => SetPropertyValue(nameof(TankContainer), ref _tankContainer, value); }

        [RuleRequiredField("RuleRequiredField Customer.TaxOffice", DefaultContexts.Save)]
        public string TaxOffice { get => _taxOffice; set => SetPropertyValue(nameof(TaxOffice), ref _taxOffice, value); }

        [Appearance("Customer TaxNumber Hide", Criteria = "IsPerson = 1", Context = "DetailView", Visibility = ViewItemVisibility.Hide)]
        [RuleRequiredField("RuleRequiredField Customer.TaxNumber", DefaultContexts.Save, TargetCriteria = "IsPerson = 0")]
        public string TaxNumber { get => _taxNumber; set => SetPropertyValue(nameof(TaxNumber), ref _taxNumber, value); }

        [RuleRequiredField("RuleRequiredField for Customer.ActivityCertificate", DefaultContexts.Save)]
        [ExpandObjectMembers(ExpandObjectMembers.Never)]
        public FileData ActivityCertificate { get => _activityCertificate; set => SetPropertyValue(nameof(ActivityCertificate), ref _activityCertificate, value); }

        [RuleRequiredField("RuleRequiredField for Customer.ActivityCertificateCode", DefaultContexts.Save)]
        public string ActivityCertificateCode { get => _activityCertificateCode; set => SetPropertyValue(nameof(ActivityCertificateCode), ref _activityCertificateCode, value); }

        [RuleRequiredField("RuleRequiredField for Customer.ActivityCertificateDate", DefaultContexts.Save)]
        public DateTime ActivityCertificateDate { get => _activityCertificateDate; set => SetPropertyValue(nameof(ActivityCertificateDate), ref _activityCertificateDate, value); }

        [Association("Employee-Customers")]
        public Employee Consultant { get => _consultant; set => SetPropertyValue(nameof(Consultant), ref _consultant, value); }

        [RuleRequiredField("RuleRequiredField for Customer.Sector", DefaultContexts.Save)]
        public Sector Sector { get => _sector; set => SetPropertyValue(nameof(Sector), ref _sector, value); }

        [ImmediatePostData]
        public bool IsOnlineTransaction { get => _isOnlineTransaction; set => SetPropertyValue(nameof(IsOnlineTransaction), ref _isOnlineTransaction, value); }

        [Appearance("Customer UETDSUsername Hide", Criteria = "IsOnlineTransaction = 0", Context = "DetailView", Visibility = ViewItemVisibility.Hide)]
        [VisibleInDetailView(false)]
        public string UETDSUsername { get => _uetdsUsername; set => SetPropertyValue(nameof(UETDSUsername), ref _uetdsUsername, value); }

        [Appearance("Customer UETDSPassword Hide", Criteria = "IsOnlineTransaction = 0", Context = "DetailView", Visibility = ViewItemVisibility.Hide)]
        [VisibleInDetailView(false)]
        public string UETDSPassword { get => _uetdsPassword; set => SetPropertyValue(nameof(UETDSPassword), ref _uetdsPassword, value); }

        [Association("Customer-Contacts"), DevExpress.Xpo.Aggregated]
        public XPCollection<CustomerContact> Contacts => GetCollection<CustomerContact>(nameof(Contacts));

        [Association("Customer-Inventories"), DevExpress.Xpo.Aggregated]
        [VisibleInDetailView(false)]
        public XPCollection<CustomerInventory> DangerousSubstanceInventory => GetCollection<CustomerInventory>(nameof(DangerousSubstanceInventory));

        [Association("Customer-Vehicles"), DevExpress.Xpo.Aggregated]
        public XPCollection<Vehicle> Vehicles => GetCollection<Vehicle>(nameof(Vehicles));

        [Association("Customer-Drivers"), DevExpress.Xpo.Aggregated]
        public XPCollection<VehicleDriver> Drivers => GetCollection<VehicleDriver>(nameof(Drivers));

        [Association("Customer-DefaultVehicleDocumentTransactions"), DevExpress.Xpo.Aggregated]
        public XPCollection<DefaultVehicleControlDocumentTransaction> DefaultVehicleDocumentTransactions => GetCollection<DefaultVehicleControlDocumentTransaction>(nameof(DefaultVehicleDocumentTransactions));

        [Association("Customer-Documents"), DevExpress.Xpo.Aggregated]
        public XPCollection<CustomerDocument> Documents => GetCollection<CustomerDocument>(nameof(Documents));

        [Association("Customer-Consignees"), DevExpress.Xpo.Aggregated]
        public XPCollection<Consignee> Consignees => GetCollection<Consignee>(nameof(Consignees));


        [Association("Customer-ActivityReports")]
        [VisibleInDetailView(false)]
        public XPCollection<ActivityReport> ActivityReports => GetCollection<ActivityReport>(nameof(ActivityReports));

        [Association("Customer-WasteInventories"), DevExpress.Xpo.Aggregated]
        [VisibleInDetailView(false)]
        public XPCollection<CustomerWasteInventory> WasteInventories => GetCollection<CustomerWasteInventory>(nameof(WasteInventories));

        [Association("Customer-Products")]
        public XPCollection<Product> Inventories => GetCollection<Product>(nameof(Inventories));
    }
}