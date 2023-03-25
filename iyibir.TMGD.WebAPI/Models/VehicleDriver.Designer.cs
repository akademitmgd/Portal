using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iyibir.TMGD.WebAPI.Models
{
    public partial class VehicleDriver
    {
        public Guid Oid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Customer Customer { get; set; }
        public DateTime SrcDateOfValidity { get; set; }
        public string Src5DocumentNo { get; set; }
        public DateTime PsychotechnicalExamination { get; set; }
    }
}