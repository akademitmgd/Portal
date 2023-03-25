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
    public class TransportDocumentOtherTransactionController : ApiController
    {
        [HttpGet]
        public DataResult GetObjectById(Guid Oid)
        {
            return new TransportDocumentOtherTransaction().GetObjectById(Oid);
        }

        [HttpGet]
        public DataResult GetObjects()
        {
            return new TransportDocumentOtherTransaction().GetObjects();
        }

        [HttpPost]
        public DataResult InsertObject([FromBody] TransportDocumentOtherTransaction otherTransaction)
        {
            return new TransportDocumentOtherTransaction().InsertObject(otherTransaction);
        }
    }
}
