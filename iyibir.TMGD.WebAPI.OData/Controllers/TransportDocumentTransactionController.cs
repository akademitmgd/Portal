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
    public class TransportDocumentTransactionController : ODataController
    {
        private UnitOfWork Session;

        [HttpGet]
        [EnableQuery]
        public SingleResult<TransportDocumentTransaction> Get([FromODataUri] Guid key)
        {
            Session = ConnectionHelper.CreateSession();
            var result = Session.Query<TransportDocumentTransaction>().Where(t => t.Oid == key);
            return SingleResult.Create(result);
        }

        [HttpPost]
        public IHttpActionResult Post(TransportDocumentTransaction transportDocumentTransaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            using (UnitOfWork uow = ConnectionHelper.CreateSession())
            {
                TransportDocumentTransaction entity = new TransportDocumentTransaction(uow)
                {
                    Oid = transportDocumentTransaction.Oid,
                    TransportCategory = transportDocumentTransaction.TransportCategory != null ? uow.GetObjectByKey<HazardousGoodsTransportCategory>(transportDocumentTransaction.TransportCategory.Oid) : null,
                    TunnelCode = transportDocumentTransaction.TunnelCode != null ? uow.GetObjectByKey<HazardousGoodsTunnelCode>(transportDocumentTransaction.TunnelCode.Oid) : null,
                    Description = transportDocumentTransaction.Description,
                    ConvFactor = transportDocumentTransaction.ConvFactor,
                    HazardousGoodsClass = transportDocumentTransaction.HazardousGoodsClass != null ? uow.GetObjectByKey<HazardousGoodsClass>(transportDocumentTransaction.HazardousGoodsClass.Oid) : null,
                    HazardousGoodsLabel = transportDocumentTransaction.HazardousGoodsLabel != null ? uow.GetObjectByKey<HazardousGoodsLabel>(transportDocumentTransaction.HazardousGoodsLabel.Oid) : null,
                    HazardousGoods = transportDocumentTransaction.HazardousGoods != null ? uow.GetObjectByKey<HazardousGoods>(transportDocumentTransaction.HazardousGoods.Oid) : null,
                    InventoryCode = transportDocumentTransaction.InventoryCode,
                    InventoryName = transportDocumentTransaction.InventoryName,
                    NetWeigth = transportDocumentTransaction.NetWeigth,
                    PackagingTypes = transportDocumentTransaction.PackagingTypes != null ? uow.GetObjectByKey<PackagingTypes>(transportDocumentTransaction.PackagingTypes.Oid) : null,
                    PackingGroup = transportDocumentTransaction.PackingGroup != null ? uow.GetObjectByKey<PackingGroup>(transportDocumentTransaction.PackingGroup.Oid) : null,
                    Quantity = transportDocumentTransaction.Quantity,
                    TotalConvFactor = transportDocumentTransaction.TotalConvFactor,
                    Val = transportDocumentTransaction.Val,
                    TransportDocument = transportDocumentTransaction.TransportDocument != null ? uow.GetObjectByKey<TransportDocument>(transportDocumentTransaction.TransportDocument.Oid) : null,
                    Unitset = transportDocumentTransaction.Unitset != null ? uow.GetObjectByKey<Unitset>(transportDocumentTransaction.Unitset.Oid) : null

                };
                uow.CommitChanges();
                return Created(entity);
            }
        }
    }
}