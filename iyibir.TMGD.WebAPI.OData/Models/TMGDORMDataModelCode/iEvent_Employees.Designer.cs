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

    [Persistent(@"iEvent-Employees")]
    public partial class iEvent_Employees : XPBaseObject
    {
        Employee fEmployees;
        [Indexed(@"MyAgenda", Name = @"iEmployeesMyAgenda_iEvent-Employees", Unique = true)]
        [Association(@"iEvent_EmployeesReferencesEmployee")]
        public Employee Employees
        {
            get { return fEmployees; }
            set { SetPropertyValue<Employee>(nameof(Employees), ref fEmployees, value); }
        }
        iEvent fMyAgenda;
        [Association(@"iEvent_EmployeesReferencesiEvent")]
        public iEvent MyAgenda
        {
            get { return fMyAgenda; }
            set { SetPropertyValue<iEvent>(nameof(MyAgenda), ref fMyAgenda, value); }
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
