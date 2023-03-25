using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace iyibir.TMGD.WebAPI.Models
{
    public partial class Consignee
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public DataResult GetObjectById(Guid Oid)
        {
            DataResult result = new DataResult();
            try
            {
                List<Consignee> items = new List<Consignee>();
                string commandString = string.Format("SELECT * FROM Consignee WHERE Oid = '{0}'", Oid);
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            Consignee consignee = new Consignee();
                            consignee.Oid = Guid.Parse(dr["Oid"].ToString());
                            consignee.FirstName = string.IsNullOrEmpty(dr["FirstName"].ToString()) ? string.Empty : dr["FirstName"].ToString();
                            consignee.Title = string.IsNullOrEmpty(dr["Title"].ToString()) ? string.Empty : dr["Title"].ToString();
                            consignee.LastName = string.IsNullOrEmpty(dr["LastName"].ToString()) ? string.Empty : dr["LastName"].ToString();
                            consignee.TaxNumber = string.IsNullOrEmpty(dr["TaxNumber"].ToString()) ? string.Empty : dr["TaxNumber"].ToString();
                            consignee.TaxOffice = string.IsNullOrEmpty(dr["TaxOffice"].ToString()) ? string.Empty : dr["TaxOffice"].ToString();
                            consignee.TCKN = string.IsNullOrEmpty(dr["TCKN"].ToString()) ? string.Empty : dr["TCKN"].ToString();
                            consignee.EMail = string.IsNullOrEmpty(dr["EMail"].ToString()) ? string.Empty : dr["EMail"].ToString();
                            consignee.Address = string.IsNullOrEmpty(dr["Address"].ToString()) ? string.Empty : dr["Address"].ToString();
                            consignee.Telephone = string.IsNullOrEmpty(dr["Telephone"].ToString()) ? string.Empty : dr["Telephone"].ToString();
                            consignee.OtherTelephone = string.IsNullOrEmpty(dr["OtherTelephone"].ToString()) ? string.Empty : dr["OtherTelephone"].ToString();
                            consignee.Code = string.IsNullOrEmpty(dr["Code"].ToString()) ? string.Empty : dr["Code"].ToString();
                            consignee.Country = dr["Country"] == DBNull.Value ? null : ((List<Country>)new Country().GetObjectById(Guid.Parse(dr["Country"].ToString())).Data).FirstOrDefault();
                            consignee.County = dr["County"] == DBNull.Value ? null : ((List<County>)new County().GetObjectById(Guid.Parse(dr["County"].ToString())).Data).FirstOrDefault();
                            consignee.City = dr["City"] == DBNull.Value ? null : ((List<City>)new City().GetObjectById(Guid.Parse(dr["City"].ToString())).Data).FirstOrDefault();
                            consignee.Customer = dr["Customer"] == DBNull.Value ? null : ((List<Customer>)new Customer().GetObjectById(Guid.Parse(dr["Customer"].ToString())).Data).FirstOrDefault();
                            consignee.IsActive = dr["IsActive"] == DBNull.Value ? false : (bool)dr["IsActive"];
                            consignee.IsPerson = dr["IsPerson"] == DBNull.Value ? false : (bool)dr["IsPerson"];
                            consignee.ConsigneeType = dr["ConsigneeType"] == DBNull.Value ? default(int) : (int)dr["ConsigneeType"];

                            items.Add(consignee);
                        }
                    }
                }

                result.Result = true;
                result.Data = items;
                result.Message = "Success";
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Data = ex.Message;
                result.Message = "Error";
            }

            return result;
        }
        public DataResult GetObjectByCode(string code)
        {
            DataResult result = new DataResult();
            try
            {
                List<Consignee> items = new List<Consignee>();
                string commandString = string.Format("SELECT * FROM Consignee WHERE Code = '{0}'", code);
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            Consignee consignee = new Consignee();
                            consignee.Oid = Guid.Parse(dr["Oid"].ToString());
                            consignee.FirstName = string.IsNullOrEmpty(dr["FirstName"].ToString()) ? string.Empty : dr["FirstName"].ToString();
                            consignee.Title = string.IsNullOrEmpty(dr["Title"].ToString()) ? string.Empty : dr["Title"].ToString();
                            consignee.LastName = string.IsNullOrEmpty(dr["LastName"].ToString()) ? string.Empty : dr["LastName"].ToString();
                            consignee.TaxNumber = string.IsNullOrEmpty(dr["TaxNumber"].ToString()) ? string.Empty : dr["TaxNumber"].ToString();
                            consignee.TaxOffice = string.IsNullOrEmpty(dr["TaxOffice"].ToString()) ? string.Empty : dr["TaxOffice"].ToString();
                            consignee.TCKN = string.IsNullOrEmpty(dr["TCKN"].ToString()) ? string.Empty : dr["TCKN"].ToString();
                            consignee.EMail = string.IsNullOrEmpty(dr["EMail"].ToString()) ? string.Empty : dr["EMail"].ToString();
                            consignee.Address = string.IsNullOrEmpty(dr["Address"].ToString()) ? string.Empty : dr["Address"].ToString();
                            consignee.Telephone = string.IsNullOrEmpty(dr["Telephone"].ToString()) ? string.Empty : dr["Telephone"].ToString();
                            consignee.OtherTelephone = string.IsNullOrEmpty(dr["OtherTelephone"].ToString()) ? string.Empty : dr["OtherTelephone"].ToString();
                            consignee.Code = string.IsNullOrEmpty(dr["Code"].ToString()) ? string.Empty : dr["Code"].ToString();
                            consignee.Country = dr["Country"] == DBNull.Value ? null : ((List<Country>)new Country().GetObjectById(Guid.Parse(dr["Country"].ToString())).Data).FirstOrDefault();
                            consignee.County = dr["County"] == DBNull.Value ? null : ((List<County>)new County().GetObjectById(Guid.Parse(dr["County"].ToString())).Data).FirstOrDefault();
                            consignee.City = dr["City"] == DBNull.Value ? null : ((List<City>)new City().GetObjectById(Guid.Parse(dr["City"].ToString())).Data).FirstOrDefault();
                            consignee.Customer = dr["Customer"] == DBNull.Value ? null : ((List<Customer>)new Customer().GetObjectById(Guid.Parse(dr["Customer"].ToString())).Data).FirstOrDefault();
                            consignee.IsActive = dr["IsActive"] == DBNull.Value ? false : (bool)dr["IsActive"];
                            consignee.IsPerson = dr["IsPerson"] == DBNull.Value ? false : (bool)dr["IsPerson"];
                            consignee.ConsigneeType = dr["ConsigneeType"] == DBNull.Value ? default(int) : (int)dr["ConsigneeType"];

                            items.Add(consignee);
                        }
                    }
                }

                result.Result = true;
                result.Data = items;
                result.Message = "Success";
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Data = ex.Message;
                result.Message = "Error";
            }

            return result;
        }
        public DataResult GetObjects()
        {
            DataResult result = new DataResult();
            try
            {
                List<Consignee> items = new List<Consignee>();
                string commandString = string.Format("SELECT * FROM Consignee");
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            Consignee consignee = new Consignee();
                            consignee.Oid = Guid.Parse(dr["Oid"].ToString());
                            consignee.FirstName = string.IsNullOrEmpty(dr["FirstName"].ToString()) ? string.Empty : dr["FirstName"].ToString();
                            consignee.Title = string.IsNullOrEmpty(dr["Title"].ToString()) ? string.Empty : dr["Title"].ToString();
                            consignee.LastName = string.IsNullOrEmpty(dr["LastName"].ToString()) ? string.Empty : dr["LastName"].ToString();
                            consignee.TaxNumber = string.IsNullOrEmpty(dr["TaxNumber"].ToString()) ? string.Empty : dr["TaxNumber"].ToString();
                            consignee.TaxOffice = string.IsNullOrEmpty(dr["TaxOffice"].ToString()) ? string.Empty : dr["TaxOffice"].ToString();
                            consignee.TCKN = string.IsNullOrEmpty(dr["TCKN"].ToString()) ? string.Empty : dr["TCKN"].ToString();
                            consignee.EMail = string.IsNullOrEmpty(dr["EMail"].ToString()) ? string.Empty : dr["EMail"].ToString();
                            consignee.Address = string.IsNullOrEmpty(dr["Address"].ToString()) ? string.Empty : dr["Address"].ToString();
                            consignee.Telephone = string.IsNullOrEmpty(dr["Telephone"].ToString()) ? string.Empty : dr["Telephone"].ToString();
                            consignee.OtherTelephone = string.IsNullOrEmpty(dr["OtherTelephone"].ToString()) ? string.Empty : dr["OtherTelephone"].ToString();
                            consignee.Code = string.IsNullOrEmpty(dr["Code"].ToString()) ? string.Empty : dr["Code"].ToString();
                            consignee.Country = dr["Country"] == DBNull.Value ? null : ((List<Country>)new Country().GetObjectById(Guid.Parse(dr["Country"].ToString())).Data).FirstOrDefault();
                            consignee.County = dr["County"] == DBNull.Value ? null : ((List<County>)new County().GetObjectById(Guid.Parse(dr["County"].ToString())).Data).FirstOrDefault();
                            consignee.City = dr["City"] == DBNull.Value ? null : ((List<City>)new City().GetObjectById(Guid.Parse(dr["City"].ToString())).Data).FirstOrDefault();
                            consignee.Customer = dr["Customer"] == DBNull.Value ? null : ((List<Customer>)new Customer().GetObjectById(Guid.Parse(dr["Customer"].ToString())).Data).FirstOrDefault();
                            consignee.IsActive = dr["IsActive"] == DBNull.Value ? false : (bool)dr["IsActive"];
                            consignee.IsPerson = dr["IsPerson"] == DBNull.Value ? false : (bool)dr["IsPerson"];
                            consignee.ConsigneeType = dr["ConsigneeType"] == DBNull.Value ? default(int) : (int)dr["ConsigneeType"];

                            items.Add(consignee);
                        }
                    }
                }

                result.Result = true;
                result.Data = items;
                result.Message = "Success";
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Data = ex.Message;
                result.Message = "Error";
            }

            return result;
        }
    }
}