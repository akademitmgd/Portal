using DevExpress.Xpo;
using iyibir.TMGD.WebAPI.OData.Helpers;
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
    public class ProductLabelController : ODataController
    {
        private UnitOfWork Session;

        [HttpGet]
        [EnableQuery]
        public IQueryable<ProductLabel> Get()
        {
            Session = ConnectionHelper.CreateSession();
            return Session.Query<ProductLabel>();
        }

        [HttpGet]
        [EnableQuery]
        public SingleResult<ProductLabel> Get([FromODataUri] Guid key)
        {
            Session = ConnectionHelper.CreateSession();
            var result = Session.Query<ProductLabel>().Where(t => t.Oid == key);
            return SingleResult.Create(result);
        }


        [HttpPost]
        public IHttpActionResult Post(ProductLabel productLabel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            using (UnitOfWork uow = ConnectionHelper.CreateSession())
            {
                ProductLabel entity = new ProductLabel(uow)
                {
                    Oid = productLabel.Oid,
                    LabelImage = productLabel.LabelImage,
                    Product = productLabel.Product != null ? uow.GetObjectByKey<Product>(productLabel.Product.Oid) : null

                };
                uow.CommitChanges();
                return Created(entity);
            }
        }
    }
}