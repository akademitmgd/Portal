using iyibir.TMGD.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace iyibir.TMGD.WebAPI.Controllers
{
    public class VehicleDriverController : ApiController
    {
        [HttpGet]
        public DataResult GetObjectById(Guid Oid)
        {
            return new VehicleDriver().GetObjectById(Oid);
        }

        [HttpGet]
        public DataResult GetObjects()
        {
            return new VehicleDriver().GetObjects();
        }

        [HttpGet]
        public DataResult GetObjectByCustomerCodeWithDriverFirstAndLastName(string customerCode,string firstName,string lastName)
        {
            return new VehicleDriver().GetObjectByCustomerCodeWithDriverFirstAndLastName(customerCode, firstName, lastName);
        }
    }
}
