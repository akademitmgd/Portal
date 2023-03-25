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
    public class ConsigneeController : ApiController
    {
        private Session session = new Session();
        public int DeleteObject(Consignee item)
        {
            throw new NotImplementedException();
        }


        [HttpGet]
        public Consignee GetObjectById([FromBody, Required] Guid Oid)
        {
            Consignee consignee = session.GetObjectByKey<Consignee>(Oid);
            if (consignee != null)
            {
                return consignee;
            }
            else
            {
                return null;
            }
        }


        [HttpGet]
        public Guid GetObjectById([FromBody, Required] Consignee item)
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
        public IEnumerable<Consignee> GetObjects()
        {
            IList<Consignee> consignees = new List<Consignee>();

            var allConsignees = session.GetObjects(session.GetClassInfo<Consignee>(), null, null, 0, false, true);
            foreach (Consignee item in allConsignees)
            {
                consignees.Add(item);
            }

            return consignees;
        }

        public Guid InsertObject(Consignee item)
        {
            throw new NotImplementedException();
        }

        public int UpdateObject(Consignee item)
        {
            throw new NotImplementedException();
        }
    }
}
