using iyibir.TMGD.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace iyibir.TMGD.WebAPI.Controllers
{
    public class CityController : ApiController
    {
        [HttpGet]
        public DataResult GetObjectById(Guid Oid)
        {
            return new City().GetObjectById(Oid);
        }

        [HttpGet]
        public DataResult GetObjects()
        {
            return new City().GetObjects();
        }

        [HttpPost]
        public DataResult InsertObject([FromBody] City city)
        {
            return new City().InsertObject(city);
        }
    }
}
