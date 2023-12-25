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
    public class DistributionOfTaskSubjectDetail : BaseObject
    {
        private DistributionOfTaskSubject _distributionOfTaskSubject;
        private string _description;
        public DistributionOfTaskSubjectDetail(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        [Association("DistributionOfTaskSubject-Details")]
        public DistributionOfTaskSubject DistributionOfTaskSubject { get=> _distributionOfTaskSubject; set=> SetPropertyValue(nameof(DistributionOfTaskSubject),ref _distributionOfTaskSubject,value); }

        [Size(-1)]
        [RuleRequiredField("RuleRequiredField for DistributionOfTaskSubjectDetail.Description", DefaultContexts.Save)]
        public string Description { get=> _description; set=> SetPropertyValue(nameof(Description),ref _description,value); }
    }
}