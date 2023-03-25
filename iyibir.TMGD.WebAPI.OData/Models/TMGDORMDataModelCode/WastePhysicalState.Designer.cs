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

    public partial class WastePhysicalState : XPCustomObject
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
        [Association(@"CustomerWasteInventoryReferencesWastePhysicalState")]
        public XPCollection<CustomerWasteInventory> CustomerWasteInventories { get { return GetCollection<CustomerWasteInventory>(nameof(CustomerWasteInventories)); } }
        [Association(@"ProductReferencesWastePhysicalState")]
        public XPCollection<Product> Products { get { return GetCollection<Product>(nameof(Products)); } }
    }

}
