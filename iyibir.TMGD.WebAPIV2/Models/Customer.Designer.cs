using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iyibir.TMGD.WebAPIV2.Models
{
    public partial class Customer
    {
        public Guid Oid { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TCKN { get; set; }
        public string TaxNumber { get; set; }
        public string TaxOffice { get; set; }
        public string Title { get; set; }
        public string Telephone { get; set; }
        public string OtherTelephone { get; set; }
        public string EMail { get; set; }
        public string Address { get; set; }
        public Employee Consultant { get; set; }
        public bool IsActive { get; set; }
        public bool IsPerson { get; set; }
        public string UETDSPassword { get; set; }
        public string UETDSUsername { get; set; }
    }
}