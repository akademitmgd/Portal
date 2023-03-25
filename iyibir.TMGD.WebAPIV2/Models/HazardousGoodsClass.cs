using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace iyibir.TMGD.WebAPIV2.Models
{
    public partial class HazardousGoodsClass
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public DataResult GetObjectById(Guid Oid)
        {
            DataResult result = new DataResult();
            try
            {
                List<HazardousGoodsClass> items = new List<HazardousGoodsClass>();
                string commandString = string.Format("SELECT * FROM HazardousGoodsClass WHERE Oid = '{0}'", Oid);
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            HazardousGoodsClass hazardousGoodsClass = new HazardousGoodsClass();
                            hazardousGoodsClass.Oid = Guid.Parse(dr["Oid"].ToString());
                            hazardousGoodsClass.Name = string.IsNullOrEmpty(dr["Name"].ToString()) ? string.Empty : dr["Name"].ToString();
                            hazardousGoodsClass.Code = string.IsNullOrEmpty(dr["Code"].ToString()) ? string.Empty : dr["Code"].ToString();
                            hazardousGoodsClass.ParentHazardousGoodsClass = dr["ParentHazardousGoodsClass"] == DBNull.Value ? null : ((List<HazardousGoodsClass>)new HazardousGoodsClass().GetObjectById(Guid.Parse(dr["ParentHazardousGoodsClass"].ToString())).Data).FirstOrDefault();

                            items.Add(hazardousGoodsClass);
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
                List<HazardousGoodsClass> items = new List<HazardousGoodsClass>();
                string commandString = string.Format("SELECT * FROM HazardousGoodsClass");
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            HazardousGoodsClass hazardousGoodsClass = new HazardousGoodsClass();
                            hazardousGoodsClass.Oid = Guid.Parse(dr["Oid"].ToString());
                            hazardousGoodsClass.Name = string.IsNullOrEmpty(dr["Name"].ToString()) ? string.Empty : dr["Name"].ToString();
                            hazardousGoodsClass.Code = string.IsNullOrEmpty(dr["Code"].ToString()) ? string.Empty : dr["Code"].ToString();
                            hazardousGoodsClass.ParentHazardousGoodsClass = dr["ParentHazardousGoodsClass"] == DBNull.Value ? null : ((List<HazardousGoodsClass>)new HazardousGoodsClass().GetObjectById(Guid.Parse(dr["ParentHazardousGoodsClass"].ToString())).Data).FirstOrDefault();

                            items.Add(hazardousGoodsClass);
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
                List<HazardousGoodsClass> items = new List<HazardousGoodsClass>();
                string commandString = string.Format(@"SELECT Classes FROM HazardousGoodsHazardousGoods_HazardousGoodsClassClasses
                    WHERE HazardousGoods = '{0}'", HazardousGoodsOid);
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            HazardousGoodsClass hazardousGoodsClass = dr["Classes"] == DBNull.Value ? null : ((List<HazardousGoodsClass>)new HazardousGoodsClass().GetObjectById(Guid.Parse(dr["Classes"].ToString())).Data).FirstOrDefault();

                            items.Add(hazardousGoodsClass);
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