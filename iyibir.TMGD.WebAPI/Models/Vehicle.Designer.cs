using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iyibir.TMGD.WebAPI.Models
{
    public partial class Vehicle
    {
        public Guid Oid { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Plate { get; set; }
        public Customer Customer { get; set; }
        public DateTime InsurancePolicy { get; set; }
        public DateTime TmgdInsurancePolicy { get; set; }
        public DateTime AdrInspectionDate { get; set; }
        public DateTime AdrInspectionThreeYearly { get; set; }
        public DateTime AdrInspectionSixYearly { get; set; }
        public DateTime TuvTurkInpectionDate { get; set; }
        public DateTime ExhaustInspectionDate { get; set; }
        public double MaxWeight { get; set; }
    }
}