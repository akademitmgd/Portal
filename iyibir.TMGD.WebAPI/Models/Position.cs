using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace iyibir.TMGD.WebAPI.Models
{
    public partial class Position
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public DataResult GetObjectById(Guid Oid)
        {
            DataResult result = new DataResult();
            try
            {
                List<Position> items = new List<Position>();
                string commandString = string.Format("SELECT * FROM Position WHERE Oid = '{0}'", Oid);
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            Position position = new Position();
                            position.Oid = Guid.Parse(dr["Oid"].ToString());
                            position.Name = string.IsNullOrEmpty(dr["Name"].ToString()) ? string.Empty : dr["Name"].ToString();
                            position.Code = string.IsNullOrEmpty(dr["Code"].ToString()) ? string.Empty : dr["Code"].ToString();
                            position.Description = string.IsNullOrEmpty(dr["Description"].ToString()) ? string.Empty : dr["Description"].ToString();
                            position.Department = dr["Department"] == DBNull.Value ? null : ((List<Department>)new Department().GetObjectById(Guid.Parse(dr["Department"].ToString())).Data).FirstOrDefault();

                            items.Add(position);
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
                List<Position> items = new List<Position>();
                string commandString = string.Format("SELECT * FROM Position");
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            Position position = new Position();
                            position.Oid = Guid.Parse(dr["Oid"].ToString());
                            position.Name = string.IsNullOrEmpty(dr["Name"].ToString()) ? string.Empty : dr["Name"].ToString();
                            position.Code = string.IsNullOrEmpty(dr["Code"].ToString()) ? string.Empty : dr["Code"].ToString();
                            position.Description = string.IsNullOrEmpty(dr["Description"].ToString()) ? string.Empty : dr["Description"].ToString();
                            position.Department = dr["Department"] == DBNull.Value ? null : ((List<Department>)new Department().GetObjectById(Guid.Parse(dr["Department"].ToString())).Data).FirstOrDefault();

                            items.Add(position);
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