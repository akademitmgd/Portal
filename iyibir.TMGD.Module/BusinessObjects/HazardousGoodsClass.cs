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
    [ImageName("BO_List")]
    [DefaultProperty("Code")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class HazardousGoodsClass : BaseObject,ITreeNode
    {
        private HazardousGoods _hazardousGoods;
        private string _code;
        private string _name;
        private HazardousGoodsClass _parentHazardousGoodsClass;

        public HazardousGoodsClass(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }


        [RuleRequiredField("RuleRequiredField for HazardousGoodsClass.Code", DefaultContexts.Save)]
        [RuleUniqueValue("RuleUniqueValue for HazardousGoodsClass.Code", DefaultContexts.Save)]
        public string Code { get=> _code; set=> SetPropertyValue(nameof(Code),ref _code,value); }

        [RuleRequiredField("RuleRequiredField for HazardousGoodsClass.Name", DefaultContexts.Save)]
        public string Name { get=> _name; set=> SetPropertyValue(nameof(Name),ref _name,value); }

        #region ITreeNode
        [Association("HazardousGoodsClass-HazardousGoodsClassChild")]
        public XPCollection<HazardousGoodsClass> Children => GetCollection<HazardousGoodsClass>(nameof(Children));

        [Association("HazardousGoodsClass-HazardousGoodsClassChild")]
        [Persistent]
        [VisibleInListView(false)]
        [ImmediatePostData]
        public HazardousGoodsClass ParentHazardousGoodsClass { get => _parentHazardousGoodsClass; set => SetPropertyValue(nameof(ParentHazardousGoodsClass), ref _parentHazardousGoodsClass, value); }


        [VisibleInListView(false)]
        public ITreeNode Parent => _parentHazardousGoodsClass;

        [VisibleInDetailView(false)]
        IBindingList ITreeNode.Children => Children;
        #endregion

        [Association("HazardousGoods-Classes")]
        public XPCollection<HazardousGoods> HazardousGoods => GetCollection<HazardousGoods>(nameof(HazardousGoods));
    }
}