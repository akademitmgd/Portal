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
    public class EmployeeController : ApiController
    {
        private Session session = new Session();
        public int DeleteObject(Employee item)
        {
            throw new NotImplementedException();
        }


        [HttpGet]
        public Employee GetObjectById([FromBody, Required] Guid Oid)
        {
            Employee employee = session.GetObjectByKey<Employee>(Oid);
            if (employee != null)
            {
                return employee;
            }
            else
            {
                return null;
            }
        }


        [HttpGet]
        public Guid GetObjectById([FromBody, Required] Employee item)
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
        public IEnumerable<Employee> GetObjects()
        {
            IList<Employee> employees = new List<Employee>();

            var allEmployees = session.GetObjects(session.GetClassInfo<Employee>(), null, null, 0, false, true);
            foreach (Employee item in allEmployees)
            {
                employees.Add(item);
            }

            return employees;
        }

        public Guid InsertObject(Employee item)
        {
            throw new NotImplementedException();
        }

        public int UpdateObject( Employee item)
        {
            throw new NotImplementedException();
        }
    }
}
