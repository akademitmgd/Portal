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
    [Appearance("VoyageNotificationTransaction Delete", AppearanceItemType = "Action", TargetItems = "Delete", Visibility = ViewItemVisibility.Hide)]
    [Appearance("VoyageNotificationTransaction New", AppearanceItemType = "Action", TargetItems = "New", Visibility = ViewItemVisibility.Hide)]
    [Appearance("VoyageNotificationTransaction  Edit", Criteria = "Status = 1", Context = "DetailView", TargetItems = "*", Enabled = false)]
    [NavigationItem(false)]
    public class VoyageNotificationTransaction : BaseObject
    {
        private TransportDocumentOtherTransaction _otherTransaction;
        private TransportDocumentTransaction _transaction;
        private VoyageNotificationTransactionStatus _status;
        private VoyageNotification _voyageNotification;
        private TransportTypeCode _transportTypeCode;
        private string _consignerVKN;
        private string _consignerTitle;
        private string _consigneeVKN;
        private string _consigneeTitle;
        private string _consignerCountryCode;
        private string _consignerCityMernisCode;
        private string _consignerCountyMernisCode;
        private string _consigneeCountryCode;
        private string _consigneeCityMernisCode;
        private string _consigneeCountyMernisCode;
        private DateTime _ladingDate;
        private TimeSpan _ladingTime;
        private DateTime _pouringDate;
        private TimeSpan _pouringTime;
        private LoadType _loadType;
        private string _loadOtherDescription;
        private HazardousUnit _hazardousUnit;
        private OtherUnit _otherUnit;
        private double _loadQuantity;
        private string _firmLoadNumber;
        private HazardousTransportType _hazardousTrasportType;
        private string _unId;
        private HazardousExemptionType _hazardousExemptionType;
        private long _referenceId;
        private VoyageNotificationTransactionCancelledType _cancelledType;
        private string _cancelledDescription;
        private DateTime _cancelledDate;
        private DateTime _activatedDate;
        private DateTime _updatedDate;
        private int _lineNumber;


        public VoyageNotificationTransaction(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (Session.IsNewObject(this))
            {
                this.TransportTypeCode = TransportTypeCode.Hazardous;
                this.HazardousExemptionType = HazardousExemptionType.No;
                this.HazardousTransportType = HazardousTransportType.Package;
            }
        }

        protected override void OnSaving()
        {
            base.OnSaving();
            if (!Session.IsObjectMarkedDeleted(this))
            {
                if (this.TransportTypeCode == TransportTypeCode.Hazardous)
                {
                    if (this.HazardousUnit == HazardousUnit.NA)
                        throw new UserFriendlyException("Lütfen tehlikeli madde yük birimini seçiniz..");
                }
                else if (this.TransportTypeCode == TransportTypeCode.Normal)
                {
                    if (this.OtherUnit == OtherUnit.NA)
                        throw new UserFriendlyException("Lütfen yük birimini seçiniz..");
                }

                if (this.Status == VoyageNotificationTransactionStatus.Cancelled)
                {
                    if (this.CancelledType == VoyageNotificationTransactionCancelledType.NA)
                        throw new UserFriendlyException("Lütfen İptal Nedeni Belirtiniz..");
                }
            }
        }

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            switch (propertyName)
            {
                case "VoyageNotification":

                    //LineNumber = VoyageNotification != null ? VoyageNotification.Transactions.Count + 1 : 0;

                    this.RaisePropertyChangedEvent("LineNumber");

                    break;
                case "TransportTypeCode":
                    switch (this.TransportTypeCode)
                    {
                        case TransportTypeCode.NA:
                            break;
                        case TransportTypeCode.Hazardous:
                            LoadType = Session.FindObject<LoadType>(CriteriaOperator.Parse("LoadOfTheType = ?", LoadOfTheType.Hazargoods));
                            this.RaisePropertyChangedEvent("LoadType");
                            break;
                        case TransportTypeCode.Normal:
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        [Browsable(false)]
        public int LineNumber { get => _lineNumber; set => SetPropertyValue(nameof(LineNumber), ref _lineNumber, value); }

        [Browsable(false)]
        public long ReferenceId { get => _referenceId; set => SetPropertyValue(nameof(ReferenceId), ref _referenceId, value); }

        [Browsable(false)]
        public TransportDocumentOtherTransaction OtherTransaction { get => _otherTransaction; set => SetPropertyValue(nameof(OtherTransaction), ref _otherTransaction, value); }

        [Browsable(false)]
        public TransportDocumentTransaction Transaction { get => _transaction; set => SetPropertyValue(nameof(Transaction), ref _transaction, value); }

        [ModelDefault("AllowEdit", "False")]
        public VoyageNotificationTransactionStatus Status { get => _status; set => SetPropertyValue(nameof(Status), ref _status, value); }

        [Association("VoyageNotification-Transactions")]
        [ImmediatePostData]
        public VoyageNotification VoyageNotification { get => _voyageNotification; set => SetPropertyValue(nameof(VoyageNotification), ref _voyageNotification, value); }

        [RuleRequiredField("RuleRequiredField for VoyageNotificationTransaction.TransportTypeCode", DefaultContexts.Save)]
        [ImmediatePostData]
        public TransportTypeCode TransportTypeCode { get => _transportTypeCode; set => SetPropertyValue(nameof(TransportTypeCode), ref _transportTypeCode, value); }

        [RuleRequiredField("RuleRequiredField for VoyageNotificationTransaction.ConsignerVKN", DefaultContexts.Save, TargetCriteria = "TransportTypeCode = 1")]
        [ModelDefault("AllowEdit", "False")]
        public string ConsignerVKN { get => _consignerVKN; set => SetPropertyValue(nameof(ConsignerVKN), ref _consignerVKN, value); }

        [RuleRequiredField("RuleRequiredField for VoyageNotificationTransaction.ConsignerTitle", DefaultContexts.Save)]
        [ModelDefault("AllowEdit", "False")]
        public string ConsignerTitle { get => _consignerTitle; set => SetPropertyValue(nameof(ConsignerTitle), ref _consignerTitle, value); }

        [RuleRequiredField("RuleRequiredField for VoyageNotificationTransaction.ConsigneeVKN", DefaultContexts.Save, TargetCriteria = "TransportTypeCode = 1")]
        [ModelDefault("AllowEdit", "False")]
        public string ConsigneeVKN { get => _consigneeVKN; set => SetPropertyValue(nameof(ConsigneeVKN), ref _consigneeVKN, value); }

        [RuleRequiredField("RuleRequiredField for VoyageNotificationTransaction.ConsigneeTitle", DefaultContexts.Save)]
        [ModelDefault("AllowEdit", "False")]
        public string ConsigneeTitle { get => _consigneeTitle; set => SetPropertyValue(nameof(ConsigneeTitle), ref _consigneeTitle, value); }

        [RuleRequiredField("RuleRequiredField for VoyageNotificationTransaction.ConsignerCountryCode", DefaultContexts.Save)]
        [ModelDefault("AllowEdit", "False")]
        public string ConsignerCountryCode { get => _consignerCountryCode; set => SetPropertyValue(nameof(ConsignerCountryCode), ref _consignerCountryCode, value); }

        [RuleRequiredField("RuleRequiredField for VoyageNotificationTransaction.ConsignerCityMernisCode", DefaultContexts.Save)]
        [ModelDefault("AllowEdit", "False")]
        public string ConsignerCityMernisCode { get => _consignerCityMernisCode; set => SetPropertyValue(nameof(ConsignerCityMernisCode), ref _consignerCityMernisCode, value); }

        [RuleRequiredField("RuleRequiredField for VoyageNotificationTransaction.ConsignerCountyMernisCode", DefaultContexts.Save)]
        [ModelDefault("AllowEdit", "False")]
        public string ConsignerCountyMernisCode { get => _consignerCountyMernisCode; set => SetPropertyValue(nameof(ConsignerCountyMernisCode), ref _consignerCountyMernisCode, value); }

        [RuleRequiredField("RuleRequiredField for VoyageNotificationTransaction.ConsigneeCountryCode", DefaultContexts.Save)]
        [ModelDefault("AllowEdit", "False")]
        public string ConsigneeCountryCode { get => _consigneeCountryCode; set => SetPropertyValue(nameof(ConsigneeCountryCode), ref _consigneeCountryCode, value); }

        [RuleRequiredField("RuleRequiredField for VoyageNotificationTransaction.ConsigneeCityMernisCode", DefaultContexts.Save)]
        [ModelDefault("AllowEdit", "False")]
        public string ConsigneeCityMernisCode { get => _consigneeCityMernisCode; set => SetPropertyValue(nameof(ConsigneeCityMernisCode), ref _consigneeCityMernisCode, value); }

        [RuleRequiredField("RuleRequiredField for VoyageNotificationTransaction.ConsigneeCountyMernisCode", DefaultContexts.Save)]
        [ModelDefault("AllowEdit", "False")]
        public string ConsigneeCountyMernisCode { get => _consigneeCountyMernisCode; set => SetPropertyValue(nameof(ConsigneeCountyMernisCode), ref _consigneeCountyMernisCode, value); }

        [RuleRequiredField("RuleRequiredField for VoyageNotificationTransaction.LadingDate", DefaultContexts.Save)]
        public DateTime LadingDate { get => _ladingDate = Session.IsNewObject(this) ? this.VoyageNotification.StartDate : _ladingDate; set => SetPropertyValue(nameof(LadingDate), ref _ladingDate, value); }

        [RuleRequiredField("RuleRequiredField for VoyageNotificationTransaction.LadingTime", DefaultContexts.Save)]
        public TimeSpan LadingTime { get => _ladingTime = Session.IsNewObject(this) ? this.VoyageNotification.StartTime : _ladingTime; set => SetPropertyValue(nameof(LadingTime), ref _ladingTime, value); }

        [RuleRequiredField("RuleRequiredField for VoyageNotificationTransaction.PouringDate", DefaultContexts.Save)]
        public DateTime PouringDate { get => _pouringDate = Session.IsNewObject(this) ? this.VoyageNotification.EndDate : _pouringDate; set => SetPropertyValue(nameof(PouringDate), ref _pouringDate, value); }

        [RuleRequiredField("RuleRequiredField for VoyageNotificationTransaction.PouringTime", DefaultContexts.Save)]
        public TimeSpan PouringTime { get => _pouringTime = Session.IsNewObject(this) ? this.VoyageNotification.EndTime : _pouringTime; set => SetPropertyValue(nameof(PouringTime), ref _pouringTime, value); }

        [RuleRequiredField("RuleRequiredField for VoyageNotificationTransaction.LoadType", DefaultContexts.Save)]
        public LoadType LoadType { get => _loadType; set => SetPropertyValue(nameof(LoadType), ref _loadType, value); }
        public string LoadOtherDescription { get => _loadOtherDescription; set => SetPropertyValue(nameof(LoadOtherDescription), ref _loadOtherDescription, value); }

        [RuleRequiredField("RuleRequiredField for VoyageNotificationTransaction.HazardousUnit", DefaultContexts.Save, TargetCriteria = "TransportTypeCode = 1")]
        [Appearance("VoyageNotificationTransaction.HazardousUnit Edit", Criteria = "TransportTypeCode != 1", Context = "DetailView", TargetItems = "*", Visibility = ViewItemVisibility.Hide)]
        public HazardousUnit HazardousUnit { get => _hazardousUnit; set => SetPropertyValue(nameof(HazardousUnit), ref _hazardousUnit, value); }

        [RuleRequiredField("RuleRequiredField for VoyageNotificationTransaction.OtherUnit", DefaultContexts.Save, TargetCriteria = "TransportTypeCode = 2")]
        [Appearance("VoyageNotificationTransaction.OtherUnit Edit", Criteria = "TransportTypeCode != 2", Context = "DetailView", TargetItems = "*", Visibility = ViewItemVisibility.Hide)]
        public OtherUnit OtherUnit { get => _otherUnit; set => SetPropertyValue(nameof(OtherUnit), ref _otherUnit, value); }

        [RuleRequiredField("RuleRequiredField for VoyageNotificationTransaction.LoadQuantity", DefaultContexts.Save)]
        public double LoadQuantity { get => _loadQuantity; set => SetPropertyValue(nameof(LoadQuantity), ref _loadQuantity, value); }

        public string FirmLoadNumber { get => _firmLoadNumber; set => SetPropertyValue(nameof(FirmLoadNumber), ref _firmLoadNumber, value); }

        [RuleRequiredField("RuleRequiredField for VoyageNotificationTransaction.HazardousTransportType", DefaultContexts.Save, TargetCriteria = "TransportTypeCode = 1")]
        public HazardousTransportType HazardousTransportType { get => _hazardousTrasportType; set => SetPropertyValue(nameof(HazardousTransportType), ref _hazardousTrasportType, value); }

        [RuleRequiredField("RuleRequiredField for VoyageNotificationTransaction.UnId", DefaultContexts.Save, TargetCriteria = "TransportTypeCode = 1")]
        public string UnId { get => _unId; set => SetPropertyValue(nameof(UnId), ref _unId, value); }
        public HazardousExemptionType HazardousExemptionType { get => _hazardousExemptionType; set => SetPropertyValue(nameof(HazardousExemptionType), ref _hazardousExemptionType, value); }

        [ModelDefault("AllowEdit", "False")]
        public VoyageNotificationTransactionCancelledType CancelledType { get => _cancelledType; set => SetPropertyValue(nameof(CancelledType), ref _cancelledType, value); }

        [ModelDefault("AllowEdit", "False")]
        public string CancelledDescription { get => _cancelledDescription; set => SetPropertyValue(nameof(CancelledDescription), ref _cancelledDescription, value); }

        [ModelDefault("AllowEdit", "False")]
        public DateTime CancelledDate { get => _cancelledDate; set => SetPropertyValue(nameof(CancelledDate), ref _cancelledDate, value); }

        [ModelDefault("AllowEdit", "False")]
        public DateTime ActivatedDate { get => _activatedDate; set => SetPropertyValue(nameof(ActivatedDate), ref _activatedDate, value); }

        [ModelDefault("AllowEdit", "False")]
        public DateTime UpdatedDate { get => _updatedDate; set => SetPropertyValue(nameof(UpdatedDate), ref _updatedDate, value); }
    }
}