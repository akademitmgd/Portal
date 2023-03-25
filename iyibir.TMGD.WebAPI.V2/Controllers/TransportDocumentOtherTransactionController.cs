using DevExpress.Xpo;
using iyibir.TMGD.WebAPI.V2.Models.iyibir_TMGD;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Transactions;
using System.Web.Http;

namespace iyibir.TMGD.WebAPI.V2.Controllers
{
    public class TransportDocumentOtherTransactionController : ApiController
    {
        private Session session = new Session();

        [HttpDelete]
        public int DeleteObject([FromBody, Required] TransportDocumentOtherTransaction item)
        {
            int result;

            if (item != null)
            {
                session.Delete(item);

                result = 1;
            }
            else
            {
                result = 0;
            }

            return result;
        }


        [HttpGet]
        public TransportDocumentOtherTransaction GetObjectById([FromBody, Required] Guid Oid)
        {
            TransportDocumentOtherTransaction transaction = session.GetObjectByKey<TransportDocumentOtherTransaction>(Oid);
            if (transaction != null)
            {
                return transaction;
            }
            else
            {
                return null;
            }
        }


        [HttpGet]
        public Guid GetObjectById([FromBody, Required] TransportDocumentOtherTransaction item)
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
        public IEnumerable<TransportDocumentOtherTransaction> GetObjects()
        {
            IList<TransportDocumentOtherTransaction> transactions = new List<TransportDocumentOtherTransaction>();

            var allTransactions = session.GetObjects(session.GetClassInfo<TransportDocumentOtherTransaction>(), null, null, 0, false, true);
            foreach (TransportDocumentOtherTransaction item in allTransactions)
            {
                transactions.Add(item);
            }

            return transactions;
        }


        [HttpPost]
        public Guid InsertObject([FromBody, Required] TransportDocumentOtherTransaction item)
        {
            try
            {
                if (item != null)
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                        TransportDocumentOtherTransaction transaction = new TransportDocumentOtherTransaction(session);
                        transaction.Description = item.Description;
                        transaction.HazardousGoods = item.HazardousGoods != null ? session.GetObjectByKey<HazardousGoods>(item.HazardousGoods.Oid) : null;
                        transaction.HazardousGoodsClass = item.HazardousGoodsClass != null ? session.GetObjectByKey<HazardousGoodsClass>(item.HazardousGoodsClass.Oid) : null;
                        transaction.HazardousGoodsLabel = item.HazardousGoodsLabel != null ? session.GetObjectByKey<HazardousGoodsLabel>(item.HazardousGoodsLabel.Oid) : null;
                        transaction.NetWeigth = item.NetWeigth;
                        transaction.PackagingTypes = item.PackagingTypes != null ? session.GetObjectByKey<PackagingTypes>(item.PackagingTypes.Oid) : null;
                        transaction.PackingGroup = item.PackingGroup != null ? session.GetObjectByKey<PackingGroup>(item.PackingGroup.Oid) : null;
                        transaction.Quantity = item.Quantity;
                        transaction.TransportDocument = item.TransportDocument != null ? session.GetObjectByKey<TransportDocument>(item.TransportDocument.Oid) : null;
                        transaction.Unitset = item.Unitset != null ? session.GetObjectByKey<Unitset>(item.Unitset.Oid) : null;
                        transaction.WasteCode = item.WasteCode != null ? session.GetObjectByKey<WasteList>(item.WasteCode.Oid) : null;

                        session.Save(transaction);

                        scope.Complete();

                        return transaction.Oid;
                    }
                }
                else
                {
                    return Guid.Empty;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [HttpPut]
        public int UpdateObject([FromBody, Required] TransportDocumentOtherTransaction item)
        {
            int result;

            try
            {
                if (item != null)
                {
                    TransportDocumentOtherTransaction transaction = session.GetObjectByKey<TransportDocumentOtherTransaction>(item.Oid);
                    if (transaction != null)
                    {
                        using (TransactionScope scope = new TransactionScope())
                        {
                            transaction.Description = item.Description;
                            transaction.HazardousGoods = item.HazardousGoods != null ? session.GetObjectByKey<HazardousGoods>(item.HazardousGoods.Oid) : null;
                            transaction.HazardousGoodsClass = item.HazardousGoodsClass != null ? session.GetObjectByKey<HazardousGoodsClass>(item.HazardousGoodsClass.Oid) : null;
                            transaction.HazardousGoodsLabel = item.HazardousGoodsLabel != null ? session.GetObjectByKey<HazardousGoodsLabel>(item.HazardousGoodsLabel.Oid) : null;
                            transaction.NetWeigth = item.NetWeigth;
                            transaction.PackagingTypes = item.PackagingTypes != null ? session.GetObjectByKey<PackagingTypes>(item.PackagingTypes.Oid) : null;
                            transaction.PackingGroup = item.PackingGroup != null ? session.GetObjectByKey<PackingGroup>(item.PackingGroup.Oid) : null;
                            transaction.Quantity = item.Quantity;
                            transaction.TransportDocument = item.TransportDocument != null ? session.GetObjectByKey<TransportDocument>(item.TransportDocument.Oid) : null;
                            transaction.Unitset = item.Unitset != null ? session.GetObjectByKey<Unitset>(item.Unitset.Oid) : null;
                            transaction.WasteCode = item.WasteCode != null ? session.GetObjectByKey<WasteList>(item.WasteCode.Oid) : null;

                            session.Save(transaction);

                            result = 1;

                            scope.Complete();
                        }
                    }
                    else
                    {
                        result = 0;
                    }
                }
                else
                {
                    result = 0;
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
