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

    public partial class HazardousGoodsTransportCategoryTransportCategory_HazardousGoodsHazardousGoods : XPBaseObject
    {
        HazardousGoods fHazardousGoods;
        [Indexed(@"TransportCategory", Name = @"iHazardousGoodsTransportCategory_HazardousGoodsTransportCategoryTransportCategory_HazardousGoodsHazardousGoods", Unique = true)]
        [Association(@"HazardousGoodsTransportCategoryTransportCategory_HazardousGoodsHazardousGoodsReferencesHazardousGoods")]
        public HazardousGoods HazardousGoods
        {
            get { return fHazardousGoods; }
            set { SetPropertyValue<HazardousGoods>(nameof(HazardousGoods), ref fHazardousGoods, value); }
        }
        HazardousGoodsTransportCategory fTransportCategory;
        [Association(@"HazardousGoodsTransportCategoryTransportCategory_HazardousGoodsHazardousGoodsReferencesHazardousGoodsTransportCategory")]
        public HazardousGoodsTransportCategory TransportCategory
        {
            get { return fTransportCategory; }
            set { SetPropertyValue<HazardousGoodsTransportCategory>(nameof(TransportCategory), ref fTransportCategory, value); }
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
