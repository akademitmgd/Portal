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
    [ImageName("BO_List")]
    [NavigationItem("DocumentManagement")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class TransportDocument : BaseObject
    {
        private string _code;
        private DateTime _createdDate;
        private TimeSpan _createdTime;
        private Employee _owner;
        private Customer _consigner;
        private string _consignerTaxOffice;
        private string _consignerTaxNumber;
        private string _consignerAddress;
        private string _consigneeTaxOffice;
        private string _consigneeTaxNumber;
        private string _consigneeAddress;
        private Vehicle _vehicle;
        private Vehicle _otherVehicle;
        private VehicleDriver _driver;
        private string _transportCategory;
        private double _scoreQuantity;
        private string _tunnelCode;
        private string _description;
        private Consignee _consignee;
        private TransportDocumentType _transportDocumentType;
        private bool _isSpecial;
        private Consignee _shipper;
        private string _specialShipper;
        private int _seferId;
        private TransportDocumentStatus _status;


        public TransportDocument(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (Session.IsNewObject(this))
            {
                CreatedDate = DateTime.Now;
                CreatedTime = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                Owner = Session.GetObjectByKey<Employee>(SecuritySystem.CurrentUserId);
                Consigner = Owner != null ? Owner.Customer != null ? Session.GetObjectByKey<Customer>(Owner.Customer.Oid) : null : null;

                int count = Session.GetObjects(Session.GetClassInfo<TransportDocument>(), null, null, 0, true, true).Count;
                count = count + 1;
                this.Code = string.Format("{0}", count.ToString().PadLeft(4, '0'));
            }
        }

        protected override void OnSaving()
        {
            base.OnSaving();
            switch (this.TransportDocumentType)
            {
                case TransportDocumentType.Product:
                    Session.Delete(this.OtherTransactions);
                    break;
                case TransportDocumentType.Waste:
                    Session.Delete(this.Transactions);
                    break;
                default:
                    break;
            }
        }

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            switch (propertyName)
            {
                case "Consigner":
                    if (Consigner != null)
                    {
                        this.ConsignerTaxNumber = Consigner.TaxNumber;
                        this.ConsignerTaxOffice = Consigner.TaxOffice;
                        this.ConsignerAddress = Consigner.Address;

                        this.RaisePropertyChangedEvent(nameof(ConsignerTaxNumber));
                        this.RaisePropertyChangedEvent(nameof(ConsignerTaxOffice));
                        this.RaisePropertyChangedEvent(nameof(ConsignerAddress));
                    }
                    break;
                case "Consignee":
                    if (Consignee != null)
                    {
                        this.ConsigneeTaxNumber = Consignee.TaxNumber;
                        this.ConsigneeTaxOffice = Consignee.TaxOffice;
                        this.ConsigneeAddress = Consignee.Address;

                        this.RaisePropertyChangedEvent(nameof(ConsigneeTaxNumber));
                        this.RaisePropertyChangedEvent(nameof(ConsigneeTaxOffice));
                        this.RaisePropertyChangedEvent(nameof(ConsigneeAddress));
                    }
                    break;
                case "Transactions":

                    ScoreQuantity = Transactions.ToList().OrderByDescending(x => x.Val).FirstOrDefault().Val;

                    this.RaisePropertyChangedEvent("ScoreQuantity");

                    break;
                case "OtherTransactions":

                    ScoreQuantity = OtherTransactions.ToList().OrderByDescending(x => x.Val).FirstOrDefault().Val;

                    this.RaisePropertyChangedEvent("ScoreQuantity");
                    break;
                default:
                    break;
            }
        }

        [Browsable(false)]
        public int SeferId { get => _seferId; set => SetPropertyValue(nameof(SeferId), ref _seferId, value); }

        [ModelDefault("AllowEdit", "False")]
        public TransportDocumentStatus Status { get => _status; set => SetPropertyValue(nameof(Status), ref _status, value); }

        [RuleRequiredField("RuleRequiredField for TransportDocument.Code", DefaultContexts.Save)]
        public string Code { get => _code; set => SetPropertyValue(nameof(Code), ref _code, value); }

        [RuleRequiredField("RuleRequiredField for TransportDocument.CreatedDate", DefaultContexts.Save)]
        public DateTime CreatedDate { get => _createdDate; set => SetPropertyValue(nameof(CreatedDate), ref _createdDate, value); }

        [RuleRequiredField("RuleRequiredField for TransportDocument.CreatedTime", DefaultContexts.Save)]
        public TimeSpan CreatedTime { get => _createdTime; set => SetPropertyValue(nameof(CreatedTime), ref _createdTime, value); }

        [ModelDefault("AllowEdit", "False")]
        public Employee Owner { get => _owner; set => SetPropertyValue(nameof(Owner), ref _owner, value); }

        [RuleRequiredField("RuleRequiredField for TransportDocument.Consigner", DefaultContexts.Save)]
        [ImmediatePostData]
        public Customer Consigner { get => _consigner; set => SetPropertyValue(nameof(Consigner), ref _consigner, value); }

        [ModelDefault("AllowEdit", "False")]
        public string ConsignerTaxOffice { get => _consignerTaxOffice; set => SetPropertyValue(nameof(ConsignerTaxOffice), ref _consignerTaxOffice, value); }

        [ModelDefault("AllowEdit", "False")]
        public string ConsignerTaxNumber { get => _consignerTaxNumber; set => SetPropertyValue(nameof(ConsignerTaxNumber), ref _consignerTaxNumber, value); }

        [ModelDefault("AllowEdit", "False")]
        public string ConsignerAddress { get => _consignerAddress; set => SetPropertyValue(nameof(ConsignerAddress), ref _consignerAddress, value); }

        [RuleRequiredField("RuleRequiredField for TransportDocument.Consignee", DefaultContexts.Save)]
        [ImmediatePostData]
        [DataSourceProperty("Consigner.Consignees")]
        public Consignee Consignee { get => _consignee; set => SetPropertyValue(nameof(Consignee), ref _consignee, value); }

        [RuleRequiredField("RuleRequiredField for TransportDocument.ConsigneeTaxOffice", DefaultContexts.Save)]
        public string ConsigneeTaxOffice { get => _consigneeTaxOffice; set => SetPropertyValue(nameof(ConsigneeTaxOffice), ref _consigneeTaxOffice, value); }

        [RuleRequiredField("RuleRequiredField for TransportDocument.ConsigneeTaxNumber", DefaultContexts.Save)]
        public string ConsigneeTaxNumber { get => _consigneeTaxNumber; set => SetPropertyValue(nameof(ConsigneeTaxNumber), ref _consigneeTaxNumber, value); }

        [RuleRequiredField("RuleRequiredField for TransportDocument.ConsigneeAddress", DefaultContexts.Save)]
        public string ConsigneeAddress { get => _consigneeAddress; set => SetPropertyValue(nameof(ConsigneeAddress), ref _consigneeAddress, value); }

        [DataSourceProperty("Consigner.Vehicles")]
        public Vehicle Vehicle { get => _vehicle; set => SetPropertyValue(nameof(Vehicle), ref _vehicle, value); }

        [DataSourceProperty("Consigner.Vehicles"), ToolTip("(Motorsuz,Römork,Yarı Römork vb)")]
        [DataSourceCriteria("VehicleType = 1")]
        public Vehicle OtherVehicle { get => _otherVehicle; set => SetPropertyValue(nameof(OtherVehicle), ref _otherVehicle, value); }

        [DataSourceProperty("Consigner.Drivers")]
        public VehicleDriver Driver { get => _driver; set => SetPropertyValue(nameof(Driver), ref _driver, value); }

        public string TransportCategory { get => _transportCategory; set => SetPropertyValue(nameof(TransportCategory), ref _transportCategory, value); }

        [ModelDefault("AllowEdit","False")]
        public double ScoreQuantity { get {

                if (!IsLoading && !IsSaving)
                {
                    switch (TransportDocumentType)
                    {
                        case TransportDocumentType.Product:

                            TransportDocumentTransaction firstValue = Transactions.FirstOrDefault();
                            bool result = true;
                            foreach (TransportDocumentTransaction transaction in Transactions)
                            {
                                if (transaction.TransportCategory != null && firstValue.TransportCategory != null)
                                {
                                    if (transaction.TransportCategory.Code != firstValue.TransportCategory.Code)
                                    {
                                        result = false;
                                        break;
                                    } 
                                }
                            }

                            if (result)
                            {
                                
                                    StatusMessage = "TK = 0 ise < 0\nTK = 1 ise < 20\nTK = 2 ise < 333\nTK = 3 ise < 1000\nTK = 4 ise Sınırsız..\n1.1.3.6 Muafiyeti Uygulanır..";
                                
                                return Transactions.Sum(x => x.NetWeigth);
                            }
                            else
                            {
                                    StatusMessage = "< 1000 ise 1.1.3.6 Muafiyeti Uygulanır.."; 
                                
                                return Transactions.Sum(x => x.TotalConvFactor);
                            }


                        case TransportDocumentType.Waste:
                            TransportDocumentOtherTransaction firstOtherValue = OtherTransactions.FirstOrDefault();
                            bool otherResult = true;
                            foreach (TransportDocumentOtherTransaction transaction in OtherTransactions)
                            {
                                if (transaction.TransportCategory != null && firstOtherValue.TransportCategory != null)
                                {
                                    if (transaction.TransportCategory.Code != firstOtherValue.TransportCategory.Code)
                                    {
                                        otherResult = false;
                                        break;
                                    } 
                                }
                            }

                            if (otherResult)
                            {
                              
                                    StatusMessage = "TK = 0 ise < 0\nTK = 1 ise < 20\nTK = 2 ise < 333\nTK = 3 ise < 1000\nTK = 4 ise Sınırsız..\n1.1.3.6 Muafiyeti Uygulanır.."; 
                                
                                return OtherTransactions.Sum(x => x.NetWeigth);
                            }
                            else
                            {
                                
                                    StatusMessage = "< 1000 ise 1.1.3.6 Muafiyeti Uygulanır.."; 
                                
                                return OtherTransactions.Sum(x => x.TotalConvFactor);
                            }

                        default:
                            return _scoreQuantity;
                    }
                }
                else
                    return _scoreQuantity;

            } set => SetPropertyValue(nameof(ScoreQuantity), ref _scoreQuantity, value); }
        
        [ModelDefault("AllowEdit","False")]
        public string TunnelCode
        {
            get
            {

                if (!IsLoading && !IsSaving)
                {
                    switch (TransportDocumentType)
                    {
                        case TransportDocumentType.Product:
                            _tunnelCode = Transactions.ToList().OrderByDescending(x => x.Val).FirstOrDefault() != null ? Transactions.ToList().OrderByDescending(x => x.Val).FirstOrDefault().TunnelCode != null ? Transactions.ToList().OrderByDescending(x => x.Val).FirstOrDefault().TunnelCode.Code : string.Empty : string.Empty;
                            return _tunnelCode;
                        case TransportDocumentType.Waste:
                            _tunnelCode = OtherTransactions.ToList().OrderByDescending(x => x.Val).FirstOrDefault() != null ? OtherTransactions.ToList().OrderByDescending(x => x.Val).FirstOrDefault().TunnelCode != null ? OtherTransactions.ToList().OrderByDescending(x => x.Val).FirstOrDefault().TunnelCode.Code : string.Empty : string.Empty;
                            return _tunnelCode;
                        default:
                            return _tunnelCode;
                    }
                }
                else
                    return _tunnelCode;
            }
            set => SetPropertyValue(nameof(TunnelCode), ref _tunnelCode, value);
        }

        [Size(-1)]
        [VisibleInDetailView(false)]
        public string Description { get => _description; set => SetPropertyValue(nameof(Description), ref _description, value); }

        [ImmediatePostData]
        public TransportDocumentType TransportDocumentType { get => _transportDocumentType; set => SetPropertyValue(nameof(TransportDocumentType), ref _transportDocumentType, value); }

        [ImmediatePostData]
        public bool IsSpecial { get => _isSpecial; set => SetPropertyValue(nameof(IsSpecial), ref _isSpecial, value); }

        [RuleRequiredField("RuleRequiredField TransportDocument.Shipper", DefaultContexts.Save, TargetCriteria = "IsSpecial = 0")]
        [Appearance("TransportDocument Shipper Hide", Criteria = "IsSpecial = 1", Context = "DetailView", Visibility = ViewItemVisibility.Hide)]
        [DataSourceCriteria("ConsigneeType = 3")]
        public Consignee Shipper { get => _shipper; set => SetPropertyValue(nameof(Shipper), ref _shipper, value); }

        [RuleRequiredField("RuleRequiredField TransportDocument.SpecialShipper", DefaultContexts.Save, TargetCriteria = "IsSpecial = 1")]
        [Appearance("TransportDocument SpecialShipper Hide", Criteria = "IsSpecial = 0", Context = "DetailView", Visibility = ViewItemVisibility.Hide)]
        public string SpecialShipper { get => _specialShipper; set => SetPropertyValue(nameof(SpecialShipper), ref _specialShipper, value); }

        [VisibleInListView(false)]
        [NonPersistent]
        [ModelDefault("AllowEdit","False")]
        [Size(-1)]
        public string StatusMessage { get; set; }

        [Association("TransportDocument-Transactions"), DevExpress.Xpo.Aggregated]
        [Appearance("TransportDocument Transactions Hide", Criteria = "TransportDocumentType = 1", Context = "DetailView", Visibility = ViewItemVisibility.Hide)]
        [ImmediatePostData]
        public XPCollection<TransportDocumentTransaction> Transactions => GetCollection<TransportDocumentTransaction>(nameof(Transactions));

        [Association("TransportDocument-OtherTransactions"), DevExpress.Xpo.Aggregated]
        [Appearance("TransportDocument OtherTransactions Hide", Criteria = "TransportDocumentType = 0", Context = "DetailView", Visibility = ViewItemVisibility.Hide)]
        [ImmediatePostData]
        public XPCollection<TransportDocumentOtherTransaction> OtherTransactions => GetCollection<TransportDocumentOtherTransaction>(nameof(OtherTransactions));

        [Association("TransportDocument-Descriptions"), DevExpress.Xpo.Aggregated]
        public XPCollection<TransportDocumentDescription> Descriptions => GetCollection<TransportDocumentDescription>(nameof(Descriptions));
    }
}