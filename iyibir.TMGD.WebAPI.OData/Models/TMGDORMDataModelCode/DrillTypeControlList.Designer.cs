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

    public partial class DrillTypeControlList : XPCustomObject
    {
        Guid fOid;
        [Key(true)]
        public Guid Oid
        {
            get { return fOid; }
            set { SetPropertyValue<Guid>(nameof(Oid), ref fOid, value); }
        }
        DrillType fDrillType;
        [Association(@"DrillTypeControlListReferencesDrillType")]
        public DrillType DrillType
        {
            get { return fDrillType; }
            set { SetPropertyValue<DrillType>(nameof(DrillType), ref fDrillType, value); }
        }
        string fControlName;
        public string ControlName
        {
            get { return fControlName; }
            set { SetPropertyValue<string>(nameof(ControlName), ref fControlName, value); }
        }
    }

}
