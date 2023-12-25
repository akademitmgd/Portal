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
    [ImageName("BO_List")]
    [NavigationItem("DocumentManagement")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class ReportOnOccurrence : BaseObject
    {
        private string _code;
        private DateTime _createdOn;
        private string _carrierRailwayInsfrastructureOperator;
        private string _address;
        private string _contactName;
        private string _telephone;
        private string _fax;
        private bool _isRail;
        private string _wagonNumber;
        private bool _isRoad;
        private string _vehicleRegistration;
        private DateTime _dateAndLocationOfOccurrence;
        private TimeSpan _timeAndLocationOfOccurrence;
        private bool _station;
        private bool _shuntingMarshallingYard;
        private bool _railLoadingUnloadingTranshipmentSite;
        private string _railLocationCountry;
        private bool _openLine;
        private string _descriptionOfLineKilometers;
        private bool _builtUpArea;
        private bool _roadLoadingUnloadingTranshipmentSite;
        private bool _openRoad;
        private string _roadLocationCountry;
        private bool _gradientIncline;
        private bool _tunnel;
        private bool _bridgeUnderpass;
        private bool _crossing;
        private bool _rain;
        private bool _snow;
        private bool _ice;
        private bool _fog;
        private bool _thunderstorm;
        private bool _storm;
        private short _temperature;
        private bool _derailmentLeavingTheRoad;
        private bool _collision;
        private bool _overturningRollingOver;
        private bool _fire;
        private bool _explosion;
        private bool _loss;
        private bool _technicalFault;
        private string _additionalDescription;
        private bool _causeOfOccurrenceTechnicalFault;
        private bool _faultLoadSecuring;
        private bool _operationalCause;
        private bool _otherCauseOfOccurrence;
        private string _otherCauseOfOccurrenceDescription;
        private bool _death;
        private short _deathNumber;
        private bool _injured;
        private short _injuredNumber;
        private bool _lossOfProductYes;
        private bool _lossOfProductNo;
        private bool _imminentRiskOfLossOfProduct;
        private bool _estimatedLevelOfDamageLess;
        private bool _estimatedLevelOfDamageGreater;
        private bool _involvementOfAuthoritiesYes;
        private bool _evacuationOfPerson;
        private bool _involvementOfAuthoritiesNo;
        private bool _closureOfPublic;
        private Employee _owner;
        private Customer _customer;

        public ReportOnOccurrence(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (Session.IsNewObject(this))
            {
                int count = Session.GetObjects(Session.GetClassInfo<ReportOnOccurrence>(), null, null, 0, true, true).Count;
                count = count + 1;
                this.Code = string.Format("{0}", count.ToString().PadLeft(4, '0'));
                CreatedOn = DateTime.Now;
                Owner = Session.GetObjectByKey<Employee>(SecuritySystem.CurrentUserId);
            }
        }

        public string Code { get => _code; set => SetPropertyValue(nameof(Code), ref _code, value); }
        public DateTime CreatedOn { get => _createdOn; set => SetPropertyValue(nameof(CreatedOn), ref _createdOn, value); }
        public string CarrierRailwayInsfrastructureOperator { get=> _carrierRailwayInsfrastructureOperator; set=> SetPropertyValue(nameof(CarrierRailwayInsfrastructureOperator),ref _carrierRailwayInsfrastructureOperator,value); }
        public string Address { get => _address; set => SetPropertyValue(nameof(Address), ref _address, value); }
        public string ContactName { get => _contactName; set => SetPropertyValue(nameof(ContactName), ref _contactName, value); }
        public string Telephone { get => _telephone; set => SetPropertyValue(nameof(Telephone), ref _telephone, value); }
        public string Fax { get => _fax; set => SetPropertyValue(nameof(Fax), ref _fax, value); }
        public bool IsRail { get => _isRail; set => SetPropertyValue(nameof(IsRail), ref _isRail, value); }
        public string WagonNumber { get => _wagonNumber; set => SetPropertyValue(nameof(WagonNumber), ref _wagonNumber, value); }
        public bool IsRoad { get => _isRoad; set => SetPropertyValue(nameof(IsRoad), ref _isRoad, value); }
        public string VehicleRegistration { get => _vehicleRegistration; set => SetPropertyValue(nameof(VehicleRegistration), ref _vehicleRegistration, value); }
        public DateTime DateAndLocationOfOccurrence { get => _dateAndLocationOfOccurrence; set => SetPropertyValue(nameof(DateAndLocationOfOccurrence), ref _dateAndLocationOfOccurrence, value); }
        public TimeSpan TimeAndLocationOfOccurrence { get => _timeAndLocationOfOccurrence; set => SetPropertyValue(nameof(TimeAndLocationOfOccurrence), ref _timeAndLocationOfOccurrence, value); }
        public bool Station { get => _station; set => SetPropertyValue(nameof(Station), ref _station, value); }
        public bool ShuntingMarshallingYard { get => _shuntingMarshallingYard; set => SetPropertyValue(nameof(ShuntingMarshallingYard), ref _shuntingMarshallingYard, value); }
        public bool RailLoadingUnloadingTranshipmentSite { get => _railLoadingUnloadingTranshipmentSite; set => SetPropertyValue(nameof(RailLoadingUnloadingTranshipmentSite), ref _railLoadingUnloadingTranshipmentSite, value); }
        public string RailLocationCountry { get => _railLocationCountry; set => SetPropertyValue(nameof(RailLocationCountry), ref _railLocationCountry, value); }
        public bool OpenLine { get => _openLine; set => SetPropertyValue(nameof(OpenLine), ref _openLine, value); }
        public string DescriptionOfLineKilometers { get => _descriptionOfLineKilometers; set => SetPropertyValue(nameof(DescriptionOfLineKilometers), ref _descriptionOfLineKilometers, value); }
        public bool BuiltUpArea { get => _builtUpArea; set => SetPropertyValue(nameof(BuiltUpArea), ref _builtUpArea, value); }
        public bool RoadLoadingUnloadingTranshipmentSite { get => _roadLoadingUnloadingTranshipmentSite; set => SetPropertyValue(nameof(RoadLoadingUnloadingTranshipmentSite), ref _roadLoadingUnloadingTranshipmentSite, value); }
        public bool OpenRoad { get => _openRoad; set => SetPropertyValue(nameof(OpenRoad), ref _openRoad, value); }
        public string RoadLocationCountry { get => _roadLocationCountry; set => SetPropertyValue(nameof(RoadLocationCountry), ref _roadLocationCountry, value); }
        public bool GradientIncline { get => _gradientIncline; set => SetPropertyValue(nameof(GradientIncline), ref _gradientIncline, value); }
        public bool Tunnel { get => _tunnel; set => SetPropertyValue(nameof(Tunnel), ref _tunnel, value); }
        public bool BridgeUnderpass { get => _bridgeUnderpass; set => SetPropertyValue(nameof(BridgeUnderpass), ref _bridgeUnderpass, value); }
        public bool Crossing { get => _crossing; set => SetPropertyValue(nameof(Crossing), ref _crossing, value); }
        public bool Rain { get => _rain; set => SetPropertyValue(nameof(Rain), ref _rain, value); }
        public bool Snow { get => _snow; set => SetPropertyValue(nameof(Snow), ref _snow, value); }
        public bool Ice { get => _ice; set => SetPropertyValue(nameof(Ice), ref _ice, value); }
        public bool Fog { get => _fog; set => SetPropertyValue(nameof(Fog), ref _fog, value); }
        public bool Thunderstorm { get => _thunderstorm; set => SetPropertyValue(nameof(Thunderstorm), ref _thunderstorm, value); }
        public bool Storm { get => _storm; set => SetPropertyValue(nameof(Storm), ref _storm, value); }
        public short Temperature { get => _temperature; set => SetPropertyValue(nameof(Temperature), ref _temperature, value); }
        public bool DerailmentLeavingTheRoad { get => _derailmentLeavingTheRoad; set => SetPropertyValue(nameof(DerailmentLeavingTheRoad), ref _derailmentLeavingTheRoad, value); }
        public bool Collision { get => _collision; set => SetPropertyValue(nameof(Collision), ref _collision, value); }
        public bool OverturningRollingOver { get => _overturningRollingOver; set => SetPropertyValue(nameof(OverturningRollingOver), ref _overturningRollingOver, value); }
        public bool Fire { get => _fire; set => SetPropertyValue(nameof(Fire), ref _fire, value); }
        public bool Explosion { get => _explosion; set => SetPropertyValue(nameof(Explosion), ref _explosion, value); }
        public bool Loss { get => _loss; set => SetPropertyValue(nameof(Loss), ref _loss, value); }
        public bool TechnicalFault { get => _technicalFault; set => SetPropertyValue(nameof(TechnicalFault), ref _technicalFault, value); }
        public string AdditionalDescription { get => _additionalDescription; set => SetPropertyValue(nameof(AdditionalDescription), ref _additionalDescription, value); }
        public bool CauseOfOccurrenceTechnicalFault { get => _causeOfOccurrenceTechnicalFault; set => SetPropertyValue(nameof(CauseOfOccurrenceTechnicalFault), ref _causeOfOccurrenceTechnicalFault, value); }
        public bool FaultLoadSecuring { get => _faultLoadSecuring; set => SetPropertyValue(nameof(FaultLoadSecuring), ref _faultLoadSecuring, value); }
        public bool OperationalCause { get => _operationalCause; set => SetPropertyValue(nameof(OperationalCause), ref _operationalCause, value); }
        public bool OtherCauseOfOccurrence { get => _otherCauseOfOccurrence; set => SetPropertyValue(nameof(OtherCauseOfOccurrence), ref _otherCauseOfOccurrence, value); }
        public string OtherCauseOfOccurrenceDescription { get => _otherCauseOfOccurrenceDescription; set => SetPropertyValue(nameof(OtherCauseOfOccurrenceDescription), ref _otherCauseOfOccurrenceDescription, value); }
        public bool Death { get => _death; set => SetPropertyValue(nameof(Death), ref _death, value); }
        public short DeathsNumber { get => _deathNumber; set => SetPropertyValue(nameof(DeathsNumber), ref _deathNumber, value); }
        public bool Injured { get => _injured; set => SetPropertyValue(nameof(Injured), ref _injured, value); }
        public short InjuredNumber { get => _injuredNumber; set => SetPropertyValue(nameof(InjuredNumber), ref _injuredNumber, value); }
        public bool LossOfProductYes { get => _lossOfProductYes; set => SetPropertyValue(nameof(LossOfProductYes), ref _lossOfProductYes, value); }
        public bool LossOfProductNo { get => _lossOfProductNo; set => SetPropertyValue(nameof(LossOfProductNo), ref _lossOfProductNo, value); }
        public bool ImminentRiskOfLossOfProduct { get => _imminentRiskOfLossOfProduct; set => SetPropertyValue(nameof(ImminentRiskOfLossOfProduct), ref _imminentRiskOfLossOfProduct, value); }
        public bool EstimatedLevelOfDamageLess { get => _estimatedLevelOfDamageLess; set => SetPropertyValue(nameof(EstimatedLevelOfDamageLess), ref _estimatedLevelOfDamageLess, value); }
        public bool EstimatedLevelOfDamageGreater { get => _estimatedLevelOfDamageGreater; set => SetPropertyValue(nameof(EstimatedLevelOfDamageGreater), ref _estimatedLevelOfDamageGreater, value); }
        public bool InvolvementOfAuthoritiesYes { get => _involvementOfAuthoritiesYes; set => SetPropertyValue(nameof(InvolvementOfAuthoritiesYes), ref _involvementOfAuthoritiesYes, value); }
        public bool EvacuationOfPerson { get => _evacuationOfPerson; set => SetPropertyValue(nameof(EvacuationOfPerson), ref _evacuationOfPerson, value); }
        public bool InvolvementOfAuthoritiesNo { get => _involvementOfAuthoritiesNo; set => SetPropertyValue(nameof(InvolvementOfAuthoritiesNo), ref _involvementOfAuthoritiesNo, value); }
        public bool ClosureOfPublic { get => _closureOfPublic; set => SetPropertyValue(nameof(ClosureOfPublic), ref _closureOfPublic, value); }

        [ModelDefault("AllowEdit","False")]
        public Employee Owner { get=> _owner; set=> SetPropertyValue(nameof(Owner),ref _owner,value); }

        [RuleRequiredField("RuleRequiredField for ReportOnOccurrence.Customer", DefaultContexts.Save)]
        public Customer Customer { get=> _customer; set=> SetPropertyValue(nameof(Customer),ref _customer,value); }

        [Association("ReportOnOccurrence-DangerousGoodInvolved"), DevExpress.Xpo.Aggregated]
        public XPCollection<DangerousGoodInvolved> DangerousGoodInvolveds => GetCollection<DangerousGoodInvolved>(nameof(DangerousGoodInvolveds));
    }
}