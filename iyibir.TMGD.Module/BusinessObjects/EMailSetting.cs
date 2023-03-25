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
    public class EMailSetting : BaseObject
    {
        private string _name;
        private string _fromMailAddress;
        private string _fromMailAddressPassword;
        private int _port;
        private bool _useSSL;
        private string _smtpAddress;
        private bool _isActive;
        public EMailSetting(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        [RuleRequiredField("RuleRequiredField from EMailSetting.Name", DefaultContexts.Save)]
        public string Name { get => _name; set => SetPropertyValue("Name", ref _name, value); }

        [RuleRequiredField("RuleRequiredField from EMailSetting.FromMailAddress", DefaultContexts.Save)]
        public string FromMailAddress { get => _fromMailAddress; set => SetPropertyValue("FromMailAddress", ref _fromMailAddress, value); }

        [RuleRequiredField("RuleRequiredField from EMailSetting.FromMailAddressPassword", DefaultContexts.Save)]
        public string FromMailAddressPassword { get => _fromMailAddressPassword; set => SetPropertyValue("FromMailAddressPassword", ref _fromMailAddressPassword, value); }

        [RuleRequiredField("RuleRequiredField from EMailSetting.Port", DefaultContexts.Save)]
        public int Port { get => _port; set => SetPropertyValue("Port", ref _port, value); }

        [RuleRequiredField("RuleRequiredField from EMailSetting.UseSSL", DefaultContexts.Save)]
        public bool UseSSL { get => _useSSL; set => SetPropertyValue("UseSSL", ref _useSSL, value); }

        [RuleRequiredField("RuleRequiredField from EMailSetting.SMTPAddress", DefaultContexts.Save)]
        public string SMTPAddress { get => _smtpAddress; set => SetPropertyValue("SMTPAddress", ref _smtpAddress, value); }

        [RuleUniqueValue("RuleUniqueValue from EMailSetting.IsActive", DefaultContexts.Save)]
        public bool IsActive { get => _isActive; set => SetPropertyValue("IsActive", ref _isActive, value); }

        [Association("EMailSetting-VehicleControlDocumentEMailList"),DevExpress.Xpo.Aggregated]
        public XPCollection<VehicleControlDocumentEMailList> VehicleControlDocumentEMailList => GetCollection<VehicleControlDocumentEMailList>(nameof(VehicleControlDocumentEMailList));
    }
}