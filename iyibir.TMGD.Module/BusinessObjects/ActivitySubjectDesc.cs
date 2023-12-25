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
    [NavigationItem(false)]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class ActivitySubjectDesc : BaseObject
    {
        private ActivitySubject _activitySubject;
        private string _code;
        private string _name;


        public ActivitySubjectDesc(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        [Association("ActivitySubject-Descriptions")]
        public ActivitySubject ActivitySubject { get => _activitySubject; set => SetPropertyValue(nameof(ActivitySubject), ref _activitySubject, value); }
        public string Code { get => _code; set => SetPropertyValue(nameof(Code), ref _code, value); }
        public string Name { get => _name; set => SetPropertyValue(nameof(Name), ref _name, value); }

        [NonPersistent]
        public string Fullname { get => string.Format("{0} {1}", this.Code, this.Name); }
    }
}