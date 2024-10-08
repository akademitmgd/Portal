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

    public partial class PermissionPolicyNavigationPermissionsObject : XPCustomObject
    {
        Guid fOid;
        [Key(true)]
        public Guid Oid
        {
            get { return fOid; }
            set { SetPropertyValue<Guid>(nameof(Oid), ref fOid, value); }
        }
        string fItemPath;
        [Size(SizeAttribute.Unlimited)]
        public string ItemPath
        {
            get { return fItemPath; }
            set { SetPropertyValue<string>(nameof(ItemPath), ref fItemPath, value); }
        }
        int fNavigateState;
        public int NavigateState
        {
            get { return fNavigateState; }
            set { SetPropertyValue<int>(nameof(NavigateState), ref fNavigateState, value); }
        }
        PermissionPolicyRole fRole;
        [Association(@"PermissionPolicyNavigationPermissionsObjectReferencesPermissionPolicyRole")]
        public PermissionPolicyRole Role
        {
            get { return fRole; }
            set { SetPropertyValue<PermissionPolicyRole>(nameof(Role), ref fRole, value); }
        }
    }

}
