using iyibir.TMGD.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace iyibir.TMGD.WebAPI.Controllers
{
    public class VehicleController : ApiController
    {
        [HttpGet]
        public DataResult GetObjectById(Guid Oid)
        {
            return new Vehicle().GetObjectById(Oid);
        }

        [HttpGet]
        public DataResult GetObjects()
        {
            return new Vehicle().GetObjects();
        }

        [HttpGet]
        public DataResult GetObjectByCode(string code)
        {
            return new Vehicle().GetObjectByCode(code);
        }

        [HttpGet]
        public DataResult GetObjectByCustomerAndVehicleCode(string customerCode,string vehicleCode)
        {
            return new Vehicle().GetObjectByCustomerAndVehicleCode(customerCode, vehicleCode);
        }
    }
}
