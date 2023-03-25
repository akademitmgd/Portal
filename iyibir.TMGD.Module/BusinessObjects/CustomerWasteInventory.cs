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
    public class CustomerWasteInventory : BaseObject
    {
        private Customer _customer;
        private HazardousGoods _hazardousGoods;
        private PackingGroup _packingGroup;
        private WasteList _wasteCode;
        private string _wasteName;
        private string _description;
        private string _wasteDescription;
        private DefaultLabel _defaultLabel1;
        private DefaultLabel _defaultLabel2;
        private DefaultLabel _defaultLabel3;
        private DefaultLabel _defaultLabel4;
        private WasteInventoryADRStatus _adrStatus;
        private WastePhysicalState _wastePhysicalState;
        private string _shipper;
        private string _disposalFirm;
        private string _msdsName;
        private PackagingTypes _packagingTypes;

        public CustomerWasteInventory(Session session)
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
                case "WasteCode":
                    if (WasteCode != null)
                    {
                        this.WasteName = WasteCode.Name ?? string.Empty;
                        this.RaisePropertyChangedEvent(nameof(WasteName));
                    }
                    break;
                case "DefaultLabel1":
                    if (this.DefaultLabel1 != null)
                    {
                        this.LabelImage1 = this.DefaultLabel1.LabelImage;
                        this.RaisePropertyChangedEvent(nameof(LabelImage1));
                    }
                    break;
                case "DefaultLabel2":
                    if (this.DefaultLabel2 != null)
                    {
                        this.LabelImage2 = this.DefaultLabel2.LabelImage;
                        this.RaisePropertyChangedEvent(nameof(LabelImage2));
                    }
                    break;
                case "DefaultLabel3":
                    if (this.DefaultLabel3 != null)
                    {
                        this.LabelImage3 = this.DefaultLabel3.LabelImage;
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

        [Association("Customer-WasteInventories")]
        public Customer Customer { get => _customer; set => SetPropertyValue(nameof(Customer), ref _customer, value); }

        
        public HazardousGoods HazardousGoods { get => _hazardousGoods; set => SetPropertyValue(nameof(HazardousGoods), ref _hazardousGoods, value); }


        [DataSourceProperty("HazardousGoods.PackingGroups")]
        public PackingGroup PackingGroup { get => _packingGroup; set => SetPropertyValue(nameof(PackingGroup), ref _packingGroup, value); }

        [ImmediatePostData]
        public WasteList WasteCode { get => _wasteCode; set => SetPropertyValue(nameof(WasteCode), ref _wasteCode, value); }

        [ModelDefault("AllowEdit","False")]
        public string WasteName { get => _wasteName; set => SetPropertyValue(nameof(WasteName), ref _wasteName, value); }
        public string Description { get=> _description; set=> SetPropertyValue(nameof(Description),ref _description,value); }

        public string WasteDescription { get => _wasteDescription; set => SetPropertyValue(nameof(WasteDescription), ref _wasteDescription, value); }

        [VisibleInListView(true)]
        [ImageEditor(ListViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorFixedHeight = 350, DetailViewImageEditorFixedWidth = 350)]
        public byte[] WasteInventoryImage
        {
            get { return GetPropertyValue<byte[]>(nameof(WasteInventoryImage)); }
            set { SetPropertyValue<byte[]>(nameof(WasteInventoryImage), value); }
        }


        [NonPersistent]
        [ImmediatePostData]
        public DefaultLabel DefaultLabel1 { get=>_defaultLabel1; set=> SetPropertyValue(nameof(DefaultLabel1),ref _defaultLabel1,value); }

        [VisibleInListView(true)]
        [ImageEditor(ListViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorFixedHeight = 300, DetailViewImageEditorFixedWidth = 200)]
        public byte[] LabelImage1
        {
            get { return GetPropertyValue<byte[]>(nameof(LabelImage1)); }
            set { SetPropertyValue<byte[]>(nameof(LabelImage1), value); }
        }

        [NonPersistent]
        [ImmediatePostData]
        public DefaultLabel DefaultLabel2 { get => _defaultLabel2; set => SetPropertyValue(nameof(DefaultLabel2), ref _defaultLabel2, value); }

        [VisibleInListView(true)]
        [ImageEditor(ListViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorFixedHeight = 300, DetailViewImageEditorFixedWidth = 200)]
        public byte[] LabelImage2
        {
            get { return GetPropertyValue<byte[]>(nameof(LabelImage2)); }
            set { SetPropertyValue<byte[]>(nameof(LabelImage2), value); }
        }


        [NonPersistent]
        [ImmediatePostData]
        public DefaultLabel DefaultLabel3 { get => _defaultLabel3; set => SetPropertyValue(nameof(DefaultLabel3), ref _defaultLabel3, value); }

        [VisibleInListView(true)]
        [ImageEditor(ListViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorFixedHeight = 300, DetailViewImageEditorFixedWidth = 200)]
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

        public WasteInventoryADRStatus ADRStatus { get=> _adrStatus; set=> SetPropertyValue(nameof(ADRStatus),ref _adrStatus,value); }
        public WastePhysicalState WastePhysicalState { get=> _wastePhysicalState; set=> SetPropertyValue(nameof(WastePhysicalState),ref _wastePhysicalState,value); }
        public string Shipper { get=> _shipper; set=> SetPropertyValue(nameof(Shipper),ref _shipper,value); }
        public string DisposalFirm { get=> _disposalFirm; set=> SetPropertyValue(nameof(DisposalFirm),ref _disposalFirm,value); }
        public string MSDSName { get => _msdsName; set => SetPropertyValue(nameof(MSDSName), ref _msdsName, value); }
        public PackagingTypes PackagingTypes { get => _packagingTypes; set => SetPropertyValue(nameof(PackagingTypes), ref _packagingTypes, value); }
    }
}