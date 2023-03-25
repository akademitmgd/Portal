using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iyibir.TMGD.WebAPIV2.Models
{
    public partial class TransportDocument
    {
        public Guid Oid { get; set; }
        public string Code { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<TimeSpan> CreatedTime { get; set; }
        public Employee Owner { get; set; }
        public Customer Consigner { get; set; }
        public string ConsignerTaxOffice { get; set; }
        public string ConsignerTaxNumber { get; set; }
        public string ConsignerAddress { get; set; }
        public string ConsigneeTaxOffice { get; set; }
        public string ConsigneeTaxNumber { get; set; }
        public string ConsigneeAddress { get; set; }
        public Vehicle Vehicle { get; set; }
        public VehicleDriver Driver { get; set; }
        public string TransportCategory { get; set; }
        public Nullable<double> ScoreQuantity { get; set; }
        public string TunnelCode { get; set; }
        public string Description { get; set; }
        public Consignee Consignee { get; set; }
        public Nullable<int> TransportDocumentType { get; set; }
        public bool IsSpecial { get; set; }
        public Consignee Shipper { get; set; }
        public string SpecialShipper { get; set; }
    }
}