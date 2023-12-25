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
    [NavigationItem("HazardousGoodsManagement")]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class HazardousGoodsLabelController : BaseObject
    {
        private HazardousGoodsLabel _hazardousGoodsLabel;
        private VehicleControlOption _vControlOption;
        private string _question;
        public HazardousGoodsLabelController(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        [Association("HazardousGoodsLabel-Controllers")]
        public HazardousGoodsLabel HazardousGoodsLabel { get => _hazardousGoodsLabel; set => SetPropertyValue(nameof(HazardousGoodsLabel), ref _hazardousGoodsLabel, value); }

        public VehicleControlOption VControlOption { get => _vControlOption; set => SetPropertyValue(nameof(VControlOption), ref _vControlOption, value); }

        [RuleRequiredField("RuleRequiredField for HazardousGoodsLabelController.Question", DefaultContexts.Save)]
        [Size(250)]
        public string Question { get => _question; set => SetPropertyValue(nameof(Question), ref _question, value); }
    }
}