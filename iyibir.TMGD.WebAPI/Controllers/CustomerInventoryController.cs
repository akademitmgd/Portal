﻿using iyibir.TMGD.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace iyibir.TMGD.WebAPI.Controllers
{
    public class CustomerInventoryController : ApiController
    {
        [HttpGet]
        public DataResult GetObjectByInventoryCode(string inventoryCode, string customerCode)
        {
            return new CustomerInventory().GetObjectByCustomerAndInventoryCode(inventoryCode, customerCode);
        }

        [HttpGet]
        public DataResult GetObjects()
        {
            return new CustomerInventory().GetObjects();
        }
    }
}
