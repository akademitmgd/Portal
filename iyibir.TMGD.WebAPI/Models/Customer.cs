using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace iyibir.TMGD.WebAPI.Models
{
    public partial class Customer
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public DataResult GetObjectById(Guid Oid)
        {
            DataResult result = new DataResult();
            try
            {
                List<Customer> items = new List<Customer>();
                string commandString = string.Format("SELECT * FROM Customer WHERE Oid = '{0}'", Oid);
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            Customer customer = new Customer();
                            customer.Oid = Guid.Parse(dr["Oid"].ToString());
                            customer.FirstName = string.IsNullOrEmpty(dr["FirstName"].ToString()) ? string.Empty : dr["FirstName"].ToString();
                            customer.LastName = string.IsNullOrEmpty(dr["LastName"].ToString()) ? string.Empty : dr["LastName"].ToString();
                            customer.TaxNumber = string.IsNullOrEmpty(dr["TaxNumber"].ToString()) ? string.Empty : dr["TaxNumber"].ToString();
                            customer.TaxOffice = string.IsNullOrEmpty(dr["TaxOffice"].ToString()) ? string.Empty : dr["TaxOffice"].ToString();
                            customer.Telephone = string.IsNullOrEmpty(dr["Telephone"].ToString()) ? string.Empty : dr["Telephone"].ToString();
                            customer.OtherTelephone = string.IsNullOrEmpty(dr["OtherTelephone"].ToString()) ? string.Empty : dr["OtherTelephone"].ToString();
                            customer.ActivityCertificateCode = string.IsNullOrEmpty(dr["ActivityCertificateCode"].ToString()) ? string.Empty : dr["ActivityCertificateCode"].ToString();
                            customer.Address = string.IsNullOrEmpty(dr["Address"].ToString()) ? string.Empty : dr["Address"].ToString();
                            customer.Code = string.IsNullOrEmpty(dr["Code"].ToString()) ? string.Empty : dr["Code"].ToString();
                            customer.EMail = string.IsNullOrEmpty(dr["EMail"].ToString()) ? string.Empty : dr["EMail"].ToString();
                            customer.TCKN = string.IsNullOrEmpty(dr["TCKN"].ToString()) ? string.Empty : dr["TCKN"].ToString();
                            customer.Title = string.IsNullOrEmpty(dr["Title"].ToString()) ? string.Empty : dr["Title"].ToString();
                            customer.ActivityCertificateDate = dr["ActivityCertificateDate"] == DBNull.Value ? default(DateTime) : (DateTime)dr["ActivityCertificateDate"];

                            customer.IsActive = dr["IsActive"] == DBNull.Value ? false : (bool)dr["IsActive"];
                            customer.IsPerson = dr["IsPerson"] == DBNull.Value ? false : (bool)dr["IsPerson"];
                            customer.Consignee = dr["Consignee"] == DBNull.Value ? false : (bool)dr["Consignee"];
                            customer.Consignor = dr["Consignor"] == DBNull.Value ? false : (bool)dr["Consignor"];
                            customer.Filler = dr["Filler"] == DBNull.Value ? false : (bool)dr["Filler"];
                            customer.Loader = dr["Loader"] == DBNull.Value ? false : (bool)dr["Loader"];
                            customer.Packer = dr["Packer"] == DBNull.Value ? false : (bool)dr["Packer"];
                            customer.TankContainer = dr["TankContainer"] == DBNull.Value ? false : (bool)dr["TankContainer"];
                            customer.UnLoader = dr["UnLoader"] == DBNull.Value ? false : (bool)dr["UnLoader"];
                            customer.Carrier = dr["Carrier"] == DBNull.Value ? false : (bool)dr["Carrier"];


                            customer.Country = dr["Country"] == DBNull.Value ? null : ((List<Country>)new Country().GetObjectById(Guid.Parse(dr["Country"].ToString())).Data).FirstOrDefault();
                            customer.City = dr["City"] == DBNull.Value ? null : ((List<City>)new City().GetObjectById(Guid.Parse(dr["City"].ToString())).Data).FirstOrDefault();
                            customer.Consultant = dr["Consultant"] == DBNull.Value ? null : ((List<Employee>)new Employee().GetObjectById(Guid.Parse(dr["Consultant"].ToString())).Data).FirstOrDefault();
                            customer.County = dr["County"] == DBNull.Value ? null : ((List<County>)new County().GetObjectById(Guid.Parse(dr["County"].ToString())).Data).FirstOrDefault();
                            customer.Sector = dr["Sector"] == DBNull.Value ? null : ((List<Sector>)new Sector().GetObjectById(Guid.Parse(dr["Sector"].ToString())).Data).FirstOrDefault();

                            items.Add(customer);
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
                List<Customer> items = new List<Customer>();
                string commandString = string.Format("SELECT * FROM Customer");
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            Customer customer = new Customer();
                            customer.Oid = Guid.Parse(dr["Oid"].ToString());
                            customer.FirstName = string.IsNullOrEmpty(dr["FirstName"].ToString()) ? string.Empty : dr["FirstName"].ToString();
                            customer.LastName = string.IsNullOrEmpty(dr["LastName"].ToString()) ? string.Empty : dr["LastName"].ToString();
                            customer.TaxNumber = string.IsNullOrEmpty(dr["TaxNumber"].ToString()) ? string.Empty : dr["TaxNumber"].ToString();
                            customer.TaxOffice = string.IsNullOrEmpty(dr["TaxOffice"].ToString()) ? string.Empty : dr["TaxOffice"].ToString();
                            customer.Telephone = string.IsNullOrEmpty(dr["Telephone"].ToString()) ? string.Empty : dr["Telephone"].ToString();
                            customer.OtherTelephone = string.IsNullOrEmpty(dr["OtherTelephone"].ToString()) ? string.Empty : dr["OtherTelephone"].ToString();
                            customer.ActivityCertificateCode = string.IsNullOrEmpty(dr["ActivityCertificateCode"].ToString()) ? string.Empty : dr["ActivityCertificateCode"].ToString();
                            customer.Address = string.IsNullOrEmpty(dr["Address"].ToString()) ? string.Empty : dr["Address"].ToString();
                            customer.Code = string.IsNullOrEmpty(dr["Code"].ToString()) ? string.Empty : dr["Code"].ToString();
                            customer.EMail = string.IsNullOrEmpty(dr["EMail"].ToString()) ? string.Empty : dr["EMail"].ToString();
                            customer.TCKN = string.IsNullOrEmpty(dr["TCKN"].ToString()) ? string.Empty : dr["TCKN"].ToString();
                            customer.Title = string.IsNullOrEmpty(dr["Title"].ToString()) ? string.Empty : dr["Title"].ToString();
                            customer.ActivityCertificateDate = dr["ActivityCertificateDate"] == DBNull.Value ? default(DateTime) : (DateTime)dr["ActivityCertificateDate"];

                            customer.IsActive = dr["IsActive"] == DBNull.Value ? false : (bool)dr["IsActive"];
                            customer.IsPerson = dr["IsPerson"] == DBNull.Value ? false : (bool)dr["IsPerson"];
                            customer.Consignee = dr["Consignee"] == DBNull.Value ? false : (bool)dr["Consignee"];
                            customer.Consignor = dr["Consignor"] == DBNull.Value ? false : (bool)dr["Consignor"];
                            customer.Filler = dr["Filler"] == DBNull.Value ? false : (bool)dr["Filler"];
                            customer.Loader = dr["Loader"] == DBNull.Value ? false : (bool)dr["Loader"];
                            customer.Packer = dr["Packer"] == DBNull.Value ? false : (bool)dr["Packer"];
                            customer.TankContainer = dr["TankContainer"] == DBNull.Value ? false : (bool)dr["TankContainer"];
                            customer.UnLoader = dr["UnLoader"] == DBNull.Value ? false : (bool)dr["UnLoader"];
                            customer.Carrier = dr["Carrier"] == DBNull.Value ? false : (bool)dr["Carrier"];


                            customer.Country = dr["Country"] == DBNull.Value ? null : ((List<Country>)new Country().GetObjectById(Guid.Parse(dr["Country"].ToString())).Data).FirstOrDefault();
                            customer.City = dr["City"] == DBNull.Value ? null : ((List<City>)new City().GetObjectById(Guid.Parse(dr["City"].ToString())).Data).FirstOrDefault();
                            customer.Consultant = dr["Consultant"] == DBNull.Value ? null : ((List<Employee>)new Employee().GetObjectById(Guid.Parse(dr["Consultant"].ToString())).Data).FirstOrDefault();
                            customer.County = dr["County"] == DBNull.Value ? null : ((List<County>)new County().GetObjectById(Guid.Parse(dr["County"].ToString())).Data).FirstOrDefault();
                            customer.Sector = dr["Sector"] == DBNull.Value ? null : ((List<Sector>)new Sector().GetObjectById(Guid.Parse(dr["Sector"].ToString())).Data).FirstOrDefault();

                            items.Add(customer);
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
                List<Customer> items = new List<Customer>();
                string commandString = string.Format("SELECT * FROM Customer WHERE Code = '{0}'", code);
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            Customer customer = new Customer();
                            customer.Oid = Guid.Parse(dr["Oid"].ToString());
                            customer.FirstName = string.IsNullOrEmpty(dr["FirstName"].ToString()) ? string.Empty : dr["FirstName"].ToString();
                            customer.LastName = string.IsNullOrEmpty(dr["LastName"].ToString()) ? string.Empty : dr["LastName"].ToString();
                            customer.TaxNumber = string.IsNullOrEmpty(dr["TaxNumber"].ToString()) ? string.Empty : dr["TaxNumber"].ToString();
                            customer.TaxOffice = string.IsNullOrEmpty(dr["TaxOffice"].ToString()) ? string.Empty : dr["TaxOffice"].ToString();
                            customer.Telephone = string.IsNullOrEmpty(dr["Telephone"].ToString()) ? string.Empty : dr["Telephone"].ToString();
                            customer.OtherTelephone = string.IsNullOrEmpty(dr["OtherTelephone"].ToString()) ? string.Empty : dr["OtherTelephone"].ToString();
                            customer.ActivityCertificateCode = string.IsNullOrEmpty(dr["ActivityCertificateCode"].ToString()) ? string.Empty : dr["ActivityCertificateCode"].ToString();
                            customer.Address = string.IsNullOrEmpty(dr["Address"].ToString()) ? string.Empty : dr["Address"].ToString();
                            customer.Code = string.IsNullOrEmpty(dr["Code"].ToString()) ? string.Empty : dr["Code"].ToString();
                            customer.EMail = string.IsNullOrEmpty(dr["EMail"].ToString()) ? string.Empty : dr["EMail"].ToString();
                            customer.TCKN = string.IsNullOrEmpty(dr["TCKN"].ToString()) ? string.Empty : dr["TCKN"].ToString();
                            customer.Title = string.IsNullOrEmpty(dr["Title"].ToString()) ? string.Empty : dr["Title"].ToString();
                            customer.ActivityCertificateDate = dr["ActivityCertificateDate"] == DBNull.Value ? default(DateTime) : (DateTime)dr["ActivityCertificateDate"];

                            customer.IsActive = dr["IsActive"] == DBNull.Value ? false : (bool)dr["IsActive"];
                            customer.IsPerson = dr["IsPerson"] == DBNull.Value ? false : (bool)dr["IsPerson"];
                            customer.Consignee = dr["Consignee"] == DBNull.Value ? false : (bool)dr["Consignee"];
                            customer.Consignor = dr["Consignor"] == DBNull.Value ? false : (bool)dr["Consignor"];
                            customer.Filler = dr["Filler"] == DBNull.Value ? false : (bool)dr["Filler"];
                            customer.Loader = dr["Loader"] == DBNull.Value ? false : (bool)dr["Loader"];
                            customer.Packer = dr["Packer"] == DBNull.Value ? false : (bool)dr["Packer"];
                            customer.TankContainer = dr["TankContainer"] == DBNull.Value ? false : (bool)dr["TankContainer"];
                            customer.UnLoader = dr["UnLoader"] == DBNull.Value ? false : (bool)dr["UnLoader"];
                            customer.Carrier = dr["Carrier"] == DBNull.Value ? false : (bool)dr["Carrier"];


                            customer.Country = dr["Country"] == DBNull.Value ? null : ((List<Country>)new Country().GetObjectById(Guid.Parse(dr["Country"].ToString())).Data).FirstOrDefault();
                            customer.City = dr["City"] == DBNull.Value ? null : ((List<City>)new City().GetObjectById(Guid.Parse(dr["City"].ToString())).Data).FirstOrDefault();
                            customer.Consultant = dr["Consultant"] == DBNull.Value ? null : ((List<Employee>)new Employee().GetObjectById(Guid.Parse(dr["Consultant"].ToString())).Data).FirstOrDefault();
                            customer.County = dr["County"] == DBNull.Value ? null : ((List<County>)new County().GetObjectById(Guid.Parse(dr["County"].ToString())).Data).FirstOrDefault();
                            customer.Sector = dr["Sector"] == DBNull.Value ? null : ((List<Sector>)new Sector().GetObjectById(Guid.Parse(dr["Sector"].ToString())).Data).FirstOrDefault();

                            items.Add(customer);
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