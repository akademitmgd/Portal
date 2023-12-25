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
    [NavigationItem(false)]
    public class VehicleDriverCompetenceCertificate : BaseObject
    {
        private VehicleDriver _vehicleDriver;
        private string _competenceCertificate;
        public VehicleDriverCompetenceCertificate(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        [Association("VehicleDriver-CompetenceCertificates")]
        public VehicleDriver VehicleDriver { get => _vehicleDriver; set => SetPropertyValue(nameof(VehicleDriver), ref _vehicleDriver, value); }

        [ModelDefault("AllowEdit","False")]
        public string CompetenceCertificate { get=> _competenceCertificate; set=>SetPropertyValue(nameof(CompetenceCertificate),ref _competenceCertificate,value); }
    }
}