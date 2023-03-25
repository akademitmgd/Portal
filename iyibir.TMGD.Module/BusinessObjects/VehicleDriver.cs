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
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        public string FirstName { get=> _firstName; set=> SetPropertyValue(nameof(FirstName),ref _firstName,value); }
        public string LastName { get=> _lastName; set=> SetPropertyValue(nameof(LastName),ref _lastName,value); }

        [RuleRequiredField("RuleRequiredField for VehicleDriver.TCKN", DefaultContexts.Save)]
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

        [RuleRequiredField("RuleRequiredField for VehicleDriver.SRCDateOfValidity", DefaultContexts.Save)]
        public DateTime SRCDateOfValidity { get => _srcDateOfValidity; set => SetPropertyValue(nameof(SRCDateOfValidity), ref _srcDateOfValidity, value); }

        public string SRC5DocumentNo { get=> _src5DocumentNo; set=> SetPropertyValue(nameof(SRC5DocumentNo),ref _src5DocumentNo,value); }
        public DateTime PsychotechnicalExamination { get=> _psychotechnicalExamination; set=> SetPropertyValue(nameof(PsychotechnicalExamination),ref _psychotechnicalExamination,value); }

        [Association("VehicleDriver-Documents"), DevExpress.Xpo.Aggregated]
        public XPCollection<VehicleDriverDocument> Documents => GetCollection<VehicleDriverDocument>(nameof(Documents));

        [Association("VehicleDriver-CompetenceCertificates"), DevExpress.Xpo.Aggregated]
        public XPCollection<VehicleDriverCompetenceCertificate> CompetenceCertificates { get=>GetCollection<VehicleDriverCompetenceCertificate>(nameof(CompetenceCertificates)); }
    }
}