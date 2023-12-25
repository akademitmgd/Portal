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
    [DefaultProperty("Name")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    [NavigationItem(false)]
    public class VehicleControlDocumentEMailList : BaseObject
    {
        private EMailSetting _eMailSetting;
        private string _name;
        private string _email;
        private Customer _customer;
        public VehicleControlDocumentEMailList(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        [Association("EMailSetting-VehicleControlDocumentEMailList")]
        public EMailSetting EMailSetting { get=> _eMailSetting; set=> SetPropertyValue(nameof(EMailSetting),ref _eMailSetting,value); }

        [RuleRequiredField("RuleRequiredField for VehicleControlDocumentEMailList.Name", DefaultContexts.Save)]
        public string Name { get=> _name; set=> SetPropertyValue(nameof(Name),ref _name,value); }

        [RuleRequiredField("RuleRequiredField for VehicleControlDocumentEMailList.EMail", DefaultContexts.Save)]
        [RuleRegularExpression("RuleRegularExpression for VehicleControlDocumentEMailList.EMail", DefaultContexts.Save, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|" + @"(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")]
        public string EMail { get=> _email; set=> SetPropertyValue(nameof(EMail),ref _email,value); }
        public Customer Customer { get=> _customer; set=> SetPropertyValue(nameof(Customer),ref _customer,value); }
    }
}