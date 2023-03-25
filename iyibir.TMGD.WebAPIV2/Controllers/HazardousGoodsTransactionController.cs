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
    public class HazardousGoodsTransactionController : ApiController
    {
        [HttpPost]
        public DataResult InsertObject([FromBody] HazardousGoodsTransaction hazadousGoodsTransaction)
        {
            return new HazardousGoodsTransactionController().InsertObject(hazadousGoodsTransaction);
        }
    }
}
