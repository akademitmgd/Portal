using DevExpress.Xpo;
using iyibir.TMGD.WebAPI.OData.Models.iyibir_TMGD;
using Microsoft.AspNet.OData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace iyibir.TMGD.WebAPI.OData.Controllers
{
    [Authorize]
    public class ActivityReportController : ODataController
    {
        private UnitOfWork Session;

        [HttpGet]
        [EnableQuery]
        public IQueryable<ActivityReport> Get()
        {
            Session = ConnectionHelper.CreateSession();
            return Session.Query<ActivityReport>();
        }

        [HttpGet]
        [EnableQuery]
        public SingleResult<ActivityReport> Get([FromODataUri] Guid key)
        {
            Session = ConnectionHelper.CreateSession();
            var result = Session.Query<ActivityReport>().Where(t => t.Oid == key);
            return SingleResult.Create(result);
        }

        [HttpPost]
        public IHttpActionResult Post(ActivityReport activityReport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            using (UnitOfWork uow = ConnectionHelper.CreateSession())
            {
                ActivityReport entity = new ActivityReport(uow)
                {
                    Oid = activityReport.Oid,
                    

                };
                uow.CommitChanges();
                return Created(entity);
            }
        }
    }
}