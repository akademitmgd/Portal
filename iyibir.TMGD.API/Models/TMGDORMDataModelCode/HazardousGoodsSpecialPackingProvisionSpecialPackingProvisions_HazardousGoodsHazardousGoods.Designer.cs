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

    public partial class HazardousGoodsSpecialPackingProvisionSpecialPackingProvisions_HazardousGoodsHazardousGoods : XPBaseObject
    {
        HazardousGoods fHazardousGoods;
        [Indexed(@"SpecialPackingProvisions", Name = @"iHazardousGoodsSpecialPackingProvisions_HazardousGoodsSpecialPackingProvisionSpecialPackingProvisions_HazardousGoodsHaz_D6594591", Unique = true)]
        [Association(@"HazardousGoodsSpecialPackingProvisionSpecialPackingProvisions_HazardousGoodsHazardousGoodsReferencesHazardousGoods")]
        public HazardousGoods HazardousGoods
        {
            get { return fHazardousGoods; }
            set { SetPropertyValue<HazardousGoods>(nameof(HazardousGoods), ref fHazardousGoods, value); }
        }
        HazardousGoodsSpecialPackingProvision fSpecialPackingProvisions;
        [Association(@"HazardousGoodsSpecialPackingProvisionSpecialPackingProvisions_HazardousGoodsHazardousGoodsReferencesHazardousGoodsSpecialPackingProvision")]
        public HazardousGoodsSpecialPackingProvision SpecialPackingProvisions
        {
            get { return fSpecialPackingProvisions; }
            set { SetPropertyValue<HazardousGoodsSpecialPackingProvision>(nameof(SpecialPackingProvisions), ref fSpecialPackingProvisions, value); }
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
