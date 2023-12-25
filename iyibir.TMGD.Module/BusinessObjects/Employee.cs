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
using DevExpress.ExpressApp.Security;
using DevExpress.Persistent.Base.Security;
using DevExpress.Persistent.Base.General;
using System.Drawing;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Editors;

namespace iyibir.TMGD.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("BO_Employee")]
    [DefaultProperty("FullName")]
    [CurrentUserDisplayImage(nameof(Image))]
    [NavigationItem("Settings")]
    public class Employee : BaseObject, ISecurityUser, IAuthenticationStandardUser, ISecurityUserWithRoles, IPermissionPolicyUser, IResource
    {
        private Position _position;
        private Department _department;
        private string _address;
        private string _telephone2;
        private string _telephone;
        private string _webAddress;
        private string _eMail;
        private string _middleName;
        private string _code;
        private string _firstName;
        private string _lastName;
        private string _clientMachineName;
        private string _logoUserName;
        private string _tckn;
        private MediaDataObject image;
        private FileData _tmgdCertificateFile;

        [Persistent("Color")]
        private int _color;
        private string _caption;
        private bool _isManager;
        private string _tmgdCertificate;
        private EmployeeType _employeeType;
        private Customer _customer;
        public Employee(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            _color = Color.White.ToArgb();
        }

        protected override void OnSaving()
        {
            base.OnSaving();
            if (!Session.IsObjectMarkedDeleted(this))
            {
                Caption = string.Format("{0} {1} {2}", _firstName, _middleName, _lastName);
            }
        }

        [RuleRequiredField("RuleRequiredField for Employee.Code", DefaultContexts.Save)]
        [RuleUniqueValue("RuleUniqueValue for Employee.Code", DefaultContexts.Save, CriteriaEvaluationBehavior = CriteriaEvaluationBehavior.BeforeTransaction)]
        [VisibleInListView(false)]
        public string Code
        {
            get { return _code; }
            set { SetPropertyValue("Code", ref _code, value); }
        }

        [Size(11)]
        public string TCKN
        {
            get { return _tckn; }
            set { SetPropertyValue("TCKN", ref _tckn, value); }
        }

        [RuleRequiredField("RuleRequiredField for Employee.FirstName", DefaultContexts.Save)]
        [VisibleInListView(false)]
        public string FirstName
        {
            get { return _firstName; }
            set { SetPropertyValue("FirstName", ref _firstName, value); }
        }

        [VisibleInListView(false)]
        public string MiddleName
        {
            get { return _middleName; }
            set { SetPropertyValue("MiddleName", ref _middleName, value); }
        }

        [RuleRequiredField("RuleRequiredField for Employee.LastName", DefaultContexts.Save)]
        [VisibleInListView(false)]
        public string LastName
        {
            get { return _lastName; }
            set { SetPropertyValue("LastName", ref _lastName, value); }
        }

        [VisibleInDetailView(false)]
        [NonPersistent]
        public string FullName
        {
            get { return string.Format("{0} {1} {2}", _firstName, _middleName, _lastName); }
        }

        [RuleRequiredField("RuleRequiredField for Employee.EMail", DefaultContexts.Save)]
        [RuleRegularExpression("RuleRegularExpression Employee.EMail", DefaultContexts.Save, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|" + @"(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")]
        public string EMail
        {
            get { return _eMail; }
            set { SetPropertyValue("EMail", ref _eMail, value); }
        }

        [VisibleInListView(false)]
        public string WebAddress
        {
            get { return _webAddress; }
            set { SetPropertyValue("WebAddress", ref _webAddress, value); }
        }

        [ModelDefault("EditMaskType", "Simple")]
        [ModelDefault("EditMask", "(999) 000-0000")]
        public string Telephone
        {
            get { return _telephone; }
            set { SetPropertyValue("Telephone", ref _telephone, value); }
        }

        [ModelDefault("EditMaskType", "Simple")]
        [ModelDefault("EditMask", "(999) 000-0000")]
        [VisibleInListView(false)]
        public string Telephone2
        {
            get { return _telephone2; }
            set { SetPropertyValue("Telephone2", ref _telephone2, value); }
        }

        [VisibleInListView(false)]
        public string Address
        {
            get { return _address; }
            set { SetPropertyValue("Address", ref _address, value); }
        }

        [VisibleInListView(false)]
        public string ClientMachineName
        {
            get { return _clientMachineName; }
            set { SetPropertyValue("ClientMachineName", ref _clientMachineName, value); }
        }

        [VisibleInListView(false)]
        public string LogoUserName
        {
            get { return _logoUserName; }
            set { SetPropertyValue("LogoUserName", ref _logoUserName, value); }
        }

        [ImmediatePostData]
        public Department Department
        {
            get { return _department; }
            set { SetPropertyValue("Department", ref _department, value); }
        }

        [DataSourceProperty("Department.Positions")]
        public Position Position
        {
            get { return _position; }
            set { SetPropertyValue("Position", ref _position, value); }
        }

        public MediaDataObject Image
        {
            get { return image; }
            set { SetPropertyValue("Image", ref image, value); }
        }

        public bool IsManager { get => _isManager; set => SetPropertyValue("IsManager", ref _isManager, value); }

        public string TMGDCertificate { get=> _tmgdCertificate; set=> SetPropertyValue(nameof(TMGDCertificate),ref _tmgdCertificate,value); }

        [RuleRequiredField("RuleRequiredField for Employee.TMGDCertificateFile", DefaultContexts.Save)]
        [ExpandObjectMembers(ExpandObjectMembers.Never)]
        public FileData TMGDCertificateFile { get => _tmgdCertificateFile; set => SetPropertyValue(nameof(TMGDCertificateFile), ref _tmgdCertificateFile, value); }

        [ImmediatePostData]
        public EmployeeType EmployeeType { get=> _employeeType; set=> SetPropertyValue(nameof(EmployeeType),ref _employeeType,value); }

        [RuleRequiredField("RuleRequiredField for Employee.Customer", DefaultContexts.Save,TargetCriteria ="EmployeeType = 1")]
        [Appearance("Employee Customer Hide", Criteria = "EmployeeType = 0", Context = "DetailView", Visibility = ViewItemVisibility.Hide)]
        public Customer Customer { get=> _customer; set=> SetPropertyValue(nameof(Customer),ref _customer,value); }

        [Association("Employees-EmployeeRoles")]
        [RuleRequiredField("EmployeeRoleIsRequired", DefaultContexts.Save, TargetCriteria = "IsActive", CustomMessageTemplate = "An active employee must have at least one role assigned")]
        public XPCollection<EmployeeRole> EmployeeRoles
        {
            get { return GetCollection<EmployeeRole>("EmployeeRoles"); }
        }

        //[Association("iEvent-Employees", UseAssociationNameAsIntermediateTableName = true)]
        //public XPCollection<iEvent> MyAgenda
        //{
        //    get { return GetCollection<iEvent>("MyAgenda"); }
        //}

        [Association("Employee-Notes"),DevExpress.Xpo.Aggregated]
        public XPCollection<Note> MyNotes => GetCollection<Note>(nameof(MyNotes));

        [Association("Employee-Customers")]
        public XPCollection<Customer> Customers => GetCollection<Customer>(nameof(Customers));

        [Association("Employee-Documents"),DevExpress.Xpo.Aggregated]
        public XPCollection<EmployeeDocument> Documents => GetCollection<EmployeeDocument>(nameof(Documents));

        [Association("Employee-Announcement")]
        public XPCollection<Announcement> Announcements => GetCollection<Announcement>(nameof(Announcements));

        #region ISecurityUser Members
        private bool isActive = true;
        public bool IsActive
        {
            get { return isActive; }
            set { SetPropertyValue("IsActive", ref isActive, value); }
        }
        private string userName = String.Empty;
        [RuleRequiredField("EmployeeUserNameRequired", DefaultContexts.Save)]
        [RuleUniqueValue("EmployeeUserNameIsUnique", DefaultContexts.Save,
            "The login with the entered user name was already registered within the system.")]
        [VisibleInListView(false)]
        public string UserName
        {
            get { return userName; }
            set { SetPropertyValue("UserName", ref userName, value); }
        }
        #endregion

        #region IAuthenticationStandardUser Members
        private bool changePasswordOnFirstLogon;

        [VisibleInListView(false)]
        public bool ChangePasswordOnFirstLogon
        {
            get { return changePasswordOnFirstLogon; }
            set
            {
                SetPropertyValue("ChangePasswordOnFirstLogon", ref changePasswordOnFirstLogon, value);
            }
        }
        private string storedPassword;
        [Browsable(false), Size(SizeAttribute.Unlimited), Persistent, SecurityBrowsable]
        protected string StoredPassword
        {
            get { return storedPassword; }
            set { storedPassword = value; }
        }
        public bool ComparePassword(string password)
        {
            return new PasswordCryptographer().AreEqual(this.storedPassword, password);
        }
        public void SetPassword(string password)
        {
            this.storedPassword = new PasswordCryptographer().GenerateSaltedPassword(password);
            OnChanged("StoredPassword");
        }
        #endregion

        #region ISecurityUserWithRoles Members
        IList<ISecurityRole> ISecurityUserWithRoles.Roles
        {
            get
            {
                IList<ISecurityRole> result = new List<ISecurityRole>();
                foreach (EmployeeRole role in EmployeeRoles)
                {
                    result.Add(role);
                }
                return result;
            }
        }
        #endregion

        #region IPermissionPolicyUser Members
        IEnumerable<IPermissionPolicyRole> IPermissionPolicyUser.Roles
        {
            get { return EmployeeRoles.OfType<IPermissionPolicyRole>(); }
        }
        #endregion

        #region IResource Members
        public string Caption
        {
            get { return _caption; }
            set { SetPropertyValue("Caption", ref _caption, value); }
        }

        [Browsable(false)]
        public object Id { get { return Oid; } }

        [Browsable(false)]
        public int OleColor
        {
            get { return ColorTranslator.ToOle(Color.FromArgb(_color)); }
        }

        [NonPersistent]
        public Color Color
        {
            get { return Color.FromArgb(_color); }
            set { SetPropertyValue("Color", ref _color, value.ToArgb()); }
        }
        #endregion
    }
}