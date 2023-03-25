using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace iyibir.TMGD.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("BO_Vendor")]
    [DefaultProperty("Plate")]
    public class Vehicle : BaseObject
    {
        private string _code;
        private string _name;
        private string _plate;
        private Customer _customer;
        private DateTime _insurancePolicy;
        private DateTime _tmgdInsurancePolicy;
        private DateTime _adrInspectionDate;
        private DateTime _adrInspectionThreeYearly;
        private DateTime _adrInspectionSixYearly;
        private DateTime _tuvTurkInpectionDate;
        private DateTime _exhaustInspectionDate;
        private double _maxWeight;
        private string _documentType;
        private string _documentNumber;
        private string _documentValidityDate;
        private string _inspectionValidityDate;
        private DateTime _extinguisherDate;
        private VehicleType _vehicleType;
        public Vehicle(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (Session.IsNewObject(this))
            {
                int count = Session.GetObjects(Session.GetClassInfo<Vehicle>(), null, null, 0, true, true).Count;
                count = count + 1;
                this.Code = string.Format("{0}", count.ToString().PadLeft(4, '0'));
            }
        }

        public VehicleType VehicleType { get=> _vehicleType; set=> SetPropertyValue(nameof(VehicleType),ref _vehicleType,value); }

        [RuleRequiredField("RuleRequiredField for Vehicle.Code", DefaultContexts.Save)]
        public string Code { get=> _plate; set=> SetPropertyValue(nameof(Code),ref _code,value); }

        [RuleRequiredField("RuleRequiredField for Vehicle.Name", DefaultContexts.Save)]
        public string Name { get=> _name; set=> SetPropertyValue(nameof(Name),ref _name,value); }

        [RuleRequiredField("RuleRequiredField for Vehicle.Plate", DefaultContexts.Save)]
        public string Plate { get=> _plate; set=> SetPropertyValue(nameof(Plate),ref _plate,value); }

        [RuleRequiredField("RuleRequiredField for Vehicle.InsurancePolicy", DefaultContexts.Save)]
        public DateTime InsurancePolicy { get => _insurancePolicy; set => SetPropertyValue(nameof(InsurancePolicy), ref _insurancePolicy, value); }

        [RuleRequiredField]
        public DateTime TmgdInsurancePolicy { get=> _tmgdInsurancePolicy; set=> SetPropertyValue(nameof(TmgdInsurancePolicy),ref _tmgdInsurancePolicy,value); }
        public DateTime AdrInspectionDate { get=> _adrInspectionDate; set=> SetPropertyValue(nameof(AdrInspectionDate),ref _adrInspectionDate,value); }
        public DateTime AdrInspectionThreeYearly { get=> _adrInspectionThreeYearly; set=> SetPropertyValue(nameof(AdrInspectionThreeYearly),ref _adrInspectionThreeYearly,value); }
        public DateTime AdrInspectionSixYearly { get=> _adrInspectionSixYearly; set=> SetPropertyValue(nameof(AdrInspectionSixYearly),ref _adrInspectionSixYearly,value); }
        public DateTime TuvTurkInpectionDate { get=> _tuvTurkInpectionDate; set=> SetPropertyValue(nameof(TuvTurkInpectionDate),ref _tuvTurkInpectionDate,value); }
        public DateTime ExhaustInspectionDate { get=> _exhaustInspectionDate; set=> SetPropertyValue(nameof(ExhaustInspectionDate),ref _exhaustInspectionDate,value); }
        public double MaxWeight { get=>_maxWeight; set=> SetPropertyValue(nameof(MaxWeight),ref _maxWeight,value); }

        [ModelDefault("AllowEdit","False")]
        public string DocumentType { get=>_documentType; set=>SetPropertyValue(nameof(DocumentType),ref _documentType,value); }

        [ModelDefault("AllowEdit", "False")]
        public string DocumentNumber { get => _documentNumber; set => SetPropertyValue(nameof(DocumentNumber), ref _documentNumber, value); }

        [ModelDefault("AllowEdit", "False")]
        public string DocumentValidityDate { get => _documentValidityDate; set => SetPropertyValue(nameof(DocumentValidityDate), ref _documentValidityDate, value); }

        [ModelDefault("AllowEdit", "False")]
        public string InspectionValidityDate { get => _inspectionValidityDate; set => SetPropertyValue(nameof(InspectionValidityDate), ref _inspectionValidityDate, value); }

        [Association("Customer-Vehicles")]
        public Customer Customer { get=> _customer; set=> SetPropertyValue(nameof(Customer),ref _customer,value); }

        public DateTime ExtinguisherDate { get=> _extinguisherDate; set=> SetPropertyValue(nameof(ExtinguisherDate),ref _exhaustInspectionDate,value); }

        [Association("Vehicle-Documents"),DevExpress.Xpo.Aggregated]
        public XPCollection<VehicleDocument> Documents => GetCollection<VehicleDocument>(nameof(Documents));
    }
}