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

    public partial class Announcement : XPCustomObject
    {
        Guid fOid;
        [Key(true)]
        public Guid Oid
        {
            get { return fOid; }
            set { SetPropertyValue<Guid>(nameof(Oid), ref fOid, value); }
        }
        string fTitle;
        public string Title
        {
            get { return fTitle; }
            set { SetPropertyValue<string>(nameof(Title), ref fTitle, value); }
        }
        Employee fCreatedBy;
        [Association(@"AnnouncementReferencesEmployee")]
        public Employee CreatedBy
        {
            get { return fCreatedBy; }
            set { SetPropertyValue<Employee>(nameof(CreatedBy), ref fCreatedBy, value); }
        }
        DateTime fCreatedOn;
        public DateTime CreatedOn
        {
            get { return fCreatedOn; }
            set { SetPropertyValue<DateTime>(nameof(CreatedOn), ref fCreatedOn, value); }
        }
        string fDescription;
        [Size(SizeAttribute.Unlimited)]
        public string Description
        {
            get { return fDescription; }
            set { SetPropertyValue<string>(nameof(Description), ref fDescription, value); }
        }
        bool fIsActive;
        public bool IsActive
        {
            get { return fIsActive; }
            set { SetPropertyValue<bool>(nameof(IsActive), ref fIsActive, value); }
        }
        [Association(@"AnnouncementUserReferencesAnnouncement")]
        public XPCollection<AnnouncementUser> AnnouncementUsers { get { return GetCollection<AnnouncementUser>(nameof(AnnouncementUsers)); } }
        [Association(@"EmployeeEmployees_AnnouncementAnnouncementsReferencesAnnouncement")]
        public XPCollection<EmployeeEmployees_AnnouncementAnnouncements> EmployeeEmployees_AnnouncementAnnouncementss { get { return GetCollection<EmployeeEmployees_AnnouncementAnnouncements>(nameof(EmployeeEmployees_AnnouncementAnnouncementss)); } }
    }

}
