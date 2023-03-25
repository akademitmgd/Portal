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
    public class VehicleDriverController : ApiController
    {
        private Session session = new Session();
        public int DeleteObject(VehicleDriver item)
        {
            throw new NotImplementedException();
        }


        [HttpGet]
        public VehicleDriver GetObjectById([FromBody, Required] Guid Oid)
        {
            VehicleDriver vehicleDriver = session.GetObjectByKey<VehicleDriver>(Oid);
            if (vehicleDriver != null)
            {
                return vehicleDriver;
            }
            else
            {
                return null;
            }
        }


        [HttpGet]
        public Guid GetObjectById([FromBody, Required] VehicleDriver item)
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
        public IEnumerable<VehicleDriver> GetObjects()
        {
            IList<VehicleDriver> vehicleDrivers = new List<VehicleDriver>();

            var allVehicleDrivers = session.GetObjects(session.GetClassInfo<VehicleDriver>(), null, null, 0, false, true);
            foreach (VehicleDriver item in allVehicleDrivers)
            {
                vehicleDrivers.Add(item);
            }

            return vehicleDrivers;
        }

        public Guid InsertObject(VehicleDriver item)
        {
            throw new NotImplementedException();
        }

        public int UpdateObject(VehicleDriver item)
        {
            throw new NotImplementedException();
        }
    }
}
