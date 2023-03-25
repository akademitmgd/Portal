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
    public class VehicleDriverController : ODataController
    {
        private UnitOfWork Session;

        [HttpGet]
        [EnableQuery]
        public IQueryable<VehicleDriver> Get()
        {
            Session = ConnectionHelper.CreateSession();
            return Session.Query<VehicleDriver>();
        }

        [HttpGet]
        [EnableQuery]
        public SingleResult<VehicleDriver> Get([FromODataUri] Guid key)
        {
            Session = ConnectionHelper.CreateSession();
            var result = Session.Query<VehicleDriver>().Where(t => t.Oid == key);
            return SingleResult.Create(result);
        }
    }
}