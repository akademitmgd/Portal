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
    public class HazardousGoodsLabelController : ApiController
    {
        [HttpGet]
        public DataResult GetObjects()
        {
            return new HazardousGoodsLabel().GetObjects();
        }

        [HttpGet]
        public DataResult GetObjectByCode(string code)
        {
            return new HazardousGoodsLabel().GetObjectByCode(code);
        }

        [HttpGet]
        public DataResult GetObjectById(Guid Oid)
        {
            return new HazardousGoodsLabel().GetObjectById(Oid);
        }

        [HttpGet]
        public DataResult GetObjectByHazardousGoods(Guid HazardousGoodsOid)
        {
            return new HazardousGoodsLabel().GetObjectByHazardousGoods(HazardousGoodsOid);
        }
    }
}
