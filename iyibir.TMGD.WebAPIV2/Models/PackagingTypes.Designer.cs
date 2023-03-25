using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iyibir.TMGD.WebAPIV2.Models
{
    public partial class PackagingTypes
    {
        public Guid Oid { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}