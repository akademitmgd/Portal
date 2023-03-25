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
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    [Appearance("TransportDocumentOtherTransaction New", AppearanceItemType = "Action", TargetItems = "New", Visibility = ViewItemVisibility.Hide)]
    public class TransportDocumentOtherTransaction : BaseObject
    {
        private TransportDocument _transportDocument;
        private PackagingTypes _packagingTypes;
        private double _quantity;
        private HazardousGoods _hazardousGoods;
        private HazardousGoodsClass _hazardousGoodsClass;
        private HazardousGoodsLabel _hazardousGoodsLabel;
        private PackingGroup _packingGroup;
        private string _description;
        private double _netWeigth;
        private WasteList _wasteCode;
        private Unitset _unitset;
        private int _val;
        private HazardousGoodsTunnelCode _tunnelCode;
        private int _convFactor;
        private double _totalConvFactor;
        private HazardousGoodsTransportCategory _transportCategory;
        public TransportDocumentOtherTransaction(Session session)
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
                case "HazardousGoods":
                    if (HazardousGoods != null)
                    {
                        Val = HazardousGoods.TunnelCodes.FirstOrDefault() != null ? HazardousGoods.TunnelCodes.FirstOrDefault().Val : 0;
                        ConvFactor = HazardousGoods.ConvFactor;

                        this.RaisePropertyChangedEvent("Val");
                        this.RaisePropertyChangedEvent("ConvFactor");
                    }
                    break;
                case "ConvFactor":
                case "NetWeigth":

                    TotalConvFactor = NetWeigth * Convert.ToDouble(ConvFactor);

                    this.RaisePropertyChangedEvent("TotalConvFactor");
                    break;
                default:
                    break;
            }
        }

        [Association("TransportDocument-OtherTransactions")]
        public TransportDocument TransportDocument { get => _transportDocument; set => SetPropertyValue(nameof(TransportDocument), ref _transportDocument, value); }

        [RuleRequiredField("RuleRequiredField for TransportDocumentOtherTransaction.HazardousGoods", DefaultContexts.Save)]
        [ImmediatePostData]
        public HazardousGoods HazardousGoods { get => _hazardousGoods; set => SetPropertyValue(nameof(HazardousGoods), ref _hazardousGoods, value); }

        [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false), VisibleInDashboards(false)]
        public HazardousGoodsClass HazardousGoodsClass { get => _hazardousGoodsClass; set => SetPropertyValue(nameof(HazardousGoodsClass), ref _hazardousGoodsClass, value); }

       
        [DataSourceProperty("HazardousGoods.Labels")]
        [VisibleInDetailView(false), VisibleInListView(false)]
        public HazardousGoodsLabel HazardousGoodsLabel { get => _hazardousGoodsLabel; set => SetPropertyValue(nameof(HazardousGoodsLabel), ref _hazardousGoodsLabel, value); }

        [RuleRequiredField("RuleRequiredField for TransportDocumentOtherTransaction.PackingGroup", DefaultContexts.Save)]
        [DataSourceProperty("HazardousGoods.PackingGroups")]
        public PackingGroup PackingGroup { get => _packingGroup; set => SetPropertyValue(nameof(PackingGroup), ref _packingGroup, value); }

        [RuleValueComparison("RuleValueComparison for TransportDocumentOtherTransaction.Quantity", DefaultContexts.Save, ValueComparisonType.GreaterThanOrEqual, 0)]
        public double Quantity { get => _quantity; set => SetPropertyValue(nameof(Quantity), ref _quantity, value); }

        public PackagingTypes PackagingTypes { get => _packagingTypes; set => SetPropertyValue(nameof(PackagingTypes), ref _packagingTypes, value); }
        public string Description { get => _description; set => SetPropertyValue(nameof(Description), ref _description, value); }

        [RuleValueComparison("RuleValueComparison for TransportDocumentOtherTransaction.NetWeigth", DefaultContexts.Save, ValueComparisonType.GreaterThanOrEqual, 0)]
        public double NetWeigth { get => _netWeigth; set => SetPropertyValue(nameof(NetWeigth), ref _netWeigth, value); }

        [ModelDefault("AllowEdit", "False")]
        public WasteList WasteCode { get => _wasteCode; set => SetPropertyValue(nameof(WasteCode), ref _wasteCode, value); }
        public Unitset Unitset { get => _unitset; set => SetPropertyValue(nameof(Unitset), ref _unitset, value); }

        [ModelDefault("AllowEdit","False")]
        public int Val { get=> _val; set=> SetPropertyValue(nameof(Val),ref _val,value); }

        [ModelDefault("AllowEdit", "False"), VisibleInListView(false), VisibleInDetailView(false)]
        public HazardousGoodsTunnelCode TunnelCode { get => _tunnelCode; set => SetPropertyValue(nameof(TunnelCode), ref _tunnelCode, value); }

        [ModelDefault("AllowEdit", "False"), VisibleInListView(false), VisibleInDetailView(false)]
        [ImmediatePostData]
        public int ConvFactor { get => _convFactor; set => SetPropertyValue(nameof(ConvFactor), ref _convFactor, value); }

        [ModelDefault("AllowEdit", "False"), VisibleInListView(false), VisibleInDetailView(false)]
        public double TotalConvFactor { get => _totalConvFactor; set => SetPropertyValue(nameof(TotalConvFactor), ref _totalConvFactor, value); }
        public HazardousGoodsTransportCategory TransportCategory { get=> _transportCategory; set=> SetPropertyValue(nameof(TransportCategory),ref _transportCategory,value); }
    }
}