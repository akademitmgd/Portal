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
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Editors;

namespace iyibir.TMGD.Module.NonPersistentObjects
{
    [DomainComponent]
    [DefaultClassOptions]
    [Appearance("NP_SeferDetay Delete", AppearanceItemType = "Action", TargetItems = "Delete", Visibility = ViewItemVisibility.Hide)]
    [Appearance("NP_SeferDetay Edit", AppearanceItemType = "Action", TargetItems = "Edit", Visibility = ViewItemVisibility.Hide)]
    [Appearance("NP_SeferDetay New", AppearanceItemType = "Action", TargetItems = "New", Visibility = ViewItemVisibility.Hide)]
    public class NP_SeferDetay : IXafEntityObject, IObjectSpaceLink, INotifyPropertyChanged
    {
        private IObjectSpace objectSpace;
        private string _durum;
        private string _firmaSeferNo;
        private string _plaka1;
        private string _plaka2;
        private string _sofor1TCKNo;
        private string _sofor2TCKNo;
        private string _iptalTurKodu;
        private string _iptalTurAciklama;
        private string _iptalAciklama;
        private string _bildirimTarihi;
        private string _sonGuncellemeTarihi;
        private string _iptalTarihi;
        private string _baslangicTarihi;
        private string _baslangicSaati;
        private string _bitisTarihi;
        private string _bitisSaati;
        private BindingList<NP_SeferDetayList> _list;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public NP_SeferDetay()
        {
            Oid = Guid.NewGuid();
            List = new BindingList<NP_SeferDetayList>();
        }

        [DevExpress.ExpressApp.Data.Key]
        [Browsable(false)]  // Hide the entity identifier from UI.
        public Guid Oid { get; set; }

        [ModelDefault("AllowEdit", "False")]
        public string Durum
        {
            get { return _durum; }
            set
            {
                if (_durum != value)
                {
                    _durum = value;
                    OnPropertyChanged(nameof(Durum));
                }
            }
        }

        [ModelDefault("AllowEdit", "False")]
        public string FirmaSeferNo
        {
            get { return _firmaSeferNo; }
            set
            {
                if (_firmaSeferNo != value)
                {
                    _firmaSeferNo = value;
                    OnPropertyChanged(nameof(FirmaSeferNo));
                }
            }
        }

        [ModelDefault("AllowEdit", "False")]
        public string Plaka1
        {
            get { return _plaka1; }
            set
            {
                if (_plaka1 != value)
                {
                    _plaka1 = value;
                    OnPropertyChanged(nameof(Plaka1));
                }
            }
        }

        [ModelDefault("AllowEdit", "False")]
        public string Plaka2
        {
            get { return _plaka2; }
            set
            {
                if (_plaka2 != value)
                {
                    _plaka2 = value;
                    OnPropertyChanged(nameof(Plaka2));
                }
            }
        }

        [ModelDefault("AllowEdit", "False")]
        public string Sofor1TCKNo
        {
            get { return _sofor1TCKNo; }
            set
            {
                if (_sofor1TCKNo != value)
                {
                    _sofor1TCKNo = value;
                    OnPropertyChanged(nameof(Sofor1TCKNo));
                }
            }
        }

        [ModelDefault("AllowEdit", "False")]
        public string Sofor2TCKNo
        {
            get { return _sofor2TCKNo; }
            set
            {
                if (_sofor2TCKNo != value)
                {
                    _sofor2TCKNo = value;
                    OnPropertyChanged(nameof(Sofor2TCKNo));
                }
            }
        }

        [ModelDefault("AllowEdit", "False")]
        public string IptalTurKodu
        {
            get { return _iptalTurKodu; }
            set
            {
                if (_iptalTurKodu != value)
                {
                    _iptalTurKodu = value;
                    OnPropertyChanged(nameof(IptalTurKodu));
                }
            }
        }

        [ModelDefault("AllowEdit", "False")]
        public string IptalTurAciklama
        {
            get { return _iptalTurAciklama; }
            set
            {
                if (_iptalTurAciklama != value)
                {
                    _iptalTurAciklama = value;
                    OnPropertyChanged(nameof(IptalTurAciklama));
                }
            }
        }

        [ModelDefault("AllowEdit", "False")]
        public string IptalAciklama
        {
            get { return _iptalAciklama; }
            set
            {
                if (_iptalAciklama != value)
                {
                    _iptalAciklama = value;
                    OnPropertyChanged(nameof(IptalAciklama));
                }
            }
        }

        [ModelDefault("AllowEdit", "False")]
        public string BildirimTarihi
        {
            get { return _bildirimTarihi; }
            set
            {
                if (_bildirimTarihi != value)
                {
                    _bildirimTarihi = value;
                    OnPropertyChanged(nameof(BildirimTarihi));
                }
            }
        }

        [ModelDefault("AllowEdit", "False")]
        public string SonGuncellemeTarihi
        {
            get { return _sonGuncellemeTarihi; }
            set
            {
                if (_sonGuncellemeTarihi != value)
                {
                    _sonGuncellemeTarihi = value;
                    OnPropertyChanged(nameof(SonGuncellemeTarihi));
                }
            }
        }

        [ModelDefault("AllowEdit", "False")]
        public string IptalTarihi
        {
            get { return _iptalTarihi; }
            set
            {
                if (_iptalTarihi != value)
                {
                    _iptalTarihi = value;
                    OnPropertyChanged(nameof(IptalTarihi));
                }
            }
        }

        [ModelDefault("AllowEdit", "False")]
        public string BaslangicTarihi
        {
            get { return _baslangicTarihi; }
            set
            {
                if (_baslangicTarihi != value)
                {
                    _baslangicTarihi = value;
                    OnPropertyChanged(nameof(BaslangicTarihi));
                }
            }
        }

        [ModelDefault("AllowEdit", "False")]
        public string BaslangicSaati
        {
            get { return _baslangicSaati; }
            set
            {
                if (_baslangicSaati != value)
                {
                    _baslangicSaati = value;
                    OnPropertyChanged(nameof(BaslangicSaati));
                }
            }
        }

        [ModelDefault("AllowEdit", "False")]
        public string BitisTarihi
        {
            get { return _bitisTarihi; }
            set
            {
                if (_bitisTarihi != value)
                {
                    _bitisTarihi = value;
                    OnPropertyChanged(nameof(BitisTarihi));
                }
            }
        }

        [ModelDefault("AllowEdit", "False")]
        public string BitisSaati
        {
            get { return _bitisSaati; }
            set
            {
                if (_bitisSaati != value)
                {
                    _bitisSaati = value;
                    OnPropertyChanged(nameof(BitisSaati));
                }
            }
        }

        [ModelDefault("AllowEdit", "False")]
        public BindingList<NP_SeferDetayList> List
        {
            get { return _list; }
            set
            {
                if (_list != value)
                {
                    _list = value;
                    OnPropertyChanged(nameof(List));
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