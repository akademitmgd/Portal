using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace iyibir.TMGD.Module.BusinessObjects
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    [NavigationItem(false)]
    public class DefaultDistributionOfTaskSubjectDesc : BaseObject
    {
        private DefaultDistributionOfTaskSubject _defaultSubject;
        private string _description;
        public DefaultDistributionOfTaskSubjectDesc(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        [Association("DefaultSubject-Descriptions")]
        public DefaultDistributionOfTaskSubject DefaultSubject { get=> _defaultSubject; set=> SetPropertyValue(nameof(DefaultSubject),ref _defaultSubject,value); }

        [Size(-1)]
        public string Description { get=> _description; set=> SetPropertyValue(nameof(Description),ref _description,value); }
    }
}