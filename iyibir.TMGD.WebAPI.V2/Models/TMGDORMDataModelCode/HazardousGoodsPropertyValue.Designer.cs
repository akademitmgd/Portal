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

    public partial class HazardousGoodsPropertyValue : XPCustomObject
    {
        Guid fOid;
        [Key(true)]
        public Guid Oid
        {
            get { return fOid; }
            set { SetPropertyValue<Guid>(nameof(Oid), ref fOid, value); }
        }
        HazardousGoodsProperty fhazardousGoodsProperty;
        [Association(@"HazardousGoodsPropertyValueReferencesHazardousGoodsProperty")]
        public HazardousGoodsProperty hazardousGoodsProperty
        {
            get { return fhazardousGoodsProperty; }
            set { SetPropertyValue<HazardousGoodsProperty>(nameof(hazardousGoodsProperty), ref fhazardousGoodsProperty, value); }
        }
        string fCode;
        public string Code
        {
            get { return fCode; }
            set { SetPropertyValue<string>(nameof(Code), ref fCode, value); }
        }
        string fName;
        public string Name
        {
            get { return fName; }
            set { SetPropertyValue<string>(nameof(Name), ref fName, value); }
        }
        byte[] fLabelImage;
        [Size(SizeAttribute.Unlimited)]
        [MemberDesignTimeVisibility(true)]
        public byte[] LabelImage
        {
            get { return fLabelImage; }
            set { SetPropertyValue<byte[]>(nameof(LabelImage), ref fLabelImage, value); }
        }
    }

}
