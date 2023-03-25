using iyibir.TMGD.WebAPIV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace iyibir.TMGD.WebAPIV2.Controllers
{
    [Authorize]
    public class VehicleController : ApiController
    {
        [HttpGet]
        public DataResult GetObjectById(Guid CustomerOid,string Plate)
        {
            return new Vehicle().GetObjectById(CustomerOid,Plate);
        }

        [HttpGet]
        public DataResult GetObjects(Guid CustomerOid)
        {
            return new Vehicle().GetObjects(CustomerOid);
        }

        [HttpGet]
        public DataResult GetObjectByCode(string code)
        {
            return new DataResult();
            //return new Vehicle().GetObjectByCode(code);
        }

        [HttpGet]
        public DataResult GetObjectByCustomerAndVehicleCode(string customerCode, string vehicleCode)
        {
            return new Vehicle().GetObjectByCustomerAndVehicleCode(customerCode, vehicleCode);
        }
    }
}
