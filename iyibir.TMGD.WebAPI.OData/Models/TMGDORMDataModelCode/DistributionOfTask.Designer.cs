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

    public partial class DistributionOfTask : XPCustomObject
    {
        Guid fOid;
        [Key(true)]
        public Guid Oid
        {
            get { return fOid; }
            set { SetPropertyValue<Guid>(nameof(Oid), ref fOid, value); }
        }
        DateTime fBeginDate;
        public DateTime BeginDate
        {
            get { return fBeginDate; }
            set { SetPropertyValue<DateTime>(nameof(BeginDate), ref fBeginDate, value); }
        }
        double fBeginTime;
        public double BeginTime
        {
            get { return fBeginTime; }
            set { SetPropertyValue<double>(nameof(BeginTime), ref fBeginTime, value); }
        }
        string fCode;
        public string Code
        {
            get { return fCode; }
            set { SetPropertyValue<string>(nameof(Code), ref fCode, value); }
        }
        string fName;
        public string Name
        {
            get { return fName; }
            set { SetPropertyValue<string>(nameof(Name), ref fName, value); }
        }
        Sector fSector;
        [Association(@"DistributionOfTaskReferencesSector")]
        public Sector Sector
        {
            get { return fSector; }
            set { SetPropertyValue<Sector>(nameof(Sector), ref fSector, value); }
        }
        string fActivityCertificate;
        public string ActivityCertificate
        {
            get { return fActivityCertificate; }
            set { SetPropertyValue<string>(nameof(ActivityCertificate), ref fActivityCertificate, value); }
        }
        DateTime fDateOfValidity;
        public DateTime DateOfValidity
        {
            get { return fDateOfValidity; }
            set { SetPropertyValue<DateTime>(nameof(DateOfValidity), ref fDateOfValidity, value); }
        }
        Customer fCustomer;
        [Association(@"DistributionOfTaskReferencesCustomer")]
        public Customer Customer
        {
            get { return fCustomer; }
            set { SetPropertyValue<Customer>(nameof(Customer), ref fCustomer, value); }
        }
        CustomerContact fCustomerContact;
        [Association(@"DistributionOfTaskReferencesCustomerContact")]
        public CustomerContact CustomerContact
        {
            get { return fCustomerContact; }
            set { SetPropertyValue<CustomerContact>(nameof(CustomerContact), ref fCustomerContact, value); }
        }
        bool fConsignor;
        public bool Consignor
        {
            get { return fConsignor; }
            set { SetPropertyValue<bool>(nameof(Consignor), ref fConsignor, value); }
        }
        bool fCarrier;
        public bool Carrier
        {
            get { return fCarrier; }
            set { SetPropertyValue<bool>(nameof(Carrier), ref fCarrier, value); }
        }
        bool fConsignee;
        public bool Consignee
        {
            get { return fConsignee; }
            set { SetPropertyValue<bool>(nameof(Consignee), ref fConsignee, value); }
        }
        bool fLoader;
        public bool Loader
        {
            get { return fLoader; }
            set { SetPropertyValue<bool>(nameof(Loader), ref fLoader, value); }
        }
        bool fUnloader;
        public bool Unloader
        {
            get { return fUnloader; }
            set { SetPropertyValue<bool>(nameof(Unloader), ref fUnloader, value); }
        }
        bool fPacker;
        public bool Packer
        {
            get { return fPacker; }
            set { SetPropertyValue<bool>(nameof(Packer), ref fPacker, value); }
        }
        bool fFiller;
        public bool Filler
        {
            get { return fFiller; }
            set { SetPropertyValue<bool>(nameof(Filler), ref fFiller, value); }
        }
        bool fTankContainer;
        public bool TankContainer
        {
            get { return fTankContainer; }
            set { SetPropertyValue<bool>(nameof(TankContainer), ref fTankContainer, value); }
        }
        string fAddress;
        public string Address
        {
            get { return fAddress; }
            set { SetPropertyValue<string>(nameof(Address), ref fAddress, value); }
        }
        string fTMGDCertificate;
        public string TMGDCertificate
        {
            get { return fTMGDCertificate; }
            set { SetPropertyValue<string>(nameof(TMGDCertificate), ref fTMGDCertificate, value); }
        }
        Employee fOwner;
        [Association(@"DistributionOfTaskReferencesEmployee")]
        public Employee Owner
        {
            get { return fOwner; }
            set { SetPropertyValue<Employee>(nameof(Owner), ref fOwner, value); }
        }
        DateTime fEndDate;
        public DateTime EndDate
        {
            get { return fEndDate; }
            set { SetPropertyValue<DateTime>(nameof(EndDate), ref fEndDate, value); }
        }
        double fEndTime;
        public double EndTime
        {
            get { return fEndTime; }
            set { SetPropertyValue<double>(nameof(EndTime), ref fEndTime, value); }
        }
        [Association(@"DistributionOfTaskSubjectReferencesDistributionOfTask")]
        public XPCollection<DistributionOfTaskSubject> DistributionOfTaskSubjects { get { return GetCollection<DistributionOfTaskSubject>(nameof(DistributionOfTaskSubjects)); } }
    }

}
