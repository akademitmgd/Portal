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
using DevExpress.Persistent.Base.General;

namespace iyibir.TMGD.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("HazardousGoodsManagement")]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class HazardousGoodsProperty : BaseObject,ITreeNode
    {
        private string _code;
        private string _name;
        private HazardousGoodsCategory _category;
        private HazardousGoodsProperty _parentHazardousGoodsProperty;
        public HazardousGoodsProperty(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        public string Code { get=> _code; set=> SetPropertyValue(nameof(Code),ref _code,value); }
        public string Name { get=> _name; set=> SetPropertyValue(nameof(Name),ref _name,value); }
        public HazardousGoodsCategory Category { get=> _category; set=> SetPropertyValue(nameof(Category),ref _category,value); }

        [Association("HazardousGoodsProperty-Values")]
        public XPCollection<HazardousGoodsPropertyValue> Values => GetCollection<HazardousGoodsPropertyValue>(nameof(Values));

        #region ITreeNode
        [Association("HazardousGoodsProperty-HazardousGoodsPropertyChild")]
        public XPCollection<HazardousGoodsProperty> Children => GetCollection<HazardousGoodsProperty>(nameof(Children));

        [Association("HazardousGoodsProperty-HazardousGoodsPropertyChild")]
        [Persistent]
        [VisibleInListView(false)]
        [ImmediatePostData]
        public HazardousGoodsProperty ParentHazardousGoodsProperty { get => _parentHazardousGoodsProperty; set => SetPropertyValue(nameof(ParentHazardousGoodsProperty), ref _parentHazardousGoodsProperty, value); }


        [VisibleInListView(false)]
        public ITreeNode Parent => _parentHazardousGoodsProperty;

        [VisibleInDetailView(false)]
        IBindingList ITreeNode.Children => Children;
        #endregion
    }
}