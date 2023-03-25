using iyibir.TMGD.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace iyibir.TMGD.WebAPI.Controllers
{
    public class TransportDocumentController : ApiController
    {
        [HttpGet]
        public DataResult GetObjectById(Guid Oid)
        {
            return new TransportDocument().GetObjectById(Oid);
        }

        [HttpGet]
        public DataResult GetObjects()
        {
            return new TransportDocument().GetObjects();
        }

        [HttpPost]
        public DataResult InsertObject([FromBody] TransportDocument transportDocument)
        {
            return new TransportDocument().InsertObject(transportDocument);
        }
    }
}
