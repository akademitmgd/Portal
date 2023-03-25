using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iyibir.TMGD.WebAPIV2.Models
{
    public partial class HazardousGoodsTransaction
    {
        public Guid Oid { get; set; }
        public int TransactionType { get; set; }
        public Customer Customer { get; set; }
        public Consignee Consignee { get; set; }
        public Nullable<DateTime> TransactionDate { get; set; }
        public Product Product { get; set; }
        public Nullable<double> Quantity { get; set; }
        public Unitset Unitset { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
        public Employee Owner { get; set; }
    }
}