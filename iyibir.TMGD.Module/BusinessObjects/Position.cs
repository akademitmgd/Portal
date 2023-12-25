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
    [ImageName("BO_Position")]
    [DefaultProperty("Name")]
    [NavigationItem("Settings")]
    public class Position : BaseObject
    {
        private string _code;
        private string _name;
        private string _description;
        private Department _department;
        public Position(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        [RuleRequiredField("RuleRequiredField for Position.Code", DefaultContexts.Save)]
        [RuleUniqueValue("RuleUniqueValue for Position.Code", DefaultContexts.Save)]
        public string Code
        {
            get { return _code; }
            set { SetPropertyValue("Code", ref _code, value); }
        }

        [RuleRequiredField("RuleRequiredField for Position.Name", DefaultContexts.Save)]
        public string Name
        {
            get { return _name; }
            set { SetPropertyValue("Name", ref _name, value); }
        }

        public string Description
        {
            get { return _description; }
            set { SetPropertyValue("Description", ref _description, value); }
        }

        [Association("Department-Positions")]
        [VisibleInDetailView(false)]
        public Department Department
        {
            get { return _department; }
            set { SetPropertyValue("Department", ref _department, value); }
        }
    }
}