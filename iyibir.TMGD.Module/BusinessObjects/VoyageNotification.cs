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
    [NavigationItem("DocumentManagement")]
    [Appearance("VoyageNotification Delete", AppearanceItemType = "Action", TargetItems = "Delete", Visibility = ViewItemVisibility.Hide)]
    [Appearance("VoyageNotification New", AppearanceItemType = "Action", TargetItems = "New", Visibility = ViewItemVisibility.Hide)]
    [Appearance("VoyageNotification  Edit", Criteria = "Status = 1", Context = "DetailView", TargetItems = "TransportDocument,StartDate,StartTime,EndDate,EndTime,FirmVoyageNumber,Plate1,Plate2,Driver1TCKN,Driver2TCKN,UpdatedDate,ActivatedDate,CancelledType,CancelledDescription,CancelledDate", Enabled = false)]
    public class VoyageNotification : BaseObject
    {
        private TransportDocument _transportDocument;
        private long _referenceId;
        private VoyageNotificationStatus _status;
        private DateTime _startDate;
        private TimeSpan _startTime;
        private DateTime _endDate;
        private TimeSpan _endTime;
        private string _firmVoyageNumber;
        private string _plate1;
        private string _plate2;
        private string _driver1TCKN;
        private string _driver2TCKN;
        private DateTime _updatedDate;
        private DateTime _activatedDate;
        private VoyageNotificationTransactionCancelledType _cancelledType;
        private string _cancelledDescription;
        private DateTime _cancelledDate;
        private Employee _owner;
        private long _transportReferenceId;

        public VoyageNotification(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (Session.IsNewObject(this))
            {
                Owner = Session.GetObjectByKey<Employee>(SecuritySystem.CurrentUserId);
            }


        }

        protected override void OnSaving()
        {
            base.OnSaving();
            if (Session.IsNewObject(this))
            {


            }
        }

        [NonPersistent]
        [VisibleInDetailView(false)]
        public string Consignee { get {

                if (!IsLoading && !IsSaving)
                    return this.Transactions?.FirstOrDefault()?.ConsigneeTitle ?? string.Empty;
                else
                    return string.Empty;
            } }


        [ModelDefault("AllowEdit", "False")]
        public Employee Owner { get => _owner; set => SetPropertyValue(nameof(Owner), ref _owner, value); }

        [Browsable(false)]
        public long ReferenceId { get => _referenceId; set => SetPropertyValue(nameof(ReferenceId), ref _referenceId, value); }

        [Browsable(false)]
        public TransportDocument TransportDocument { get => _transportDocument; set => SetPropertyValue(nameof(TransportDocument), ref _transportDocument, value); }

        [ModelDefault("AllowEdit", "False")]
        public DateTime UpdatedDate { get => _updatedDate; set => SetPropertyValue(nameof(UpdatedDate), ref _updatedDate, value); }

        [ModelDefault("AllowEdit", "False")]
        public DateTime ActivatedDate { get => _activatedDate; set => SetPropertyValue(nameof(ActivatedDate), ref _activatedDate, value); }

        [ModelDefault("AllowEdit", "False")]
        public VoyageNotificationStatus Status { get => _status; set => SetPropertyValue(nameof(Status), ref _status, value); }

        [RuleRequiredField("RuleRequiredField for VoyageNotification.StartDate", DefaultContexts.Save)]
        public DateTime StartDate { get => _startDate; set => SetPropertyValue(nameof(StartDate), ref _startDate, value); }

        [RuleRequiredField("RuleRequiredField for VoyageNotification.StartTime", DefaultContexts.Save)]
        public TimeSpan StartTime { get => _startTime; set => SetPropertyValue(nameof(StartTime), ref _startTime, value); }

        [RuleRequiredField("RuleRequiredField for VoyageNotification.EndDate", DefaultContexts.Save)]
        public DateTime EndDate { get => _endDate; set => SetPropertyValue(nameof(EndDate), ref _endDate, value); }

        [RuleRequiredField("RuleRequiredField for VoyageNotification.EndTime", DefaultContexts.Save)]
        public TimeSpan EndTime { get => _endTime; set => SetPropertyValue(nameof(EndTime), ref _endTime, value); }
        public string FirmVoyageNumber { get => _firmVoyageNumber; set => SetPropertyValue(nameof(FirmVoyageNumber), ref _firmVoyageNumber, value); }

        [RuleRequiredField("RuleRequiredField for VoyageNotification.Plate1", DefaultContexts.Save)]
        public string Plate1 { get => _plate1; set => SetPropertyValue(nameof(Plate1), ref _plate1, value); }
        public string Plate2 { get => _plate2; set => SetPropertyValue(nameof(Plate2), ref _plate2, value); }

        [RuleRequiredField("RuleRequiredField for VoyageNotification.Driver1TCKN", DefaultContexts.Save)]
        public string Driver1TCKN { get => _driver1TCKN; set => SetPropertyValue(nameof(Driver1TCKN), ref _driver1TCKN, value); }
        public string Driver2TCKN { get => _driver2TCKN; set => SetPropertyValue(nameof(Driver2TCKN), ref _driver2TCKN, value); }

        [ModelDefault("AllowEdit", "False")]
        public VoyageNotificationTransactionCancelledType CancelledType { get => _cancelledType; set => SetPropertyValue(nameof(CancelledType), ref _cancelledType, value); }

        [ModelDefault("AllowEdit", "False")]
        public string CancelledDescription { get => _cancelledDescription; set => SetPropertyValue(nameof(CancelledDescription), ref _cancelledDescription, value); }

        [ModelDefault("AllowEdit", "False")]
        public DateTime CancelledDate { get => _cancelledDate; set => SetPropertyValue(nameof(CancelledDate), ref _cancelledDate, value); }

        [ModelDefault("AllowEdit", "False"),XafDisplayName("Sefer Id")]
        public long TransportReferenceId { get => _transportReferenceId; set => SetPropertyValue(nameof(TransportReferenceId), ref _transportReferenceId, value); }

        [Association("VoyageNotification-Transactions"), DevExpress.Xpo.Aggregated]
        public XPCollection<VoyageNotificationTransaction> Transactions { get => GetCollection<VoyageNotificationTransaction>(nameof(Transactions)); }

        [Association("VoyageNotification-Histories"), DevExpress.Xpo.Aggregated]
        public XPCollection<VoyageNotificationHistory> Histories { get => GetCollection<VoyageNotificationHistory>(nameof(Histories)); }
    }
}