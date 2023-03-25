using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace iyibir.TMGD.WebAPIV2.Models
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
                            customer.Address = string.IsNullOrEmpty(dr["Address"].ToString()) ? string.Empty : dr["Address"].ToString();
                            customer.Code = string.IsNullOrEmpty(dr["Code"].ToString()) ? string.Empty : dr["Code"].ToString();
                            customer.EMail = string.IsNullOrEmpty(dr["EMail"].ToString()) ? string.Empty : dr["EMail"].ToString();
                            customer.TCKN = string.IsNullOrEmpty(dr["TCKN"].ToString()) ? string.Empty : dr["TCKN"].ToString();
                            customer.Title = string.IsNullOrEmpty(dr["Title"].ToString()) ? string.Empty : dr["Title"].ToString();
                            customer.UETDSPassword = string.IsNullOrEmpty(dr["UETDSPassword"].ToString()) ? string.Empty : dr["UETDSPassword"].ToString();
                            customer.UETDSUsername = string.IsNullOrEmpty(dr["UETDSUsername"].ToString()) ? string.Empty : dr["UETDSUsername"].ToString();
                            customer.Consultant = dr["Consultant"] == DBNull.Value ? null : ((List<Employee>)new Employee().GetObjectById(Guid.Parse(dr["Consultant"].ToString())).Data).FirstOrDefault();

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
                            customer.Address = string.IsNullOrEmpty(dr["Address"].ToString()) ? string.Empty : dr["Address"].ToString();
                            customer.Code = string.IsNullOrEmpty(dr["Code"].ToString()) ? string.Empty : dr["Code"].ToString();
                            customer.EMail = string.IsNullOrEmpty(dr["EMail"].ToString()) ? string.Empty : dr["EMail"].ToString();
                            customer.TCKN = string.IsNullOrEmpty(dr["TCKN"].ToString()) ? string.Empty : dr["TCKN"].ToString();
                            customer.Title = string.IsNullOrEmpty(dr["Title"].ToString()) ? string.Empty : dr["Title"].ToString();
                            customer.UETDSPassword = string.IsNullOrEmpty(dr["UETDSPassword"].ToString()) ? string.Empty : dr["UETDSPassword"].ToString();
                            customer.UETDSUsername = string.IsNullOrEmpty(dr["UETDSUsername"].ToString()) ? string.Empty : dr["UETDSUsername"].ToString();
                            customer.Consultant = dr["Consultant"] == DBNull.Value ? null : ((List<Employee>)new Employee().GetObjectById(Guid.Parse(dr["Consultant"].ToString())).Data).FirstOrDefault();

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
                            customer.Address = string.IsNullOrEmpty(dr["Address"].ToString()) ? string.Empty : dr["Address"].ToString();
                            customer.Code = string.IsNullOrEmpty(dr["Code"].ToString()) ? string.Empty : dr["Code"].ToString();
                            customer.EMail = string.IsNullOrEmpty(dr["EMail"].ToString()) ? string.Empty : dr["EMail"].ToString();
                            customer.TCKN = string.IsNullOrEmpty(dr["TCKN"].ToString()) ? string.Empty : dr["TCKN"].ToString();
                            customer.Title = string.IsNullOrEmpty(dr["Title"].ToString()) ? string.Empty : dr["Title"].ToString();
                            customer.UETDSPassword = string.IsNullOrEmpty(dr["UETDSPassword"].ToString()) ? string.Empty : dr["UETDSPassword"].ToString();
                            customer.UETDSUsername = string.IsNullOrEmpty(dr["UETDSUsername"].ToString()) ? string.Empty : dr["UETDSUsername"].ToString();
                            customer.Consultant = dr["Consultant"] == DBNull.Value ? null : ((List<Employee>)new Employee().GetObjectById(Guid.Parse(dr["Consultant"].ToString())).Data).FirstOrDefault();

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
        public DataResult InsertObject(Customer customer)
        {
            DataResult result = new DataResult();

            try
            {
                if (customer != null)
                {
                    string commandString = string.Format(@"
                            INSERT INTO Customer
                            (Oid, 
                            Code, 
                            Title, 
                            Telephone, 
                            OtherTelephone, 
                            EMail, 
                            Address, 
                            IsActive, 
                            IsPerson, 
                            TCKN, 
                            FirstName, 
                            LastName, 
                            TaxOffice, 
                            TaxNumber, 
                            UETDSUsername, 
                            UETDSPassword)
                    VALUES(@Oid, 
                            @Code, 
                            @Title, 
                            @Telephone, 
                            @OtherTelephone, 
                            @EMail, 
                            @Address, 
                            @IsActive, 
                            @IsPerson, 
                            @TCKN, 
                            @FirstName, 
                            @LastName, 
                            @TaxOffice, 
                            @TaxNumber, 
                            @UETDSUsername, 
                            @UETDSPassword); SELECT SCOPE_IDENTITY();");

                    using (SqlConnection cnn = new SqlConnection(connectionString))
                    {
                        cnn.Open();
                        using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                        {
                            cmd.Parameters.AddWithValue("Oid", customer.Oid);
                            cmd.Parameters.AddWithValue("Code", customer.Code ?? string.Empty);
                            cmd.Parameters.AddWithValue("Title", customer.Title ?? string.Empty);
                            cmd.Parameters.AddWithValue("Telephone", customer.Telephone ?? string.Empty);
                            cmd.Parameters.AddWithValue("OtherTelephone", customer.OtherTelephone ?? string.Empty);
                            cmd.Parameters.AddWithValue("EMail", customer.EMail ?? string.Empty);
                            cmd.Parameters.AddWithValue("Address", customer.Address ?? string.Empty);
                            cmd.Parameters.AddWithValue("IsActive", customer.IsActive);
                            cmd.Parameters.AddWithValue("IsPerson", customer.IsPerson);
                            cmd.Parameters.AddWithValue("TCKN", customer.TCKN ?? string.Empty);
                            cmd.Parameters.AddWithValue("FirstName", customer.FirstName ?? string.Empty);
                            cmd.Parameters.AddWithValue("LastName", customer.LastName ?? string.Empty);
                            cmd.Parameters.AddWithValue("TaxOffice", customer.TaxOffice ?? string.Empty);
                            cmd.Parameters.AddWithValue("TaxNumber", customer.TaxNumber ?? string.Empty);
                            cmd.Parameters.AddWithValue("UETDSUsername", customer.UETDSUsername ?? string.Empty);
                            cmd.Parameters.AddWithValue("UETDSPassword", customer.UETDSPassword ?? string.Empty);

                            cmd.ExecuteNonQuery();
                            cnn.Close();

                            result.Data = customer.Oid;
                            result.Result = true;
                            result.Message = "Success";
                        }
                    }
                }
                else
                {
                    result.Data = "Parametre boş geçilemez.";
                    result.Result = false;
                    result.Message = "Error";
                }
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