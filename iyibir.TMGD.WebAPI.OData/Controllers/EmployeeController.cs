using DevExpress.Xpo;
using iyibir.TMGD.WebAPI.OData.Models.iyibir_TMGD;
using Microsoft.AspNet.OData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace iyibir.TMGD.WebAPI.OData.Controllers
{
    public class EmployeeController : ODataController
    {
        private UnitOfWork Session;

        [HttpGet]
        [EnableQuery]
        public IQueryable<Employee> Get()
        {
            Session = ConnectionHelper.CreateSession();
            return Session.Query<Employee>();
        }

        [HttpGet]
        [EnableQuery]
        public SingleResult<Employee> Get([FromODataUri] Guid key)
        {
            Session = ConnectionHelper.CreateSession();
            var result = Session.Query<Employee>().Where(t => t.Oid == key);
            return SingleResult.Create(result);
        }
    }
    }