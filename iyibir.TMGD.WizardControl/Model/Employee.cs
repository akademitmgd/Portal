using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iyibir.TMGD.WizardControl.Model
{
    public partial class Employee
    {
        public Guid Oid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public bool IsManager { get; set; }
        public string Telephone { get; set; }
        public string Telephone2 { get; set; }
        public string EMail { get; set; }
        public string Address { get; set; }
        public string WebAddress { get; set; }
        public bool IsActive { get; set; }
        public int EmployeeType { get; set; }
        public string TmgdCertificate { get; set; }
        public string Caption { get; set; }
        public Customer Customer { get; set; }
        public Department Department { get; set; }
        public Position Position { get; set; }
    }
}
