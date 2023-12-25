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
    [NavigationItem("Settings")]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class AuditDeterminationLegalStatute : BaseObject
    {
        private AuditDeterminationForm _auditDeterminationForm;
        private string _legalStatute;
        private DefaultLegalLegislation _defaultLegalLegislation;
        public AuditDeterminationLegalStatute(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        [Association("AuditDeterminationForm-LegalStatutes")]
        public AuditDeterminationForm AuditDeterminationForm { get=> _auditDeterminationForm; set=> SetPropertyValue(nameof(AuditDeterminationForm),ref _auditDeterminationForm,value); }


       
        [VisibleInDetailView(false),VisibleInListView(false)]
        public string LegalStatute { get=> _legalStatute; set=> SetPropertyValue(nameof(LegalStatute),ref _legalStatute,value); }

        [RuleRequiredField("RuleRequiredField for AuditDeterminationLegalStatute.DefaultLegalLegislation", DefaultContexts.Save)]
        public DefaultLegalLegislation DefaultLegalLegislation { get => _defaultLegalLegislation; set => SetPropertyValue(nameof(DefaultLegalLegislation), ref _defaultLegalLegislation, value); }

        [Association("LegalStatute-Transactions"),DevExpress.Xpo.Aggregated]
        public XPCollection<AuditDeterminationLegalStatuteTransaction> Transactions => GetCollection<AuditDeterminationLegalStatuteTransaction>(nameof(Transactions));
    }
}