using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Validation;
using iyibir.TMGD.Module.BusinessObjects;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Editors;

namespace iyibir.TMGD.Module.NonPersistentObjects
{
    [DomainComponent]
    [DefaultClassOptions]
    public class NP_VoyageNotificationTransaction : IXafEntityObject, IObjectSpaceLink, INotifyPropertyChanged
    {
        private IObjectSpace objectSpace;
        private VoyageNotificationTransactionStatus _status;
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

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public NP_VoyageNotificationTransaction()
        {
            Oid = Guid.NewGuid();
            HazardousTransportType = HazardousTransportType.Package;
            HazardousExemptionType = HazardousExemptionType.No;
        }

        [DevExpress.ExpressApp.Data.Key]
        [Browsable(false)]  // Hide the entity identifier from UI.
        public Guid Oid { get; set; }

        [Browsable(false)]
        public long ReferenceId
        {
            get { return _referenceId; }
            set
            {
                if (_referenceId != value)
                {
                    _referenceId = value;
                    OnPropertyChanged(nameof(ReferenceId));
                }
            }
        }

        [ModelDefault("AllowEdit","False")]
        public VoyageNotificationTransactionStatus Status
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged(nameof(Status));
                }
            }
        }

        [ImmediatePostData]
        public TransportTypeCode TransportTypeCode
        {
            get { return _transportTypeCode; }
            set
            {
                if (_transportTypeCode != value)
                {
                    _transportTypeCode = value;
                    OnPropertyChanged(nameof(TransportTypeCode));
                }
            }
        }

        [RuleRequiredField("RuleRequiredField for NP_VoyageNotificationTransaction.ConsignerVKN", DefaultContexts.Save)]
        [ModelDefault("AllowEdit", "False")]
        public string ConsignerVKN
        {
            get { return _consignerVKN; }
            set
            {
                if (_consignerVKN != value)
                {
                    _consignerVKN = value;
                    OnPropertyChanged(nameof(ConsignerVKN));
                }
            }
        }

        [ModelDefault("AllowEdit", "False")]
        public string ConsignerTitle
        {
            get { return _consignerTitle; }
            set
            {
                if (_consignerTitle != value)
                {
                    _consignerTitle = value;
                    OnPropertyChanged(nameof(ConsignerTitle));
                }
            }
        }

        [ModelDefault("AllowEdit", "False")]
        [RuleRequiredField("RuleRequiredField for NP_VoyageNotificationTransaction.ConsigneeVKN", DefaultContexts.Save)]
        public string ConsigneeVKN
        {
            get { return _consigneeVKN; }
            set
            {
                if (_consigneeVKN != value)
                {
                    _consigneeVKN = value;
                    OnPropertyChanged(nameof(ConsigneeVKN));
                }
            }
        }

        [ModelDefault("AllowEdit", "False")]
        public string ConsigneeTitle
        {
            get { return _consigneeTitle; }
            set
            {
                if (_consigneeTitle != value)
                {
                    _consigneeTitle = value;
                    OnPropertyChanged(nameof(ConsigneeTitle));
                }
            }
        }

        [ModelDefault("AllowEdit", "False")]
        public string ConsignerCountryCode
        {
            get { return _consignerCountryCode; }
            set
            {
                if (_consignerCountryCode != value)
                {
                    _consignerCountryCode = value;
                    OnPropertyChanged(nameof(ConsignerCountryCode));
                }
            }
        }

        [ModelDefault("AllowEdit", "False")]
        public string ConsignerCityMernisCode
        {
            get { return _consignerCityMernisCode; }
            set
            {
                if (_consignerCityMernisCode != value)
                {
                    _consignerCityMernisCode = value;
                    OnPropertyChanged(nameof(ConsignerCityMernisCode));
                }
            }
        }

        [ModelDefault("AllowEdit", "False")]
        public string ConsignerCountyMernisCode
        {
            get { return _consignerCountyMernisCode; }
            set
            {
                if (_consignerCountyMernisCode != value)
                {
                    _consignerCountyMernisCode = value;
                    OnPropertyChanged(nameof(ConsignerCountyMernisCode));
                }
            }
        }

        [ModelDefault("AllowEdit", "False")]
        public string ConsigneeCountryCode
        {
            get { return _consigneeCountryCode; }
            set
            {
                if (_consigneeCountryCode != value)
                {
                    _consigneeCountryCode = value;
                    OnPropertyChanged(nameof(ConsigneeCountryCode));
                }
            }
        }

        [ModelDefault("AllowEdit", "False")]
        public string ConsigneeCityMernisCode
        {
            get { return _consigneeCityMernisCode; }
            set
            {
                if (_consigneeCityMernisCode != value)
                {
                    _consigneeCityMernisCode = value;
                    OnPropertyChanged(nameof(ConsigneeCityMernisCode));
                }
            }
        }

        [ModelDefault("AllowEdit", "False")]
        public string ConsigneeCountyMernisCode
        {
            get { return _consigneeCountyMernisCode; }
            set
            {
                if (_consigneeCountyMernisCode != value)
                {
                    _consigneeCountyMernisCode = value;
                    OnPropertyChanged(nameof(ConsigneeCountyMernisCode));
                }
            }
        }

        [RuleRequiredField("RuleRequiredField for NP_VoyageNotificationTransaction.LadingDate", DefaultContexts.Save)]
        public DateTime LadingDate
        {
            get { return _ladingDate; }
            set
            {
                if (_ladingDate != value)
                {
                    _ladingDate = value;
                    OnPropertyChanged(nameof(LadingDate));
                }
            }
        }

        [RuleRequiredField("RuleRequiredField for NP_VoyageNotificationTransaction.LadingTime", DefaultContexts.Save)]
        public TimeSpan LadingTime
        {
            get { return _ladingTime; }
            set
            {
                if (_ladingTime != value)
                {
                    _ladingTime = value;
                    OnPropertyChanged(nameof(LadingTime));
                }
            }
        }

        [RuleRequiredField("RuleRequiredField for NP_VoyageNotificationTransaction.PouringDate", DefaultContexts.Save)]
        public DateTime PouringDate
        {
            get { return _pouringDate; }
            set
            {
                if (_pouringDate != value)
                {
                    _pouringDate = value;
                    OnPropertyChanged(nameof(PouringDate));
                }
            }
        }

        [RuleRequiredField("RuleRequiredField for NP_VoyageNotificationTransaction.PouringTime", DefaultContexts.Save)]
        public TimeSpan PouringTime
        {
            get { return _pouringTime; }
            set
            {
                if (_pouringTime != value)
                {
                    _pouringTime = value;
                    OnPropertyChanged(nameof(PouringTime));
                }
            }
        }

        [RuleRequiredField("RuleRequiredField for NP_VoyageNotificationTransaction.LoadType", DefaultContexts.Save)]
        public LoadType LoadType
        {
            get { return _loadType; }
            set
            {
                if (_loadType != value)
                {
                    _loadType = value;
                    OnPropertyChanged(nameof(LoadType));
                }
            }
        }
        public string LoadOtherDescription
        {
            get { return _loadOtherDescription; }
            set
            {
                if (_loadOtherDescription != value)
                {
                    _loadOtherDescription = value;
                    OnPropertyChanged(nameof(LoadOtherDescription));
                }
            }
        }

        [Appearance("NP_VoyageNotificationTransaction HazardousUnit Hide", Criteria = "TransportTypeCode = 2", Context = "DetailView", Visibility = ViewItemVisibility.Hide)]
        public HazardousUnit HazardousUnit
        {
            get { return _hazardousUnit; }
            set
            {
                if (_hazardousUnit != value)
                {
                    _hazardousUnit = value;
                    OnPropertyChanged(nameof(HazardousUnit));
                }
            }
        }

        [Appearance("NP_VoyageNotificationTransaction OtherUnit Hide", Criteria = "TransportTypeCode = 1", Context = "DetailView", Visibility = ViewItemVisibility.Hide)]
        public OtherUnit OtherUnit
        {
            get { return _otherUnit; }
            set
            {
                if (_otherUnit != value)
                {
                    _otherUnit = value;
                    OnPropertyChanged(nameof(OtherUnit));
                }
            }
        }

        [RuleRequiredField("RuleRequiredField for NP_VoyageNotificationTransaction.LoadQuantity", DefaultContexts.Save)]
        public double LoadQuantity
        {
            get { return _loadQuantity; }
            set
            {
                if (_loadQuantity != value)
                {
                    _loadQuantity = value;
                    OnPropertyChanged(nameof(LoadQuantity));
                }
            }
        }
        public string FirmLoadNumber
        {
            get { return _firmLoadNumber; }
            set
            {
                if (_firmLoadNumber != value)
                {
                    _firmLoadNumber = value;
                    OnPropertyChanged(nameof(FirmLoadNumber));
                }
            }
        }
        public HazardousTransportType HazardousTransportType
        {
            get { return _hazardousTrasportType; }
            set
            {
                if (_hazardousTrasportType != value)
                {
                    _hazardousTrasportType = value;
                    OnPropertyChanged(nameof(HazardousTransportType));
                }
            }
        }

        [RuleRequiredField("RuleRequiredField for NP_VoyageNotificationTransaction.UNId", DefaultContexts.Save)]
        public string UNId
        {
            get { return _unId; }
            set
            {
                if (_unId != value)
                {
                    _unId = value;
                    OnPropertyChanged(nameof(UNId));
                }
            }
        }
        public HazardousExemptionType HazardousExemptionType
        {
            get { return _hazardousExemptionType; }
            set
            {
                if (_hazardousExemptionType != value)
                {
                    _hazardousExemptionType = value;
                    OnPropertyChanged(nameof(HazardousExemptionType));
                }
            }
        }

        #region IXafEntityObject members (see https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppIXafEntityObjecttopic.aspx)
        void IXafEntityObject.OnCreated()
        {
            // Place the entity initialization code here.
            // You can initialize reference properties using Object Space methods; e.g.:
            // this.Address = objectSpace.CreateObject<Address>();
        }
        void IXafEntityObject.OnLoaded()
        {
            // Place the code that is executed each time the entity is loaded here.
        }
        void IXafEntityObject.OnSaving()
        {
            // Place the code that is executed each time the entity is saved here.
        }
        #endregion

        #region IObjectSpaceLink members (see https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppIObjectSpaceLinktopic.aspx)
        // Use the Object Space to access other entities from IXafEntityObject methods (see https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113707.aspx).
        IObjectSpace IObjectSpaceLink.ObjectSpace
        {
            get { return objectSpace; }
            set { objectSpace = value; }
        }
        #endregion

        #region INotifyPropertyChanged members (see http://msdn.microsoft.com/en-us/library/system.componentmodel.inotifypropertychanged(v=vs.110).aspx)
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}