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
    [NavigationItem("Settings")]
    public class DistributionOfTaskSubject : BaseObject
    {
        private DistributionOfTask _distributionOfTask;
        private string _subject;
        public DistributionOfTaskSubject(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        [Association("DistributionOfTask-Subjects")]
        public DistributionOfTask DistributionOfTask { get=> _distributionOfTask; set=> SetPropertyValue(nameof(DistributionOfTask),ref _distributionOfTask,value); }

        [RuleRequiredField("RuleRequiredField for DistributionOfTaskSubject.Subject", DefaultContexts.Save)]
        public string Subject { get=> _subject; set=> SetPropertyValue(nameof(Subject),ref _subject, value); }

        [Association("DistributionOfTaskSubject-Details"),DevExpress.Xpo.Aggregated]
        public XPCollection<DistributionOfTaskSubjectDetail> Details => GetCollection<DistributionOfTaskSubjectDetail>(nameof(Details));

        [Association("DistributionOfTaskSubject-AuthorizedPersons"), DevExpress.Xpo.Aggregated]
        public XPCollection<DistributionOfTaskSubjectAuth> AuthorizedPersons => GetCollection<DistributionOfTaskSubjectAuth>(nameof(AuthorizedPersons));
    }
}