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

    public partial class HazardousGoodsSpecialProvisionForCarriageOperation : XPCustomObject
    {
        Guid fOid;
        [Key(true)]
        public Guid Oid
        {
            get { return fOid; }
            set { SetPropertyValue<Guid>(nameof(Oid), ref fOid, value); }
        }
        HazardousGoods fHazardousGoods;
        [Association(@"HazardousGoodsSpecialProvisionForCarriageOperationReferencesHazardousGoods")]
        public HazardousGoods HazardousGoods
        {
            get { return fHazardousGoods; }
            set { SetPropertyValue<HazardousGoods>(nameof(HazardousGoods), ref fHazardousGoods, value); }
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
        [Association(@"HazardousGoodsSpecialProvisionForCarriageOperationSpecialProvisionForCarriageOperation_HazardousGoodsHazardousGoodsReferencesHazardousGoodsSpecialProvisionForCarriageOperation")]
        public XPCollection<HazardousGoodsSpecialProvisionForCarriageOperationSpecialProvisionForCarriageOperation_HazardousGoodsHazardousGoods> HazardousGoodsSpecialProvisionForCarriageOperationSpecialProvisionForCarriageOperation_HazardousGoodsHazardousGoodss { get { return GetCollection<HazardousGoodsSpecialProvisionForCarriageOperationSpecialProvisionForCarriageOperation_HazardousGoodsHazardousGoods>(nameof(HazardousGoodsSpecialProvisionForCarriageOperationSpecialProvisionForCarriageOperation_HazardousGoodsHazardousGoodss)); } }
    }

}
