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
    [ImageName("BO_FileAttachment")]
    [DefaultProperty("Name")]
    public class CustomerDocument : BaseObject
    {
        private Customer _customer;
        private FileData _document;
        public CustomerDocument(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        [Association("Customer-Documents")]
        public Customer Customer { get=> _customer; set=> SetPropertyValue(nameof(Customer),ref _customer,value); }

        [RuleRequiredField("RuleRequiredField for CustomerDocument.Document", DefaultContexts.Save)]
        [ExpandObjectMembers(ExpandObjectMembers.Never)]
        public FileData Document { get => _document; set => SetPropertyValue("Document", ref _document, value); }
    }
}