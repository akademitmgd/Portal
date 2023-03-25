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
    public class PackingGroupController : ApiController
    {
        [HttpGet]
        public DataResult GetObjectById(Guid Oid)
        {
            return new PackingGroup().GetObjectById(Oid);
        }

        [HttpGet]
        public DataResult GetObjects()
        {
            return new PackingGroup().GetObjects();
        }

        [HttpGet]
        public DataResult GetObjectByCode(string code)
        {
            return new PackingGroup().GetObjectByCode(code);
        }

        [HttpGet]
        public DataResult GetObjectByHazardousGoods(Guid HazardousGoodsOid)
        {
            return new PackingGroup().GetObjectByHazardousGoods(HazardousGoodsOid);
        }
    }
}
