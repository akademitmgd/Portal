using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace iyibir.TMGD.WebAPI.Models
{
    public partial class WastePhysicalState
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public DataResult GetObjectById(Guid Oid)
        {
            DataResult result = new DataResult();
            try
            {
                List<WastePhysicalState> items = new List<WastePhysicalState>();
                string commandString = string.Format("SELECT * FROM WastePhysicalState WHERE Oid = '{0}'", Oid);
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            WastePhysicalState state = new WastePhysicalState();
                            state.Oid = Guid.Parse(dr["Oid"].ToString());
                            state.Name = string.IsNullOrEmpty(dr["Name"].ToString()) ? string.Empty : dr["Name"].ToString();

                            items.Add(state);
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
                List<WastePhysicalState> items = new List<WastePhysicalState>();
                string commandString = string.Format("SELECT * FROM WastePhysicalState");
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            WastePhysicalState state = new WastePhysicalState();
                            state.Oid = Guid.Parse(dr["Oid"].ToString());
                            state.Name = string.IsNullOrEmpty(dr["Name"].ToString()) ? string.Empty : dr["Name"].ToString();

                            items.Add(state);
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