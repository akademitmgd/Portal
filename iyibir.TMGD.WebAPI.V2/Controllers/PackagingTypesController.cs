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
    public class PackagingTypesController : ApiController
    {
        private Session session = new Session();
        public int DeleteObject(PackagingTypes item)
        {
            throw new NotImplementedException();
        }


        [HttpGet]
        public PackagingTypes GetObjectById([FromBody, Required] Guid Oid)
        {
            PackagingTypes packagingTypes = session.GetObjectByKey<PackagingTypes>(Oid);
            if (packagingTypes != null)
            {
                return packagingTypes;
            }
            else
            {
                return null;
            }
        }


        [HttpGet]
        public Guid GetObjectById([FromBody, Required] PackagingTypes item)
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
        public IEnumerable<PackagingTypes> GetObjects()
        {
            IList<PackagingTypes> packagings = new List<PackagingTypes>();

            var allPackagings = session.GetObjects(session.GetClassInfo<PackagingTypes>(), null, null, 0, false, true);
            foreach (PackagingTypes item in allPackagings)
            {
                packagings.Add(item);
            }

            return packagings;
        }

        public Guid InsertObject(PackagingTypes item)
        {
            throw new NotImplementedException();
        }

        public int UpdateObject(PackagingTypes item)
        {
            throw new NotImplementedException();
        }
    }
}
