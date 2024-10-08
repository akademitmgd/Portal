﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iyibir.TMGD.WebAPIV2.Models
{
    public partial class TransportDocumentTransaction
    {
        public Guid Oid { get; set; }
        public TransportDocument TransportDocument { get; set; }
        public PackagingTypes PackagingTypes { get; set; }
        public HazardousGoods HazardousGoods { get; set; }
        public HazardousGoodsClass HazardousGoodsClass { get; set; }
        public HazardousGoodsLabel HazardousGoodsLabel { get; set; }
        public PackingGroup PackingGroup { get; set; }
        public Unitset Unitset { get; set; }
        public Nullable<double> Quantity { get; set; }
        public string Description { get; set; }
        public Nullable<double> NetWeigth { get; set; }
        public string InventoryCode { get; set; }
        public string InventoryName { get; set; }
    }
}