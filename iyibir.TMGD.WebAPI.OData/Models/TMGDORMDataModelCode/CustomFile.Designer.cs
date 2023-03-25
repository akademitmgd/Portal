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

    public partial class CustomFile : XPCustomObject
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
        Employee fOwner;
        [Association(@"CustomFileReferencesEmployee")]
        public Employee Owner
        {
            get { return fOwner; }
            set { SetPropertyValue<Employee>(nameof(Owner), ref fOwner, value); }
        }
        DateTime fCreatedOn;
        public DateTime CreatedOn
        {
            get { return fCreatedOn; }
            set { SetPropertyValue<DateTime>(nameof(CreatedOn), ref fCreatedOn, value); }
        }
        CustomFile fParentFile;
        [Association(@"CustomFileReferencesCustomFile")]
        public CustomFile ParentFile
        {
            get { return fParentFile; }
            set { SetPropertyValue<CustomFile>(nameof(ParentFile), ref fParentFile, value); }
        }
        [Association(@"CustomDocumentReferencesCustomFile")]
        public XPCollection<CustomDocument> CustomDocuments { get { return GetCollection<CustomDocument>(nameof(CustomDocuments)); } }
        [Association(@"CustomFileReferencesCustomFile")]
        public XPCollection<CustomFile> CustomFileCollection { get { return GetCollection<CustomFile>(nameof(CustomFileCollection)); } }
    }

}
