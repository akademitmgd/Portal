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

namespace iyibir.TMGD.Module.BusinessObjects
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class CustomerInventory : BaseObject
    {
        private Customer _customer;
        private HazardousGoods _hazardousGoods;
        private PackingGroup _packingGroup;
        private bool _isWaste;
        private string _inventoryCode;
        private string _inventoryName;
        private FactoryDepartment _factoryDepartment;
        private string _supplier;
        private double _packagingQuantity;
        private Unitset _packagingQuantityUnit;
        private FileData _documentData;
        private double _lastYearIntake;
        private Unitset _lastYearIntakeUnit;
        private CustomerInventoryMSDSStatus _msdsStatus;
        private bool _consignor;
        private bool _carrier;
        private bool _consignee;
        private bool _loader;
        private bool _unloader;
        private bool _packer;
        private bool _filler;
        private bool _tankContainer;
        private DefaultLabel _defaultLabel1;
        private DefaultLabel _defaultLabel2;
        private DefaultLabel _defaultLabel3;
        private DefaultLabel _defaultLabel4;
        private string _shipper;
        private string _msdsName;
        private PackagingTypes _packagingTypes;
        private HazardousGoodsLabel _hazardousGoodsLabel1;
        private HazardousGoodsLabel _hazardousGoodsLabel2;
        private HazardousGoodsLabel _hazardousGoodsLabel3;

        public CustomerInventory(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            switch (propertyName)
            {
                case "HazardousGoodsLabel1":
                    if (this.HazardousGoodsLabel1 != null)
                    {
                        this.LabelImage1 = this.HazardousGoodsLabel1.LabelImage;
                        this.RaisePropertyChangedEvent(nameof(LabelImage1));
                    }
                    break;
                case "HazardousGoodsLabel2":
                    if (this.HazardousGoodsLabel2 != null)
                    {
                        this.LabelImage2 = this.HazardousGoodsLabel2.LabelImage;
                        this.RaisePropertyChangedEvent(nameof(LabelImage2));
                    }
                    break;
                case "HazardousGoodsLabel3":
                    if (this.HazardousGoodsLabel3 != null)
                    {
                        this.LabelImage3 = this.HazardousGoodsLabel3.LabelImage;
                        this.RaisePropertyChangedEvent(nameof(LabelImage3));
                    }
                    break;
                case "DefaultLabel4":
                    if (this.DefaultLabel4 != null)
                    {
                        this.LabelImage4 = this.DefaultLabel4.LabelImage;
                        this.RaisePropertyChangedEvent(nameof(LabelImage4));
                    }
                    break;
                default:
                    break;
            }
        }

        [Association("Customer-Inventories")]
        public Customer Customer { get=> _customer; set=> SetPropertyValue(nameof(Customer),ref _customer,value); }

        [ImmediatePostData]
        
        public HazardousGoods HazardousGoods { get=> _hazardousGoods; set=> SetPropertyValue(nameof(HazardousGoods),ref _hazardousGoods, value); }

        
        [DataSourceProperty("HazardousGoods.PackingGroups")]
        public PackingGroup PackingGroup { get=> _packingGroup; set=> SetPropertyValue(nameof(PackingGroup),ref _packingGroup,value); }
        public bool IsWaste { get=> _isWaste; set=> SetPropertyValue(nameof(IsWaste),ref _isWaste,value); }

        public string InventoryCode { get=> _inventoryCode; set=> SetPropertyValue(nameof(InventoryCode),ref _inventoryCode,value); }
        public string InventoryName { get=> _inventoryName; set=> SetPropertyValue(nameof(InventoryName),ref _inventoryName,value); }

        [VisibleInListView(true)]
        [ImageEditor(ListViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorFixedHeight = 350, DetailViewImageEditorFixedWidth = 350)]
        public byte[] InventoryImage
        {
            get { return GetPropertyValue<byte[]>(nameof(InventoryImage)); }
            set { SetPropertyValue<byte[]>(nameof(InventoryImage), value); }
        }

        
        public FactoryDepartment FactoryDepartment { get=> _factoryDepartment; set=> SetPropertyValue(nameof(FactoryDepartment),ref _factoryDepartment,value); }
        public string Supplier { get=> _supplier; set=> SetPropertyValue(nameof(Supplier),ref _supplier,value); }
        public double PackagingQuantity { get=> _packagingQuantity; set=> SetPropertyValue(nameof(PackagingQuantity),ref _packagingQuantity,value); }

        [ExpandObjectMembers(ExpandObjectMembers.Never)]
        public FileData FileData { get => _documentData; set => SetPropertyValue("FileData", ref _documentData, value); }
        public double LastYearIntake { get=> _lastYearIntake; set=> SetPropertyValue(nameof(LastYearIntake),ref _lastYearIntake,value); }
        public CustomerInventoryMSDSStatus MSDSStatus { get=> _msdsStatus; set=> SetPropertyValue(nameof(MSDSStatus),ref _msdsStatus,value); }
        public bool Consignor { get => _consignor; set => SetPropertyValue(nameof(Consignor), ref _consignor, value); }
        public bool Carrier { get => _carrier; set => SetPropertyValue(nameof(Carrier), ref _carrier, value); }
        public bool Consignee { get => _consignee; set => SetPropertyValue(nameof(Consignee), ref _consignee, value); }
        public bool Loader { get => _loader; set => SetPropertyValue(nameof(Loader), ref _loader, value); }
        public bool Unloader { get => _unloader; set => SetPropertyValue(nameof(Unloader), ref _unloader, value); }
        public bool Packer { get => _packer; set => SetPropertyValue(nameof(Packer), ref _packer, value); }
        public bool Filler { get => _filler; set => SetPropertyValue(nameof(Filler), ref _filler, value); }
        public bool TankContainer { get => _tankContainer; set => SetPropertyValue(nameof(TankContainer), ref _tankContainer, value); }
        public Unitset PackagingQuantityUnit { get=> _packagingQuantityUnit; set=> SetPropertyValue(nameof(PackagingQuantityUnit),ref _packagingQuantityUnit,value); }
        public Unitset LastYearIntakeUnit { get=> _lastYearIntakeUnit; set=> SetPropertyValue(nameof(LastYearIntakeUnit),ref _lastYearIntakeUnit,value); }

        [NonPersistent]
        [Browsable(false)]
        public DefaultLabel DefaultLabel1 { get => _defaultLabel1; set => SetPropertyValue(nameof(DefaultLabel1), ref _defaultLabel1, value); }


        [DataSourceProperty("HazardousGoods.Labels")]
        [ImmediatePostData]
        public HazardousGoodsLabel HazardousGoodsLabel1 { get => _hazardousGoodsLabel1; set => SetPropertyValue(nameof(HazardousGoodsLabel1), ref _hazardousGoodsLabel1, value); }

        [VisibleInListView(true)]
        [ImageEditor(ListViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorFixedHeight = 300, DetailViewImageEditorFixedWidth = 200)]
        [ModelDefault("AllowEdit", "False")]
        public byte[] LabelImage1
        {
            get { return GetPropertyValue<byte[]>(nameof(LabelImage1)); }
            set { SetPropertyValue<byte[]>(nameof(LabelImage1), value); }
        }

        [NonPersistent]
        [Browsable(false)]
        public DefaultLabel DefaultLabel2 { get => _defaultLabel2; set => SetPropertyValue(nameof(DefaultLabel2), ref _defaultLabel2, value); }

        //[RuleRequiredField("RuleRequiredField for CustomerInventory.HazardousGoodsLabel2", DefaultContexts.Save)]
        [DataSourceProperty("HazardousGoods.Labels")]
        [ImmediatePostData]
        public HazardousGoodsLabel HazardousGoodsLabel2 { get => _hazardousGoodsLabel2; set => SetPropertyValue(nameof(HazardousGoodsLabel2), ref _hazardousGoodsLabel2, value); }

        [VisibleInListView(true)]
        [ImageEditor(ListViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorFixedHeight = 300, DetailViewImageEditorFixedWidth = 200)]
        [ModelDefault("AllowEdit", "False")]
        public byte[] LabelImage2
        {
            get { return GetPropertyValue<byte[]>(nameof(LabelImage2)); }
            set { SetPropertyValue<byte[]>(nameof(LabelImage2), value); }
        }


        [NonPersistent]
        [Browsable(false)]
        public DefaultLabel DefaultLabel3 { get => _defaultLabel3; set => SetPropertyValue(nameof(DefaultLabel3), ref _defaultLabel3, value); }

        //[RuleRequiredField("RuleRequiredField for CustomerInventory.HazardousGoodsLabel3", DefaultContexts.Save)]
        [DataSourceProperty("HazardousGoods.Labels")]
        [ImmediatePostData]
        public HazardousGoodsLabel HazardousGoodsLabel3 { get => _hazardousGoodsLabel3; set => SetPropertyValue(nameof(HazardousGoodsLabel), ref _hazardousGoodsLabel3, value); }

        [VisibleInListView(true)]
        [ImageEditor(ListViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorFixedHeight = 300, DetailViewImageEditorFixedWidth = 200)]
        [ModelDefault("AllowEdit", "False")]
        public byte[] LabelImage3
        {
            get { return GetPropertyValue<byte[]>(nameof(LabelImage3)); }
            set { SetPropertyValue<byte[]>(nameof(LabelImage3), value); }
        }


        [NonPersistent]
        [ImmediatePostData]
        public DefaultLabel DefaultLabel4 { get => _defaultLabel4; set => SetPropertyValue(nameof(DefaultLabel4), ref _defaultLabel4, value); }

        [VisibleInListView(true)]
        [ImageEditor(ListViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorFixedHeight = 300, DetailViewImageEditorFixedWidth = 200)]
        public byte[] LabelImage4
        {
            get { return GetPropertyValue<byte[]>(nameof(LabelImage4)); }
            set { SetPropertyValue<byte[]>(nameof(LabelImage4), value); }
        }

        public string Shipper { get=> _shipper; set=> SetPropertyValue(nameof(Shipper),ref _shipper,value); }
        public string MSDSName { get=> _msdsName; set=> SetPropertyValue(nameof(MSDSName),ref _msdsName,value); }
        public PackagingTypes PackagingTypes { get=> _packagingTypes; set=> SetPropertyValue(nameof(PackagingTypes),ref _packagingTypes,value); }
    }
}