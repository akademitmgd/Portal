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
    [DefaultProperty("Question")]
    public class DefaultVehicleControlDocumentTransaction : BaseObject
    {
        private Customer _customer;
        private VehicleControlOption _vControlOption;
        private string _question;
        private string _hint;
        public DefaultVehicleControlDocumentTransaction(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        [Association("Customer-DefaultVehicleDocumentTransactions")]
        public Customer Customer { get=>_customer; set=> SetPropertyValue(nameof(Customer),ref _customer,value); }

        public VehicleControlOption VControlOption { get => _vControlOption; set => SetPropertyValue(nameof(VControlOption), ref _vControlOption, value); }

        [RuleRequiredField("RuleRequiredField for DefaultVehicleControlDocumentTransaction.Question", DefaultContexts.Save)]
        [Size(450)]
        public string Question { get=> _question; set=> SetPropertyValue(nameof(Question),ref _question,value); }

        [Size(-1)]
        public string Hint { get => _hint; set => SetPropertyValue(nameof(Hint), ref _hint, value); }
    }
}