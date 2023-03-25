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

    public partial class DistributionOfTaskSubject : XPCustomObject
    {
        Guid fOid;
        [Key(true)]
        public Guid Oid
        {
            get { return fOid; }
            set { SetPropertyValue<Guid>(nameof(Oid), ref fOid, value); }
        }
        DistributionOfTask fDistributionOfTask;
        [Association(@"DistributionOfTaskSubjectReferencesDistributionOfTask")]
        public DistributionOfTask DistributionOfTask
        {
            get { return fDistributionOfTask; }
            set { SetPropertyValue<DistributionOfTask>(nameof(DistributionOfTask), ref fDistributionOfTask, value); }
        }
        string fSubject;
        public string Subject
        {
            get { return fSubject; }
            set { SetPropertyValue<string>(nameof(Subject), ref fSubject, value); }
        }
        [Association(@"DistributionOfTaskSubjectAuthReferencesDistributionOfTaskSubject")]
        public XPCollection<DistributionOfTaskSubjectAuth> DistributionOfTaskSubjectAuths { get { return GetCollection<DistributionOfTaskSubjectAuth>(nameof(DistributionOfTaskSubjectAuths)); } }
        [Association(@"DistributionOfTaskSubjectDetailReferencesDistributionOfTaskSubject")]
        public XPCollection<DistributionOfTaskSubjectDetail> DistributionOfTaskSubjectDetails { get { return GetCollection<DistributionOfTaskSubjectDetail>(nameof(DistributionOfTaskSubjectDetails)); } }
    }

}
