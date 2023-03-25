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

    public partial class EmployeeEmployees_AnnouncementAnnouncements : XPBaseObject
    {
        Announcement fAnnouncements;
        [Indexed(@"Employees", Name = @"iAnnouncementsEmployees_EmployeeEmployees_AnnouncementAnnouncements", Unique = true)]
        [Association(@"EmployeeEmployees_AnnouncementAnnouncementsReferencesAnnouncement")]
        public Announcement Announcements
        {
            get { return fAnnouncements; }
            set { SetPropertyValue<Announcement>(nameof(Announcements), ref fAnnouncements, value); }
        }
        Employee fEmployees;
        [Association(@"EmployeeEmployees_AnnouncementAnnouncementsReferencesEmployee")]
        public Employee Employees
        {
            get { return fEmployees; }
            set { SetPropertyValue<Employee>(nameof(Employees), ref fEmployees, value); }
        }
        Guid fOID;
        [Key(true)]
        public Guid OID
        {
            get { return fOID; }
            set { SetPropertyValue<Guid>(nameof(OID), ref fOID, value); }
        }
    }

}
