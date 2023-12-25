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
    [NavigationItem("DocumentManagement")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class DrillForm : BaseObject
    {
        private string _code;
        private Employee _owner;
        private Customer _customer;
        private string _address;
        private DateTime _createdOn;
        private DrillType _drillType;
        private string _subject;
        private DateTime _drillStartDate;
        private TimeSpan _drillStartTime;
        private string _drillScenario;

        public DrillForm(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (Session.IsNewObject(this))
            {
                DrillStartDate = DateTime.Now;
                DrillStartTime = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                Owner = Session.GetObjectByKey<Employee>(SecuritySystem.CurrentUserId);
                CreatedOn = DateTime.Now;

                int count = Session.GetObjects(Session.GetClassInfo<DrillForm>(), null, null, 0, true, true).Count;
                count = count + 1;
                this.Code = string.Format("{0}", count.ToString().PadLeft(4, '0'));
            }
        }

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            switch (propertyName)
            {
                case "DrillType":
                    DrillScenario = DrillType != null ? DrillType.Scenario : string.Empty;
                    if (DrillType != null)
                    {
                        foreach (var item in DrillType.ControlLists)
                        {
                            DrillFormControlList drillFormControl = new DrillFormControlList(Session);
                            drillFormControl.DrillForm = this;
                            drillFormControl.ControlName = item.ControlName;
                        }
                    }
                    else
                    {
                        Session.Delete(ControlLists);
                    }


                    this.RaisePropertyChangedEvent(nameof(DrillScenario));
                    this.RaisePropertyChangedEvent(nameof(ControlLists));

                    break;
                case "Customer":
                    Address = Customer != null ? Customer.Address : string.Empty;

                    this.RaisePropertyChangedEvent(nameof(Address));
                    break;
                default:
                    break;
            }
        }

        [ModelDefault("AllowEdit", "False")]
        [RuleRequiredField("RuleRequiredField for DrillForm.Code", DefaultContexts.Save)]
        public string Code { get => _code; set => SetPropertyValue(nameof(Code), ref _code, value); }

        [ModelDefault("AllowEdit", "False")]
        public Employee Owner { get => _owner; set => SetPropertyValue(nameof(Owner), ref _owner, value); }

        [RuleRequiredField("RuleRequiredField for DrillForm.Customer", DefaultContexts.Save)]
        [ImmediatePostData]
        public Customer Customer { get => _customer; set => SetPropertyValue(nameof(Customer), ref _customer, value); }

        [RuleRequiredField("RuleRequiredField for DrillForm.Address", DefaultContexts.Save)]
        public string Address { get => _address; set => SetPropertyValue(nameof(Address), ref _address, value); }

        [RuleRequiredField("RuleRequiredField for DrillForm.CreatedOn", DefaultContexts.Save)]
        public DateTime CreatedOn { get => _createdOn; set => SetPropertyValue(nameof(CreatedOn), ref _createdOn, value); }

        [RuleRequiredField("RuleRequiredField for DrillForm.DrillType", DefaultContexts.Save)]
        [ImmediatePostData]
        public DrillType DrillType { get => _drillType; set => SetPropertyValue(nameof(DrillType), ref _drillType, value); }

        [RuleRequiredField("RuleRequiredField for DrillForm.Subject", DefaultContexts.Save)]
        public string Subject { get => _subject; set => SetPropertyValue(nameof(Subject), ref _subject, value); }

        [RuleRequiredField("RuleRequiredField for DrillForm.DrillStartDate", DefaultContexts.Save)]
        public DateTime DrillStartDate { get => _drillStartDate; set => SetPropertyValue(nameof(DrillStartDate), ref _drillStartDate, value); }

        [RuleRequiredField("RuleRequiredField for DrillForm.DrillStartTime", DefaultContexts.Save)]
        public TimeSpan DrillStartTime { get => _drillStartTime; set => SetPropertyValue(nameof(DrillStartTime), ref _drillStartTime, value); }

        [Size(-1)]
        [RuleRequiredField("RuleRequiredField for DrillForm.Scenario", DefaultContexts.Save)]
        public string DrillScenario { get => _drillScenario; set => SetPropertyValue(nameof(DrillScenario), ref _drillScenario, value); }

        [Association("DrillForm-ControlList"), DevExpress.Xpo.Aggregated]
        public XPCollection<DrillFormControlList> ControlLists => GetCollection<DrillFormControlList>(nameof(ControlLists));

    }
}