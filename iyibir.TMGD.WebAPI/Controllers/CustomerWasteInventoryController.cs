using iyibir.TMGD.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace iyibir.TMGD.WebAPI.Controllers
{
    public class CustomerWasteInventoryController : ApiController
    {

        [HttpGet]
        public DataResult GetObjectById(Guid Oid)
        {
            return new CustomerWasteInventory().GetObjectById(Oid);
        }

        [HttpGet]
        public DataResult GetObjects()
        {
            return new CustomerWasteInventory().GetObjects();
        }

        [HttpGet]
        public DataResult GetObjectByCustomerAndWasteCode(string customerCode, string wasteCode)
        {
            return new CustomerWasteInventory().GetObjectByCustomerAndWasteCode(customerCode, wasteCode);
        }
    }
}
