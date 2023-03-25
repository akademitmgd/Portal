using iyibir.TMGD.WebAPI.Models;
using System;
using System.Web.Http;

namespace iyibir.TMGD.WebAPI.Controllers
{
    public class WasteListController : ApiController
    {
        [HttpGet]
        public DataResult GetObjectById(Guid Oid)
        {
            return new WasteList().GetObjectById(Oid);
        }

        [HttpGet]
        public DataResult GetObjects()
        {
            return new WasteList().GetObjects();
        }

        [HttpGet]
        public DataResult GetObjectByCode(string code)
        {
            return new WasteList().GetObjectByCode(code);
        }
    }
}
