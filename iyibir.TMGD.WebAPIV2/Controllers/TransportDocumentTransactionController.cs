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
    public class TransportDocumentTransactionController : ApiController
    {
        [HttpGet]
        public DataResult GetObjectById(Guid Oid)
        {
            return new TransportDocumentTransaction().GetObjectById(Oid);
        }

        [HttpGet]
        public DataResult GetObjects()
        {
            return new TransportDocumentTransaction().GetObjects();
        }

        [HttpPost]
        public DataResult InsertObject([FromBody] TransportDocumentTransaction transaction)
        {
            return new TransportDocumentTransaction().InsertObject(transaction);
        }
    }
}
