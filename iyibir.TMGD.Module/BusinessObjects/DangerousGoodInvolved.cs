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
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class DangerousGoodInvolved : BaseObject
    {
        private ReportOnOccurrence _report;
        private HazardousGoods _hazardousGoods;
        private HazardousGoodsClass _class;
        private PackingGroup _packingGroup;
        private string _estimatedQuantityOfLossOfProduct;
        private MeansOfContainment _meansOfContainment;
        private string _meansOfContainmentMaterial;
        private TypeOfFailureMOC _typeOfFailureMOC;
        public DangerousGoodInvolved(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        [Association("ReportOnOccurrence-DangerousGoodInvolved")]
        public ReportOnOccurrence ReportOnOccurrence { get=> _report; set=> SetPropertyValue(nameof(ReportOnOccurrence),ref _report,value); }
        public HazardousGoods HazardousGoods { get=> _hazardousGoods; set=> SetPropertyValue(nameof(HazardousGoods),ref _hazardousGoods,value); }
        public HazardousGoodsClass Class { get=> _class; set=> SetPropertyValue(nameof(Class),ref _class,value); }
        public PackingGroup PackingGroup { get=> _packingGroup; set=> SetPropertyValue(nameof(PackingGroup),ref _packingGroup,value); }
        public string EstimatedQuantityOfLossOfProduct { get=> _estimatedQuantityOfLossOfProduct; set=> SetPropertyValue(nameof(EstimatedQuantityOfLossOfProduct),ref _estimatedQuantityOfLossOfProduct,value); }
        public MeansOfContainment MeansOfContainment { get=> _meansOfContainment; set=> SetPropertyValue(nameof(MeansOfContainment),ref _meansOfContainment,value); }
        public string MeansOfContainmentMaterial { get=> _meansOfContainmentMaterial; set=> SetPropertyValue(nameof(MeansOfContainmentMaterial),ref _meansOfContainmentMaterial,value ); }
        public TypeOfFailureMOC TypeOfFailureMOC { get=> _typeOfFailureMOC; set=> SetPropertyValue(nameof(TypeOfFailureMOC),ref _typeOfFailureMOC,value); }

    }
}