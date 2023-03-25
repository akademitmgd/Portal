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
    public class ProductController : ODataController
    {
        private UnitOfWork Session;

        [HttpGet]
        [EnableQuery]
        public IQueryable<Product> Get([FromODataUri] Guid customerKey)
        {
            Session = ConnectionHelper.CreateSession();
            return Session.Query<Product>().Where(t => t.Customer.Oid == customerKey);
        }

        //[HttpGet]
        //[EnableQuery]
        //public SingleResult<Product> Get([FromODataUri] Guid customerKey)
        //{
        //    Session = ConnectionHelper.CreateSession();
        //    var result = Session.Query<Product>().Where(t => t.Customer.Oid == customerKey);
        //    return SingleResult.Create(result);
        //}


        [HttpPost]
        public IHttpActionResult Post(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            using (UnitOfWork uow = ConnectionHelper.CreateSession())
            {
                Product entity = new Product(uow)
                {
                    Oid = product.Oid,
                    WastePhysicalState = product.WastePhysicalState != null ? uow.GetObjectByKey<WastePhysicalState>(product.WastePhysicalState.Oid) : null,
                    WasteName = product.WasteName,
                    WasteCode = product.WasteCode,
                    Code = product.Code,
                    Customer = product.Customer != null ? uow.GetObjectByKey<Customer>(product.Customer.Oid) : null,
                    FactoryDepartment = product.FactoryDepartment != null ? uow.GetObjectByKey<FactoryDepartment>(product.FactoryDepartment.Oid) : null,
                    FileData = product.FileData != null ? uow.GetObjectByKey<FileData>(product.FileData.Oid) : null,
                    HazardousGoods = product.HazardousGoods != null ? uow.GetObjectByKey<HazardousGoods>(product.HazardousGoods.Oid) : null,
                    Image = product.Image,
                    IsActive = product.IsActive,
                    MSDSDateOfValidity = product.MSDSDateOfValidity,
                    MSDSName = product.MSDSName,
                    MSDSStatus = product.MSDSStatus,
                    Name = product.Name,
                    OtherName = product.OtherName,
                    Owner = product.Owner != null ? uow.GetObjectByKey<Employee>(product.Owner.Oid) : null,
                    PackagingTypes = product.PackagingTypes != null ? uow.GetObjectByKey<PackagingTypes>(product.PackagingTypes.Oid) : null,
                    ProductGroupType = product.ProductGroupType,
                    ProductType = product.ProductType,
                    Unitset = product.Unitset != null ? uow.GetObjectByKey<Unitset>(product.Unitset.Oid) : null

                };
                uow.CommitChanges();
                return Created(entity);
            }
        }
    }
}