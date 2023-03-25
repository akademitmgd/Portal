using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iyibir.TMGD.WebAPI.Models
{
    public partial class CustomerInventory
    {
        public Guid Oid { get; set; }
        public Customer Customer { get; set; }
        public HazardousGoods HazardousGoods { get; set; }
        public PackingGroup PackingGroup { get; set; }
        public FactoryDepartment FactoryDepartment { get; set; }
        public bool IsWaste { get; set; }
        public string InventoryCode { get; set; }
        public string InventoryName { get; set; }
        public string Supplier { get; set; }
        public double PackagingQuantity { get; set; }
        public double LastYearIntake { get; set; }
        public int MSDSStatus { get; set; }
        public bool Consignor { get; set; }
        public bool Carrier { get; set; }
        public bool Consignee { get; set; }
        public bool Loader { get; set; }
        public bool Unloader { get; set; }
        public bool Packer { get; set; }
        public bool Filler { get; set; }
        public bool TankContainer { get; set; }
        public string PackagingQuantityUnit { get; set; }
        public string LastYearIntakeUnit { get; set; }
        public DefaultLabel DefaultLabel1 { get; set; }
        public DefaultLabel DefaultLabel2 { get; set; }
        public DefaultLabel DefaultLabel3 { get; set; }
        public DefaultLabel DefaultLabel4 { get; set; }
        public string Shipper { get; set; }
        public string MSDSName { get; set; }
        public PackagingTypes PackagingTypes { get; set; }

    }
}