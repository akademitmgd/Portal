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
    [NavigationItem(false)]
    public class CustomDocument : BaseObject
    {
        private CustomFile _customFile;
        private Employee _owner;
        private DateTime _createdOn;
        private string _name;
        private string _description;
        private FileData _documentData;
        public CustomDocument(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        [Association("CustomFile-Documents")]
        public CustomFile CustomFile { get=> _customFile; set=> SetPropertyValue(nameof(CustomFile),ref _customFile,value); }

        [VisibleInDetailView(false)]
        [ModelDefault("AllowEdit", "False")]
        public Employee Owner { get => _owner; set => SetPropertyValue("Owner", ref _owner, value); }

        [VisibleInDetailView(false)]
        [ModelDefault("AllowEdit", "False")]
        public DateTime CreatedOn { get => _createdOn; set => SetPropertyValue("CreatedOn", ref _createdOn, value); }

        [RuleRequiredField("RuleRequiredField for CustomDocument.Name", DefaultContexts.Save)]
        public string Name { get=> _name; set=> SetPropertyValue(nameof(Name),ref _name,value); }

        [Size(-1)]
        [VisibleInDetailView(false),VisibleInListView(false)]
        public string Description { get=> _description; set=> SetPropertyValue(nameof(Description),ref _description,value); }

        [RuleRequiredField("RuleRequiredField for CustomDocument.FileData", DefaultContexts.Save)]
        [ExpandObjectMembers(ExpandObjectMembers.Never)]
        public FileData FileData { get => _documentData; set => SetPropertyValue("FileData", ref _documentData, value); }

    }
}