using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace iyibir.TMGD.WebAPI.Models
{
    public partial class VehicleDriver
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public DataResult GetObjectById(Guid Oid)
        {
            DataResult result = new DataResult();
            try
            {
                List<VehicleDriver> items = new List<VehicleDriver>();
                string commandString = string.Format("SELECT * FROM VehicleDriver WHERE Oid = '{0}'", Oid);
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            VehicleDriver vehicleDriver = new VehicleDriver();
                            vehicleDriver.Oid = Guid.Parse(dr["Oid"].ToString());
                            vehicleDriver.FirstName = string.IsNullOrEmpty(dr["FirstName"].ToString()) ? string.Empty : dr["FirstName"].ToString();
                            vehicleDriver.LastName = string.IsNullOrEmpty(dr["LastName"].ToString()) ? string.Empty : dr["LastName"].ToString();
                            vehicleDriver.Src5DocumentNo = string.IsNullOrEmpty(dr["Src5DocumentNo"].ToString()) ? string.Empty : dr["Src5DocumentNo"].ToString();
                            vehicleDriver.SrcDateOfValidity = dr["SrcDateOfValidity"] == DBNull.Value ? default(DateTime) : (DateTime)dr["SrcDateOfValidity"];
                            vehicleDriver.PsychotechnicalExamination = dr["PsychotechnicalExamination"] == DBNull.Value ? default(DateTime) : (DateTime)dr["PsychotechnicalExamination"];
                            vehicleDriver.Customer = dr["Customer"] == DBNull.Value ? null : ((List<Customer>)new Customer().GetObjectById(Guid.Parse(dr["Customer"].ToString())).Data).FirstOrDefault();

                            items.Add(vehicleDriver);
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
                List<VehicleDriver> items = new List<VehicleDriver>();
                string commandString = string.Format("SELECT * FROM VehicleDriver");
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            VehicleDriver vehicleDriver = new VehicleDriver();
                            vehicleDriver.Oid = Guid.Parse(dr["Oid"].ToString());
                            vehicleDriver.FirstName = string.IsNullOrEmpty(dr["FirstName"].ToString()) ? string.Empty : dr["FirstName"].ToString();
                            vehicleDriver.LastName = string.IsNullOrEmpty(dr["LastName"].ToString()) ? string.Empty : dr["LastName"].ToString();
                            vehicleDriver.Src5DocumentNo = string.IsNullOrEmpty(dr["Src5DocumentNo"].ToString()) ? string.Empty : dr["Src5DocumentNo"].ToString();
                            vehicleDriver.SrcDateOfValidity = dr["SrcDateOfValidity"] == DBNull.Value ? default(DateTime) : (DateTime)dr["SrcDateOfValidity"];
                            vehicleDriver.PsychotechnicalExamination = dr["PsychotechnicalExamination"] == DBNull.Value ? default(DateTime) : (DateTime)dr["PsychotechnicalExamination"];
                            vehicleDriver.Customer = dr["Customer"] == DBNull.Value ? null : ((List<Customer>)new Customer().GetObjectById(Guid.Parse(dr["Customer"].ToString())).Data).FirstOrDefault();

                            items.Add(vehicleDriver);
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

        public DataResult GetObjectByCustomerCodeWithDriverFirstAndLastName(string customerCode, string firstName,string lastName)
        {
            DataResult result = new DataResult();

            try
            {
                List<VehicleDriver> items = new List<VehicleDriver>();
                string commandString = string.Format("SELECT * FROM VehicleDriver WHERE Customer = '{0}' AND FirstName = '{1}' AND LastName = '{2}'", ((List<Customer>)new Customer().GetObjectByCode(customerCode).Data).FirstOrDefault().Oid, firstName, lastName);
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            VehicleDriver vehicleDriver = new VehicleDriver();
                            vehicleDriver.Oid = Guid.Parse(dr["Oid"].ToString());
                            vehicleDriver.FirstName = string.IsNullOrEmpty(dr["FirstName"].ToString()) ? string.Empty : dr["FirstName"].ToString();
                            vehicleDriver.LastName = string.IsNullOrEmpty(dr["LastName"].ToString()) ? string.Empty : dr["LastName"].ToString();
                            vehicleDriver.Src5DocumentNo = string.IsNullOrEmpty(dr["Src5DocumentNo"].ToString()) ? string.Empty : dr["Src5DocumentNo"].ToString();
                            vehicleDriver.SrcDateOfValidity = dr["SrcDateOfValidity"] == DBNull.Value ? default(DateTime) : (DateTime)dr["SrcDateOfValidity"];
                            vehicleDriver.PsychotechnicalExamination = dr["PsychotechnicalExamination"] == DBNull.Value ? default(DateTime) : (DateTime)dr["PsychotechnicalExamination"];
                            vehicleDriver.Customer = dr["Customer"] == DBNull.Value ? null : ((List<Customer>)new Customer().GetObjectById(Guid.Parse(dr["Customer"].ToString())).Data).FirstOrDefault();

                            items.Add(vehicleDriver);
                        }
                    }
                }

                result.Result = true;
                result.Data = items;
                result.Message = "Success";

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