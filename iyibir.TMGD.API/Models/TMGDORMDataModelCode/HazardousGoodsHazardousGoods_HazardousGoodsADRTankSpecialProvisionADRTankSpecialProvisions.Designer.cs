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

    public partial class HazardousGoodsHazardousGoods_HazardousGoodsADRTankSpecialProvisionADRTankSpecialProvisions : XPBaseObject
    {
        HazardousGoodsADRTankSpecialProvision fADRTankSpecialProvisions;
        [Indexed(@"HazardousGoods", Name = @"iADRTankSpecialProvisionsHazardousGoods_HazardousGoodsHazardousGoods_HazardousGoodsADRTankSpecialProvisionADRTankSpecia_24969761", Unique = true)]
        [Association(@"HazardousGoodsHazardousGoods_HazardousGoodsADRTankSpecialProvisionADRTankSpecialProvisionsReferencesHazardousGoodsADRTankSpecialProvision")]
        public HazardousGoodsADRTankSpecialProvision ADRTankSpecialProvisions
        {
            get { return fADRTankSpecialProvisions; }
            set { SetPropertyValue<HazardousGoodsADRTankSpecialProvision>(nameof(ADRTankSpecialProvisions), ref fADRTankSpecialProvisions, value); }
        }
        HazardousGoods fHazardousGoods;
        [Association(@"HazardousGoodsHazardousGoods_HazardousGoodsADRTankSpecialProvisionADRTankSpecialProvisionsReferencesHazardousGoods")]
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
