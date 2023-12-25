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
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class ActivityReportTransaction : BaseObject
    {
        private ActivityReport _activityReport;
        private HazardousGoodsClass _class;
        private double _alinanMiktar;
        private double _bosaltilanMiktar;
        private double _doldurulanMiktar;
        private double _paketlenenMiktar;
        private double _yuklenenMiktar;
        private double _tasinanMiktar;
        private double _karayoluAmbalajliTasinan;
        private double _karayoluDokmeTasinan;
        private double _karayoluTanktaTasinan;
        private double _demiryoluAmbalajliTasinan;
        private double _demiryoluDokmeTasinan;
        private double _demiryoluTanktaTasinan;
        private double _denizyoluAmbalajliTasinan;
        private double _denizyoluDokmeTasinan;
        private double _denizyoluTanktaTasinan;
        private double _karmaAmbalajliTasinan;
        private double _karmaDokmeTasinan;
        private double _karmaTanktaTasinan;
        private string _unit;
        private Unitset _unitset;
        public ActivityReportTransaction(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        [Association("ActivityReport-Transactions")]
        public ActivityReport ActivityReport { get => _activityReport; set => SetPropertyValue(nameof(ActivityReport), ref _activityReport, value); }

        [RuleRequiredField("RuleRequiredField for ActivityReportTransaction.Class", DefaultContexts.Save)]
        public HazardousGoodsClass Class { get => _class; set => SetPropertyValue(nameof(Class), ref _class, value); }

        [RuleValueComparison("RuleValueComparison for ActivityReportTransaction.AlinanMiktar", DefaultContexts.Save, ValueComparisonType.GreaterThanOrEqual, 0)]
        public double AlinanMiktar { get => _alinanMiktar; set => SetPropertyValue(nameof(AlinanMiktar), ref _alinanMiktar, value); }

        [RuleValueComparison("RuleValueComparison for ActivityReportTransaction.BosaltilanMiktar", DefaultContexts.Save, ValueComparisonType.GreaterThanOrEqual, 0)]
        public double BosaltilanMiktar { get => _bosaltilanMiktar; set => SetPropertyValue(nameof(BosaltilanMiktar), ref _bosaltilanMiktar, value); }

        [RuleValueComparison("RuleValueComparison for ActivityReportTransaction.DoldurulanMiktar", DefaultContexts.Save, ValueComparisonType.GreaterThanOrEqual, 0)]
        public double DoldurulanMiktar { get => _doldurulanMiktar; set => SetPropertyValue(nameof(DoldurulanMiktar), ref _doldurulanMiktar, value); }

        [RuleValueComparison("RuleValueComparison for ActivityReportTransaction.PaketlenenMiktar", DefaultContexts.Save, ValueComparisonType.GreaterThanOrEqual, 0)]
        public double PaketlenenMiktar { get => _paketlenenMiktar; set => SetPropertyValue(nameof(PaketlenenMiktar), ref _paketlenenMiktar, value); }

        [RuleValueComparison("RuleValueComparison for ActivityReportTransaction.YuklenenMiktar", DefaultContexts.Save, ValueComparisonType.GreaterThanOrEqual, 0)]
        public double YuklenenMiktar { get => _yuklenenMiktar; set => SetPropertyValue(nameof(YuklenenMiktar), ref _yuklenenMiktar, value); }

        [RuleValueComparison("RuleValueComparison for ActivityReportTransaction.TasinanMiktar", DefaultContexts.Save, ValueComparisonType.GreaterThanOrEqual, 0)]
        public double TasinanMiktar { get => _tasinanMiktar; set => SetPropertyValue(nameof(TasinanMiktar), ref _tasinanMiktar, value); }

        [RuleValueComparison("RuleValueComparison for ActivityReportTransaction.KarayoluAmbalajliTasinan", DefaultContexts.Save, ValueComparisonType.GreaterThanOrEqual, 0)]
        public double KarayoluAmbalajliTasinan { get => _karayoluAmbalajliTasinan; set => SetPropertyValue(nameof(KarayoluAmbalajliTasinan), ref _karayoluAmbalajliTasinan, value); }

        [RuleValueComparison("RuleValueComparison for ActivityReportTransaction.KarayoluDokmeTasinan", DefaultContexts.Save, ValueComparisonType.GreaterThanOrEqual, 0)]
        public double KarayoluDokmeTasinan { get => _karayoluDokmeTasinan; set => SetPropertyValue(nameof(KarayoluDokmeTasinan), ref _karayoluDokmeTasinan, value); }

        [RuleValueComparison("RuleValueComparison for ActivityReportTransaction.KarayoluTanktaTasinan", DefaultContexts.Save, ValueComparisonType.GreaterThanOrEqual, 0)]
        public double KarayoluTanktaTasinan { get => _karayoluTanktaTasinan; set => SetPropertyValue(nameof(KarayoluTanktaTasinan), ref _karayoluTanktaTasinan, value); }

        [RuleValueComparison("RuleValueComparison for ActivityReportTransaction.DemiryoluAmbalajliTasinan", DefaultContexts.Save, ValueComparisonType.GreaterThanOrEqual, 0)]
        public double DemiryoluAmbalajliTasinan { get => _demiryoluAmbalajliTasinan; set => SetPropertyValue(nameof(DemiryoluAmbalajliTasinan), ref _demiryoluAmbalajliTasinan, value); }

        [RuleValueComparison("RuleValueComparison for ActivityReportTransaction.DemiryoluDokmeTasinan", DefaultContexts.Save, ValueComparisonType.GreaterThanOrEqual, 0)]
        public double DemiryoluDokmeTasinan { get => _demiryoluDokmeTasinan; set => SetPropertyValue(nameof(DemiryoluDokmeTasinan), ref _demiryoluDokmeTasinan, value); }

        [RuleValueComparison("RuleValueComparison for ActivityReportTransaction.DemiryoluTanktaTasinan", DefaultContexts.Save, ValueComparisonType.GreaterThanOrEqual, 0)]
        public double DemiryoluTanktaTasinan { get => _demiryoluTanktaTasinan; set => SetPropertyValue(nameof(DemiryoluTanktaTasinan), ref _demiryoluTanktaTasinan, value); }

        [RuleValueComparison("RuleValueComparison for ActivityReportTransaction.DenizyoluAmbalajliTasinan", DefaultContexts.Save, ValueComparisonType.GreaterThanOrEqual, 0)]
        public double DenizyoluAmbalajliTasinan { get => _denizyoluAmbalajliTasinan; set => SetPropertyValue(nameof(DenizyoluAmbalajliTasinan), ref _denizyoluAmbalajliTasinan, value); }

        [RuleValueComparison("RuleValueComparison for ActivityReportTransaction.DenizyoluDokmeTasinan", DefaultContexts.Save, ValueComparisonType.GreaterThanOrEqual, 0)]
        public double DenizyoluDokmeTasinan { get => _denizyoluDokmeTasinan; set => SetPropertyValue(nameof(DenizyoluDokmeTasinan), ref _denizyoluDokmeTasinan, value); }

        [RuleValueComparison("RuleValueComparison for ActivityReportTransaction.DenizyoluTanktaTasinan", DefaultContexts.Save, ValueComparisonType.GreaterThanOrEqual, 0)]
        public double DenizyoluTanktaTasinan { get => _denizyoluTanktaTasinan; set => SetPropertyValue(nameof(DenizyoluTanktaTasinan), ref _denizyoluTanktaTasinan, value); }

        [RuleValueComparison("RuleValueComparison for ActivityReportTransaction.KarmaAmbalajliTasinan", DefaultContexts.Save, ValueComparisonType.GreaterThanOrEqual, 0)]
        public double KarmaAmbalajliTasinan { get => _karmaAmbalajliTasinan; set => SetPropertyValue(nameof(KarmaAmbalajliTasinan), ref _karmaAmbalajliTasinan, value); }

        [RuleValueComparison("RuleValueComparison for ActivityReportTransaction.KarmaDokmeTasinan", DefaultContexts.Save, ValueComparisonType.GreaterThanOrEqual, 0)]
        public double KarmaDokmeTasinan { get => _karmaDokmeTasinan; set => SetPropertyValue(nameof(KarmaDokmeTasinan), ref _karmaDokmeTasinan, value); }

        [RuleValueComparison("RuleValueComparison for ActivityReportTransaction.KarmaTanktaTasinan", DefaultContexts.Save, ValueComparisonType.GreaterThanOrEqual, 0)]
        public double KarmaTanktaTasinan { get => _karmaTanktaTasinan; set => SetPropertyValue(nameof(KarmaTanktaTasinan), ref _karmaTanktaTasinan, value); }

        [VisibleInDetailView(false),VisibleInListView(false),VisibleInLookupListView(false)]
        public string Unit { get=> _unit; set=> SetPropertyValue(nameof(Unit),ref _unit,value); }

        [RuleRequiredField("RuleRequiredField for ActivityReportTransaction.Unitset", DefaultContexts.Save)]
        public Unitset Unitset { get => _unitset; set => SetPropertyValue(nameof(Unitset), ref _unitset, value); }


    }
}