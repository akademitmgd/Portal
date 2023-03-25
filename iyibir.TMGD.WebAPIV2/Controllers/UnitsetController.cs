using iyibir.TMGD.WebAPIV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace iyibir.TMGD.WebAPIV2.Controllers
{
    public class UnitsetController : ApiController
    {
        [HttpGet]
        public DataResult GetObjectById(Guid Oid)
        {
            return new Unitset().GetObjectById(Oid);
        }

        [HttpGet]
        public DataResult GetObjects()
        {
            return new Unitset().GetObjects();
        }

        [HttpGet]
        public DataResult GetObjectByCode(string code)
        {
            return new Unitset().GetObjectByCode(code);
        }
    }
}
