using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace iyibir.TMGD.WebAPIV2.Models
{
    public partial class Department
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public DataResult GetObjectById(Guid Oid)
        {
            DataResult result = new DataResult();
            try
            {
                List<Department> items = new List<Department>();
                string commandString = string.Format("SELECT * FROM Department WHERE Oid = '{0}'", Oid);
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            Department department = new Department();
                            department.Oid = Guid.Parse(dr["Oid"].ToString());
                            department.Name = string.IsNullOrEmpty(dr["Name"].ToString()) ? string.Empty : dr["Name"].ToString();
                            department.Code = string.IsNullOrEmpty(dr["Code"].ToString()) ? string.Empty : dr["Code"].ToString();
                            department.Description = string.IsNullOrEmpty(dr["Description"].ToString()) ? string.Empty : dr["Description"].ToString();
                            department.Manager = dr["Manager"] == DBNull.Value ? null : ((List<Employee>)new Employee().GetObjectById(Guid.Parse(dr["Manager"].ToString())).Data).FirstOrDefault();
                            department.IsManager = dr["IsManager"] == DBNull.Value ? false : (bool)dr["IsManager"];

                            items.Add(department);
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
                List<Department> items = new List<Department>();
                string commandString = string.Format("SELECT * FROM Department");
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            Department department = new Department();
                            department.Oid = Guid.Parse(dr["Oid"].ToString());
                            department.Name = string.IsNullOrEmpty(dr["Name"].ToString()) ? string.Empty : dr["Name"].ToString();
                            department.Code = string.IsNullOrEmpty(dr["Code"].ToString()) ? string.Empty : dr["Code"].ToString();
                            department.Description = string.IsNullOrEmpty(dr["Description"].ToString()) ? string.Empty : dr["Description"].ToString();
                            department.Manager = dr["Manager"] == DBNull.Value ? null : ((List<Employee>)new Employee().GetObjectById(Guid.Parse(dr["Manager"].ToString())).Data).FirstOrDefault();
                            department.IsManager = dr["IsManager"] == DBNull.Value ? false : (bool)dr["IsManager"];

                            items.Add(department);
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