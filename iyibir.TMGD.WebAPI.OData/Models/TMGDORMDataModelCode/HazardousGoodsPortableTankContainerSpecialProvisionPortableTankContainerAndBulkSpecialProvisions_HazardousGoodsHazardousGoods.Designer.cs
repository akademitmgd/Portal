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

    public partial class HazardousGoodsPortableTankContainerSpecialProvisionPortableTankContainerAndBulkSpecialProvisions_HazardousGoodsHazardousGoods : XPBaseObject
    {
        HazardousGoods fHazardousGoods;
        [Indexed(@"PortableTankContainerAndBulkSpecialProvisions", Name = @"iHazardousGoodsPortableTankContainerAndBulkSpecialProvisions_HazardousGoodsPortableTankContainerSpecialProvisionPortabl_C9D10064", Unique = true)]
        [Association(@"HazardousGoodsPortableTankContainerSpecialProvisionPortableTankContainerAndBulkSpecialProvisions_HazardousGoodsHazardousGoodsReferencesHazardousGoods")]
        public HazardousGoods HazardousGoods
        {
            get { return fHazardousGoods; }
            set { SetPropertyValue<HazardousGoods>(nameof(HazardousGoods), ref fHazardousGoods, value); }
        }
        HazardousGoodsPortableTankContainerSpecialProvision fPortableTankContainerAndBulkSpecialProvisions;
        [Association(@"HazardousGoodsPortableTankContainerSpecialProvisionPortableTankContainerAndBulkSpecialProvisions_HazardousGoodsHazardousGoodsReferencesHazardousGoodsPortableTankContainerSpecialProvision")]
        public HazardousGoodsPortableTankContainerSpecialProvision PortableTankContainerAndBulkSpecialProvisions
        {
            get { return fPortableTankContainerAndBulkSpecialProvisions; }
            set { SetPropertyValue<HazardousGoodsPortableTankContainerSpecialProvision>(nameof(PortableTankContainerAndBulkSpecialProvisions), ref fPortableTankContainerAndBulkSpecialProvisions, value); }
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
