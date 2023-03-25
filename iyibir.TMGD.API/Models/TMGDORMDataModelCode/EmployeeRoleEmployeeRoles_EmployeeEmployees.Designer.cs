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

    public partial class EmployeeRoleEmployeeRoles_EmployeeEmployees : XPBaseObject
    {
        Employee fEmployees;
        [Indexed(@"EmployeeRoles", Name = @"iEmployeesEmployeeRoles_EmployeeRoleEmployeeRoles_EmployeeEmployees", Unique = true)]
        [Association(@"EmployeeRoleEmployeeRoles_EmployeeEmployeesReferencesEmployee")]
        public Employee Employees
        {
            get { return fEmployees; }
            set { SetPropertyValue<Employee>(nameof(Employees), ref fEmployees, value); }
        }
        EmployeeRole fEmployeeRoles;
        [Association(@"EmployeeRoleEmployeeRoles_EmployeeEmployeesReferencesEmployeeRole")]
        public EmployeeRole EmployeeRoles
        {
            get { return fEmployeeRoles; }
            set { SetPropertyValue<EmployeeRole>(nameof(EmployeeRoles), ref fEmployeeRoles, value); }
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
