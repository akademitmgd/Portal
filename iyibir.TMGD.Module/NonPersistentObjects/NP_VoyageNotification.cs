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

namespace iyibir.TMGD.Module.NonPersistentObjects
{
    [DomainComponent]
    [DefaultClassOptions]
    public class NP_VoyageNotification : IXafEntityObject, IObjectSpaceLink, INotifyPropertyChanged
    {
        private IObjectSpace objectSpace;
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
        private BindingList<NP_VoyageNotificationTransaction> _transations;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public NP_VoyageNotification()
        {
            Oid = Guid.NewGuid();
            Transations = new BindingList<NP_VoyageNotificationTransaction>();
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
        public DateTime UpdatedDate
        {
            get { return _updatedDate; }
            set
            {
                if (_updatedDate != value)
                {
                    _updatedDate = value;
                    OnPropertyChanged(nameof(UpdatedDate));
                }
            }
        }

        [ModelDefault("AllowEdit", "False")]
        public VoyageNotificationStatus Status
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

        [RuleRequiredField("RuleRequiredField for NP_VoyageNotificationTransaction.StartDate", DefaultContexts.Save)]
        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                if (_startDate != value)
                {
                    _startDate = value;
                    OnPropertyChanged(nameof(StartDate));
                }
            }
        }

        [RuleRequiredField("RuleRequiredField for NP_VoyageNotificationTransaction.StartTime", DefaultContexts.Save)]
        public TimeSpan StartTime
        {
            get { return _startTime; }
            set
            {
                if (_startTime != value)
                {
                    _startTime = value;
                    OnPropertyChanged(nameof(StartTime));
                }
            }
        }

        [RuleRequiredField("RuleRequiredField for NP_VoyageNotificationTransaction.EndDate", DefaultContexts.Save)]
        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                if (_endDate != value)
                {
                    _endDate = value;
                    OnPropertyChanged(nameof(EndDate));
                }
            }
        }

        [RuleRequiredField("RuleRequiredField for NP_VoyageNotificationTransaction.EndTime", DefaultContexts.Save)]
        public TimeSpan EndTime
        {
            get { return _endTime; }
            set
            {
                if (_endTime != value)
                {
                    _endTime = value;
                    OnPropertyChanged(nameof(EndTime));
                }
            }
        }

        public string FirmVoyageNumber
        {
            get { return _firmVoyageNumber; }
            set
            {
                if (_firmVoyageNumber != value)
                {
                    _firmVoyageNumber = value;
                    OnPropertyChanged(nameof(FirmVoyageNumber));
                }
            }
        }

        [RuleRequiredField("RuleRequiredField for NP_VoyageNotificationTransaction.Plate1", DefaultContexts.Save)]
        public string Plate1
        {
            get { return _plate1; }
            set
            {
                if (_plate1 != value)
                {
                    _plate1 = value;
                    OnPropertyChanged(nameof(Plate1));
                }
            }
        }

        public string Plate2
        {
            get { return _plate2; }
            set
            {
                if (_plate2 != value)
                {
                    _plate2 = value;
                    OnPropertyChanged(nameof(Plate2));
                }
            }
        }

        public string Driver1TCKN
        {
            get { return _driver1TCKN; }
            set
            {
                if (_driver1TCKN != value)
                {
                    _driver1TCKN = value;
                    OnPropertyChanged(nameof(Driver1TCKN));
                }
            }
        }

        public string Driver2TCKN
        {
            get { return _driver2TCKN; }
            set
            {
                if (_driver2TCKN != value)
                {
                    _driver2TCKN = value;
                    OnPropertyChanged(nameof(Driver2TCKN));
                }
            }
        }

        public BindingList<NP_VoyageNotificationTransaction> Transations
        {
            get { return _transations; }
            set
            {
                if (_transations != value)
                {
                    _transations = value;
                    OnPropertyChanged(nameof(Transations));
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