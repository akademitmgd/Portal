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

    public partial class DangerousGoodInvolved : XPCustomObject
    {
        Guid fOid;
        [Key(true)]
        public Guid Oid
        {
            get { return fOid; }
            set { SetPropertyValue<Guid>(nameof(Oid), ref fOid, value); }
        }
        ReportOnOccurrence fReportOnOccurrence;
        [Association(@"DangerousGoodInvolvedReferencesReportOnOccurrence")]
        public ReportOnOccurrence ReportOnOccurrence
        {
            get { return fReportOnOccurrence; }
            set { SetPropertyValue<ReportOnOccurrence>(nameof(ReportOnOccurrence), ref fReportOnOccurrence, value); }
        }
        HazardousGoods fHazardousGoods;
        [Association(@"DangerousGoodInvolvedReferencesHazardousGoods")]
        public HazardousGoods HazardousGoods
        {
            get { return fHazardousGoods; }
            set { SetPropertyValue<HazardousGoods>(nameof(HazardousGoods), ref fHazardousGoods, value); }
        }
        HazardousGoodsClass fClass;
        [Association(@"DangerousGoodInvolvedReferencesHazardousGoodsClass")]
        public HazardousGoodsClass Class
        {
            get { return fClass; }
            set { SetPropertyValue<HazardousGoodsClass>(nameof(Class), ref fClass, value); }
        }
        PackingGroup fPackingGroup;
        [Association(@"DangerousGoodInvolvedReferencesPackingGroup")]
        public PackingGroup PackingGroup
        {
            get { return fPackingGroup; }
            set { SetPropertyValue<PackingGroup>(nameof(PackingGroup), ref fPackingGroup, value); }
        }
        EstimatedQuantityOfLossOfProduct fEstimatedQuantityOfLossOfProduct;
        [Association(@"DangerousGoodInvolvedReferencesEstimatedQuantityOfLossOfProduct")]
        public EstimatedQuantityOfLossOfProduct EstimatedQuantityOfLossOfProduct
        {
            get { return fEstimatedQuantityOfLossOfProduct; }
            set { SetPropertyValue<EstimatedQuantityOfLossOfProduct>(nameof(EstimatedQuantityOfLossOfProduct), ref fEstimatedQuantityOfLossOfProduct, value); }
        }
        int fMeansOfContainment;
        public int MeansOfContainment
        {
            get { return fMeansOfContainment; }
            set { SetPropertyValue<int>(nameof(MeansOfContainment), ref fMeansOfContainment, value); }
        }
        string fMeansOfContainmentMaterial;
        public string MeansOfContainmentMaterial
        {
            get { return fMeansOfContainmentMaterial; }
            set { SetPropertyValue<string>(nameof(MeansOfContainmentMaterial), ref fMeansOfContainmentMaterial, value); }
        }
        int fTypeOfFailureMOC;
        public int TypeOfFailureMOC
        {
            get { return fTypeOfFailureMOC; }
            set { SetPropertyValue<int>(nameof(TypeOfFailureMOC), ref fTypeOfFailureMOC, value); }
        }
    }

}
