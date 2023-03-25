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
    public class TransportDocumentController : ApiController
    {
        private Session session = new Session();

        [HttpDelete]
        public int DeleteObject([FromBody, Required] TransportDocument item)
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
        public TransportDocument GetObjectById([FromBody, Required] Guid Oid)
        {
            TransportDocument transportDocument = session.GetObjectByKey<TransportDocument>(Oid);
            if (transportDocument != null)
            {
                return transportDocument;
            }
            else
            {
                return null;
            }
        }


        [HttpGet]
        public Guid GetObjectById([FromBody, Required] TransportDocument item)
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
        public IEnumerable<TransportDocument> GetObjects()
        {
            IList<TransportDocument> transportDocuments = new List<TransportDocument>();
            var allTransportDocuments = session.GetObjects(session.GetClassInfo<TransportDocument>(), null, null, 0, false, true);

            foreach (TransportDocument item in allTransportDocuments)
            {
                transportDocuments.Add(item);
            }

            return transportDocuments;
        }


        [HttpPost]
        public Guid InsertObject([FromBody, Required]  TransportDocument item)
        {
            if (item != null)
            {
                try
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                        TransportDocument transportDocument = new TransportDocument(session);
                        transportDocument.Vehicle = item.Vehicle != null ? session.GetObjectByKey<Vehicle>(item.Vehicle.Oid) : null;
                        transportDocument.TunnelCode = item.TunnelCode;
                        transportDocument.TransportDocumentType = item.TransportDocumentType;
                        transportDocument.TransportCategory = item.TransportCategory;
                        transportDocument.SpecialShipper = item.SpecialShipper;
                        transportDocument.Shipper = item.Shipper != null ? session.GetObjectByKey<Consignee>(item.Shipper.Oid) : null;
                        transportDocument.ScoreQuantity = item.ScoreQuantity;
                        transportDocument.Owner = item.Owner != null ? session.GetObjectByKey<Employee>(item.Owner.Oid) : null;
                        transportDocument.IsSpecial = item.IsSpecial;
                        transportDocument.Driver = item.Driver != null ? session.GetObjectByKey<VehicleDriver>(item.Driver.Oid) : null;
                        transportDocument.Description = item.Description;
                        transportDocument.CreatedTime = item.CreatedTime;
                        transportDocument.CreatedDate = item.CreatedDate;
                        transportDocument.ConsignerTaxOffice = item.ConsignerTaxOffice;
                        transportDocument.ConsignerTaxNumber = item.ConsignerTaxNumber;
                        transportDocument.ConsignerAddress = item.ConsignerAddress;
                        transportDocument.Consigner = item.Consigner != null ? session.GetObjectByKey<Customer>(item.Consigner.Oid) : null;
                        transportDocument.ConsigneeTaxOffice = item.ConsigneeTaxOffice;
                        transportDocument.ConsigneeTaxNumber = item.ConsigneeTaxNumber;
                        transportDocument.ConsigneeAddress = item.ConsigneeAddress;
                        transportDocument.Consignee = item.Consignee != null ? session.GetObjectByKey<Consignee>(item.Consignee.Oid) : null;
                        transportDocument.Code = item.Code;

                        session.Save(transportDocument);

                        scope.Complete();

                        return transportDocument.Oid;
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                return Guid.Empty;
            }

        }


        [HttpPut]
        public int UpdateObject([FromBody, Required] TransportDocument item)
        {
            int result;

            try
            {
                if (item != null)
                {
                    TransportDocument transportDocument = session.GetObjectByKey<TransportDocument>(item.Oid);
                    if (transportDocument != null)
                    {
                        using (TransactionScope scope = new TransactionScope())
                        {
                            transportDocument.Vehicle = item.Vehicle != null ? session.GetObjectByKey<Vehicle>(item.Vehicle.Oid) : null;
                            transportDocument.TunnelCode = item.TunnelCode;
                            transportDocument.TransportDocumentType = item.TransportDocumentType;
                            transportDocument.TransportCategory = item.TransportCategory;
                            transportDocument.SpecialShipper = item.SpecialShipper;
                            transportDocument.Shipper = item.Shipper != null ? session.GetObjectByKey<Consignee>(item.Shipper.Oid) : null;
                            transportDocument.ScoreQuantity = item.ScoreQuantity;
                            transportDocument.Owner = item.Owner != null ? session.GetObjectByKey<Employee>(item.Owner.Oid) : null;
                            transportDocument.IsSpecial = item.IsSpecial;
                            transportDocument.Driver = item.Driver != null ? session.GetObjectByKey<VehicleDriver>(item.Driver.Oid) : null;
                            transportDocument.Description = item.Description;
                            transportDocument.CreatedTime = item.CreatedTime;
                            transportDocument.CreatedDate = item.CreatedDate;
                            transportDocument.ConsignerTaxOffice = item.ConsignerTaxOffice;
                            transportDocument.ConsignerTaxNumber = item.ConsignerTaxNumber;
                            transportDocument.ConsignerAddress = item.ConsignerAddress;
                            transportDocument.Consigner = item.Consigner != null ? session.GetObjectByKey<Customer>(item.Consigner.Oid) : null;
                            transportDocument.ConsigneeTaxOffice = item.ConsigneeTaxOffice;
                            transportDocument.ConsigneeTaxNumber = item.ConsigneeTaxNumber;
                            transportDocument.ConsigneeAddress = item.ConsigneeAddress;
                            transportDocument.Consignee = item.Consignee != null ? session.GetObjectByKey<Consignee>(item.Consignee.Oid) : null;
                            transportDocument.Code = item.Code;

                            session.Save(transportDocument);

                            result = 1;
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
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}
