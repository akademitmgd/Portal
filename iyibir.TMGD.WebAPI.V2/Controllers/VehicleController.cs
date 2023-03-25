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
    public class VehicleController : ApiController
    {
        private Session session = new Session();
        public int DeleteObject(Vehicle item)
        {
            throw new NotImplementedException();
        }


        [HttpGet]
        public Vehicle GetObjectById([FromBody, Required] Guid Oid)
        {
            Vehicle vehicle = session.GetObjectByKey<Vehicle>(Oid);
            if (vehicle != null)
            {
                return vehicle;
            }
            else
            {
                return null;
            }
        }


        [HttpGet]
        public Guid GetObjectById([FromBody, Required] Vehicle item)
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
        public IEnumerable<Vehicle> GetObjects()
        {
            IList<Vehicle> vehicles = new List<Vehicle>();

            var allVehicles = session.GetObjects(session.GetClassInfo<Vehicle>(), null, null, 0, false, true);
            foreach (Vehicle item in allVehicles)
            {
                vehicles.Add(item);
            }

            return vehicles;
        }

        public Guid InsertObject(Vehicle item)
        {
            throw new NotImplementedException();
        }

        public int UpdateObject(Vehicle item)
        {
            throw new NotImplementedException();
        }
    }
}
