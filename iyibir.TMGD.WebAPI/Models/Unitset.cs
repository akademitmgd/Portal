using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace iyibir.TMGD.WebAPI.Models
{
    public partial class Unitset
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public DataResult GetObjectById(Guid Oid)
        {
            DataResult result = new DataResult();
            try
            {
                List<Unitset> items = new List<Unitset>();
                string commandString = string.Format("SELECT * FROM Unitset WHERE Oid = '{0}'", Oid);
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            Unitset unitset = new Unitset();
                            unitset.Oid = Guid.Parse(dr["Oid"].ToString());
                            unitset.Name = string.IsNullOrEmpty(dr["Name"].ToString()) ? string.Empty : dr["Name"].ToString();
                            unitset.Code = string.IsNullOrEmpty(dr["Code"].ToString()) ? string.Empty : dr["Code"].ToString();

                            items.Add(unitset);
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
                List<Unitset> items = new List<Unitset>();
                string commandString = string.Format("SELECT * FROM Unitset WHERE Code = '{0}'", code);
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            Unitset unitset = new Unitset();
                            unitset.Oid = Guid.Parse(dr["Oid"].ToString());
                            unitset.Name = string.IsNullOrEmpty(dr["Name"].ToString()) ? string.Empty : dr["Name"].ToString();
                            unitset.Code = string.IsNullOrEmpty(dr["Code"].ToString()) ? string.Empty : dr["Code"].ToString();

                            items.Add(unitset);
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
                List<Unitset> items = new List<Unitset>();
                string commandString = string.Format("SELECT * FROM Unitset");
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            Unitset unitset = new Unitset();
                            unitset.Oid = Guid.Parse(dr["Oid"].ToString());
                            unitset.Name = string.IsNullOrEmpty(dr["Name"].ToString()) ? string.Empty : dr["Name"].ToString();
                            unitset.Code = string.IsNullOrEmpty(dr["Code"].ToString()) ? string.Empty : dr["Code"].ToString();

                            items.Add(unitset);
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