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

    public partial class HazardousGoodsVehicleForTankCarriageVehicleForTankCarriage_HazardousGoodsHazardousGoods : XPBaseObject
    {
        HazardousGoods fHazardousGoods;
        [Indexed(@"VehicleForTankCarriage", Name = @"iHazardousGoodsVehicleForTankCarriage_HazardousGoodsVehicleForTankCarriageVehicleForTankCarriage_HazardousGoodsHazardousGoods", Unique = true)]
        [Association(@"HazardousGoodsVehicleForTankCarriageVehicleForTankCarriage_HazardousGoodsHazardousGoodsReferencesHazardousGoods")]
        public HazardousGoods HazardousGoods
        {
            get { return fHazardousGoods; }
            set { SetPropertyValue<HazardousGoods>(nameof(HazardousGoods), ref fHazardousGoods, value); }
        }
        HazardousGoodsVehicleForTankCarriage fVehicleForTankCarriage;
        [Association(@"HazardousGoodsVehicleForTankCarriageVehicleForTankCarriage_HazardousGoodsHazardousGoodsReferencesHazardousGoodsVehicleForTankCarriage")]
        public HazardousGoodsVehicleForTankCarriage VehicleForTankCarriage
        {
            get { return fVehicleForTankCarriage; }
            set { SetPropertyValue<HazardousGoodsVehicleForTankCarriage>(nameof(VehicleForTankCarriage), ref fVehicleForTankCarriage, value); }
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
