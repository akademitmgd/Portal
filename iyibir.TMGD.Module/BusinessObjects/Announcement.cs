using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Base.General;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace iyibir.TMGD.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("BO_Scheduler")]
    [DefaultProperty("Title")]
    [Appearance("Announcement Closed", Criteria = "Users[Employee.Oid = CurrentUserId() and IsRead = True]", Context = "ListView", TargetItems = "*", FontStyle = System.Drawing.FontStyle.Strikeout)]
    public class Announcement : BaseObject
    {
        private string _title;
        private Employee _createdBy;
        private DateTime _createdOn;
        private string _description;
        private bool _isActive;
        public Announcement(Session session)
                    : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (Session.IsNewObject(this))
            {
                CreatedBy = Session.GetObjectByKey<Employee>(SecuritySystem.CurrentUserId);
                CreatedOn = DateTime.Now;
            }
        }

        public string Title
        {
            get { return _title; }
            set { SetPropertyValue("Title", ref _title, value); }
        }

        [VisibleInDetailView(false)]
        public Employee CreatedBy
        {
            get { return _createdBy; }
            set { SetPropertyValue("CreatedBy", ref _createdBy, value); }
        }

        [VisibleInDetailView(false)]
        public DateTime CreatedOn
        {
            get { return _createdOn; }
            set { SetPropertyValue("CreatedOn", ref _createdOn, value); }
        }

        [Size(-1)]
        public string Description
        {
            get { return _description; }
            set { SetPropertyValue("Description", ref _description, value); }
        }

        public bool IsActive
        {
            get { return _isActive; }
            set { SetPropertyValue("IsActive", ref _isActive, value); }
        }



        [Association("Announcement-Users")]
        [DevExpress.Xpo.Aggregated]
        public XPCollection<AnnouncementUser> Users
        {
            get { return GetCollection<AnnouncementUser>("Users"); }
        }

        [DevExpress.Xpo.Aggregated]
        [VisibleInDetailView(false)]
        [Association("Employee-Announcement")]
        public XPCollection<Employee> Employees
        {
            get { return GetCollection<Employee>("Employees"); }
        }
    }
}