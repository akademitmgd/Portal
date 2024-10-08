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
namespace iyibir.TMGD.API.Models.iyibir_TMGD
{

    public partial class ReportOnOccurrence : XPCustomObject
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
        DateTime fCreatedOn;
        public DateTime CreatedOn
        {
            get { return fCreatedOn; }
            set { SetPropertyValue<DateTime>(nameof(CreatedOn), ref fCreatedOn, value); }
        }
        string fCarrierRailwayInsfrastructureOperator;
        public string CarrierRailwayInsfrastructureOperator
        {
            get { return fCarrierRailwayInsfrastructureOperator; }
            set { SetPropertyValue<string>(nameof(CarrierRailwayInsfrastructureOperator), ref fCarrierRailwayInsfrastructureOperator, value); }
        }
        string fAddress;
        public string Address
        {
            get { return fAddress; }
            set { SetPropertyValue<string>(nameof(Address), ref fAddress, value); }
        }
        string fContactName;
        public string ContactName
        {
            get { return fContactName; }
            set { SetPropertyValue<string>(nameof(ContactName), ref fContactName, value); }
        }
        string fTelephone;
        public string Telephone
        {
            get { return fTelephone; }
            set { SetPropertyValue<string>(nameof(Telephone), ref fTelephone, value); }
        }
        string fFax;
        public string Fax
        {
            get { return fFax; }
            set { SetPropertyValue<string>(nameof(Fax), ref fFax, value); }
        }
        bool fIsRail;
        public bool IsRail
        {
            get { return fIsRail; }
            set { SetPropertyValue<bool>(nameof(IsRail), ref fIsRail, value); }
        }
        string fWagonNumber;
        public string WagonNumber
        {
            get { return fWagonNumber; }
            set { SetPropertyValue<string>(nameof(WagonNumber), ref fWagonNumber, value); }
        }
        bool fIsRoad;
        public bool IsRoad
        {
            get { return fIsRoad; }
            set { SetPropertyValue<bool>(nameof(IsRoad), ref fIsRoad, value); }
        }
        string fVehicleRegistration;
        public string VehicleRegistration
        {
            get { return fVehicleRegistration; }
            set { SetPropertyValue<string>(nameof(VehicleRegistration), ref fVehicleRegistration, value); }
        }
        DateTime fDateAndLocationOfOccurrence;
        public DateTime DateAndLocationOfOccurrence
        {
            get { return fDateAndLocationOfOccurrence; }
            set { SetPropertyValue<DateTime>(nameof(DateAndLocationOfOccurrence), ref fDateAndLocationOfOccurrence, value); }
        }
        double fTimeAndLocationOfOccurrence;
        public double TimeAndLocationOfOccurrence
        {
            get { return fTimeAndLocationOfOccurrence; }
            set { SetPropertyValue<double>(nameof(TimeAndLocationOfOccurrence), ref fTimeAndLocationOfOccurrence, value); }
        }
        bool fStation;
        public bool Station
        {
            get { return fStation; }
            set { SetPropertyValue<bool>(nameof(Station), ref fStation, value); }
        }
        bool fShuntingMarshallingYard;
        public bool ShuntingMarshallingYard
        {
            get { return fShuntingMarshallingYard; }
            set { SetPropertyValue<bool>(nameof(ShuntingMarshallingYard), ref fShuntingMarshallingYard, value); }
        }
        bool fRailLoadingUnloadingTranshipmentSite;
        public bool RailLoadingUnloadingTranshipmentSite
        {
            get { return fRailLoadingUnloadingTranshipmentSite; }
            set { SetPropertyValue<bool>(nameof(RailLoadingUnloadingTranshipmentSite), ref fRailLoadingUnloadingTranshipmentSite, value); }
        }
        string fRailLocationCountry;
        public string RailLocationCountry
        {
            get { return fRailLocationCountry; }
            set { SetPropertyValue<string>(nameof(RailLocationCountry), ref fRailLocationCountry, value); }
        }
        bool fOpenLine;
        public bool OpenLine
        {
            get { return fOpenLine; }
            set { SetPropertyValue<bool>(nameof(OpenLine), ref fOpenLine, value); }
        }
        string fDescriptionOfLineKilometers;
        public string DescriptionOfLineKilometers
        {
            get { return fDescriptionOfLineKilometers; }
            set { SetPropertyValue<string>(nameof(DescriptionOfLineKilometers), ref fDescriptionOfLineKilometers, value); }
        }
        bool fBuiltUpArea;
        public bool BuiltUpArea
        {
            get { return fBuiltUpArea; }
            set { SetPropertyValue<bool>(nameof(BuiltUpArea), ref fBuiltUpArea, value); }
        }
        bool fRoadLoadingUnloadingTranshipmentSite;
        public bool RoadLoadingUnloadingTranshipmentSite
        {
            get { return fRoadLoadingUnloadingTranshipmentSite; }
            set { SetPropertyValue<bool>(nameof(RoadLoadingUnloadingTranshipmentSite), ref fRoadLoadingUnloadingTranshipmentSite, value); }
        }
        bool fOpenRoad;
        public bool OpenRoad
        {
            get { return fOpenRoad; }
            set { SetPropertyValue<bool>(nameof(OpenRoad), ref fOpenRoad, value); }
        }
        string fRoadLocationCountry;
        public string RoadLocationCountry
        {
            get { return fRoadLocationCountry; }
            set { SetPropertyValue<string>(nameof(RoadLocationCountry), ref fRoadLocationCountry, value); }
        }
        bool fGradientIncline;
        public bool GradientIncline
        {
            get { return fGradientIncline; }
            set { SetPropertyValue<bool>(nameof(GradientIncline), ref fGradientIncline, value); }
        }
        bool fTunnel;
        public bool Tunnel
        {
            get { return fTunnel; }
            set { SetPropertyValue<bool>(nameof(Tunnel), ref fTunnel, value); }
        }
        bool fBridgeUnderpass;
        public bool BridgeUnderpass
        {
            get { return fBridgeUnderpass; }
            set { SetPropertyValue<bool>(nameof(BridgeUnderpass), ref fBridgeUnderpass, value); }
        }
        bool fCrossing;
        public bool Crossing
        {
            get { return fCrossing; }
            set { SetPropertyValue<bool>(nameof(Crossing), ref fCrossing, value); }
        }
        bool fRain;
        public bool Rain
        {
            get { return fRain; }
            set { SetPropertyValue<bool>(nameof(Rain), ref fRain, value); }
        }
        bool fSnow;
        public bool Snow
        {
            get { return fSnow; }
            set { SetPropertyValue<bool>(nameof(Snow), ref fSnow, value); }
        }
        bool fIce;
        public bool Ice
        {
            get { return fIce; }
            set { SetPropertyValue<bool>(nameof(Ice), ref fIce, value); }
        }
        bool fFog;
        public bool Fog
        {
            get { return fFog; }
            set { SetPropertyValue<bool>(nameof(Fog), ref fFog, value); }
        }
        bool fThunderstorm;
        public bool Thunderstorm
        {
            get { return fThunderstorm; }
            set { SetPropertyValue<bool>(nameof(Thunderstorm), ref fThunderstorm, value); }
        }
        bool fStorm;
        public bool Storm
        {
            get { return fStorm; }
            set { SetPropertyValue<bool>(nameof(Storm), ref fStorm, value); }
        }
        short fTemperature;
        public short Temperature
        {
            get { return fTemperature; }
            set { SetPropertyValue<short>(nameof(Temperature), ref fTemperature, value); }
        }
        bool fDerailmentLeavingTheRoad;
        public bool DerailmentLeavingTheRoad
        {
            get { return fDerailmentLeavingTheRoad; }
            set { SetPropertyValue<bool>(nameof(DerailmentLeavingTheRoad), ref fDerailmentLeavingTheRoad, value); }
        }
        bool fCollision;
        public bool Collision
        {
            get { return fCollision; }
            set { SetPropertyValue<bool>(nameof(Collision), ref fCollision, value); }
        }
        bool fOverturningRollingOver;
        public bool OverturningRollingOver
        {
            get { return fOverturningRollingOver; }
            set { SetPropertyValue<bool>(nameof(OverturningRollingOver), ref fOverturningRollingOver, value); }
        }
        bool fFire;
        public bool Fire
        {
            get { return fFire; }
            set { SetPropertyValue<bool>(nameof(Fire), ref fFire, value); }
        }
        bool fExplosion;
        public bool Explosion
        {
            get { return fExplosion; }
            set { SetPropertyValue<bool>(nameof(Explosion), ref fExplosion, value); }
        }
        bool fLoss;
        public bool Loss
        {
            get { return fLoss; }
            set { SetPropertyValue<bool>(nameof(Loss), ref fLoss, value); }
        }
        bool fTechnicalFault;
        public bool TechnicalFault
        {
            get { return fTechnicalFault; }
            set { SetPropertyValue<bool>(nameof(TechnicalFault), ref fTechnicalFault, value); }
        }
        string fAdditionalDescription;
        public string AdditionalDescription
        {
            get { return fAdditionalDescription; }
            set { SetPropertyValue<string>(nameof(AdditionalDescription), ref fAdditionalDescription, value); }
        }
        bool fCauseOfOccurrenceTechnicalFault;
        public bool CauseOfOccurrenceTechnicalFault
        {
            get { return fCauseOfOccurrenceTechnicalFault; }
            set { SetPropertyValue<bool>(nameof(CauseOfOccurrenceTechnicalFault), ref fCauseOfOccurrenceTechnicalFault, value); }
        }
        bool fFaultLoadSecuring;
        public bool FaultLoadSecuring
        {
            get { return fFaultLoadSecuring; }
            set { SetPropertyValue<bool>(nameof(FaultLoadSecuring), ref fFaultLoadSecuring, value); }
        }
        bool fOperationalCause;
        public bool OperationalCause
        {
            get { return fOperationalCause; }
            set { SetPropertyValue<bool>(nameof(OperationalCause), ref fOperationalCause, value); }
        }
        bool fOtherCauseOfOccurrence;
        public bool OtherCauseOfOccurrence
        {
            get { return fOtherCauseOfOccurrence; }
            set { SetPropertyValue<bool>(nameof(OtherCauseOfOccurrence), ref fOtherCauseOfOccurrence, value); }
        }
        string fOtherCauseOfOccurrenceDescription;
        public string OtherCauseOfOccurrenceDescription
        {
            get { return fOtherCauseOfOccurrenceDescription; }
            set { SetPropertyValue<string>(nameof(OtherCauseOfOccurrenceDescription), ref fOtherCauseOfOccurrenceDescription, value); }
        }
        bool fDeath;
        public bool Death
        {
            get { return fDeath; }
            set { SetPropertyValue<bool>(nameof(Death), ref fDeath, value); }
        }
        short fDeathsNumber;
        public short DeathsNumber
        {
            get { return fDeathsNumber; }
            set { SetPropertyValue<short>(nameof(DeathsNumber), ref fDeathsNumber, value); }
        }
        bool fInjured;
        public bool Injured
        {
            get { return fInjured; }
            set { SetPropertyValue<bool>(nameof(Injured), ref fInjured, value); }
        }
        short fInjuredNumber;
        public short InjuredNumber
        {
            get { return fInjuredNumber; }
            set { SetPropertyValue<short>(nameof(InjuredNumber), ref fInjuredNumber, value); }
        }
        bool fLossOfProductYes;
        public bool LossOfProductYes
        {
            get { return fLossOfProductYes; }
            set { SetPropertyValue<bool>(nameof(LossOfProductYes), ref fLossOfProductYes, value); }
        }
        bool fLossOfProductNo;
        public bool LossOfProductNo
        {
            get { return fLossOfProductNo; }
            set { SetPropertyValue<bool>(nameof(LossOfProductNo), ref fLossOfProductNo, value); }
        }
        bool fImminentRiskOfLossOfProduct;
        public bool ImminentRiskOfLossOfProduct
        {
            get { return fImminentRiskOfLossOfProduct; }
            set { SetPropertyValue<bool>(nameof(ImminentRiskOfLossOfProduct), ref fImminentRiskOfLossOfProduct, value); }
        }
        bool fEstimatedLevelOfDamageLess;
        public bool EstimatedLevelOfDamageLess
        {
            get { return fEstimatedLevelOfDamageLess; }
            set { SetPropertyValue<bool>(nameof(EstimatedLevelOfDamageLess), ref fEstimatedLevelOfDamageLess, value); }
        }
        bool fEstimatedLevelOfDamageGreater;
        public bool EstimatedLevelOfDamageGreater
        {
            get { return fEstimatedLevelOfDamageGreater; }
            set { SetPropertyValue<bool>(nameof(EstimatedLevelOfDamageGreater), ref fEstimatedLevelOfDamageGreater, value); }
        }
        bool fInvolvementOfAuthoritiesYes;
        public bool InvolvementOfAuthoritiesYes
        {
            get { return fInvolvementOfAuthoritiesYes; }
            set { SetPropertyValue<bool>(nameof(InvolvementOfAuthoritiesYes), ref fInvolvementOfAuthoritiesYes, value); }
        }
        bool fEvacuationOfPerson;
        public bool EvacuationOfPerson
        {
            get { return fEvacuationOfPerson; }
            set { SetPropertyValue<bool>(nameof(EvacuationOfPerson), ref fEvacuationOfPerson, value); }
        }
        bool fInvolvementOfAuthoritiesNo;
        public bool InvolvementOfAuthoritiesNo
        {
            get { return fInvolvementOfAuthoritiesNo; }
            set { SetPropertyValue<bool>(nameof(InvolvementOfAuthoritiesNo), ref fInvolvementOfAuthoritiesNo, value); }
        }
        bool fClosureOfPublic;
        public bool ClosureOfPublic
        {
            get { return fClosureOfPublic; }
            set { SetPropertyValue<bool>(nameof(ClosureOfPublic), ref fClosureOfPublic, value); }
        }
        Employee fOwner;
        [Association(@"ReportOnOccurrenceReferencesEmployee")]
        public Employee Owner
        {
            get { return fOwner; }
            set { SetPropertyValue<Employee>(nameof(Owner), ref fOwner, value); }
        }
        Customer fCustomer;
        [Association(@"ReportOnOccurrenceReferencesCustomer")]
        public Customer Customer
        {
            get { return fCustomer; }
            set { SetPropertyValue<Customer>(nameof(Customer), ref fCustomer, value); }
        }
        [Association(@"DangerousGoodInvolvedReferencesReportOnOccurrence")]
        public XPCollection<DangerousGoodInvolved> DangerousGoodInvolveds { get { return GetCollection<DangerousGoodInvolved>(nameof(DangerousGoodInvolveds)); } }
    }

}
