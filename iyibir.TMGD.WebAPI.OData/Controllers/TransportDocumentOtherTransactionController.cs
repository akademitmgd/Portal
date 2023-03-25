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
    public class TransportDocumentOtherTransactionController : ODataController
    {
        private UnitOfWork Session;

        [HttpGet]
        [EnableQuery]
        public SingleResult<TransportDocumentOtherTransaction> Get([FromODataUri] Guid key)
        {
            Session = ConnectionHelper.CreateSession();
            var result = Session.Query<TransportDocumentOtherTransaction>().Where(t => t.Oid == key);
            return SingleResult.Create(result);
        }

        [HttpPost]
        public IHttpActionResult Post(TransportDocumentOtherTransaction transportDocumentOtherTransaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            using (UnitOfWork uow = ConnectionHelper.CreateSession())
            {
                TransportDocumentOtherTransaction entity = new TransportDocumentOtherTransaction(uow)
                {
                    Oid = transportDocumentOtherTransaction.Oid,
                    TransportCategory = transportDocumentOtherTransaction.TransportCategory != null ? uow.GetObjectByKey<HazardousGoodsTransportCategory>(transportDocumentOtherTransaction.TransportCategory.Oid) : null,
                    TunnelCode = transportDocumentOtherTransaction.TunnelCode != null ? uow.GetObjectByKey<HazardousGoodsTunnelCode>(transportDocumentOtherTransaction.TunnelCode.Oid) : null,
                    Description = transportDocumentOtherTransaction.Description,
                    ConvFactor = transportDocumentOtherTransaction.ConvFactor,
                    HazardousGoodsClass = transportDocumentOtherTransaction.HazardousGoodsClass != null ? uow.GetObjectByKey<HazardousGoodsClass>(transportDocumentOtherTransaction.HazardousGoodsClass.Oid) : null,
                    HazardousGoodsLabel = transportDocumentOtherTransaction.HazardousGoodsLabel != null ? uow.GetObjectByKey<HazardousGoodsLabel>(transportDocumentOtherTransaction.HazardousGoodsLabel.Oid) : null,
                    HazardousGoods = transportDocumentOtherTransaction.HazardousGoods != null ? uow.GetObjectByKey<HazardousGoods>(transportDocumentOtherTransaction.HazardousGoods.Oid) : null,
                    NetWeigth = transportDocumentOtherTransaction.NetWeigth,
                    PackagingTypes = transportDocumentOtherTransaction.PackagingTypes != null ? uow.GetObjectByKey<PackagingTypes>(transportDocumentOtherTransaction.PackagingTypes.Oid) : null,
                    PackingGroup = transportDocumentOtherTransaction.PackingGroup != null ? uow.GetObjectByKey<PackingGroup>(transportDocumentOtherTransaction.PackingGroup.Oid) : null,
                    Quantity = transportDocumentOtherTransaction.Quantity,
                    TotalConvFactor = transportDocumentOtherTransaction.TotalConvFactor,
                    Val = transportDocumentOtherTransaction.Val,
                    TransportDocument = transportDocumentOtherTransaction.TransportDocument != null ? uow.GetObjectByKey<TransportDocument>(transportDocumentOtherTransaction.TransportDocument.Oid) : null,
                    Unitset = transportDocumentOtherTransaction.Unitset != null ? uow.GetObjectByKey<Unitset>(transportDocumentOtherTransaction.Unitset.Oid) : null,
                    WasteCode = transportDocumentOtherTransaction.WasteCode != null ? uow.GetObjectByKey<WasteList>(transportDocumentOtherTransaction.WasteCode.Oid) : null

                };
                uow.CommitChanges();
                return Created(entity);
            }
        }
    }
}