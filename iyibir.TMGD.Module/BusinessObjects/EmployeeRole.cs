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
using DevExpress.Persistent.BaseImpl.PermissionPolicy;

namespace iyibir.TMGD.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("BO_Role")]
    [NavigationItem("Settings")]
    public class EmployeeRole : PermissionPolicyRoleBase, IPermissionPolicyRoleWithUsers
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public EmployeeRole(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }


        [Association("Employees-EmployeeRoles")]
        public XPCollection<Employee> Employees
        {
            get { return GetCollection<Employee>("Employees"); }
        }
        IEnumerable<IPermissionPolicyUser> IPermissionPolicyRoleWithUsers.Users
        {
            get { return Employees.OfType<IPermissionPolicyUser>(); }
        }
    }
}