﻿using iyibir.TMGD.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace iyibir.TMGD.WebAPI.Controllers
{
    public class DefaultLabelController : ApiController
    {
        [HttpGet]
        public DataResult GetObjectById(Guid Oid)
        {
            return new DefaultLabel().GetObjectById(Oid);
        }

        [HttpGet]
        public DataResult GetObjects()
        {
            return new DefaultLabel().GetObjects();
        }
    }
}
