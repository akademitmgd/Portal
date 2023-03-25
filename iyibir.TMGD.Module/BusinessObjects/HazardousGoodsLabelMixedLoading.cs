using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace iyibir.TMGD.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("BO_Vendor")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class HazardousGoodsLabelMixedLoading : BaseObject
    {
        private HazardousGoodsLabel _hazardousGoodsLabel;
        private HazardousGoodsLabel _loadedHazardousGoodsLabel;
        private MixedLoadingType _mixedLoadingType;
        public HazardousGoodsLabelMixedLoading(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        [Association("HazardousGoodsLabel-MixedLoading")]
        public HazardousGoodsLabel HazardousGoodsLabel { get=> _hazardousGoodsLabel; set=> SetPropertyValue(nameof(HazardousGoodsLabel),ref _hazardousGoodsLabel,value); }

        [RuleRequiredField]
        public HazardousGoodsLabel LoadedHazardousGoodsLabel { get=> _loadedHazardousGoodsLabel; set=> SetPropertyValue(nameof(LoadedHazardousGoodsLabel),ref _loadedHazardousGoodsLabel,value); }
        public MixedLoadingType MixedLoadingType { get=> _mixedLoadingType; set=> SetPropertyValue(nameof(MixedLoadingType),ref _mixedLoadingType,value); }
    }
}