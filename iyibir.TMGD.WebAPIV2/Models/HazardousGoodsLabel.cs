using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace iyibir.TMGD.WebAPIV2.Models
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
                            //string LabelImage = string.IsNullOrEmpty(dr["LabelImage"].ToString()) ? string.Empty : dr["LabelImage"].ToString();

                            HazardousGoodsLabel hazardousGoodsLabel = new HazardousGoodsLabel();
                            hazardousGoodsLabel.Oid = Guid.Parse(dr["Oid"].ToString());
                            hazardousGoodsLabel.Name = string.IsNullOrEmpty(dr["Name"].ToString()) ? string.Empty : dr["Name"].ToString();
                            hazardousGoodsLabel.Code = string.IsNullOrEmpty(dr["Code"].ToString()) ? string.Empty : dr["Code"].ToString();
                            hazardousGoodsLabel.LineNumber = dr["LineNumber"] == DBNull.Value ? default(int) : (int)dr["LineNumber"];
                            hazardousGoodsLabel.LabelImage = dr["LabelImage"] == DBNull.Value ? new byte[0] : (byte[])dr["LabelImage"];
                            //hazardousGoodsLabel.LabelImage = Convert.ToByte(LabelImage);

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
                            //string LabelImage = string.IsNullOrEmpty(dr["LabelImage"].ToString()) ? string.Empty : dr["LabelImage"].ToString();

                            HazardousGoodsLabel hazardousGoodsLabel = new HazardousGoodsLabel();
                            hazardousGoodsLabel.Oid = Guid.Parse(dr["Oid"].ToString());
                            hazardousGoodsLabel.Name = string.IsNullOrEmpty(dr["Name"].ToString()) ? string.Empty : dr["Name"].ToString();
                            hazardousGoodsLabel.Code = string.IsNullOrEmpty(dr["Code"].ToString()) ? string.Empty : dr["Code"].ToString();
                            hazardousGoodsLabel.LineNumber = dr["LineNumber"] == DBNull.Value ? default(int) : (int)dr["LineNumber"];
                            hazardousGoodsLabel.LabelImage = dr["LabelImage"] == DBNull.Value ? new byte[0] : (byte[])dr["LabelImage"];
                            //hazardousGoodsLabel.LabelImage = Convert.ToByte(LabelImage);

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
        public DataResult GetObjectByCode(string code)
        {
            DataResult result = new DataResult();
            try
            {
                List<HazardousGoodsLabel> items = new List<HazardousGoodsLabel>();
                string commandString = string.Format("SELECT * FROM HazardousGoodsLabel WHERE Code = '{0}'", code);
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            //string LabelImage = string.IsNullOrEmpty(dr["LabelImage"].ToString()) ? string.Empty : dr["LabelImage"].ToString();

                            HazardousGoodsLabel hazardousGoodsLabel = new HazardousGoodsLabel();
                            hazardousGoodsLabel.Oid = Guid.Parse(dr["Oid"].ToString());
                            hazardousGoodsLabel.Name = string.IsNullOrEmpty(dr["Name"].ToString()) ? string.Empty : dr["Name"].ToString();
                            hazardousGoodsLabel.Code = string.IsNullOrEmpty(dr["Code"].ToString()) ? string.Empty : dr["Code"].ToString();
                            hazardousGoodsLabel.LineNumber = dr["LineNumber"] == DBNull.Value ? default(int) : (int)dr["LineNumber"];
                            hazardousGoodsLabel.LabelImage = dr["LabelImage"] == DBNull.Value ? new byte[0] : (byte[])dr["LabelImage"];
                            //hazardousGoodsLabel.LabelImage = Convert.ToByte(LabelImage);

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

        public DataResult GetObjectByHazardousGoods(Guid HazardousGoodsOid)
        {
            DataResult result = new DataResult();
            try
            {
                List<HazardousGoodsLabel> items = new List<HazardousGoodsLabel>();
                string commandString = string.Format(@"SELECT Labels FROM HazardousGoodsLabelLabels_HazardousGoodsHazardousGoods
                            WHERE HazardousGoods = '{0}'", HazardousGoodsOid);
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            HazardousGoodsLabel hazardousGoodsLabel = dr["Labels"] == DBNull.Value ? null : ((List<HazardousGoodsLabel>)new HazardousGoodsLabel().GetObjectById(Guid.Parse(dr["Labels"].ToString())).Data).FirstOrDefault();

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