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
    public class HazardousGoodsPropertyValue : BaseObject
    {
        private HazardousGoodsProperty _hazardousGoodsProperty;
        private string _code;
        private string _name;
        public HazardousGoodsPropertyValue(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        [Association("HazardousGoodsProperty-Values")]
        public HazardousGoodsProperty hazardousGoodsProperty { get=> _hazardousGoodsProperty; set=> SetPropertyValue(nameof(hazardousGoodsProperty),ref _hazardousGoodsProperty,value); }

        public string Code { get => _code; set => SetPropertyValue(nameof(Code), ref _code, value); }
        public string Name { get => _name; set => SetPropertyValue(nameof(Name), ref _name, value); }

        [VisibleInListView(true)]
        [ImageEditor(ListViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorFixedHeight = 350, DetailViewImageEditorFixedWidth = 350)]
        public byte[] LabelImage
        {
            get { return GetPropertyValue<byte[]>(nameof(LabelImage)); }
            set { SetPropertyValue<byte[]>(nameof(LabelImage), value); }
        }

    }
}