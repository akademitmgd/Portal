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

    public partial class FileData : XPCustomObject
    {
        Guid fOid;
        [Key(true)]
        public Guid Oid
        {
            get { return fOid; }
            set { SetPropertyValue<Guid>(nameof(Oid), ref fOid, value); }
        }
        int fsize;
        public int size
        {
            get { return fsize; }
            set { SetPropertyValue<int>(nameof(size), ref fsize, value); }
        }
        string fFileName;
        [Size(260)]
        public string FileName
        {
            get { return fFileName; }
            set { SetPropertyValue<string>(nameof(FileName), ref fFileName, value); }
        }
        byte[] fContent;
        [Size(SizeAttribute.Unlimited)]
        [MemberDesignTimeVisibility(true)]
        public byte[] Content
        {
            get { return fContent; }
            set { SetPropertyValue<byte[]>(nameof(Content), ref fContent, value); }
        }
        [Association(@"AuditDeterminationLegalStatuteTransactionReferencesFileData")]
        public XPCollection<AuditDeterminationLegalStatuteTransaction> AuditDeterminationLegalStatuteTransactions { get { return GetCollection<AuditDeterminationLegalStatuteTransaction>(nameof(AuditDeterminationLegalStatuteTransactions)); } }
        [Association(@"CustomDocumentReferencesFileData")]
        public XPCollection<CustomDocument> CustomDocuments { get { return GetCollection<CustomDocument>(nameof(CustomDocuments)); } }
        [Association(@"CustomerReferencesFileData")]
        public XPCollection<Customer> Customers { get { return GetCollection<Customer>(nameof(Customers)); } }
        [Association(@"CustomerDocumentReferencesFileData")]
        public XPCollection<CustomerDocument> CustomerDocuments { get { return GetCollection<CustomerDocument>(nameof(CustomerDocuments)); } }
        [Association(@"CustomerInventoryReferencesFileData")]
        public XPCollection<CustomerInventory> CustomerInventories { get { return GetCollection<CustomerInventory>(nameof(CustomerInventories)); } }
        [Association(@"EmployeeReferencesFileData")]
        public XPCollection<Employee> Employees { get { return GetCollection<Employee>(nameof(Employees)); } }
        [Association(@"EmployeeDocumentReferencesFileData")]
        public XPCollection<EmployeeDocument> EmployeeDocuments { get { return GetCollection<EmployeeDocument>(nameof(EmployeeDocuments)); } }
        [Association(@"SharedFileReferencesFileData")]
        public XPCollection<SharedFile> SharedFiles { get { return GetCollection<SharedFile>(nameof(SharedFiles)); } }
        [Association(@"VehicleDocumentReferencesFileData")]
        public XPCollection<VehicleDocument> VehicleDocuments { get { return GetCollection<VehicleDocument>(nameof(VehicleDocuments)); } }
        [Association(@"VehicleDriverDocumentReferencesFileData")]
        public XPCollection<VehicleDriverDocument> VehicleDriverDocuments { get { return GetCollection<VehicleDriverDocument>(nameof(VehicleDriverDocuments)); } }
    }

}
