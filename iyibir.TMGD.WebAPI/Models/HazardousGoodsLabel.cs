using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace iyibir.TMGD.WebAPI.Models
{
    public partial class HazardousGoodsLabel
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public DataResult GetObjectById(Guid Oid)
        {
            DataResult result = new DataResult();
            try
            {
                List<HazardousGoodsLabel> items = new List<HazardousGoodsLabel>();
                string commandString = string.Format("SELECT * FROM HazardousGoodsLabel WHERE Oid = '{0}'", Oid);
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            HazardousGoodsLabel hazardousGoodsLabel = new HazardousGoodsLabel();
                            hazardousGoodsLabel.Oid = Guid.Parse(dr["Oid"].ToString());
                            hazardousGoodsLabel.Name = string.IsNullOrEmpty(dr["Name"].ToString()) ? string.Empty : dr["Name"].ToString();
                            hazardousGoodsLabel.Code = string.IsNullOrEmpty(dr["Code"].ToString()) ? string.Empty : dr["Code"].ToString();

                            items.Add(hazardousGoodsLabel);
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
                List<HazardousGoodsLabel> items = new List<HazardousGoodsLabel>();
                string commandString = string.Format("SELECT * FROM HazardousGoodsLabel");
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {

                            HazardousGoodsLabel hazardousGoodsLabel = new HazardousGoodsLabel();
                            hazardousGoodsLabel.Oid = Guid.Parse(dr["Oid"].ToString());
                            hazardousGoodsLabel.Name = string.IsNullOrEmpty(dr["Name"].ToString()) ? string.Empty : dr["Name"].ToString();
                            hazardousGoodsLabel.Code = string.IsNullOrEmpty(dr["Code"].ToString()) ? string.Empty : dr["Code"].ToString();

                            items.Add(hazardousGoodsLabel);
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