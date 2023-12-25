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
    [NavigationItem("Settings")]
    public class DefaultLabel : BaseObject
    {
        private string _name;
        
        public DefaultLabel(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        [RuleRequiredField("RuleRequiredField for DefaultLabel.Name", DefaultContexts.Save)]
        [RuleUniqueValue("RuleUniqueValue for DefaultLabel.Name", DefaultContexts.Save)]
        public string Name { get=> _name; set=> SetPropertyValue(nameof(Name),ref _name,value); }


        [VisibleInListView(true)]
        [ImageEditor(ListViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorFixedHeight = 300, DetailViewImageEditorFixedWidth = 200)]
        public byte[] LabelImage
        {
            get { return GetPropertyValue<byte[]>(nameof(LabelImage)); }
            set { SetPropertyValue<byte[]>(nameof(LabelImage), value); }
        }
    }
}