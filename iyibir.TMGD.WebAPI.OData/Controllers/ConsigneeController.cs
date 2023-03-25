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
    public class ConsigneeController : ODataController
    {
        //private UnitOfWork Session;
        public UnitOfWork Session { get; set; }

        public ConsigneeController()
        {
            
        }

        [HttpGet]
        [EnableQuery]
        public IQueryable<Consignee> Get()
        {
            Session = ConnectionHelper.CreateSession();
            return Session.Query<Consignee>();
        }

        [HttpGet]
        [EnableQuery]
        public SingleResult<Consignee> Get([FromODataUri] Guid key)
        {
            Session = ConnectionHelper.CreateSession();
            var result = Session.Query<Consignee>().Where(t => t.Oid == key);
            return SingleResult.Create(result);
        }

        [HttpPost]
        public IHttpActionResult Post(Consignee consignee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            using (UnitOfWork uow = ConnectionHelper.CreateSession())
            {
                Consignee entity = new Consignee(uow)
                {
                    Oid = consignee.Oid,
                    City = consignee.City != null ? uow.GetObjectByKey<City>(consignee.City.Oid) : null,
                    Country = consignee.Country != null ? uow.GetObjectByKey<Country>(consignee.Country.Oid) : null,
                    County = consignee.County != null ? uow.GetObjectByKey<County>(consignee.County.Oid) : null,
                    Customer = consignee.Customer != null ? uow.GetObjectByKey<Customer>(consignee.Customer.Oid) : null,
                    Code = consignee.Code,
                    ConsigneeType = consignee.ConsigneeType,
                    TCKN = consignee.TCKN,
                    Address = consignee.Address,
                    IsActive = consignee.IsActive,
                    EMail = consignee.EMail,
                    FirstName = consignee.FirstName,
                    IsPerson = consignee.IsPerson,
                    LastName = consignee.LastName,
                    OtherTelephone = consignee.OtherTelephone,
                    Telephone = consignee.Telephone,
                    Owner = consignee.Owner != null ? uow.GetObjectByKey<Employee>(consignee.Owner.Oid) : null,
                    TaxNumber = consignee.TaxNumber,
                    TaxOffice = consignee.TaxOffice,
                    Title = consignee.Title

                };
                uow.CommitChanges();
                return Created(entity);
            }
        }
    }
}