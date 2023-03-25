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

    public partial class HazardousGoodsProperty : XPCustomObject
    {
        Guid fOid;
        [Key(true)]
        public Guid Oid
        {
            get { return fOid; }
            set { SetPropertyValue<Guid>(nameof(Oid), ref fOid, value); }
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
        HazardousGoodsCategory fCategory;
        [Association(@"HazardousGoodsPropertyReferencesHazardousGoodsCategory")]
        public HazardousGoodsCategory Category
        {
            get { return fCategory; }
            set { SetPropertyValue<HazardousGoodsCategory>(nameof(Category), ref fCategory, value); }
        }
        HazardousGoodsProperty fParentHazardousGoodsProperty;
        [Association(@"HazardousGoodsPropertyReferencesHazardousGoodsProperty")]
        public HazardousGoodsProperty ParentHazardousGoodsProperty
        {
            get { return fParentHazardousGoodsProperty; }
            set { SetPropertyValue<HazardousGoodsProperty>(nameof(ParentHazardousGoodsProperty), ref fParentHazardousGoodsProperty, value); }
        }
        [Association(@"HazardousGoodsPropertyReferencesHazardousGoodsProperty")]
        public XPCollection<HazardousGoodsProperty> HazardousGoodsPropertyCollection { get { return GetCollection<HazardousGoodsProperty>(nameof(HazardousGoodsPropertyCollection)); } }
        [Association(@"HazardousGoodsPropertyValueReferencesHazardousGoodsProperty")]
        public XPCollection<HazardousGoodsPropertyValue> HazardousGoodsPropertyValues { get { return GetCollection<HazardousGoodsPropertyValue>(nameof(HazardousGoodsPropertyValues)); } }
    }

}
