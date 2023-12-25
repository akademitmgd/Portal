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
    [NavigationItem(false)]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class AnnualWorkPlanSubjectTransaction : BaseObject
    {
        private AnnualWorkPlanSubject _annualWorkPlanSubject;
        private Months _month;
        private bool _primary;
        private bool _secondary;
        private bool _thirdy;
        private bool _fourty;
        private AnnualWorkPlanStatus _status;
        public AnnualWorkPlanSubjectTransaction(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        [Association("Subject-Transactions")]
        public AnnualWorkPlanSubject AnnualWorkPlanSubject { get=> _annualWorkPlanSubject; set=> SetPropertyValue(nameof(AnnualWorkPlanSubject),ref _annualWorkPlanSubject,value); }

        public Months Month { get => _month; set => SetPropertyValue(nameof(Month), ref _month, value); }

        [ImmediatePostData]
        public bool Primary { get => _primary; set => SetPropertyValue(nameof(Primary), ref _primary, value); }

        [ImmediatePostData]
        public bool Secondary { get => _secondary; set => SetPropertyValue(nameof(Secondary), ref _secondary, value); }

        [ImmediatePostData]
        public bool Thirdy { get => _thirdy; set => SetPropertyValue(nameof(Thirdy), ref _thirdy, value); }

        [ImmediatePostData]
        public bool Fourty { get => _fourty; set => SetPropertyValue(nameof(Fourty), ref _fourty, value); }
    }
}