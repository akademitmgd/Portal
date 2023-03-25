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

    public partial class ActivityReportTransaction : XPCustomObject
    {
        Guid fOid;
        [Key(true)]
        public Guid Oid
        {
            get { return fOid; }
            set { SetPropertyValue<Guid>(nameof(Oid), ref fOid, value); }
        }
        ActivityReport fActivityReport;
        [Association(@"ActivityReportTransactionReferencesActivityReport")]
        public ActivityReport ActivityReport
        {
            get { return fActivityReport; }
            set { SetPropertyValue<ActivityReport>(nameof(ActivityReport), ref fActivityReport, value); }
        }
        HazardousGoodsClass fClass;
        [Association(@"ActivityReportTransactionReferencesHazardousGoodsClass")]
        public HazardousGoodsClass Class
        {
            get { return fClass; }
            set { SetPropertyValue<HazardousGoodsClass>(nameof(Class), ref fClass, value); }
        }
        double fAlinanMiktar;
        public double AlinanMiktar
        {
            get { return fAlinanMiktar; }
            set { SetPropertyValue<double>(nameof(AlinanMiktar), ref fAlinanMiktar, value); }
        }
        double fBosaltilanMiktar;
        public double BosaltilanMiktar
        {
            get { return fBosaltilanMiktar; }
            set { SetPropertyValue<double>(nameof(BosaltilanMiktar), ref fBosaltilanMiktar, value); }
        }
        double fDoldurulanMiktar;
        public double DoldurulanMiktar
        {
            get { return fDoldurulanMiktar; }
            set { SetPropertyValue<double>(nameof(DoldurulanMiktar), ref fDoldurulanMiktar, value); }
        }
        double fPaketlenenMiktar;
        public double PaketlenenMiktar
        {
            get { return fPaketlenenMiktar; }
            set { SetPropertyValue<double>(nameof(PaketlenenMiktar), ref fPaketlenenMiktar, value); }
        }
        double fYuklenenMiktar;
        public double YuklenenMiktar
        {
            get { return fYuklenenMiktar; }
            set { SetPropertyValue<double>(nameof(YuklenenMiktar), ref fYuklenenMiktar, value); }
        }
        double fTasinanMiktar;
        public double TasinanMiktar
        {
            get { return fTasinanMiktar; }
            set { SetPropertyValue<double>(nameof(TasinanMiktar), ref fTasinanMiktar, value); }
        }
        double fKarayoluAmbalajliTasinan;
        public double KarayoluAmbalajliTasinan
        {
            get { return fKarayoluAmbalajliTasinan; }
            set { SetPropertyValue<double>(nameof(KarayoluAmbalajliTasinan), ref fKarayoluAmbalajliTasinan, value); }
        }
        double fKarayoluDokmeTasinan;
        public double KarayoluDokmeTasinan
        {
            get { return fKarayoluDokmeTasinan; }
            set { SetPropertyValue<double>(nameof(KarayoluDokmeTasinan), ref fKarayoluDokmeTasinan, value); }
        }
        double fKarayoluTanktaTasinan;
        public double KarayoluTanktaTasinan
        {
            get { return fKarayoluTanktaTasinan; }
            set { SetPropertyValue<double>(nameof(KarayoluTanktaTasinan), ref fKarayoluTanktaTasinan, value); }
        }
        double fDemiryoluAmbalajliTasinan;
        public double DemiryoluAmbalajliTasinan
        {
            get { return fDemiryoluAmbalajliTasinan; }
            set { SetPropertyValue<double>(nameof(DemiryoluAmbalajliTasinan), ref fDemiryoluAmbalajliTasinan, value); }
        }
        double fDemiryoluDokmeTasinan;
        public double DemiryoluDokmeTasinan
        {
            get { return fDemiryoluDokmeTasinan; }
            set { SetPropertyValue<double>(nameof(DemiryoluDokmeTasinan), ref fDemiryoluDokmeTasinan, value); }
        }
        double fDemiryoluTanktaTasinan;
        public double DemiryoluTanktaTasinan
        {
            get { return fDemiryoluTanktaTasinan; }
            set { SetPropertyValue<double>(nameof(DemiryoluTanktaTasinan), ref fDemiryoluTanktaTasinan, value); }
        }
        double fDenizyoluAmbalajliTasinan;
        public double DenizyoluAmbalajliTasinan
        {
            get { return fDenizyoluAmbalajliTasinan; }
            set { SetPropertyValue<double>(nameof(DenizyoluAmbalajliTasinan), ref fDenizyoluAmbalajliTasinan, value); }
        }
        double fDenizyoluDokmeTasinan;
        public double DenizyoluDokmeTasinan
        {
            get { return fDenizyoluDokmeTasinan; }
            set { SetPropertyValue<double>(nameof(DenizyoluDokmeTasinan), ref fDenizyoluDokmeTasinan, value); }
        }
        double fDenizyoluTanktaTasinan;
        public double DenizyoluTanktaTasinan
        {
            get { return fDenizyoluTanktaTasinan; }
            set { SetPropertyValue<double>(nameof(DenizyoluTanktaTasinan), ref fDenizyoluTanktaTasinan, value); }
        }
        double fKarmaAmbalajliTasinan;
        public double KarmaAmbalajliTasinan
        {
            get { return fKarmaAmbalajliTasinan; }
            set { SetPropertyValue<double>(nameof(KarmaAmbalajliTasinan), ref fKarmaAmbalajliTasinan, value); }
        }
        double fKarmaDokmeTasinan;
        public double KarmaDokmeTasinan
        {
            get { return fKarmaDokmeTasinan; }
            set { SetPropertyValue<double>(nameof(KarmaDokmeTasinan), ref fKarmaDokmeTasinan, value); }
        }
        double fKarmaTanktaTasinan;
        public double KarmaTanktaTasinan
        {
            get { return fKarmaTanktaTasinan; }
            set { SetPropertyValue<double>(nameof(KarmaTanktaTasinan), ref fKarmaTanktaTasinan, value); }
        }
        string fUnit;
        public string Unit
        {
            get { return fUnit; }
            set { SetPropertyValue<string>(nameof(Unit), ref fUnit, value); }
        }
        Unitset fUnitset;
        [Association(@"ActivityReportTransactionReferencesUnitset")]
        public Unitset Unitset
        {
            get { return fUnitset; }
            set { SetPropertyValue<Unitset>(nameof(Unitset), ref fUnitset, value); }
        }
    }

}
