using iyibir.TMGD.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace iyibir.TMGD.WebAPI.Controllers
{
    public class ActivityReportTransactionController : ApiController
    {
        [HttpPost]
        public DataResult InsertObject(ActivityReportTransaction transaction)
        {
            return new ActivityReportTransaction().InsertObject(transaction);
        }

        [HttpGet]
        public DataResult GetObjects()
        {
            return new ActivityReportTransaction().GetObjects();
        }

        [HttpGet]
        public DataResult GetObjectById(Guid Oid)
        {
            return new ActivityReportTransaction().GetObjectById(Oid);
        }
    }
}
