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
    public class TransportDocumentController : ODataController
    {
        private UnitOfWork Session;


        [HttpGet]
        [EnableQuery]
        public SingleResult<TransportDocument> Get([FromODataUri] Guid customerKey)
        {
            Session = ConnectionHelper.CreateSession();
            var result = Session.Query<TransportDocument>().Where(t => t.Consignee.Oid == customerKey);
            return SingleResult.Create(result);
        }

        [HttpGet]
        [EnableQuery]
        public SingleResult<TransportDocument> Get([FromODataUri] Guid customerKey, Guid key)
        {
            Session = ConnectionHelper.CreateSession();
            var result = Session.Query<TransportDocument>().Where(t => t.Oid == key && t.Consignee.Oid == customerKey);
            return SingleResult.Create(result);
        }

        [HttpPost]
        public IHttpActionResult Post(TransportDocument transportDocument)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            using (UnitOfWork uow = ConnectionHelper.CreateSession())
            {
                TransportDocument entity = new TransportDocument(uow)
                {
                    Oid = transportDocument.Oid,
                    ConsigneeAddress = transportDocument.ConsigneeAddress,
                    ConsignerAddress = transportDocument.ConsignerAddress,
                    Carrier = transportDocument.Carrier != null ? uow.GetObjectByKey<Consignee>(transportDocument.Carrier.Oid) : null,
                    Code = transportDocument.Code,
                    Consignee = transportDocument.Consignee != null ? uow.GetObjectByKey<Consignee>(transportDocument.Consignee.Oid) : null,
                    ConsigneeTaxNumber = transportDocument.ConsigneeTaxNumber,
                    ConsigneeTaxOffice = transportDocument.ConsigneeTaxOffice,
                    Consigner = transportDocument.Consigner != null ? uow.GetObjectByKey<Customer>(transportDocument.Consigner.Oid) : null,
                    ConsignerTaxNumber = transportDocument.ConsignerTaxNumber,
                    ConsignerTaxOffice = transportDocument.ConsignerTaxOffice,
                    CreatedDate = transportDocument.CreatedDate,
                    CreatedTime = transportDocument.CreatedTime,
                    IsCarrier = transportDocument.IsCarrier,
                    TransportCategory = transportDocument.TransportCategory,
                    TunnelCode = transportDocument.TunnelCode,
                    Description = transportDocument.Description,
                    Driver = transportDocument.Driver != null ? uow.GetObjectByKey<VehicleDriver>(transportDocument.Driver.Oid) : null,
                    IsSpecial = transportDocument.IsSpecial,
                    OtherVehicle = transportDocument.OtherVehicle != null ? uow.GetObjectByKey<Vehicle>(transportDocument.OtherVehicle.Oid) : null,
                    TransportDocumentType = transportDocument.TransportDocumentType,
                    Vehicle = transportDocument.Vehicle != null ? uow.GetObjectByKey<Vehicle>(transportDocument.Vehicle.Oid) : null,
                    Status = transportDocument.Status,
                    ScoreQuantity = transportDocument.ScoreQuantity,
                    SeferId = transportDocument.SeferId,
                    Shipper = transportDocument.Shipper != null ? uow.GetObjectByKey<Consignee>(transportDocument.Shipper.Oid) : null,
                    SpecialShipper = transportDocument.SpecialShipper,
                    Owner = transportDocument.Owner != null ? uow.GetObjectByKey<Employee>(transportDocument.Owner.Oid) : null
                };
                uow.CommitChanges();
                return Created(entity);
            }
        }
    }
}