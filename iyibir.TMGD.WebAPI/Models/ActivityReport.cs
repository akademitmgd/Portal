using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace iyibir.TMGD.WebAPI.Models
{
    public partial class ActivityReport
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public DataResult GetObjectById(Guid Oid)
        {
            DataResult result = new DataResult();
            try
            {
                List<ActivityReport> items = new List<ActivityReport>();
                string commandString = string.Format("SELECT * FROM ActivityReport WHERE Oid = '{0}'", Oid);
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            ActivityReport activityReport = new ActivityReport();
                            activityReport.Oid = Guid.Parse(dr["Oid"].ToString());
                            activityReport.Description = string.IsNullOrEmpty(dr["Description"].ToString()) ? string.Empty : dr["Description"].ToString();
                            activityReport.Colsultant = dr["Colsultant"] == DBNull.Value ? null : ((List<Employee>)new Employee().GetObjectById(Guid.Parse(dr["Colsultant"].ToString())).Data).FirstOrDefault();
                            activityReport.Customer = dr["Customer"] == DBNull.Value ? null : ((List<Customer>)new Customer().GetObjectById(Guid.Parse(dr["Customer"].ToString())).Data).FirstOrDefault();
                            activityReport.Code = string.IsNullOrEmpty(dr["Code"].ToString()) ? string.Empty : dr["Code"].ToString();
                            activityReport.CreatedOn = dr["CreatedOn"] == DBNull.Value ? default(DateTime) : (DateTime)dr["CreatedOn"];

                            items.Add(activityReport);
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
                List<ActivityReport> items = new List<ActivityReport>();
                string commandString = string.Format("SELECT * FROM ActivityReport");
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            ActivityReport activityReport = new ActivityReport();
                            activityReport.Oid = Guid.Parse(dr["Oid"].ToString());
                            activityReport.Description = string.IsNullOrEmpty(dr["Description"].ToString()) ? string.Empty : dr["Description"].ToString();
                            activityReport.Colsultant = dr["Colsultant"] == DBNull.Value ? null : ((List<Employee>)new Employee().GetObjectById(Guid.Parse(dr["Colsultant"].ToString())).Data).FirstOrDefault();
                            activityReport.Customer = dr["Customer"] == DBNull.Value ? null : ((List<Customer>)new Customer().GetObjectById(Guid.Parse(dr["Customer"].ToString())).Data).FirstOrDefault();
                            activityReport.Code = string.IsNullOrEmpty(dr["Code"].ToString()) ? string.Empty : dr["Code"].ToString();
                            activityReport.CreatedOn = dr["CreatedOn"] == DBNull.Value ? default(DateTime) : (DateTime)dr["CreatedOn"];

                            items.Add(activityReport);
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

        public DataResult InsertObject(ActivityReport activityReport)
        {
            DataResult result = new DataResult();

            try
            {
                if (activityReport != null)
                {
                    string commandString = string.Format(@"INSERT INTO ActivityReport
                            (
                            Oid, 
                            Code, 
                            Colsultant, 
                            CreatedOn, 
                            Customer, 
                            Description
                            )
                            VALUES
                            (
                            @Oid, 
                            @Code, 
                            @Colsultant, 
                            @CreatedOn, 
                            @Customer, 
                            @Description
                            ); SELECT SCOPE_IDENTITY();");

                    using (SqlConnection cnn = new SqlConnection(connectionString))
                    {
                        cnn.Open();
                        using (SqlCommand cmd = new SqlCommand(commandString,cnn))
                        {
                            cmd.Parameters.AddWithValue("Code", activityReport.Code);
                            cmd.Parameters.AddWithValue("CreatedOn", activityReport.CreatedOn ?? default(DateTime));
                            cmd.Parameters.AddWithValue("Description", activityReport.Description);
                            cmd.Parameters.AddWithValue("Oid", activityReport.Oid);

                            #region AddColsultant
                            if (activityReport.Colsultant != null)
                            {
                                cmd.Parameters.AddWithValue("Colsultant", activityReport.Colsultant.Oid);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("Colsultant", DBNull.Value);
                            }
                            #endregion

                            #region AddCustomer
                            if (activityReport.Customer != null)
                            {
                                cmd.Parameters.AddWithValue("Customer", activityReport.Customer.Oid);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("Customer", DBNull.Value);
                            }
                            #endregion

                            var oid = cmd.ExecuteScalar();
                            cnn.Close();

                            result.Data = activityReport.Oid;
                            result.Message = "Success";
                            result.Result = true;
                        }
                    }
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