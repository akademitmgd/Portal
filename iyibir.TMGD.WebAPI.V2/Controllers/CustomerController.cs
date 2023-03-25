using DevExpress.ExpressApp.Xpo;
using DevExpress.Xpo;
using iyibir.TMGD.WebAPI.V2.EModels;
using iyibir.TMGD.WebAPI.V2.Models;
using iyibir.TMGD.WebAPI.V2.Models.iyibir_TMGD;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Web.Http;

namespace iyibir.TMGD.WebAPI.V2.Controllers
{
    public class CustomerController : ApiController
    {
        [HttpGet]
        public DataResult GetObjects()
        {
            DataResult result = new DataResult();
            try
            {
                List<CustomerModel> customerModels = new List<CustomerModel>();
                using (Session session = new Session())
                {
                    foreach (Customer item in session.GetObjects(session.GetClassInfo<Customer>(), null, null, 0, false, true))
                    {
                        CustomerModel customer = new CustomerModel();
                        customer.ActivityCertificateCode = item.ActivityCertificateCode;
                        customer.ActivityCertificateDate = item.ActivityCertificateDate;
                        customer.Address = item.Address;
                        customer.Carrier = item.Carrier;
                       

                        customerModels.Add(customer);
                    }
                }

                result.Data = customerModels;
                result.Message = "Success";
                result.Result = true;

            }
            catch (Exception ex)
            {

                result.Data = null;
                result.Message = ex.Message;
                result.Result = false;

            }
            return result;
        }
    }
}
