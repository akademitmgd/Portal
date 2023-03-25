using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iyibir.TMGD.WebAPI.Models
{
    public partial class ActivityReport
    {
        public Guid Oid { get; set; }
        public string Code { get; set; }
        public Employee Colsultant { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Customer Customer { get; set; }
        public string Description { get; set; }
    }
}