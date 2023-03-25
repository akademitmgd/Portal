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
    [ImageName("BO_List")]
    [DefaultProperty("Fullname")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class ActivitySubject : BaseObject
    {
        private string _code;
        private string _name;
        private bool _isActive;
        public ActivitySubject(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if ((Session.IsNewObject(this)))
            {
                IsActive = true;
            }
        }

        [RuleRequiredField("RuleRequiredField for ActivitySubject.Code", DefaultContexts.Save)]
        public string Code { get=> _code; set=> SetPropertyValue(nameof(Code),ref _code,value); }

        [RuleRequiredField("RuleRequiredField for ActivitySubject.Name", DefaultContexts.Save)]
        public string Name { get=> _name; set=> SetPropertyValue(nameof(Name),ref _name,value); }
        public bool IsActive { get=> _isActive; set=> SetPropertyValue(nameof(IsActive),ref _isActive,value); }

        [NonPersistent]
        public string Fullname { get => string.Format("{0} {1}", this.Code, this.Name); }

        [Association("ActivitySubject-Descriptions"), DevExpress.Xpo.Aggregated]
        public XPCollection<ActivitySubjectDesc> Descriptions => GetCollection<ActivitySubjectDesc>(nameof(Descriptions));
    }
}