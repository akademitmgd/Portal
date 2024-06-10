using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace iyibir.TMGD.Module.NonPersistentObjects
{
    [DomainComponent]
    [DefaultClassOptions]
    //[ImageName("BO_Unknown")]
    //[DefaultProperty("SampleProperty")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class NP_DispatchList : IXafEntityObject, IObjectSpaceLink, INotifyPropertyChanged
    {
        private IObjectSpace objectSpace;
        private int _referenceId;
        private string _ficheNo;
        private DateTime _createdOn;
        private string _docode;
        private string _clientCode;
        private string _clientName;
        private string _shipperCode;
        private string _vehiclePlate1;
        private string _vehiclePlate2;
        private string _driverTCKN1;
        private string _driverTCKN2;
        private string _driverPlate;
        private BindingList<NP_DispatchLine> _lines;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public NP_DispatchList()
        {
            Oid = Guid.NewGuid();
            Lines = new BindingList<NP_DispatchLine>();
        }

        [DevExpress.ExpressApp.Data.Key]
        [Browsable(false)]  // Hide the entity identifier from UI.
        public Guid Oid { get; set; }

        [ModelDefault("AllowEdit", "False")]
        [Browsable(false)]
        public int ReferenceId
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

        [ModelDefault("AllowEdit", "False")]
        public string FicheNo
        {
            get { return _ficheNo; }
            set
            {
                if (_ficheNo != value)
                {
                    _ficheNo = value;
                    OnPropertyChanged(nameof(FicheNo));
                }
            }
        }

        [ModelDefault("AllowEdit", "False")]
        public DateTime CreatedOn
        {
            get { return _createdOn; }
            set
            {
                if (_createdOn != value)
                {
                    _createdOn = value;
                    OnPropertyChanged(nameof(CreatedOn));
                }
            }
        }

        [ModelDefault("AllowEdit", "False")]
        public string Docode
        {
            get { return _docode; }
            set
            {
                if (_docode != value)
                {
                    _docode = value;
                    OnPropertyChanged(nameof(Docode));
                }
            }
        }

        [ModelDefault("AllowEdit", "False")]
        public string ClientCode
        {
            get { return _clientCode; }
            set
            {
                if (_clientCode != value)
                {
                    _clientCode = value;
                    OnPropertyChanged(nameof(ClientCode));
                }
            }
        }

        [ModelDefault("AllowEdit", "False")]
        public string ClientName
        {
            get { return _clientName; }
            set
            {
                if (_clientName != value)
                {
                    _clientName = value;
                    OnPropertyChanged(nameof(ClientName));
                }
            }
        }

        [ModelDefault("AllowEdit", "False")]
        public string ShipperCode
        {
            get { return _shipperCode; }
            set
            {
                if (_shipperCode != value)
                {
                    _shipperCode = value;
                    OnPropertyChanged(nameof(ShipperCode));
                }
            }
        }

        [ModelDefault("AllowEdit", "False")]
        public string VehiclePlate1
        {
            get { return _vehiclePlate1; }
            set
            {
                if (_vehiclePlate1 != value)
                {
                    _vehiclePlate1 = value;
                    OnPropertyChanged(nameof(VehiclePlate1));
                }
            }
        }

        [ModelDefault("AllowEdit", "False")]
        public string VehiclePlate2
        {
            get { return _vehiclePlate2; }
            set
            {
                if (_vehiclePlate2 != value)
                {
                    _vehiclePlate2 = value;
                    OnPropertyChanged(nameof(VehiclePlate2));
                }
            }
        }

        [ModelDefault("AllowEdit", "False")]
        public string DriverTCKN1
        {
            get { return _driverTCKN1; }
            set
            {
                if (_driverTCKN1 != value)
                {
                    _driverTCKN1 = value;
                    OnPropertyChanged(nameof(DriverTCKN1));
                }
            }
        }

        [ModelDefault("AllowEdit", "False")]
        public string DriverTCKN2
        {
            get { return _driverTCKN2; }
            set
            {
                if (_driverTCKN2 != value)
                {
                    _driverTCKN2 = value;
                    OnPropertyChanged(nameof(DriverTCKN2));
                }
            }
        }

        [ModelDefault("AllowEdit", "False")]
        public string DriverPlate
        {
            get { return _driverPlate; }
            set
            {
                if (_driverPlate != value)
                {
                    _driverPlate = value;
                    OnPropertyChanged(nameof(DriverPlate));
                }
            }
        }

        [ModelDefault("AllowEdit", "False")]
        public BindingList<NP_DispatchLine> Lines
        {
            get { return _lines; }
            set
            {
                if (_lines != value)
                {
                    _lines = value;
                    OnPropertyChanged(nameof(Lines));
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