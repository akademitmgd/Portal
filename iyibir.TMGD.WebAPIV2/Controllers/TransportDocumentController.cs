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
    public class TransportDocumentController : ApiController
    {
        [HttpGet]
        public DataResult GetObjectById(Guid Oid)
        {
            return new TransportDocument().GetObjectById(Oid);
        }

        [HttpGet]
        public DataResult GetObjects(Guid customerOid)
        {
            return new TransportDocument().GetObjectByCode(customerOid);
        }

        [HttpPost]
        public DataResult InsertObject([FromBody] TransportDocument transportDocument)
        {
            return new TransportDocument().InsertObject(transportDocument);
        }
    }
}
