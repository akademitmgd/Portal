using DevExpress.Xpo;
using iyibir.TMGD.WebAPI.V2.Models.iyibir_TMGD;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace iyibir.TMGD.WebAPI.V2.Controllers
{
    public class HazardousGoodsController : ApiController
    {
        private Session session = new Session();
        public int DeleteObject(HazardousGoods item)
        {
            throw new NotImplementedException();
        }


        [HttpGet]
        public HazardousGoods GetObjectById([FromBody, Required] Guid Oid)
        {
            HazardousGoods hazardousGoods = session.GetObjectByKey<HazardousGoods>(Oid);
            if (hazardousGoods != null)
            {
                return hazardousGoods;
            }
            else
            {
                return null;
            }
        }


        [HttpGet]
        public Guid GetObjectById([FromBody, Required] HazardousGoods item)
        {
            if (item != null)
            {
                return item.Oid;
            }
            else
            {
                return Guid.Empty;
            }
        }


        [HttpGet]
        public IEnumerable<HazardousGoods> GetObjects()
        {
            IList<HazardousGoods> hazardousGoods = new List<HazardousGoods>();

            var allHazardousGoods = session.GetObjects(session.GetClassInfo<HazardousGoods>(), null, null, 0, false, true);
            foreach (HazardousGoods item in allHazardousGoods)
            {
                hazardousGoods.Add(item);
            }

            return hazardousGoods;
        }

        public Guid InsertObject(HazardousGoods item)
        {
            throw new NotImplementedException();
        }

        public int UpdateObject(HazardousGoods item)
        {
            throw new NotImplementedException();
        }
    }
}
