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
namespace iyibir.TMGD.WebAPI.V2.Models.iyibir_TMGD
{

    public partial class CustomerWasteInventory : XPCustomObject
    {
        Guid fOid;
        [Key(true)]
        public Guid Oid
        {
            get { return fOid; }
            set { SetPropertyValue<Guid>(nameof(Oid), ref fOid, value); }
        }
        Customer fCustomer;
        [Association(@"CustomerWasteInventoryReferencesCustomer")]
        public Customer Customer
        {
            get { return fCustomer; }
            set { SetPropertyValue<Customer>(nameof(Customer), ref fCustomer, value); }
        }
        HazardousGoods fHazardousGoods;
        [Association(@"CustomerWasteInventoryReferencesHazardousGoods")]
        public HazardousGoods HazardousGoods
        {
            get { return fHazardousGoods; }
            set { SetPropertyValue<HazardousGoods>(nameof(HazardousGoods), ref fHazardousGoods, value); }
        }
        WasteList fWasteCode;
        [Association(@"CustomerWasteInventoryReferencesWasteList")]
        public WasteList WasteCode
        {
            get { return fWasteCode; }
            set { SetPropertyValue<WasteList>(nameof(WasteCode), ref fWasteCode, value); }
        }
        string fDescription;
        public string Description
        {
            get { return fDescription; }
            set { SetPropertyValue<string>(nameof(Description), ref fDescription, value); }
        }
        byte[] fWasteInventoryImage;
        [Size(SizeAttribute.Unlimited)]
        [MemberDesignTimeVisibility(true)]
        public byte[] WasteInventoryImage
        {
            get { return fWasteInventoryImage; }
            set { SetPropertyValue<byte[]>(nameof(WasteInventoryImage), ref fWasteInventoryImage, value); }
        }
        PackingGroup fPackingGroup;
        [Association(@"CustomerWasteInventoryReferencesPackingGroup")]
        public PackingGroup PackingGroup
        {
            get { return fPackingGroup; }
            set { SetPropertyValue<PackingGroup>(nameof(PackingGroup), ref fPackingGroup, value); }
        }
        string fWasteDescription;
        public string WasteDescription
        {
            get { return fWasteDescription; }
            set { SetPropertyValue<string>(nameof(WasteDescription), ref fWasteDescription, value); }
        }
        byte[] fLabelImage1;
        [Size(SizeAttribute.Unlimited)]
        [MemberDesignTimeVisibility(true)]
        public byte[] LabelImage1
        {
            get { return fLabelImage1; }
            set { SetPropertyValue<byte[]>(nameof(LabelImage1), ref fLabelImage1, value); }
        }
        byte[] fLabelImage2;
        [Size(SizeAttribute.Unlimited)]
        [MemberDesignTimeVisibility(true)]
        public byte[] LabelImage2
        {
            get { return fLabelImage2; }
            set { SetPropertyValue<byte[]>(nameof(LabelImage2), ref fLabelImage2, value); }
        }
        byte[] fLabelImage3;
        [Size(SizeAttribute.Unlimited)]
        [MemberDesignTimeVisibility(true)]
        public byte[] LabelImage3
        {
            get { return fLabelImage3; }
            set { SetPropertyValue<byte[]>(nameof(LabelImage3), ref fLabelImage3, value); }
        }
        byte[] fLabelImage4;
        [Size(SizeAttribute.Unlimited)]
        [MemberDesignTimeVisibility(true)]
        public byte[] LabelImage4
        {
            get { return fLabelImage4; }
            set { SetPropertyValue<byte[]>(nameof(LabelImage4), ref fLabelImage4, value); }
        }
        string fWasteName;
        public string WasteName
        {
            get { return fWasteName; }
            set { SetPropertyValue<string>(nameof(WasteName), ref fWasteName, value); }
        }
        int fADRStatus;
        public int ADRStatus
        {
            get { return fADRStatus; }
            set { SetPropertyValue<int>(nameof(ADRStatus), ref fADRStatus, value); }
        }
        WastePhysicalState fWastePhysicalState;
        [Association(@"CustomerWasteInventoryReferencesWastePhysicalState")]
        public WastePhysicalState WastePhysicalState
        {
            get { return fWastePhysicalState; }
            set { SetPropertyValue<WastePhysicalState>(nameof(WastePhysicalState), ref fWastePhysicalState, value); }
        }
        string fShipper;
        public string Shipper
        {
            get { return fShipper; }
            set { SetPropertyValue<string>(nameof(Shipper), ref fShipper, value); }
        }
        string fDisposalFirm;
        public string DisposalFirm
        {
            get { return fDisposalFirm; }
            set { SetPropertyValue<string>(nameof(DisposalFirm), ref fDisposalFirm, value); }
        }
        string fMSDSName;
        public string MSDSName
        {
            get { return fMSDSName; }
            set { SetPropertyValue<string>(nameof(MSDSName), ref fMSDSName, value); }
        }
        PackagingTypes fPackagingTypes;
        [Association(@"CustomerWasteInventoryReferencesPackagingTypes")]
        public PackagingTypes PackagingTypes
        {
            get { return fPackagingTypes; }
            set { SetPropertyValue<PackagingTypes>(nameof(PackagingTypes), ref fPackagingTypes, value); }
        }
    }

}
