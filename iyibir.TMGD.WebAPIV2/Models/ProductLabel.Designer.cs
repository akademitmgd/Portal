using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iyibir.TMGD.WebAPIV2.Models
{
    public partial class ProductLabel
    {
        public Guid Oid { get; set; }
        public Product Product { get; set; }
        public byte LabelImage { get; set; }

    }
}