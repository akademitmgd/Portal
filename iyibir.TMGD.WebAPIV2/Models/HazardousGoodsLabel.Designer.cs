
using System;
using System.Linq;
using System.Web;

namespace iyibir.TMGD.WebAPIV2.Models
{
    public partial class HazardousGoodsLabel
    {
        public Guid Oid { get; set; }
        public int LineNumber { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public byte[] LabelImage { get; set; }

    }
}