using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace iyibir.TMGD.WebAPIV2.Models
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
        public DataResult InsertObject(Consignee consignee)
        {
            DataResult result = new DataResult();

            try
            {
                if (consignee != null)
                {
                    string commandString = string.Format(@"
                    INSERT INTO Consignee
                        (Oid, 
                        Customer, 
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
                        ConsigneeType,
                        Country)
                    VALUES
                        (@Oid, 
                        @Customer, 
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
                        @ConsigneeType,
                        @Country)");

                    using (SqlConnection cnn = new SqlConnection(connectionString))
                    {
                        cnn.Open();
                        using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                        {
                            cmd.Parameters.AddWithValue("Oid", consignee.Oid);
                            cmd.Parameters.AddWithValue("Code", consignee.Code);
                            cmd.Parameters.AddWithValue("Title", consignee.Title);
                            cmd.Parameters.AddWithValue("Telephone", consignee.Telephone);
                            cmd.Parameters.AddWithValue("TCKN", consignee.TCKN);
                            cmd.Parameters.AddWithValue("TaxOffice", consignee.TaxOffice);
                            cmd.Parameters.AddWithValue("TaxNumber", consignee.TaxNumber);
                            cmd.Parameters.AddWithValue("OtherTelephone", consignee.OtherTelephone);
                            cmd.Parameters.AddWithValue("LastName", consignee.LastName);
                            cmd.Parameters.AddWithValue("FirstName", consignee.FirstName);
                            cmd.Parameters.AddWithValue("EMail", consignee.EMail);
                            cmd.Parameters.AddWithValue("ConsigneeType", consignee.ConsigneeType);
                            cmd.Parameters.AddWithValue("Address", consignee.Address);
                            cmd.Parameters.AddWithValue("IsActive", consignee.IsActive);
                            cmd.Parameters.AddWithValue("IsPerson", consignee.IsPerson);
                            cmd.Parameters.AddWithValue("Country", Guid.Parse("5B0F82CB-EB2C-4EFD-9C0B-BF6A1338B84F"));

                            #region AddCustomer
                            if (consignee.Customer != null)
                            {
                                cmd.Parameters.AddWithValue("Customer", consignee.Customer.Oid);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("Customer", DBNull.Value);
                            }
                            #endregion

                            cmd.ExecuteNonQuery();
                            cnn.Close();

                            result.Data = consignee.Oid;
                            result.Result = true;
                            result.Message = "Success";
                        }
                    }
                }
                else
                {
                    result.Data = "Parametre gönderilmelidir.";
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