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
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Participant : BaseObject
    {
        private Education _education;
        private int _lineNumber;
        private string _name;
        private string _tckn;
        private double _degree;
        public Participant(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

        }

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            switch (propertyName)
            {
                case "Education":
                    if (Education != null)
                    {
                        LineNumber = Education.Participants.Count;

                        this.RaisePropertyChangedEvent(nameof(LineNumber));
                    }
                    break;
                default:
                    break;
            }
        }

        [Association("Education-Participants")]
        [ImmediatePostData]
        public Education Education { get=> _education; set=> SetPropertyValue(nameof(Education),ref _education,value); }

        public int LineNumber { get => _lineNumber;
                 set=> SetPropertyValue(nameof(LineNumber),ref _lineNumber,value); }

        [RuleRequiredField("RuleRequiredField for Participant.Name", DefaultContexts.Save)]
        public string Name { get=> _name; set=> SetPropertyValue(nameof(Name),ref _name,value); }

        [Size(11),Browsable(false)]
        public string TCKN { get=> _tckn; set=> SetPropertyValue(nameof(TCKN),ref _tckn,value); }

        [Browsable(false)]
        public double Degree { get=> _degree; set=> SetPropertyValue(nameof(Degree),ref _degree,value); }
    }
}