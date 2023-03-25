﻿using iyibir.TMGD.WebAPIV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace iyibir.TMGD.WebAPIV2.Controllers
{
    [Authorize]
    public class HazardousGoodsController : ApiController
    {
        [HttpGet]
        public DataResult GetObjectById(Guid Oid)
        {
            return new HazardousGoods().GetObjectById(Oid);
        }

        [HttpGet]
        public DataResult GetObjects()
        {
            return new HazardousGoods().GetObjects();
        }

        [HttpGet]
        public DataResult GetObjectByCode(string code)
        {
            return new HazardousGoods().GetObjectByCode(code);
        }
    }
}
