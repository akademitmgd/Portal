using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace iyibir.TMGD.WebAPI.Models
{
    public partial class Employee
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public DataResult GetObjectById(Guid Oid)
        {
            DataResult result = new DataResult();
            try
            {
                List<Employee> items = new List<Employee>();
                string commandString = string.Format("SELECT * FROM Employee WHERE Oid = '{0}'", Oid);
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            Employee employee = new Employee();
                            employee.Oid = Guid.Parse(dr["Oid"].ToString());
                            employee.FirstName = string.IsNullOrEmpty(dr["FirstName"].ToString()) ? string.Empty : dr["FirstName"].ToString();
                            employee.LastName = string.IsNullOrEmpty(dr["LastName"].ToString()) ? string.Empty : dr["LastName"].ToString();
                            employee.Address = string.IsNullOrEmpty(dr["Address"].ToString()) ? string.Empty : dr["Address"].ToString();
                            employee.EMail = string.IsNullOrEmpty(dr["EMail"].ToString()) ? string.Empty : dr["EMail"].ToString();
                            employee.MiddleName = string.IsNullOrEmpty(dr["MiddleName"].ToString()) ? string.Empty : dr["MiddleName"].ToString();
                            employee.Telephone = string.IsNullOrEmpty(dr["Telephone"].ToString()) ? string.Empty : dr["Telephone"].ToString();
                            employee.Telephone2 = string.IsNullOrEmpty(dr["Telephone2"].ToString()) ? string.Empty : dr["Telephone2"].ToString();
                            employee.TmgdCertificate = string.IsNullOrEmpty(dr["TmgdCertificate"].ToString()) ? string.Empty : dr["TmgdCertificate"].ToString();
                            employee.WebAddress = string.IsNullOrEmpty(dr["WebAddress"].ToString()) ? string.Empty : dr["WebAddress"].ToString();
                            employee.IsActive = dr["IsActive"] == DBNull.Value ? false : (bool)dr["IsActive"];
                            employee.IsManager = dr["IsManager"] == DBNull.Value ? false : (bool)dr["IsManager"];
                            employee.EmployeeType = dr["EmployeeType"] == DBNull.Value ? default(int) : (int)dr["EmployeeType"];
                            employee.Department = dr["Department"] == DBNull.Value ? null : ((List<Department>)new Department().GetObjectById(Guid.Parse(dr["Department"].ToString())).Data).FirstOrDefault();
                            employee.Position = dr["Position"] == DBNull.Value ? null : ((List<Position>)new Position().GetObjectById(Guid.Parse(dr["Position"].ToString())).Data).FirstOrDefault();
                            employee.Customer = dr["Customer"] == DBNull.Value ? null : ((List<Customer>)new Customer().GetObjectById(Guid.Parse(dr["Customer"].ToString())).Data).FirstOrDefault();

                            items.Add(employee);
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
                List<Employee> items = new List<Employee>();
                string commandString = string.Format("SELECT * FROM Employee");
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            Employee employee = new Employee();
                            employee.Oid = Guid.Parse(dr["Oid"].ToString());
                            employee.FirstName = string.IsNullOrEmpty(dr["FirstName"].ToString()) ? string.Empty : dr["FirstName"].ToString();
                            employee.LastName = string.IsNullOrEmpty(dr["LastName"].ToString()) ? string.Empty : dr["LastName"].ToString();
                            employee.Address = string.IsNullOrEmpty(dr["Address"].ToString()) ? string.Empty : dr["Address"].ToString();
                            employee.EMail = string.IsNullOrEmpty(dr["EMail"].ToString()) ? string.Empty : dr["EMail"].ToString();
                            employee.MiddleName = string.IsNullOrEmpty(dr["MiddleName"].ToString()) ? string.Empty : dr["MiddleName"].ToString();
                            employee.Telephone = string.IsNullOrEmpty(dr["Telephone"].ToString()) ? string.Empty : dr["Telephone"].ToString();
                            employee.Telephone2 = string.IsNullOrEmpty(dr["Telephone2"].ToString()) ? string.Empty : dr["Telephone2"].ToString();
                            employee.WebAddress = string.IsNullOrEmpty(dr["WebAddress"].ToString()) ? string.Empty : dr["WebAddress"].ToString();
                            employee.IsActive = dr["IsActive"] == DBNull.Value ? false : (bool)dr["IsActive"];
                            employee.IsManager = dr["IsManager"] == DBNull.Value ? false : (bool)dr["IsManager"];
                            employee.EmployeeType = dr["EmployeeType"] == DBNull.Value ? default(int) : (int)dr["EmployeeType"];
                            employee.Department = dr["Department"] == DBNull.Value ? null : ((List<Department>)new Department().GetObjectById(Guid.Parse(dr["Department"].ToString())).Data).FirstOrDefault();
                            employee.Position = dr["Position"] == DBNull.Value ? null : ((List<Position>)new Position().GetObjectById(Guid.Parse(dr["Position"].ToString())).Data).FirstOrDefault();
                            employee.Customer = dr["Customer"] == DBNull.Value ? null : ((List<Customer>)new Customer().GetObjectById(Guid.Parse(dr["Customer"].ToString())).Data).FirstOrDefault();
                            employee.TmgdCertificate = string.IsNullOrEmpty(dr["TmgdCertificate"].ToString()) ? string.Empty : dr["TmgdCertificate"].ToString();

                            items.Add(employee);
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