using iyibir.TMGD.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace iyibir.TMGD.WebAPI.Controllers
{
    public class ActivityReportController : ApiController
    {
        [HttpPost]
        public DataResult InsertObject(ActivityReport activityReport)
        {
            return new ActivityReport().InsertObject(activityReport);
        }

        [HttpGet]
        public DataResult GetObjects()
        {
            return new ActivityReport().GetObjects();
        }

        [HttpGet]
        public DataResult GetObjectById(Guid Oid)
        {
            return new ActivityReport().GetObjectById(Oid);
        }
    }
}
