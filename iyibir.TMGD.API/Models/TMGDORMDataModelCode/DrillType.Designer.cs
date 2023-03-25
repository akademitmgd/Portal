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

    public partial class DrillType : XPCustomObject
    {
        Guid fOid;
        [Key(true)]
        public Guid Oid
        {
            get { return fOid; }
            set { SetPropertyValue<Guid>(nameof(Oid), ref fOid, value); }
        }
        string fName;
        public string Name
        {
            get { return fName; }
            set { SetPropertyValue<string>(nameof(Name), ref fName, value); }
        }
        string fScenario;
        public string Scenario
        {
            get { return fScenario; }
            set { SetPropertyValue<string>(nameof(Scenario), ref fScenario, value); }
        }
        bool fIsActive;
        public bool IsActive
        {
            get { return fIsActive; }
            set { SetPropertyValue<bool>(nameof(IsActive), ref fIsActive, value); }
        }
        [Association(@"DrillFormReferencesDrillType")]
        public XPCollection<DrillForm> DrillForms { get { return GetCollection<DrillForm>(nameof(DrillForms)); } }
        [Association(@"DrillTypeControlListReferencesDrillType")]
        public XPCollection<DrillTypeControlList> DrillTypeControlLists { get { return GetCollection<DrillTypeControlList>(nameof(DrillTypeControlLists)); } }
    }

}
