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
    public class NP_VoyageNotificationTransactionCancelled : IXafEntityObject, IObjectSpaceLink, INotifyPropertyChanged
    {
        private IObjectSpace objectSpace;
        private long _referenceId;
        private string _cancelledDescription;
        private VoyageNotificationTransactionCancelledType _cancelledType;
        private DateTime _cancelledDate;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public NP_VoyageNotificationTransactionCancelled()
        {
            Oid = Guid.NewGuid();
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

        [RuleRequiredField("RuleRequiredField for NP_VoyageNotificationTransactionCancelled.CancelledDate", DefaultContexts.Save)]
        public DateTime CancelledDate
        {
            get { return _cancelledDate; }
            set
            {
                if (_cancelledDate != value)
                {
                    _cancelledDate = value;
                    OnPropertyChanged(nameof(CancelledDate));
                }
            }
        }

        public VoyageNotificationTransactionCancelledType CancelledType
        {
            get { return _cancelledType; }
            set
            {
                if (_cancelledType != value)
                {
                    _cancelledType = value;
                    OnPropertyChanged(nameof(CancelledType));
                }
            }
        }

        public string CancelledDescription
        {
            get { return _cancelledDescription; }
            set
            {
                if (_cancelledDescription != value)
                {
                    _cancelledDescription = value;
                    OnPropertyChanged(nameof(CancelledDescription));
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