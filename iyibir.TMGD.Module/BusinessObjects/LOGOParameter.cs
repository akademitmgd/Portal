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
    [NavigationItem("Settings")]
    public class LOGOParameter : BaseObject
    {
        private Employee _employee;
        private string _uri;
        private string _username;
        private string _password;
        private int _firmNumber;
        private int _periodNumber;
        private bool _isActive;
        public LOGOParameter(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (Session.IsNewObject(this))
            {
                IsActive = true;
            }
        }

        public Employee Employee { get => _employee; set => SetPropertyValue(nameof(Employee), ref _employee, value); }

        [RuleRequiredField]
        public string Uri { get => _uri; set => SetPropertyValue(nameof(Uri), ref _uri, value); }

        [RuleRequiredField]
        public string Username { get => _username; set => SetPropertyValue(nameof(Username), ref _username, value); }

        [RuleRequiredField]
        [PasswordPropertyText]
        public string Password { get => _password; set => SetPropertyValue(nameof(Password), ref _password, value); }

        [RuleRequiredField]
        public int FirmNumber { get => _firmNumber; set => SetPropertyValue(nameof(FirmNumber), ref _firmNumber, value); }

        [RuleRequiredField]
        public int PeriodNumber { get => _periodNumber; set => SetPropertyValue(nameof(PeriodNumber), ref _periodNumber, value); }

        [VisibleInListView(false), VisibleInDetailView(false), ModelDefault("AllowEdit", "False")]
        public bool IsActive { get => _isActive; set => SetPropertyValue(nameof(IsActive), ref _isActive, value); }
    }
}