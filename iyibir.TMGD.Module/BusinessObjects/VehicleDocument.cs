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
    public class VehicleDocument : BaseObject
    {
        private Vehicle _vehicle;
        private FileData _documentData;
        private Employee _owner;
        private DateTime _createdOn;
        private string _description;
        public VehicleDocument(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (Session.IsNewObject(this))
            {
                CreatedOn = DateTime.Now;
                Owner = Session.GetObjectByKey<Employee>(SecuritySystem.CurrentUserId);
            }
        }

        [Association("Vehicle-Documents")]
        public Vehicle Vehicle { get=> _vehicle; set=> SetPropertyValue(nameof(Vehicle),ref _vehicle,value); }

        [RuleRequiredField("RuleRequiredField for VehicleDocument.FileData", DefaultContexts.Save)]
        [ExpandObjectMembers(ExpandObjectMembers.Never)]
        public FileData FileData { get => _documentData; set => SetPropertyValue("FileData", ref _documentData, value); }

        [VisibleInDetailView(false)]
        [ModelDefault("AllowEdit", "False")]
        public Employee Owner { get => _owner; set => SetPropertyValue("Owner", ref _owner, value); }

        [VisibleInDetailView(false)]
        [ModelDefault("AllowEdit", "False")]
        public DateTime CreatedOn { get => _createdOn; set => SetPropertyValue("CreatedOn", ref _createdOn, value); }
        public string Description { get => _description; set => SetPropertyValue("Description", ref _description, value); }
    }
}