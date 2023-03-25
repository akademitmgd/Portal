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
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class ProductCASNumber : BaseObject
    {
        private Product _product;
        private CASNumber _cASNumber;
        private double _contentRate;
        private CASType _casType;
        public ProductCASNumber(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        [Association("Product-CASNumbers")]
        public Product Product { get=> _product; set=> SetPropertyValue(nameof(Product),ref _product,value); }

        [RuleRequiredField]
        public CASNumber CASNumber { get=> _cASNumber; set=> SetPropertyValue(nameof(CASNumber),ref _cASNumber,value); }

        [RuleValueComparison(ValueComparisonType.GreaterThanOrEqual,0)]
        public double ContentRate { get=> _contentRate; set=> SetPropertyValue(nameof(ContentRate),ref _contentRate,value); }

        public CASType CASType { get=> _casType; set=> SetPropertyValue(nameof(CASType),ref _casType,value); }
    }
}