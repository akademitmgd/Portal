using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace iyibir.TMGD.WebAPI.Models
{
    public partial class Vehicle
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public DataResult GetObjectById(Guid Oid)
        {
            DataResult result = new DataResult();
            try
            {
                List<Vehicle> items = new List<Vehicle>();
                string commandString = string.Format("SELECT * FROM Vehicle WHERE Oid = '{0}'", Oid);
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            Vehicle vehicle = new Vehicle();
                            vehicle.Oid = Guid.Parse(dr["Oid"].ToString());
                            vehicle.Name = string.IsNullOrEmpty(dr["Name"].ToString()) ? string.Empty : dr["Name"].ToString();
                            vehicle.Code = string.IsNullOrEmpty(dr["Code"].ToString()) ? string.Empty : dr["Code"].ToString();
                            vehicle.Plate = string.IsNullOrEmpty(dr["Plate"].ToString()) ? string.Empty : dr["Plate"].ToString();
                            vehicle.AdrInspectionDate = dr["AdrInspectionDate"] == DBNull.Value ? default(DateTime) : (DateTime)dr["AdrInspectionDate"];
                            vehicle.AdrInspectionSixYearly = dr["AdrInspectionSixYearly"] == DBNull.Value ? default(DateTime) : (DateTime)dr["AdrInspectionSixYearly"];
                            vehicle.AdrInspectionThreeYearly = dr["AdrInspectionThreeYearly"] == DBNull.Value ? default(DateTime) : (DateTime)dr["AdrInspectionThreeYearly"];
                            vehicle.ExhaustInspectionDate = dr["ExhaustInspectionDate"] == DBNull.Value ? default(DateTime) : (DateTime)dr["ExhaustInspectionDate"];
                            vehicle.InsurancePolicy = dr["InsurancePolicy"] == DBNull.Value ? default(DateTime) : (DateTime)dr["InsurancePolicy"];
                            vehicle.TmgdInsurancePolicy = dr["TmgdInsurancePolicy"] == DBNull.Value ? default(DateTime) : (DateTime)dr["TmgdInsurancePolicy"];
                            vehicle.TuvTurkInpectionDate = dr["TuvTurkInpectionDate"] == DBNull.Value ? default(DateTime) : (DateTime)dr["TuvTurkInpectionDate"];
                            vehicle.MaxWeight = dr["MaxWeight"] == DBNull.Value ? default(double) : (double)dr["MaxWeight"];
                            vehicle.Customer = dr["Customer"] == DBNull.Value ? null : ((List<Customer>)new Customer().GetObjectById(Guid.Parse(dr["Customer"].ToString())).Data).FirstOrDefault();

                            items.Add(vehicle);
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
                List<Vehicle> items = new List<Vehicle>();
                string commandString = string.Format("SELECT * FROM Vehicle WHERE Code = '{0}'", code);
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            Vehicle vehicle = new Vehicle();
                            vehicle.Oid = Guid.Parse(dr["Oid"].ToString());
                            vehicle.Name = string.IsNullOrEmpty(dr["Name"].ToString()) ? string.Empty : dr["Name"].ToString();
                            vehicle.Code = string.IsNullOrEmpty(dr["Code"].ToString()) ? string.Empty : dr["Code"].ToString();
                            vehicle.Plate = string.IsNullOrEmpty(dr["Plate"].ToString()) ? string.Empty : dr["Plate"].ToString();
                            vehicle.AdrInspectionDate = dr["AdrInspectionDate"] == DBNull.Value ? default(DateTime) : (DateTime)dr["AdrInspectionDate"];
                            vehicle.AdrInspectionSixYearly = dr["AdrInspectionSixYearly"] == DBNull.Value ? default(DateTime) : (DateTime)dr["AdrInspectionSixYearly"];
                            vehicle.AdrInspectionThreeYearly = dr["AdrInspectionThreeYearly"] == DBNull.Value ? default(DateTime) : (DateTime)dr["AdrInspectionThreeYearly"];
                            vehicle.ExhaustInspectionDate = dr["ExhaustInspectionDate"] == DBNull.Value ? default(DateTime) : (DateTime)dr["ExhaustInspectionDate"];
                            vehicle.InsurancePolicy = dr["InsurancePolicy"] == DBNull.Value ? default(DateTime) : (DateTime)dr["InsurancePolicy"];
                            vehicle.TmgdInsurancePolicy = dr["TmgdInsurancePolicy"] == DBNull.Value ? default(DateTime) : (DateTime)dr["TmgdInsurancePolicy"];
                            vehicle.TuvTurkInpectionDate = dr["TuvTurkInpectionDate"] == DBNull.Value ? default(DateTime) : (DateTime)dr["TuvTurkInpectionDate"];
                            vehicle.MaxWeight = dr["MaxWeight"] == DBNull.Value ? default(double) : (double)dr["MaxWeight"];
                            vehicle.Customer = dr["Customer"] == DBNull.Value ? null : ((List<Customer>)new Customer().GetObjectById(Guid.Parse(dr["Customer"].ToString())).Data).FirstOrDefault();

                            items.Add(vehicle);
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

        public DataResult GetObjectByCustomerAndVehicleCode(string customerCode,string vehicleCode)
        {
            DataResult result = new DataResult();
            try
            {
                List<Vehicle> items = new List<Vehicle>();
                string commandString = string.Format("SELECT * FROM Vehicle WHERE Code = '{0}' AND Customer = '{1}'", vehicleCode, ((List<Customer>)new Customer().GetObjectByCode(customerCode).Data).FirstOrDefault().Oid);
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            Vehicle vehicle = new Vehicle();
                            vehicle.Oid = Guid.Parse(dr["Oid"].ToString());
                            vehicle.Name = string.IsNullOrEmpty(dr["Name"].ToString()) ? string.Empty : dr["Name"].ToString();
                            vehicle.Code = string.IsNullOrEmpty(dr["Code"].ToString()) ? string.Empty : dr["Code"].ToString();
                            vehicle.Plate = string.IsNullOrEmpty(dr["Plate"].ToString()) ? string.Empty : dr["Plate"].ToString();
                            vehicle.AdrInspectionDate = dr["AdrInspectionDate"] == DBNull.Value ? default(DateTime) : (DateTime)dr["AdrInspectionDate"];
                            vehicle.AdrInspectionSixYearly = dr["AdrInspectionSixYearly"] == DBNull.Value ? default(DateTime) : (DateTime)dr["AdrInspectionSixYearly"];
                            vehicle.AdrInspectionThreeYearly = dr["AdrInspectionThreeYearly"] == DBNull.Value ? default(DateTime) : (DateTime)dr["AdrInspectionThreeYearly"];
                            vehicle.ExhaustInspectionDate = dr["ExhaustInspectionDate"] == DBNull.Value ? default(DateTime) : (DateTime)dr["ExhaustInspectionDate"];
                            vehicle.InsurancePolicy = dr["InsurancePolicy"] == DBNull.Value ? default(DateTime) : (DateTime)dr["InsurancePolicy"];
                            vehicle.TmgdInsurancePolicy = dr["TmgdInsurancePolicy"] == DBNull.Value ? default(DateTime) : (DateTime)dr["TmgdInsurancePolicy"];
                            vehicle.TuvTurkInpectionDate = dr["TuvTurkInpectionDate"] == DBNull.Value ? default(DateTime) : (DateTime)dr["TuvTurkInpectionDate"];
                            vehicle.MaxWeight = dr["MaxWeight"] == DBNull.Value ? default(double) : (double)dr["MaxWeight"];
                            vehicle.Customer = dr["Customer"] == DBNull.Value ? null : ((List<Customer>)new Customer().GetObjectById(Guid.Parse(dr["Customer"].ToString())).Data).FirstOrDefault();

                            items.Add(vehicle);
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
                List<Vehicle> items = new List<Vehicle>();
                string commandString = string.Format("SELECT * FROM Vehicle");
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            Vehicle vehicle = new Vehicle();
                            vehicle.Oid = Guid.Parse(dr["Oid"].ToString());
                            vehicle.Name = string.IsNullOrEmpty(dr["Name"].ToString()) ? string.Empty : dr["Name"].ToString();
                            vehicle.Code = string.IsNullOrEmpty(dr["Code"].ToString()) ? string.Empty : dr["Code"].ToString();
                            vehicle.Plate = string.IsNullOrEmpty(dr["Plate"].ToString()) ? string.Empty : dr["Plate"].ToString();
                            vehicle.AdrInspectionDate = dr["AdrInspectionDate"] == DBNull.Value ? default(DateTime) : (DateTime)dr["AdrInspectionDate"];
                            vehicle.AdrInspectionSixYearly = dr["AdrInspectionSixYearly"] == DBNull.Value ? default(DateTime) : (DateTime)dr["AdrInspectionSixYearly"];
                            vehicle.AdrInspectionThreeYearly = dr["AdrInspectionThreeYearly"] == DBNull.Value ? default(DateTime) : (DateTime)dr["AdrInspectionThreeYearly"];
                            vehicle.ExhaustInspectionDate = dr["ExhaustInspectionDate"] == DBNull.Value ? default(DateTime) : (DateTime)dr["ExhaustInspectionDate"];
                            vehicle.InsurancePolicy = dr["InsurancePolicy"] == DBNull.Value ? default(DateTime) : (DateTime)dr["InsurancePolicy"];
                            vehicle.TmgdInsurancePolicy = dr["TmgdInsurancePolicy"] == DBNull.Value ? default(DateTime) : (DateTime)dr["TmgdInsurancePolicy"];
                            vehicle.TuvTurkInpectionDate = dr["TuvTurkInpectionDate"] == DBNull.Value ? default(DateTime) : (DateTime)dr["TuvTurkInpectionDate"];
                            vehicle.MaxWeight = dr["MaxWeight"] == DBNull.Value ? default(double) : (double)dr["MaxWeight"];
                            vehicle.Customer = dr["Customer"] == DBNull.Value ? null : ((List<Customer>)new Customer().GetObjectById(Guid.Parse(dr["Customer"].ToString())).Data).FirstOrDefault();

                            items.Add(vehicle);
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