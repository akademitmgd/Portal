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
    public class ProductController : ApiController
    {
        [HttpGet]
        public DataResult GetObjects(Guid customerOid, int groupType)
        {
            return new Product().GetObjects(customerOid, groupType);
        }

        [HttpGet]
        public DataResult GetObjectByCode(string code, Guid customerOid)
        {
            return new Product().GetObjectByCode(code, customerOid);
        }

        [HttpPost]
        public DataResult InsertObject([FromBody] Product product)
        {
            return new Product().InsertObject(product);
        }
    }
}
