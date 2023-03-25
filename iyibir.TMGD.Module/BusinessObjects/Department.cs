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
    [ImageName("BO_Department")]
    [DefaultProperty("Name")]
    public class Department : BaseObject
    {
        private string _code;
        private string _name;
        private string _description;
        private Employee _manager;
        private bool _isManager;
        public Department(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        [RuleRequiredField("RuleRequiredField for Department.Code", DefaultContexts.Save)]
        [RuleUniqueValue("RuleUniqueValue for Department.Code", DefaultContexts.Save)]
        public string Code
        {
            get { return _code; }
            set { SetPropertyValue("Code", ref _code, value); }
        }

        [RuleRequiredField("RuleRequiredField for Department.Name", DefaultContexts.Save)]
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

        public Employee Manager
        {
            get { return _manager; }
            set { SetPropertyValue("Manager", ref _manager, value); }
        }

        public bool IsManager { get => _isManager; set => SetPropertyValue("IsManager", ref _isManager, value); }

        [Association("Department-Positions")]
        public XPCollection<Position> Positions
        {
            get { return GetCollection<Position>("Positions"); }
        }
    }
}