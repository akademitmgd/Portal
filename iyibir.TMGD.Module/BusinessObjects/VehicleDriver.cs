using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.ComponentModel;

namespace iyibir.TMGD.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("BO_Employee")]
    [DefaultProperty("FullName")]
    public class VehicleDriver : BaseObject
    {
        private string _firstName;
        private string _lastName;
        private string _tckn;
        private Customer _customer;
        private DateTime _srcDateOfValidity;
        private string _src5DocumentNo;
        private DateTime _psychotechnicalExamination;
        public VehicleDriver(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        [RuleRequiredField]
        public string FirstName { get=> _firstName; set=> SetPropertyValue(nameof(FirstName),ref _firstName,value); }

        [RuleRequiredField]
        public string LastName { get=> _lastName; set=> SetPropertyValue(nameof(LastName),ref _lastName,value); }
        public string TCKN { get=>_tckn; set=>SetPropertyValue(nameof(TCKN),ref _tckn,value); }

        [NonPersistent]
        [VisibleInDetailView(false)]
        public string FullName { get {

                if (!IsLoading && !IsSaving)
                    return string.Format("{0} {1}", FirstName ?? string.Empty, LastName ?? string.Empty);
                else
                    return string.Empty;
                
            } }

        [Association("Customer-Drivers")]
        public Customer Customer { get=> _customer; set=> SetPropertyValue(nameof(Customer),ref _customer,value); }


        public DateTime SRCDateOfValidity { get => _srcDateOfValidity; set => SetPropertyValue(nameof(SRCDateOfValidity), ref _srcDateOfValidity, value); }

        public string SRC5DocumentNo { get=> _src5DocumentNo; set=> SetPropertyValue(nameof(SRC5DocumentNo),ref _src5DocumentNo,value); }
        public DateTime PsychotechnicalExamination { get=> _psychotechnicalExamination; set=> SetPropertyValue(nameof(PsychotechnicalExamination),ref _psychotechnicalExamination,value); }

        [Association("VehicleDriver-Documents"), DevExpress.Xpo.Aggregated]
        public XPCollection<VehicleDriverDocument> Documents => GetCollection<VehicleDriverDocument>(nameof(Documents));

        [Association("VehicleDriver-CompetenceCertificates"), DevExpress.Xpo.Aggregated]
        public XPCollection<VehicleDriverCompetenceCertificate> CompetenceCertificates { get=>GetCollection<VehicleDriverCompetenceCertificate>(nameof(CompetenceCertificates)); }
    }
}