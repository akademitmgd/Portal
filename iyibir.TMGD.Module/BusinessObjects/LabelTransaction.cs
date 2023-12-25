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
    [ImageName("BO_List")]
    [DefaultProperty("HazardousGoodsLabel")]
    [NavigationItem("HazardousGoodsManagement")]
    public class LabelTransaction : BaseObject
    {
        private int _lineNumber;
        private HazardousGoods _hazardousGoods;
        private HazardousGoodsLabel _hazardousGoodsLabel;

        public LabelTransaction(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        [Association("HazardousGoods-LabelTransactions")]
        [VisibleInDetailView(false)]
        public HazardousGoods HazardousGoods { get => _hazardousGoods; set => SetPropertyValue(nameof(HazardousGoods), ref _hazardousGoods, value); }

        public int LineNumber { get => _lineNumber; set => SetPropertyValue(nameof(LineNumber), ref _lineNumber, value); }

        [RuleRequiredField]
        public HazardousGoodsLabel HazardousGoodsLabel { get => _hazardousGoodsLabel; set => SetPropertyValue(nameof(HazardousGoodsLabel), ref _hazardousGoodsLabel, value); }
    }
}