using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace iyibir.TMGD.WebAPI.Models
{
    public partial class WasteList
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public DataResult GetObjectById(Guid Oid)
        {
            DataResult result = new DataResult();
            try
            {
                List<WasteList> items = new List<WasteList>();
                string commandString = string.Format("SELECT * FROM WasteList WHERE Oid = '{0}'", Oid);
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            WasteList wasteList = new WasteList();
                            wasteList.Oid = Guid.Parse(dr["Oid"].ToString());
                            wasteList.Name = string.IsNullOrEmpty(dr["Name"].ToString()) ? string.Empty : dr["Name"].ToString();
                            wasteList.Code = string.IsNullOrEmpty(dr["Code"].ToString()) ? string.Empty : dr["Code"].ToString();
                            wasteList.WasteListType = dr["WasteType"] == DBNull.Value ? default(int) : (int)dr["WasteType"];

                            items.Add(wasteList);
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
                List<WasteList> items = new List<WasteList>();
                string commandString = string.Format("SELECT * FROM WasteList WHERE Code = '{0}'", code);
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            WasteList wasteList = new WasteList();
                            wasteList.Oid = Guid.Parse(dr["Oid"].ToString());
                            wasteList.Name = string.IsNullOrEmpty(dr["Name"].ToString()) ? string.Empty : dr["Name"].ToString();
                            wasteList.Code = string.IsNullOrEmpty(dr["Code"].ToString()) ? string.Empty : dr["Code"].ToString();
                            wasteList.WasteListType = dr["WasteType"] == DBNull.Value ? default(int) : (int)dr["WasteType"];

                            items.Add(wasteList);
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
                List<WasteList> items = new List<WasteList>();
                string commandString = string.Format("SELECT * FROM WasteList", Oid);
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            WasteList wasteList = new WasteList();
                            wasteList.Oid = Guid.Parse(dr["Oid"].ToString());
                            wasteList.Name = string.IsNullOrEmpty(dr["Name"].ToString()) ? string.Empty : dr["Name"].ToString();
                            wasteList.Code = string.IsNullOrEmpty(dr["Code"].ToString()) ? string.Empty : dr["Code"].ToString();
                            wasteList.WasteListType = dr["WasteType"] == DBNull.Value ? default(int) : (int)dr["WasteType"];

                            items.Add(wasteList);
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