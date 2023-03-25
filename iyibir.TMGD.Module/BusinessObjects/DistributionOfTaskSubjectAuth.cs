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
    [ImageName("BO_User")]    
    public class DistributionOfTaskSubjectAuth : BaseObject
    {
        private DistributionOfTaskSubject _distributionOfTaskSubject;
        private string _authorizedPerson;
        public DistributionOfTaskSubjectAuth(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        [Association("DistributionOfTaskSubject-AuthorizedPersons")]
        public DistributionOfTaskSubject DistributionOfTaskSubject { get => _distributionOfTaskSubject; set => SetPropertyValue(nameof(DistributionOfTaskSubject), ref _distributionOfTaskSubject, value); }

        [RuleRequiredField("RuleRequiredField for DistributionOfTaskSubjectAuth.AuthorizedPerson", DefaultContexts.Save)]
        public string AuthorizedPerson { get=> _authorizedPerson; set=> SetPropertyValue(nameof(AuthorizedPerson),ref _authorizedPerson,value); }
    }
}