using iyibir.TMGD.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace iyibir.TMGD.WebAPI.Controllers
{
    public class PackagingTypesController : ApiController
    {
        [HttpGet]
        public DataResult GetObjectById(Guid Oid)
        {
            return new PackagingTypes().GetObjectById(Oid);
        }

        [HttpGet]
        public DataResult GetObjects()
        {
            return new PackagingTypes().GetObjects();
        }

        [HttpGet]
        public DataResult GetObjectByCode(string code)
        {
            return new PackagingTypes().GetObjectByCode(code);
        }
    }
}
