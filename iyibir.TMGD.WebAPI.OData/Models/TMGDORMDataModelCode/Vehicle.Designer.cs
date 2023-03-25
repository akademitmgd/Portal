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

    public partial class Vehicle : XPCustomObject
    {
        Guid fOid;
        [Key(true)]
        public Guid Oid
        {
            get { return fOid; }
            set { SetPropertyValue<Guid>(nameof(Oid), ref fOid, value); }
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
        string fPlate;
        public string Plate
        {
            get { return fPlate; }
            set { SetPropertyValue<string>(nameof(Plate), ref fPlate, value); }
        }
        DateTime fInsurancePolicy;
        public DateTime InsurancePolicy
        {
            get { return fInsurancePolicy; }
            set { SetPropertyValue<DateTime>(nameof(InsurancePolicy), ref fInsurancePolicy, value); }
        }
        double fMaxWeight;
        public double MaxWeight
        {
            get { return fMaxWeight; }
            set { SetPropertyValue<double>(nameof(MaxWeight), ref fMaxWeight, value); }
        }
        Customer fCustomer;
        [Association(@"VehicleReferencesCustomer")]
        public Customer Customer
        {
            get { return fCustomer; }
            set { SetPropertyValue<Customer>(nameof(Customer), ref fCustomer, value); }
        }
        DateTime fTmgdInsurancePolicy;
        public DateTime TmgdInsurancePolicy
        {
            get { return fTmgdInsurancePolicy; }
            set { SetPropertyValue<DateTime>(nameof(TmgdInsurancePolicy), ref fTmgdInsurancePolicy, value); }
        }
        DateTime fAdrInspectionDate;
        public DateTime AdrInspectionDate
        {
            get { return fAdrInspectionDate; }
            set { SetPropertyValue<DateTime>(nameof(AdrInspectionDate), ref fAdrInspectionDate, value); }
        }
        DateTime fAdrInspectionThreeYearly;
        public DateTime AdrInspectionThreeYearly
        {
            get { return fAdrInspectionThreeYearly; }
            set { SetPropertyValue<DateTime>(nameof(AdrInspectionThreeYearly), ref fAdrInspectionThreeYearly, value); }
        }
        DateTime fAdrInspectionSixYearly;
        public DateTime AdrInspectionSixYearly
        {
            get { return fAdrInspectionSixYearly; }
            set { SetPropertyValue<DateTime>(nameof(AdrInspectionSixYearly), ref fAdrInspectionSixYearly, value); }
        }
        DateTime fTuvTurkInpectionDate;
        public DateTime TuvTurkInpectionDate
        {
            get { return fTuvTurkInpectionDate; }
            set { SetPropertyValue<DateTime>(nameof(TuvTurkInpectionDate), ref fTuvTurkInpectionDate, value); }
        }
        DateTime fExhaustInspectionDate;
        public DateTime ExhaustInspectionDate
        {
            get { return fExhaustInspectionDate; }
            set { SetPropertyValue<DateTime>(nameof(ExhaustInspectionDate), ref fExhaustInspectionDate, value); }
        }
        string fDocumentType;
        public string DocumentType
        {
            get { return fDocumentType; }
            set { SetPropertyValue<string>(nameof(DocumentType), ref fDocumentType, value); }
        }
        string fDocumentNumber;
        public string DocumentNumber
        {
            get { return fDocumentNumber; }
            set { SetPropertyValue<string>(nameof(DocumentNumber), ref fDocumentNumber, value); }
        }
        string fDocumentValidityDate;
        public string DocumentValidityDate
        {
            get { return fDocumentValidityDate; }
            set { SetPropertyValue<string>(nameof(DocumentValidityDate), ref fDocumentValidityDate, value); }
        }
        string fInspectionValidityDate;
        public string InspectionValidityDate
        {
            get { return fInspectionValidityDate; }
            set { SetPropertyValue<string>(nameof(InspectionValidityDate), ref fInspectionValidityDate, value); }
        }
        DateTime fExtinguisherDate;
        public DateTime ExtinguisherDate
        {
            get { return fExtinguisherDate; }
            set { SetPropertyValue<DateTime>(nameof(ExtinguisherDate), ref fExtinguisherDate, value); }
        }
        int fVehicleType;
        public int VehicleType
        {
            get { return fVehicleType; }
            set { SetPropertyValue<int>(nameof(VehicleType), ref fVehicleType, value); }
        }
        [Association(@"TransportDocumentReferencesVehicle")]
        public XPCollection<TransportDocument> TransportDocuments { get { return GetCollection<TransportDocument>(nameof(TransportDocuments)); } }
        [Association(@"TransportDocumentReferencesVehicle1")]
        public XPCollection<TransportDocument> TransportDocuments1 { get { return GetCollection<TransportDocument>(nameof(TransportDocuments1)); } }
        [Association(@"VehicleControlDocumentReferencesVehicle")]
        public XPCollection<VehicleControlDocument> VehicleControlDocuments { get { return GetCollection<VehicleControlDocument>(nameof(VehicleControlDocuments)); } }
        [Association(@"VehicleDocumentReferencesVehicle")]
        public XPCollection<VehicleDocument> VehicleDocuments { get { return GetCollection<VehicleDocument>(nameof(VehicleDocuments)); } }
    }

}
