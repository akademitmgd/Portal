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
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Editors;
using DevExpress.Persistent.Base.General;

namespace iyibir.TMGD.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("BO_Folder")]
    [DefaultProperty("Name")]
    [DefaultListViewOptions(MasterDetailMode.ListViewAndDetailView, false, NewItemRowPosition.None)]
    [Appearance("EFile New", AppearanceItemType = "Action", TargetItems = "New", Visibility = ViewItemVisibility.Hide)]
    public class CustomFile : BaseObject, ITreeNode
    {
        private string _name;
        private Employee _owner;
        private DateTime _createdOn;
        private CustomFile _parentFile;
        public CustomFile(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (Session.IsNewObject(this))
            {
                CreatedOn = DateTime.Now;
                Owner = Session.GetObjectByKey<Employee>(SecuritySystem.CurrentUserId);
            }
        }

        [RuleRequiredField("RuleRequiredField for CustomFile.Name", DefaultContexts.Save)]
        [RuleUniqueValue("RuleUniqueValue for CustomFile.Name", DefaultContexts.Save)]
        public string Name { get => _name; set => SetPropertyValue("Name", ref _name, value); }

        [VisibleInDetailView(false)]
        [ModelDefault("AllowEdit", "False")]
        public Employee Owner { get => _owner; set => SetPropertyValue("Owner", ref _owner, value); }

        [VisibleInDetailView(false)]
        [ModelDefault("AllowEdit", "False")]
        public DateTime CreatedOn { get => _createdOn; set => SetPropertyValue("CreatedOn", ref _createdOn, value); }

        #region ITreeNode
        [Association("CustomFile-CustomFileChild")]
        public XPCollection<CustomFile> Children => GetCollection<CustomFile>(nameof(Children));

        [Association("CustomFile-CustomFileChild")]
        [Persistent]
        public CustomFile ParentFile { get => _parentFile; set => SetPropertyValue(nameof(ParentFile), ref _parentFile, value); }

        [VisibleInDetailView(false)]
        public ITreeNode Parent => _parentFile;

        IBindingList ITreeNode.Children => Children;

        #endregion

        [Association("CustomFile-Documents"),DevExpress.Xpo.Aggregated]
        public XPCollection<CustomDocument> Documents => GetCollection<CustomDocument>(nameof(Documents));
    }
}