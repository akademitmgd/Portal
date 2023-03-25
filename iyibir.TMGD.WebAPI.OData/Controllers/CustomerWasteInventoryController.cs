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
    [Authorize]
    public class CustomerWasteInventoryController : ODataController
    {
        private UnitOfWork Session;

        [HttpGet]
        [EnableQuery]
        public IQueryable<CustomerWasteInventory> Get()
        {
            Session = ConnectionHelper.CreateSession();
            return Session.Query<CustomerWasteInventory>();
        }

        [HttpGet]
        [EnableQuery]
        public SingleResult<CustomerWasteInventory> Get([FromODataUri] Guid key)
        {
            Session = ConnectionHelper.CreateSession();
            var result = Session.Query<CustomerWasteInventory>().Where(t => t.Oid == key);
            return SingleResult.Create(result);
        }
    }
}