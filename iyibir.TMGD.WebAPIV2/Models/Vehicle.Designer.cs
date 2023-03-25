using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iyibir.TMGD.WebAPIV2.Models
{
    public partial class Vehicle
    {
        public Guid Oid { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Plate { get; set; }
        public Customer Customer { get; set; }
        public Nullable<System.DateTime> InsurancePolicy { get; set; }
        public Nullable<System.DateTime> TmgdInsurancePolicy { get; set; }
        public Nullable<System.DateTime> AdrInspectionDate { get; set; }
        public Nullable<System.DateTime> AdrInspectionThreeYearly { get; set; }
        public Nullable<System.DateTime> AdrInspectionSixYearly { get; set; }
        public Nullable<System.DateTime> TuvTurkInpectionDate { get; set; }
        public Nullable<System.DateTime> ExhaustInspectionDate { get; set; }
        public double MaxWeight { get; set; }
    }
}