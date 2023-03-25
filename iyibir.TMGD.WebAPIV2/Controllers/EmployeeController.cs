using iyibir.TMGD.WebAPIV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace iyibir.TMGD.WebAPIV2.Controllers
{
    public class EmployeeController : ApiController
    {
        [HttpGet]
        public DataResult GetObjectById(Guid Oid)
        {
            return new Employee().GetObjectById(Oid);
        }

        [HttpGet]
        public DataResult GetObjectByCustomerId(Guid Oid)
        {
            return new Employee().GetObjectByCustomerId(Oid);
        }

        [HttpGet]
        public DataResult GetObjects()
        {
            return new Employee().GetObjects();
        }
    }
}
