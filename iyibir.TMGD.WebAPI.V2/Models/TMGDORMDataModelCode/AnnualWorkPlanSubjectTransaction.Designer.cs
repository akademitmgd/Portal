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

    public partial class AnnualWorkPlanSubjectTransaction : XPCustomObject
    {
        Guid fOid;
        [Key(true)]
        public Guid Oid
        {
            get { return fOid; }
            set { SetPropertyValue<Guid>(nameof(Oid), ref fOid, value); }
        }
        AnnualWorkPlanSubject fAnnualWorkPlanSubject;
        [Association(@"AnnualWorkPlanSubjectTransactionReferencesAnnualWorkPlanSubject")]
        public AnnualWorkPlanSubject AnnualWorkPlanSubject
        {
            get { return fAnnualWorkPlanSubject; }
            set { SetPropertyValue<AnnualWorkPlanSubject>(nameof(AnnualWorkPlanSubject), ref fAnnualWorkPlanSubject, value); }
        }
        int fMonth;
        public int Month
        {
            get { return fMonth; }
            set { SetPropertyValue<int>(nameof(Month), ref fMonth, value); }
        }
        bool fPrimary;
        public bool Primary
        {
            get { return fPrimary; }
            set { SetPropertyValue<bool>(nameof(Primary), ref fPrimary, value); }
        }
        bool fSecondary;
        public bool Secondary
        {
            get { return fSecondary; }
            set { SetPropertyValue<bool>(nameof(Secondary), ref fSecondary, value); }
        }
        bool fThirdy;
        public bool Thirdy
        {
            get { return fThirdy; }
            set { SetPropertyValue<bool>(nameof(Thirdy), ref fThirdy, value); }
        }
        bool fFourty;
        public bool Fourty
        {
            get { return fFourty; }
            set { SetPropertyValue<bool>(nameof(Fourty), ref fFourty, value); }
        }
    }

}
