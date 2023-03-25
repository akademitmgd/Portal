using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace iyibir.TMGD.WebAPIV2.Models
{
    public partial class PackagingTypes
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public DataResult GetObjectById(Guid Oid)
        {
            DataResult result = new DataResult();
            try
            {
                List<PackagingTypes> items = new List<PackagingTypes>();
                string commandString = string.Format("SELECT * FROM PackagingTypes WHERE Oid = '{0}'", Oid);
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            PackagingTypes packagingTypes = new PackagingTypes();
                            packagingTypes.Oid = Guid.Parse(dr["Oid"].ToString());
                            packagingTypes.Name = string.IsNullOrEmpty(dr["Name"].ToString()) ? string.Empty : dr["Name"].ToString();
                            packagingTypes.Code = string.IsNullOrEmpty(dr["Code"].ToString()) ? string.Empty : dr["Code"].ToString();

                            items.Add(packagingTypes);
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
                List<PackagingTypes> items = new List<PackagingTypes>();
                string commandString = string.Format("SELECT * FROM PackagingTypes WHERE Code = '{0}'", code);
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            PackagingTypes packagingTypes = new PackagingTypes();
                            packagingTypes.Oid = Guid.Parse(dr["Oid"].ToString());
                            packagingTypes.Name = string.IsNullOrEmpty(dr["Name"].ToString()) ? string.Empty : dr["Name"].ToString();
                            packagingTypes.Code = string.IsNullOrEmpty(dr["Code"].ToString()) ? string.Empty : dr["Code"].ToString();

                            items.Add(packagingTypes);
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
                List<PackagingTypes> items = new List<PackagingTypes>();
                string commandString = string.Format("SELECT * FROM PackagingTypes");
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            PackagingTypes packagingTypes = new PackagingTypes();
                            packagingTypes.Oid = Guid.Parse(dr["Oid"].ToString());
                            packagingTypes.Name = string.IsNullOrEmpty(dr["Name"].ToString()) ? string.Empty : dr["Name"].ToString();
                            packagingTypes.Code = string.IsNullOrEmpty(dr["Code"].ToString()) ? string.Empty : dr["Code"].ToString();

                            items.Add(packagingTypes);
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
                List<PackagingTypes> items = new List<PackagingTypes>();
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
                            PackagingTypes packagingTypes = dr["Labels"] == DBNull.Value ? null : ((List<PackagingTypes>)new PackagingTypes().GetObjectById(Guid.Parse(dr["Labels"].ToString())).Data).FirstOrDefault();

                            items.Add(packagingTypes);
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