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

    public partial class HazardousGoodsHazardousGoods_HazardousGoodsHazardIdentificationHazardIdentificationNo : XPBaseObject
    {
        HazardousGoodsHazardIdentification fHazardIdentificationNo;
        [Indexed(@"HazardousGoods", Name = @"iHazardIdentificationNoHazardousGoods_HazardousGoodsHazardousGoods_HazardousGoodsHazardIdentificationHazardIdentificationNo", Unique = true)]
        [Association(@"HazardousGoodsHazardousGoods_HazardousGoodsHazardIdentificationHazardIdentificationNoReferencesHazardousGoodsHazardIdentification")]
        public HazardousGoodsHazardIdentification HazardIdentificationNo
        {
            get { return fHazardIdentificationNo; }
            set { SetPropertyValue<HazardousGoodsHazardIdentification>(nameof(HazardIdentificationNo), ref fHazardIdentificationNo, value); }
        }
        HazardousGoods fHazardousGoods;
        [Association(@"HazardousGoodsHazardousGoods_HazardousGoodsHazardIdentificationHazardIdentificationNoReferencesHazardousGoods")]
        public HazardousGoods HazardousGoods
        {
            get { return fHazardousGoods; }
            set { SetPropertyValue<HazardousGoods>(nameof(HazardousGoods), ref fHazardousGoods, value); }
        }
        Guid fOID;
        [Key(true)]
        public Guid OID
        {
            get { return fOID; }
            set { SetPropertyValue<Guid>(nameof(OID), ref fOID, value); }
        }
    }

}
