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

    public partial class HazardousGoodsLabelEquipment : XPCustomObject
    {
        Guid fOid;
        [Key(true)]
        public Guid Oid
        {
            get { return fOid; }
            set { SetPropertyValue<Guid>(nameof(Oid), ref fOid, value); }
        }
        HazardousGoodsLabel fHazardousGoodsLabel;
        [Association(@"HazardousGoodsLabelEquipmentReferencesHazardousGoodsLabel")]
        public HazardousGoodsLabel HazardousGoodsLabel
        {
            get { return fHazardousGoodsLabel; }
            set { SetPropertyValue<HazardousGoodsLabel>(nameof(HazardousGoodsLabel), ref fHazardousGoodsLabel, value); }
        }
        byte[] fEquipmentImage;
        [Size(SizeAttribute.Unlimited)]
        [MemberDesignTimeVisibility(true)]
        public byte[] EquipmentImage
        {
            get { return fEquipmentImage; }
            set { SetPropertyValue<byte[]>(nameof(EquipmentImage), ref fEquipmentImage, value); }
        }
    }

}
