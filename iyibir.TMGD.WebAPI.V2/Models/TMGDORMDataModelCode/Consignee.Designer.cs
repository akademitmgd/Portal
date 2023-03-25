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
namespace iyibir.TMGD.WebAPI.V2.Models.iyibir_TMGD
{

    public partial class Consignee : XPCustomObject
    {
        Guid fOid;
        [Key(true)]
        public Guid Oid
        {
            get { return fOid; }
            set { SetPropertyValue<Guid>(nameof(Oid), ref fOid, value); }
        }
        Customer fCustomer;
        [Association(@"ConsigneeReferencesCustomer")]
        public Customer Customer
        {
            get { return fCustomer; }
            set { SetPropertyValue<Customer>(nameof(Customer), ref fCustomer, value); }
        }
        string fCode;
        public string Code
        {
            get { return fCode; }
            set { SetPropertyValue<string>(nameof(Code), ref fCode, value); }
        }
        string fTitle;
        public string Title
        {
            get { return fTitle; }
            set { SetPropertyValue<string>(nameof(Title), ref fTitle, value); }
        }
        Country fCountry;
        [Association(@"ConsigneeReferencesCountry")]
        public Country Country
        {
            get { return fCountry; }
            set { SetPropertyValue<Country>(nameof(Country), ref fCountry, value); }
        }
        City fCity;
        [Association(@"ConsigneeReferencesCity")]
        public City City
        {
            get { return fCity; }
            set { SetPropertyValue<City>(nameof(City), ref fCity, value); }
        }
        County fCounty;
        [Association(@"ConsigneeReferencesCounty")]
        public County County
        {
            get { return fCounty; }
            set { SetPropertyValue<County>(nameof(County), ref fCounty, value); }
        }
        string fTelephone;
        public string Telephone
        {
            get { return fTelephone; }
            set { SetPropertyValue<string>(nameof(Telephone), ref fTelephone, value); }
        }
        string fOtherTelephone;
        public string OtherTelephone
        {
            get { return fOtherTelephone; }
            set { SetPropertyValue<string>(nameof(OtherTelephone), ref fOtherTelephone, value); }
        }
        string fEMail;
        public string EMail
        {
            get { return fEMail; }
            set { SetPropertyValue<string>(nameof(EMail), ref fEMail, value); }
        }
        string fAddress;
        public string Address
        {
            get { return fAddress; }
            set { SetPropertyValue<string>(nameof(Address), ref fAddress, value); }
        }
        bool fIsActive;
        public bool IsActive
        {
            get { return fIsActive; }
            set { SetPropertyValue<bool>(nameof(IsActive), ref fIsActive, value); }
        }
        bool fIsPerson;
        public bool IsPerson
        {
            get { return fIsPerson; }
            set { SetPropertyValue<bool>(nameof(IsPerson), ref fIsPerson, value); }
        }
        string fTCKN;
        [Size(11)]
        public string TCKN
        {
            get { return fTCKN; }
            set { SetPropertyValue<string>(nameof(TCKN), ref fTCKN, value); }
        }
        string fFirstName;
        public string FirstName
        {
            get { return fFirstName; }
            set { SetPropertyValue<string>(nameof(FirstName), ref fFirstName, value); }
        }
        string fLastName;
        public string LastName
        {
            get { return fLastName; }
            set { SetPropertyValue<string>(nameof(LastName), ref fLastName, value); }
        }
        string fTaxOffice;
        public string TaxOffice
        {
            get { return fTaxOffice; }
            set { SetPropertyValue<string>(nameof(TaxOffice), ref fTaxOffice, value); }
        }
        string fTaxNumber;
        public string TaxNumber
        {
            get { return fTaxNumber; }
            set { SetPropertyValue<string>(nameof(TaxNumber), ref fTaxNumber, value); }
        }
        int fConsigneeType;
        public int ConsigneeType
        {
            get { return fConsigneeType; }
            set { SetPropertyValue<int>(nameof(ConsigneeType), ref fConsigneeType, value); }
        }
        [Association(@"TransportDocumentReferencesConsignee")]
        public XPCollection<TransportDocument> TransportDocuments { get { return GetCollection<TransportDocument>(nameof(TransportDocuments)); } }
        [Association(@"TransportDocumentReferencesConsignee1")]
        public XPCollection<TransportDocument> TransportDocuments1 { get { return GetCollection<TransportDocument>(nameof(TransportDocuments1)); } }
    }

}
