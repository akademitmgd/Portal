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

    public partial class VehicleDriverCompetenceCertificate : XPCustomObject
    {
        Guid fOid;
        [Key(true)]
        public Guid Oid
        {
            get { return fOid; }
            set { SetPropertyValue<Guid>(nameof(Oid), ref fOid, value); }
        }
        VehicleDriver fVehicleDriver;
        [Association(@"VehicleDriverCompetenceCertificateReferencesVehicleDriver")]
        public VehicleDriver VehicleDriver
        {
            get { return fVehicleDriver; }
            set { SetPropertyValue<VehicleDriver>(nameof(VehicleDriver), ref fVehicleDriver, value); }
        }
        string fCompetenceCertificate;
        public string CompetenceCertificate
        {
            get { return fCompetenceCertificate; }
            set { SetPropertyValue<string>(nameof(CompetenceCertificate), ref fCompetenceCertificate, value); }
        }
    }

}
