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

    public partial class ActivityLine : XPCustomObject
    {
        Guid fOid;
        [Key(true)]
        public Guid Oid
        {
            get { return fOid; }
            set { SetPropertyValue<Guid>(nameof(Oid), ref fOid, value); }
        }
        Activity fActivity;
        [Association(@"ActivityLineReferencesActivity")]
        public Activity Activity
        {
            get { return fActivity; }
            set { SetPropertyValue<Activity>(nameof(Activity), ref fActivity, value); }
        }
        string fLineNumber;
        public string LineNumber
        {
            get { return fLineNumber; }
            set { SetPropertyValue<string>(nameof(LineNumber), ref fLineNumber, value); }
        }
        ActivitySubject fSubject;
        [Association(@"ActivityLineReferencesActivitySubject")]
        public ActivitySubject Subject
        {
            get { return fSubject; }
            set { SetPropertyValue<ActivitySubject>(nameof(Subject), ref fSubject, value); }
        }
        ActivitySubjectDesc fSubjectDescription;
        [Association(@"ActivityLineReferencesActivitySubjectDesc")]
        public ActivitySubjectDesc SubjectDescription
        {
            get { return fSubjectDescription; }
            set { SetPropertyValue<ActivitySubjectDesc>(nameof(SubjectDescription), ref fSubjectDescription, value); }
        }
        string fDescription;
        [Size(SizeAttribute.Unlimited)]
        public string Description
        {
            get { return fDescription; }
            set { SetPropertyValue<string>(nameof(Description), ref fDescription, value); }
        }
        string fOwner;
        public string Owner
        {
            get { return fOwner; }
            set { SetPropertyValue<string>(nameof(Owner), ref fOwner, value); }
        }
        DateTime fDueDate;
        public DateTime DueDate
        {
            get { return fDueDate; }
            set { SetPropertyValue<DateTime>(nameof(DueDate), ref fDueDate, value); }
        }
        AnnualWorkPlanSubject fAnnualWorkPlanSubject;
        [Association(@"ActivityLineReferencesAnnualWorkPlanSubject")]
        public AnnualWorkPlanSubject AnnualWorkPlanSubject
        {
            get { return fAnnualWorkPlanSubject; }
            set { SetPropertyValue<AnnualWorkPlanSubject>(nameof(AnnualWorkPlanSubject), ref fAnnualWorkPlanSubject, value); }
        }
        int fannualWorkPlanSubjectStatus;
        public int annualWorkPlanSubjectStatus
        {
            get { return fannualWorkPlanSubjectStatus; }
            set { SetPropertyValue<int>(nameof(annualWorkPlanSubjectStatus), ref fannualWorkPlanSubjectStatus, value); }
        }
    }

}
