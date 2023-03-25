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
    [Appearance("VoyageNotificationHistory Delete", AppearanceItemType = "Action", TargetItems = "Delete", Visibility = ViewItemVisibility.Hide)]
    [Appearance("VoyageNotificationHistory Edit", AppearanceItemType = "Action", TargetItems = "Edit", Visibility = ViewItemVisibility.Hide)]
    [Appearance("VoyageNotificationHistory New", AppearanceItemType = "Action", TargetItems = "New", Visibility = ViewItemVisibility.Hide)]
    public class VoyageNotificationHistory : BaseObject
    {
        private VoyageNotification _voyageNotification;
        private string _message;
        private DateTime _createdOn;
        public VoyageNotificationHistory(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        [Association("VoyageNotification-Histories")]
        public VoyageNotification VoyageNotification { get=>_voyageNotification; set=>SetPropertyValue(nameof(VoyageNotification),ref _voyageNotification,value); }
        
        [ModelDefault("AllowEdit","False")]
        public string Message { get=>_message; set=>SetPropertyValue(nameof(Message),ref _message,value); }

        [ModelDefault("AllowEdit", "False")]
        public DateTime CreatedOn { get => _createdOn; set => SetPropertyValue(nameof(CreatedOn), ref _createdOn, value); }
    }
}