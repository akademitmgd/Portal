using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iyibir.TMGD.WebAPI.V2.EModels
{
    public class EmployeeModel
    {
        public Guid Oid { get; set; }
        public string Address { get; set; }
        public string Telephone2 { get; set; }
        public string Telephone { get; set; }
        public string WebAddress { get; set; }
        public string EMail { get; set; }
        public string MiddleName { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TCKN { get; set; }
        public string Caption { get; set; }
        public bool IsManager { get; set; }
        public string TMGDCertificate { get; set; }
        public int EmployeeType { get; set; }
        public CustomerModel Customer { get; set; }
    }
}