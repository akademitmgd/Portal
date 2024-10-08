﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace iyibir.TMGD.WebAPI.OData.Models.iyibir_TMGD
{

    public partial class HazardousGoodsLabel : XPCustomObject
    {
        Guid fOid;
        [Key(true)]
        public Guid Oid
        {
            get { return fOid; }
            set { SetPropertyValue<Guid>(nameof(Oid), ref fOid, value); }
        }
        string fCode;
        public string Code
        {
            get { return fCode; }
            set { SetPropertyValue<string>(nameof(Code), ref fCode, value); }
        }
        string fName;
        [Size(SizeAttribute.Unlimited)]
        public string Name
        {
            get { return fName; }
            set { SetPropertyValue<string>(nameof(Name), ref fName, value); }
        }
        byte[] fLabelImage;
        [Size(SizeAttribute.Unlimited)]
        [MemberDesignTimeVisibility(true)]
        public byte[] LabelImage
        {
            get { return fLabelImage; }
            set { SetPropertyValue<byte[]>(nameof(LabelImage), ref fLabelImage, value); }
        }
        HazardousGoods fHazardousGoods;
        [Association(@"HazardousGoodsLabelReferencesHazardousGoods")]
        public HazardousGoods HazardousGoods
        {
            get { return fHazardousGoods; }
            set { SetPropertyValue<HazardousGoods>(nameof(HazardousGoods), ref fHazardousGoods, value); }
        }
        int fLineNumber;
        public int LineNumber
        {
            get { return fLineNumber; }
            set { SetPropertyValue<int>(nameof(LineNumber), ref fLineNumber, value); }
        }
        [Association(@"CustomerInventoryReferencesHazardousGoodsLabel")]
        public XPCollection<CustomerInventory> CustomerInventories { get { return GetCollection<CustomerInventory>(nameof(CustomerInventories)); } }
        [Association(@"CustomerInventoryReferencesHazardousGoodsLabel1")]
        public XPCollection<CustomerInventory> CustomerInventories1 { get { return GetCollection<CustomerInventory>(nameof(CustomerInventories1)); } }
        [Association(@"CustomerInventoryReferencesHazardousGoodsLabel2")]
        public XPCollection<CustomerInventory> CustomerInventories2 { get { return GetCollection<CustomerInventory>(nameof(CustomerInventories2)); } }
        [Association(@"HazardousGoodsReferencesHazardousGoodsLabel")]
        public XPCollection<HazardousGoods> HazardousGoodsCollection { get { return GetCollection<HazardousGoods>(nameof(HazardousGoodsCollection)); } }
        [Association(@"HazardousGoodsLabelControllerReferencesHazardousGoodsLabel")]
        public XPCollection<HazardousGoodsLabelController> HazardousGoodsLabelControllers { get { return GetCollection<HazardousGoodsLabelController>(nameof(HazardousGoodsLabelControllers)); } }
        [Association(@"HazardousGoodsLabelEquipmentReferencesHazardousGoodsLabel")]
        public XPCollection<HazardousGoodsLabelEquipment> HazardousGoodsLabelEquipments { get { return GetCollection<HazardousGoodsLabelEquipment>(nameof(HazardousGoodsLabelEquipments)); } }
        [Association(@"HazardousGoodsLabelLabels_HazardousGoodsHazardousGoodsReferencesHazardousGoodsLabel")]
        public XPCollection<HazardousGoodsLabelLabels_HazardousGoodsHazardousGoods> HazardousGoodsLabelLabels_HazardousGoodsHazardousGoodss { get { return GetCollection<HazardousGoodsLabelLabels_HazardousGoodsHazardousGoods>(nameof(HazardousGoodsLabelLabels_HazardousGoodsHazardousGoodss)); } }
        [Association(@"HazardousGoodsLabelMixedLoadingReferencesHazardousGoodsLabel")]
        public XPCollection<HazardousGoodsLabelMixedLoading> HazardousGoodsLabelMixedLoadings { get { return GetCollection<HazardousGoodsLabelMixedLoading>(nameof(HazardousGoodsLabelMixedLoadings)); } }
        [Association(@"HazardousGoodsLabelMixedLoadingReferencesHazardousGoodsLabel1")]
        public XPCollection<HazardousGoodsLabelMixedLoading> HazardousGoodsLabelMixedLoadings1 { get { return GetCollection<HazardousGoodsLabelMixedLoading>(nameof(HazardousGoodsLabelMixedLoadings1)); } }
        [Association(@"LabelTransactionReferencesHazardousGoodsLabel")]
        public XPCollection<LabelTransaction> LabelTransactions { get { return GetCollection<LabelTransaction>(nameof(LabelTransactions)); } }
        [Association(@"TransportDocumentOtherTransactionReferencesHazardousGoodsLabel")]
        public XPCollection<TransportDocumentOtherTransaction> TransportDocumentOtherTransactions { get { return GetCollection<TransportDocumentOtherTransaction>(nameof(TransportDocumentOtherTransactions)); } }
        [Association(@"TransportDocumentTransactionReferencesHazardousGoodsLabel")]
        public XPCollection<TransportDocumentTransaction> TransportDocumentTransactions { get { return GetCollection<TransportDocumentTransaction>(nameof(TransportDocumentTransactions)); } }
        [Association(@"VehicleControlDocumentLabelReferencesHazardousGoodsLabel")]
        public XPCollection<VehicleControlDocumentLabel> VehicleControlDocumentLabels { get { return GetCollection<VehicleControlDocumentLabel>(nameof(VehicleControlDocumentLabels)); } }
        [Association(@"VehicleControlDocumentTransactionReferencesHazardousGoodsLabel")]
        public XPCollection<VehicleControlDocumentTransaction> VehicleControlDocumentTransactions { get { return GetCollection<VehicleControlDocumentTransaction>(nameof(VehicleControlDocumentTransactions)); } }
    }

}
