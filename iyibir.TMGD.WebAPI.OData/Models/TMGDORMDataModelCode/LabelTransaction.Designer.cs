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

    public partial class LabelTransaction : XPCustomObject
    {
        Guid fOid;
        [Key(true)]
        public Guid Oid
        {
            get { return fOid; }
            set { SetPropertyValue<Guid>(nameof(Oid), ref fOid, value); }
        }
        HazardousGoods fHazardousGoods;
        [Association(@"LabelTransactionReferencesHazardousGoods")]
        public HazardousGoods HazardousGoods
        {
            get { return fHazardousGoods; }
            set { SetPropertyValue<HazardousGoods>(nameof(HazardousGoods), ref fHazardousGoods, value); }
        }
        int fLineNumber;
        public int LineNumber
        {
            get { return fLineNumber; }
            set { SetPropertyValue<int>(nameof(LineNumber), ref fLineNumber, value); }
        }
        HazardousGoodsLabel fHazardousGoodsLabel;
        [Association(@"LabelTransactionReferencesHazardousGoodsLabel")]
        public HazardousGoodsLabel HazardousGoodsLabel
        {
            get { return fHazardousGoodsLabel; }
            set { SetPropertyValue<HazardousGoodsLabel>(nameof(HazardousGoodsLabel), ref fHazardousGoodsLabel, value); }
        }
    }

}
