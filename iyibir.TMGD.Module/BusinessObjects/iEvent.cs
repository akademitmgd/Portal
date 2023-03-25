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
using DevExpress.Persistent.Base.General;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml;
using DevExpress.Xpo.Metadata;

namespace iyibir.TMGD.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("BO_Scheduler")]
    [DefaultProperty("Subject")]
    public class iEvent : BaseObject, IEvent, IRecurrentEvent, ISupportNotifications
    {
        private bool _AllDay;
        private string _Description;
        private DateTime _StartOn;
        private DateTime _EndOn;
        private int _Label;
        private string _Location;
        private int _Status;
        private string _Subject;
        private int _Type;
        private string _RecurrenceInfoXml;
        private Employee _owner;

        [Persistent("ResourceIds"), Size(SizeAttribute.Unlimited)]
        private string _EmployeeIds;

        [Persistent("RecurrencePattern")]
        private iEvent _RecurrencePattern;
        public iEvent(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

            Owner = Session.GetObjectByKey<Employee>(SecuritySystem.CurrentUserId);
            StartOn = DateTime.Now;
            EndOn = StartOn.AddHours(1);
            Employees.Add(Session.GetObjectByKey<Employee>(SecuritySystem.CurrentUserId));
        }

        [Association("iEvent-Employees", UseAssociationNameAsIntermediateTableName = true)]
        public XPCollection<Employee> Employees
        {
            get { return GetCollection<Employee>("Employees"); }
        }
        protected override XPCollection<T> CreateCollection<T>(XPMemberInfo property)
        {
            XPCollection<T> result = base.CreateCollection<T>(property);
            if (property.Name == "Employees")
            {
                result.ListChanged += Employees_ListChanged;
            }
            return result;
        }
        public void UpdateEmployeeIds()
        {
            _EmployeeIds = string.Empty;
            foreach (Employee employee in Employees)
            {
                _EmployeeIds += String.Format(@"<ResourceId Type=""{0}"" Value=""{1}"" />", employee.Id.GetType().FullName, employee.Id);
            }
            _EmployeeIds = String.Format("<ResourceIds>{0}</ResourceIds>", _EmployeeIds);
        }
        private void UpdateEmployees()
        {
            Employees.SuspendChangedEvents();
            try
            {
                while (Employees.Count > 0)
                    Employees.Remove(Employees[0]);
                if (!string.IsNullOrEmpty(_EmployeeIds))
                {
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.LoadXml(_EmployeeIds);
                    foreach (XmlNode xmlNode in xmlDocument.DocumentElement.ChildNodes)
                    {
                        //Employee activityUser = Session.GetObjectByKey<Employee>(new Guid(xmlNode.Attributes["Value"].Value));
                        Employee activityUser = Session.GetObjectByKey<Employee>(SecuritySystem.CurrentUserId);
                        if (activityUser != null)
                            Employees.Add(activityUser);
                    }
                }
            }
            finally
            {
                Employees.ResumeChangedEvents();
            }
        }
        private void Employees_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted)
            {
                UpdateEmployeeIds();
                OnChanged("ResourceId");
            }
        }
        protected override void OnLoaded()
        {
            base.OnLoaded();
            if (Employees.IsLoaded && !Session.IsNewObject(this))
                Employees.Reload();
        }

        [NonPersistent]
        [Browsable(false)]
        [RuleFromBoolProperty("iEventIntervalValid", DefaultContexts.Save, "The start date must be less than the end date", SkipNullOrEmptyValues = false, UsedProperties = "StartOn, EndOn")]
        public bool IsIntervalValid { get { return StartOn <= EndOn; } }

        [ModelDefault("AllowEdit","False")]
        public Employee Owner { get=> _owner; set=> SetPropertyValue(nameof(Owner),ref _owner,value); }

        #region IEvent Members
        public bool AllDay
        {
            get { return _AllDay; }
            set { SetPropertyValue("AllDay", ref _AllDay, value); }
        }

        [Browsable(false), NonPersistent]
        public object AppointmentId
        {
            get { return Oid; }
        }

        [Size(SizeAttribute.Unlimited)]
        public string Description
        {
            get { return _Description; }
            set { SetPropertyValue("Description", ref _Description, value); }
        }

        public int Label
        {
            get { return _Label; }
            set { SetPropertyValue("Label", ref _Label, value); }
        }
        public string Location
        {
            get { return _Location; }
            set { SetPropertyValue("Location", ref _Location, value); }
        }
        [PersistentAlias("_EmployeeIds"), Browsable(false)]
        public string ResourceId
        {
            get
            {
                if (_EmployeeIds == null)
                    UpdateEmployeeIds();
                return _EmployeeIds;
            }
            set
            {
                if (_EmployeeIds != value && value != null)
                {
                    _EmployeeIds = value;
                    UpdateEmployees();
                }
            }
        }
        [Indexed]
        [ModelDefault("DisplayFormat", "{0:G}")]
        [ModelDefault("EditMask", "G")]
        public DateTime StartOn
        {
            get { return _StartOn; }
            set { SetPropertyValue("StartOn", ref _StartOn, value); }
        }
        [Indexed]
        [ModelDefault("DisplayFormat", "{0:G}")]
        [ModelDefault("EditMask", "G")]
        public DateTime EndOn
        {
            get { return _EndOn; }
            set { SetPropertyValue("EndOn", ref _EndOn, value); }
        }
        public int Status
        {
            get { return _Status; }
            set { SetPropertyValue("Status", ref _Status, value); }
        }
        [Size(250)]
        public string Subject
        {
            get { return _Subject; }
            set { SetPropertyValue("Subject", ref _Subject, value); }
        }
        [Browsable(false)]
        public int Type
        {
            get { return _Type; }
            set { SetPropertyValue("Type", ref _Type, value); }
        }
        #endregion

        #region IRecurrentEvent Members
        [DevExpress.Xpo.DisplayName("Recurrence"), Size(SizeAttribute.Unlimited)]
        public string RecurrenceInfoXml
        {
            get { return _RecurrenceInfoXml; }
            set { SetPropertyValue("RecurrenceInfoXml", ref _RecurrenceInfoXml, value); }
        }
        [Browsable(false)]
        [PersistentAlias("_RecurrencePattern")]
        public IRecurrentEvent RecurrencePattern
        {
            get { return _RecurrencePattern; }
            set { SetPropertyValue("RecurrencePattern", ref _RecurrencePattern, value as iEvent); }
        }
        #endregion

        #region ISupportNotifications members
        private DateTime? alarmTime;
        [Browsable(false)]
        public DateTime? AlarmTime
        {
            get { return alarmTime; }
            set
            {
                SetPropertyValue<DateTime?>("AlarmTime", ref alarmTime, value);
                if (value == null)
                {
                    RemindIn = null;
                    IsPostponed = false;
                }
            }
        }
        private bool isPostponed;
        [Browsable(false)]
        public bool IsPostponed
        {
            get { return isPostponed; }
            set { SetPropertyValue<bool>("IsPostponed", ref isPostponed, value); }
        }

        [Browsable(false), NotMapped]
        public string NotificationMessage
        {
            get { return Subject; }
        }

        private TimeSpan? remindIn;
        public TimeSpan? RemindIn
        {
            get { return remindIn; }
            set { SetPropertyValue<TimeSpan?>("RemindIn", ref remindIn, value); }
        }

        [Browsable(false), NotMapped]
        public object UniqueId
        {
            get { return Oid; }
        }
        #endregion
    }
}