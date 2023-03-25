﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iyibir.TMGD.WizardControl.Model
{
    public class Consignee
    {
        public Guid Oid { get; set; }
        public Customer Customer { get; set; }
        public int ConsigneeType { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Telephone { get; set; }
        public string OtherTelephone { get; set; }
        public string EMail { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public string TaxNumber { get; set; }
        public string TaxOffice { get; set; }
        public bool IsPerson { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TCKN { get; set; }
    }
}
