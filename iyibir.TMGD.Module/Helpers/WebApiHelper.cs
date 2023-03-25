using iyibir.TMGD.Module.ApiModel;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iyibir.TMGD.Module.Helpers
{
    public class WebApiHelper
    {
        //private static string uri = ConfigurationManager.AppSettings["Uri"].ToString();

        public string GetToken(string customerUrl,string username,string password)
        {
            var client = new RestClient(string.Format("{0}/token", customerUrl));
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("grant_type", "password");
            request.AddParameter("username", username);
            request.AddParameter("password", password);
            IRestResponse response = client.Execute(request);

            var json = Newtonsoft.Json.JsonConvert.DeserializeObject<TokenClass>(response.Content);

            return json.Access_Token;

        }

        public DBResult GetDispatchList(string token,int FirmNumber,int PeriodNumber,string customerUrl)
        {
            DBResult result = new DBResult();

            try
            {
                var client = new RestClient(string.Format("{0}/api/STFICHE/GetObjects", customerUrl));
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", string.Format("Bearer {0}", token));
                request.AddParameter("FirmNumber", FirmNumber, ParameterType.QueryString);
                request.AddParameter("PeriodNumber", PeriodNumber, ParameterType.QueryString);

                IRestResponse response = client.Execute(request);

                var json = Newtonsoft.Json.JsonConvert.DeserializeObject<DBResult>(response.Content);

                result.Status = json.Status;
                result.Data = json.Data;
                result.Message = "Success";
                result.Data = json.Data;
                result.ErrorMessage = json.ErrorMessage;
            }
            catch (Exception ex)
            {
                result.Data = ex.Message;
                result.Status = false;
                result.Message = "Error";
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public DBResult GetProductTransaction(string token, int FirmNumber, int PeriodNumber,string ProductCode,string customerUrl)
        {
            DBResult result = new DBResult();

            try
            {
                var client = new RestClient(string.Format("{0}/api/STFICHE/GetObjects", customerUrl));
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", string.Format("Bearer {0}", token));
                request.AddParameter("FirmNumber", FirmNumber, ParameterType.QueryString);
                request.AddParameter("PeriodNumber", PeriodNumber, ParameterType.QueryString);
                request.AddParameter("ProductCode", ProductCode, ParameterType.QueryString);

                IRestResponse response = client.Execute(request);

                var json = Newtonsoft.Json.JsonConvert.DeserializeObject<DBResult>(response.Content);

                result.Status = true;
                result.Data = json.Data;
                result.Message = "Success";
                result.Data = json.Data;
            }
            catch (Exception ex)
            {
                result.Data = ex.Message;
                result.Status = false;
                result.Message = "Error";
                result.ErrorMessage = ex.Message;
            }

            return result;
        }
    }
}
