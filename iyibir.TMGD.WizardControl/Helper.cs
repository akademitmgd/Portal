using iyibir.TMGD.WizardControl.Model;
using IyibirDLL;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iyibir.TMGD.WizardControl
{
    public class Helper
    {
        private static string uri = ConfigurationManager.AppSettings["Uri"].ToString();
        public string GetToken()
        {
            var client = new RestClient(string.Format("{0}/token",uri));
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("grant_type", "password");
            request.AddParameter("username", "iyibir");
            request.AddParameter("password", "123");
            IRestResponse response = client.Execute(request);

            var json = Newtonsoft.Json.JsonConvert.DeserializeObject<TokenClass>(response.Content);

            return json.Access_Token;

        }

        public DataResult InsertProduct(LG_ITEMS item, string token, Customer customer, Employee owner)
        {
            DataResult result = new DataResult();

            try
            {
                var client = new RestClient(string.Format("{0}/api/Product/InsertObject", uri));
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", string.Format("Bearer {0}", token));
                request.AddHeader("Content-Type", "application/json");

                Product product = new Product();
                product.Code = item.CODE;
                product.Name = item.NAME;
                product.ProductGroupType = 0;
                product.ProductType = 2;
                product.OtherName = item.NAME2;
                product.IsActive = true;
                product.Oid = Guid.NewGuid();

                var hazardousGoods = (JArray)GetHazardousGoods(item.SPECODE, token).Data;
                if (hazardousGoods != null)
                    product.HazardousGoods = hazardousGoods.ToObject<List<HazardousGoods>>().FirstOrDefault();
                else
                    product.HazardousGoods = null;

                product.Customer = customer;
                product.Owner = owner;


                object data = Newtonsoft.Json.JsonConvert.SerializeObject(product);
                request.AddParameter("product", data, "application/json", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                var json = Newtonsoft.Json.JsonConvert.DeserializeObject<DataResult>(response.Content);

                result.Data = json.Data;
                result.Result = json.Result;
                result.Message = json.Message;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public DataResult InsertConsignee(LG_CLCARD item, string token, Customer customer)
        {
            DataResult result = new DataResult();

            try
            {
                var client = new RestClient(string.Format("{0}/api/Consignee/InsertObject", uri));
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", string.Format("Bearer {0}", token));
                request.AddHeader("Content-Type", "application/json");

                Consignee consignee = new Consignee();
                consignee.Oid = Guid.NewGuid();
                consignee.Code = item.CODE;
                consignee.Title = item.DEFINITION_;
                consignee.Address = item.ADDR1;
                consignee.ConsigneeType = 1;
                consignee.Customer = customer;
                consignee.EMail = item.EMAILADDR;
                consignee.FirstName = item.NAME;
                consignee.IsActive = true;
                consignee.IsPerson = item.ISPERSCOMP == 1 ? true : false;
                consignee.LastName = item.SURNAME;
                consignee.OtherTelephone = string.Format("{0}{1}", item.TELCODES2, item.TELNRS2);
                consignee.TaxNumber = item.TAXNR;
                consignee.TaxOffice = item.TAXOFFICE;
                consignee.TCKN = item.TCKNO;
                consignee.Telephone = string.Format("{0}{1}", item.TELCODES1, item.TELNRS1);


                object data = Newtonsoft.Json.JsonConvert.SerializeObject(consignee);
                request.AddParameter("consignee", data, "application/json", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                var json = Newtonsoft.Json.JsonConvert.DeserializeObject<DataResult>(response.Content);

                result.Data = json.Data;
                result.Result = json.Result;
                result.Message = json.Message;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public DataResult GetCustomer(Guid Oid, string token)
        {
            DataResult result = new DataResult();

            try
            {
                var client = new RestClient(string.Format("{0}/api/Customer/GetObjectById", uri));
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", string.Format("Bearer {0}", token));
                request.AddParameter("Oid", Oid, ParameterType.QueryString);
                IRestResponse response = client.Execute(request);

                var json = Newtonsoft.Json.JsonConvert.DeserializeObject<DataResult>(response.Content);

                result.Data = json.Data;
                result.Message = json.Message;
                result.Result = json.Result;
            }
            catch (Exception ex)
            {
                result.Data = ex.Message;
                result.Result = false;
                result.Message = "Error";
            }

            return result;
        }

        public DataResult GetHazardousGoods(string code, string token)
        {
            DataResult result = new DataResult();

            try
            {
                var client = new RestClient(string.Format("{0}/api/HazardousGoods/GetObjectByCode", uri));
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", string.Format("Bearer {0}", token));
                request.AddParameter("code", code, ParameterType.QueryString);
                IRestResponse response = client.Execute(request);

                var json = Newtonsoft.Json.JsonConvert.DeserializeObject<DataResult>(response.Content);

                result.Data = json.Data;
                result.Message = json.Message;
                result.Result = json.Result;
            }
            catch (Exception ex)
            {
                result.Data = ex.Message;
                result.Result = false;
                result.Message = "Error";
            }

            return result;
        }

        public DataResult GetWasteCode(string code, string token)
        {
            DataResult result = new DataResult();

            try
            {
                var client = new RestClient(string.Format("{0}/api/WasteList/GetObjectByCode", uri));
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", string.Format("Bearer {0}", token));
                request.AddParameter("code", code, ParameterType.QueryString);
                IRestResponse response = client.Execute(request);

                var json = Newtonsoft.Json.JsonConvert.DeserializeObject<DataResult>(response.Content);

                result.Data = json.Data;
                result.Message = json.Message;
                result.Result = json.Result;
            }
            catch (Exception ex)
            {
                result.Data = ex.Message;
                result.Result = false;
                result.Message = "Error";
            }

            return result;
        }

        public DataResult GetEmployee(Guid Oid, string token)
        {
            DataResult result = new DataResult();

            try
            {
                var client = new RestClient(string.Format("{0}/api/Employee/GetObjectByCustomerId", uri));
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", string.Format("Bearer {0}", token));
                request.AddParameter("Oid", Oid, ParameterType.QueryString);
                IRestResponse response = client.Execute(request);

                var json = Newtonsoft.Json.JsonConvert.DeserializeObject<DataResult>(response.Content);

                result.Data = json.Data;
                result.Message = json.Message;
                result.Result = json.Result;
            }
            catch (Exception ex)
            {
                result.Data = ex.Message;
                result.Result = false;
                result.Message = "Error";
            }

            return result;
        }
    }
}
