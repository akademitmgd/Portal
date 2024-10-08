﻿using DevExpress.Xpo;
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
    public class SectorController : ODataController
    {
        private UnitOfWork Session;

        [HttpGet]
        [EnableQuery]
        public IQueryable<Sector> Get()
        {
            Session = ConnectionHelper.CreateSession();
            return Session.Query<Sector>();
        }

        [HttpGet]
        [EnableQuery]
        public SingleResult<Sector> Get([FromODataUri] Guid key)
        {
            Session = ConnectionHelper.CreateSession();
            var result = Session.Query<Sector>().Where(t => t.Oid == key);
            return SingleResult.Create(result);
        }
    }
}