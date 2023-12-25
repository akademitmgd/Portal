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
    [DefaultProperty("Code")]
    [NavigationItem("HazardousGoodsManagement")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class HazardousGoodsLabel : BaseObject
    {
        private HazardousGoods _hazardousGoods;
        private int _lineNumber;
        private string _code;
        private string _name;
        public HazardousGoodsLabel(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        public int LineNumber { get => _lineNumber; set => SetPropertyValue(nameof(LineNumber), ref _lineNumber, value); }

        [RuleRequiredField("RuleRequiredField for HazardousGoodsLabel.Code", DefaultContexts.Save)]
        [RuleUniqueValue("RuleUniqueValue for HazardousGoodsLabel.Code", DefaultContexts.Save)]
        public string Code { get => _code; set => SetPropertyValue(nameof(Code), ref _code, value); }

        [RuleRequiredField("RuleRequiredField for HazardousGoodsLabel.Name", DefaultContexts.Save)]
        [VisibleInListView(false)]
        public string Name { get => _name; set => SetPropertyValue(nameof(Name), ref _name, value); }

        [VisibleInListView(true)]
        [ImageEditor(ListViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorFixedHeight = 350, DetailViewImageEditorFixedWidth = 350)]
        public byte[] LabelImage
        {
            get { return GetPropertyValue<byte[]>(nameof(LabelImage)); }
            set { SetPropertyValue<byte[]>(nameof(LabelImage), value); }
        }

        //[Association("HazardousGoods-Labels")]
        [VisibleInDetailView(false),VisibleInListView(false)]
        public HazardousGoods HazardousGoods { get => _hazardousGoods; set => SetPropertyValue(nameof(HazardousGoods), ref _hazardousGoods, value); }

        [Association("HazardousGoodsLabel-Equipments"), DevExpress.Xpo.Aggregated]
        public XPCollection<HazardousGoodsLabelEquipment> Equipments => GetCollection<HazardousGoodsLabelEquipment>(nameof(Equipments));

        [Association("HazardousGoodsLabel-Controllers"), DevExpress.Xpo.Aggregated]
        public XPCollection<HazardousGoodsLabelController> Controllers => GetCollection<HazardousGoodsLabelController>(nameof(Controllers));

        [Association("HazardousGoodsLabel-MixedLoading"), DevExpress.Xpo.Aggregated]
        public XPCollection<HazardousGoodsLabelMixedLoading> MixedLoadedList => GetCollection<HazardousGoodsLabelMixedLoading>(nameof(MixedLoadedList));
    }
}