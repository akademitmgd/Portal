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

    public partial class PackingGroupPackingGroups_HazardousGoodsHazardousGoods : XPBaseObject
    {
        HazardousGoods fHazardousGoods;
        [Indexed(@"PackingGroups", Name = @"iHazardousGoodsPackingGroups_PackingGroupPackingGroups_HazardousGoodsHazardousGoods", Unique = true)]
        [Association(@"PackingGroupPackingGroups_HazardousGoodsHazardousGoodsReferencesHazardousGoods")]
        public HazardousGoods HazardousGoods
        {
            get { return fHazardousGoods; }
            set { SetPropertyValue<HazardousGoods>(nameof(HazardousGoods), ref fHazardousGoods, value); }
        }
        PackingGroup fPackingGroups;
        [Association(@"PackingGroupPackingGroups_HazardousGoodsHazardousGoodsReferencesPackingGroup")]
        public PackingGroup PackingGroups
        {
            get { return fPackingGroups; }
            set { SetPropertyValue<PackingGroup>(nameof(PackingGroups), ref fPackingGroups, value); }
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
