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

    public partial class DefaultLegalLegislation : XPCustomObject
    {
        Guid fOid;
        [Key(true)]
        public Guid Oid
        {
            get { return fOid; }
            set { SetPropertyValue<Guid>(nameof(Oid), ref fOid, value); }
        }
        string fLegalLegislation;
        [Size(150)]
        public string LegalLegislation
        {
            get { return fLegalLegislation; }
            set { SetPropertyValue<string>(nameof(LegalLegislation), ref fLegalLegislation, value); }
        }
        [Association(@"AuditDeterminationLegalStatuteReferencesDefaultLegalLegislation")]
        public XPCollection<AuditDeterminationLegalStatute> AuditDeterminationLegalStatutes { get { return GetCollection<AuditDeterminationLegalStatute>(nameof(AuditDeterminationLegalStatutes)); } }
    }

}
