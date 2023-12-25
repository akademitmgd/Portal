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
    [ImageName("BO_Scheduler")]
    [NavigationItem("DocumentManagement")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class AnnualWorkPlan : BaseObject
    {
        private Customer _customer;
        private CustomerContact _customerContact;
        private DateTime _createdOn;
        private Employee _owner;


        public AnnualWorkPlan(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (Session.IsNewObject(this))
            {
                Owner = Session.GetObjectByKey<Employee>(SecuritySystem.CurrentUserId);
                CreatedOn = DateTime.Now;

                SortingCollection sortProperties = new SortingCollection();
                sortProperties.Add(new SortProperty("LineNumber", DevExpress.Xpo.DB.SortingDirection.Ascending));

                var defaultPlan = Session.GetObjects(Session.GetClassInfo<DefaultAnnualWorkPlan>(), null, sortProperties, 0, false, true);
                foreach (DefaultAnnualWorkPlan plan in defaultPlan)
                {
                    AnnualWorkPlanSubject annualWorkPlanSubject = new AnnualWorkPlanSubject(Session);
                    annualWorkPlanSubject.AnnualWorkPlan = this;
                    annualWorkPlanSubject.SubjectStatus = AnnualWorkPlanSubjectStatus.Planning;
                    annualWorkPlanSubject.Subject = plan.PlanName;
                    this.Subjects.Add(annualWorkPlanSubject);


                    foreach (var item in Enum.GetNames(typeof(Months)))
                    {
                        DevExpress.ExpressApp.Utils.EnumDescriptor ed = new DevExpress.ExpressApp.Utils.EnumDescriptor(typeof(Months));

                        AnnualWorkPlanSubjectTransaction annualWorkPlanSubjectTransaction = new AnnualWorkPlanSubjectTransaction(Session);
                        annualWorkPlanSubjectTransaction.AnnualWorkPlanSubject = annualWorkPlanSubject;

                        switch (item)
                        {
                            case "January":
                                annualWorkPlanSubjectTransaction.Month = Months.January;
                                break;
                            case "February":
                                annualWorkPlanSubjectTransaction.Month = Months.February;
                                break;
                            case "March":
                                annualWorkPlanSubjectTransaction.Month = Months.March;
                                break;
                            case "April":
                                annualWorkPlanSubjectTransaction.Month = Months.April;
                                break;
                            case "May":
                                annualWorkPlanSubjectTransaction.Month = Months.May;
                                break;
                            case "June":
                                annualWorkPlanSubjectTransaction.Month = Months.June;
                                break;
                            case "July":
                                annualWorkPlanSubjectTransaction.Month = Months.July;
                                break;
                            case"August":
                                annualWorkPlanSubjectTransaction.Month = Months.August;
                                break;
                            case "September":
                                annualWorkPlanSubjectTransaction.Month = Months.September;
                                break;
                            case "October":
                                annualWorkPlanSubjectTransaction.Month = Months.October;
                                break;
                            case "November":
                                annualWorkPlanSubjectTransaction.Month = Months.November;
                                break;
                            case "December":
                                annualWorkPlanSubjectTransaction.Month = Months.December;
                                break;
                            default:
                                break;
                        }

                        annualWorkPlanSubject.Transactions.Add(annualWorkPlanSubjectTransaction);
                    }
                }
            }
        }

        [ImmediatePostData]
        [RuleRequiredField("RuleRequiredField for AnnualWorkPlan.Customer", DefaultContexts.Save)]
        public Customer Customer { get=> _customer; set=> SetPropertyValue(nameof(Customer),ref _customer,value); }

        [RuleRequiredField("RuleRequiredField for AnnualWorkPlan.CustomerContact", DefaultContexts.Save)]
        [DataSourceProperty("Customer.Contacts")]
        public CustomerContact CustomerContact { get=> _customerContact; set=> SetPropertyValue(nameof(CustomerContact),ref _customerContact,value); }

        [ModelDefault("AllowEdit","False")]
        public DateTime CreatedOn { get=> _createdOn; set=> SetPropertyValue(nameof(CreatedOn),ref _createdOn,value); }

        [ModelDefault("AllowEdit","False")]
        public Employee Owner { get=> _owner; set=> SetPropertyValue(nameof(Owner),ref _owner,value); }

        [Association("AnnualWorkPlan-Subjects")]
        public XPCollection<AnnualWorkPlanSubject> Subjects => GetCollection<AnnualWorkPlanSubject>(nameof(Subjects));
        
    }
}