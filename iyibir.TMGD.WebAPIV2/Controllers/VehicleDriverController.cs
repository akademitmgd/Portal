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
    public class VehicleDriverController : ApiController
    {
        [HttpGet]
        public DataResult GetObjectById(Guid customerOid,string tckn)
        {            
            return new VehicleDriver().GetObjectById(customerOid,tckn);
        }

        [HttpGet]
        public DataResult GetObjects(Guid customerOid)
        {
            return new VehicleDriver().GetObjects(customerOid);
        }

        [HttpGet]
        public DataResult GetObjectByCustomerCodeWithDriverFirstAndLastName(string customerCode, string firstName, string lastName)
        {
            return new VehicleDriver().GetObjectByCustomerCodeWithDriverFirstAndLastName(customerCode, firstName, lastName);
        }
    }
}
