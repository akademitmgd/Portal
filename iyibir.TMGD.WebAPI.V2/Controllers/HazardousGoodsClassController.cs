using DevExpress.Xpo;
using iyibir.TMGD.WebAPI.V2.Models.iyibir_TMGD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace iyibir.TMGD.WebAPI.V2.Controllers
{
    public class HazardousGoodsClassController : ApiController
    {
        private Session session = new Session();
        public int DeleteObject(HazardousGoodsClass item)
        {
            throw new NotImplementedException();
        }


        [HttpGet]
        public HazardousGoodsClass GetObjectById(Guid Oid)
        {
            HazardousGoodsClass hazardousGoodsClass = session.GetObjectByKey<HazardousGoodsClass>(Oid);
            if (hazardousGoodsClass != null)
            {
                return hazardousGoodsClass;
            }
            else
            {
                return null;
            }
        }


        [HttpGet]
        public Guid GetObjectById(HazardousGoodsClass item)
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
        public IEnumerable<HazardousGoodsClass> GetObjects()
        {
            IList<HazardousGoodsClass> hazardousGoodsClasses = new List<HazardousGoodsClass>();

            var allHazardousGoodsClasses = session.GetObjects(session.GetClassInfo<HazardousGoodsClass>(), null, null, 0, false, true);
            foreach (HazardousGoodsClass item in allHazardousGoodsClasses)
            {
                hazardousGoodsClasses.Add(item);
            }

            return hazardousGoodsClasses;
        }

        public Guid InsertObject(HazardousGoodsClass item)
        {
            throw new NotImplementedException();
        }

        public int UpdateObject(HazardousGoodsClass item)
        {
            throw new NotImplementedException();
        }
    }
}
