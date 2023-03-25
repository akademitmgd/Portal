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
namespace iyibir.TMGD.API.Models.iyibir_TMGD
{

    public partial class TransportDocumentTransaction : XPCustomObject
    {
        Guid fOid;
        [Key(true)]
        public Guid Oid
        {
            get { return fOid; }
            set { SetPropertyValue<Guid>(nameof(Oid), ref fOid, value); }
        }
        TransportDocument fTransportDocument;
        [Association(@"TransportDocumentTransactionReferencesTransportDocument")]
        public TransportDocument TransportDocument
        {
            get { return fTransportDocument; }
            set { SetPropertyValue<TransportDocument>(nameof(TransportDocument), ref fTransportDocument, value); }
        }
        HazardousGoods fHazardousGoods;
        [Association(@"TransportDocumentTransactionReferencesHazardousGoods")]
        public HazardousGoods HazardousGoods
        {
            get { return fHazardousGoods; }
            set { SetPropertyValue<HazardousGoods>(nameof(HazardousGoods), ref fHazardousGoods, value); }
        }
        double fQuantity;
        public double Quantity
        {
            get { return fQuantity; }
            set { SetPropertyValue<double>(nameof(Quantity), ref fQuantity, value); }
        }
        PackagingTypes fPackagingTypes;
        [Association(@"TransportDocumentTransactionReferencesPackagingTypes")]
        public PackagingTypes PackagingTypes
        {
            get { return fPackagingTypes; }
            set { SetPropertyValue<PackagingTypes>(nameof(PackagingTypes), ref fPackagingTypes, value); }
        }
        string fDescription;
        public string Description
        {
            get { return fDescription; }
            set { SetPropertyValue<string>(nameof(Description), ref fDescription, value); }
        }
        double fNetWeigth;
        public double NetWeigth
        {
            get { return fNetWeigth; }
            set { SetPropertyValue<double>(nameof(NetWeigth), ref fNetWeigth, value); }
        }
        HazardousGoodsClass fHazardousGoodsClass;
        [Association(@"TransportDocumentTransactionReferencesHazardousGoodsClass")]
        public HazardousGoodsClass HazardousGoodsClass
        {
            get { return fHazardousGoodsClass; }
            set { SetPropertyValue<HazardousGoodsClass>(nameof(HazardousGoodsClass), ref fHazardousGoodsClass, value); }
        }
        PackingGroup fPackingGroup;
        [Association(@"TransportDocumentTransactionReferencesPackingGroup")]
        public PackingGroup PackingGroup
        {
            get { return fPackingGroup; }
            set { SetPropertyValue<PackingGroup>(nameof(PackingGroup), ref fPackingGroup, value); }
        }
        string fInventoryCode;
        public string InventoryCode
        {
            get { return fInventoryCode; }
            set { SetPropertyValue<string>(nameof(InventoryCode), ref fInventoryCode, value); }
        }
        string fInventoryName;
        public string InventoryName
        {
            get { return fInventoryName; }
            set { SetPropertyValue<string>(nameof(InventoryName), ref fInventoryName, value); }
        }
        Unitset fUnitset;
        [Association(@"TransportDocumentTransactionReferencesUnitset")]
        public Unitset Unitset
        {
            get { return fUnitset; }
            set { SetPropertyValue<Unitset>(nameof(Unitset), ref fUnitset, value); }
        }
        HazardousGoodsLabel fHazardousGoodsLabel;
        [Association(@"TransportDocumentTransactionReferencesHazardousGoodsLabel")]
        public HazardousGoodsLabel HazardousGoodsLabel
        {
            get { return fHazardousGoodsLabel; }
            set { SetPropertyValue<HazardousGoodsLabel>(nameof(HazardousGoodsLabel), ref fHazardousGoodsLabel, value); }
        }
    }

}
