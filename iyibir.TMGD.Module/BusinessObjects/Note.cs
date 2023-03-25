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
using DevExpress.ExpressApp.SystemModule;

namespace iyibir.TMGD.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("BO_Note")]
    [DefaultProperty("Topic")]
    [Appearance("Appearance Opportunity Quote", Criteria = "IsActive = 0", Context = "ListView", TargetItems = "*", Enabled = false, FontStyle = System.Drawing.FontStyle.Strikeout)]
    [ListViewFilter("MyNoteList", "Owner.Oid = CurrentUserId()", "Benim Notlarım", Index = 0)]
    [ListViewFilter("ActiveNoteList", "IsActive = 1", "Aktif Notlar", Index = 0)]
    [ListViewFilter("DeactiveNoteList", "IsActive = 0", "Kapanan Notlar", Index = 1)]
    [ListViewFilter("AllNoteList", "", "Hepsi", Index = 2)]
    public class Note : BaseObject
    {
        private string _topic;
        private DateTime _createdOn;
        private Employee _owner;
        private NotePriority _priority;
        private string _description;
        private bool _isActive;
        public Note(Session session)
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
                IsActive = true;
            }
        }

        [RuleRequiredField("RuleRequiredField for Note.Topic", DefaultContexts.Save)]
        public string Topic { get => _topic; set => SetPropertyValue("Topic", ref _topic, value); }

        [RuleRequiredField("RuleRequiredField for Note.CreatedOn", DefaultContexts.Save)]
        public DateTime CreatedOn { get => _createdOn; set => SetPropertyValue("CreatedOn", ref _createdOn, value); }

        [ModelDefault("AllowEdit", "False")]
        [VisibleInDetailView(false)]
        [Association("Employee-Notes")]
        public Employee Owner { get => _owner; set => SetPropertyValue("Owner", ref _owner, value); }

        public NotePriority Priority { get => _priority; set => SetPropertyValue("Priority", ref _priority, value); }

        [VisibleInDetailView(false), VisibleInListView(false)]
        [ModelDefault("AllowEdit", "False")]
        public bool IsActive { get => _isActive; set => SetPropertyValue("IsActive", ref _isActive, value); }

        [Size(-1)]
        public string Description { get => _description; set => SetPropertyValue("Description", ref _description, value); }
    }
}