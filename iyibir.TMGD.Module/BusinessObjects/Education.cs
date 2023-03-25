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
    [ImageName("BO_Position")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Education : BaseObject
    {
        private string _code;
        private DateTime _createdOn;
        private string _subject;
        private Employee _instructor;
        private Customer _customer;
        private string _location;
        private string _description;
        public Education(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (Session.IsNewObject(this))
            {
                CreatedOn = DateTime.Now;
                int count = Session.GetObjects(Session.GetClassInfo<Education>(), null, null, 0, true, true).Count;
                this.Code = string.Format("{0}", (count + 1).ToString().PadLeft(6, '0'));
            }
        }

        public string Code { get=> _code; set=> SetPropertyValue(nameof(Code),ref _code,value); }
        public DateTime CreatedOn { get=> _createdOn; set=> SetPropertyValue(nameof(CreatedOn),ref _createdOn,value); }

        [Size(-1)]
        public string Subject { get => _subject; set => SetPropertyValue(nameof(Subject), ref _subject, value); }
        public Employee Instructur { get=> _instructor; set=> SetPropertyValue(nameof(Instructur),ref _instructor,value); }
        public Customer Customer { get=> _customer; set=> SetPropertyValue(nameof(Customer),ref _customer,value); }
        public string Location { get=> _location; set=> SetPropertyValue(nameof(Location),ref _location,value); }
        public string Description { get=> _description; set=> SetPropertyValue(nameof(Description),ref _description,value); }

        [Association("Education-Participants"),DevExpress.Xpo.Aggregated]
        public XPCollection<Participant> Participants => GetCollection<Participant>(nameof(Participants));
    }
}