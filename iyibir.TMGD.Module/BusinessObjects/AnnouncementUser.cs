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
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Editors;

namespace iyibir.TMGD.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem(false)]
    [Appearance("AnnouncementUser Delete", AppearanceItemType = "Action", TargetItems = "Delete", Visibility = ViewItemVisibility.Hide)]
    [Appearance("AnnouncementUser Edit", AppearanceItemType = "Action", TargetItems = "Edit", Visibility = ViewItemVisibility.Hide)]
    [Appearance("AnnouncementUser New", AppearanceItemType = "Action", TargetItems = "New", Visibility = ViewItemVisibility.Hide)]
    public class AnnouncementUser : BaseObject
    {
        private Employee _employee;
        private Announcement _announcement;
        private bool _isRead;
        private DateTime _readDate;
        public AnnouncementUser(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [Association("Announcement-Users")]
        [ModelDefault("AllowEdit", "False")]
        public Announcement Announcement
        {
            get { return _announcement; }
            set { SetPropertyValue("Announcement", ref _announcement, value); }
        }

        [ModelDefault("AllowEdit", "False")]
        public Employee Employee
        {
            get { return _employee; }
            set { SetPropertyValue("Employee", ref _employee, value); }
        }

        [ModelDefault("AllowEdit", "False")]
        [VisibleInDetailView(false)]
        public bool IsRead
        {
            get { return _isRead; }
            set { SetPropertyValue("IsRead", ref _isRead, value); }
        }

        [ModelDefault("AllowEdit", "False")]
        [VisibleInDetailView(false)]
        public DateTime ReadDate
        {
            get { return _readDate; }
            set { SetPropertyValue("ReadDate", ref _readDate, value); }
        }
    }
}