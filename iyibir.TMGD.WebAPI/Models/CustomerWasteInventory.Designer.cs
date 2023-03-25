using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iyibir.TMGD.WebAPI.Models
{
    public partial class CustomerWasteInventory
    {
        public Guid Oid { get; set; }
        public Customer Customer { get; set; }
        public HazardousGoods HazardousGoods { get; set; }
        public PackingGroup PackingGroup { get; set; }
        public WasteList WasteCode { get; set; }
        public WastePhysicalState WastePhysicalState { get; set; }
        public string WasteName { get; set; }
        public string Description { get; set; }
        public int AdrStatus { get; set; }
        public string Shipper { get; set; }
        public string DisposalFirm { get; set; }
        public string MSDSName { get; set; }
        public PackagingTypes PackagingTypes { get; set; }

    }
}