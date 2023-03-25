using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace iyibir.TMGD.WebAPIV2.Models
{
    public partial class Product
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public DataResult GetObjectByCode(string code,Guid customerOid)
        {
            DataResult result = new DataResult();

            try
            {
                List<Product> items = new List<Product>();
                string commandString = string.Format("SELECT * FROM Product WHERE Customer = '{0}' AND Code = '{1}'", customerOid, code);

                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            Product product = new Product();
                            product.Code = string.IsNullOrEmpty(dr["Code"].ToString()) ? string.Empty : dr["Code"].ToString();
                            product.MSDSName = string.IsNullOrEmpty(dr["MSDSName"].ToString()) ? string.Empty : dr["MSDSName"].ToString();
                            product.Name = string.IsNullOrEmpty(dr["Name"].ToString()) ? string.Empty : dr["Name"].ToString();
                            product.OtherName = string.IsNullOrEmpty(dr["OtherName"].ToString()) ? string.Empty : dr["OtherName"].ToString();
                            product.WasteName = string.IsNullOrEmpty(dr["WasteName"].ToString()) ? string.Empty : dr["WasteName"].ToString();
                            product.WasteList = dr["WasteCode"] == DBNull.Value ? null : ((List<WasteList>)new WasteList().GetObjectById(Guid.Parse(dr["WasteCode"].ToString())).Data).FirstOrDefault();
                            product.Customer = dr["Customer"] == DBNull.Value ? null : ((List<Customer>)new Customer().GetObjectById(Guid.Parse(dr["Customer"].ToString())).Data).FirstOrDefault();
                            product.Unitset = dr["Unitset"] == DBNull.Value ? null : ((List<Unitset>)new Unitset().GetObjectById(Guid.Parse(dr["Unitset"].ToString())).Data).FirstOrDefault();
                            product.MSDSStatus = dr["MSDSStatus"] == DBNull.Value ? default(int) : (int)dr["MSDSStatus"];
                            product.HazardousGoods = dr["HazardousGoods"] == DBNull.Value ? null : ((List<HazardousGoods>)new HazardousGoods().GetObjectById(Guid.Parse(dr["HazardousGoods"].ToString())).Data).FirstOrDefault();
                            product.ProductGroupType = dr["ProductGroupType"] == DBNull.Value ? default(int) : (int)dr["ProductGroupType"];
                            product.ProductType = dr["ProductType"] == DBNull.Value ? default(int) : (int)dr["ProductType"];

                            items.Add(product);
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
        public DataResult GetObjects(Guid customerOid,int groupTpye)
        {
            DataResult result = new DataResult();

            try
            {
                List<Product> items = new List<Product>();
                string commandString = string.Format("SELECT * FROM Product WHERE Customer = '{0}' and ProductGroupType = {1}", customerOid, groupTpye);

                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            Product product = new Product();
                            product.Code = string.IsNullOrEmpty(dr["Code"].ToString()) ? string.Empty : dr["Code"].ToString();
                            product.MSDSName = string.IsNullOrEmpty(dr["MSDSName"].ToString()) ? string.Empty : dr["MSDSName"].ToString();
                            product.Name = string.IsNullOrEmpty(dr["Name"].ToString()) ? string.Empty : dr["Name"].ToString();
                            product.OtherName = string.IsNullOrEmpty(dr["OtherName"].ToString()) ? string.Empty : dr["OtherName"].ToString();
                            product.WasteName = string.IsNullOrEmpty(dr["WasteName"].ToString()) ? string.Empty : dr["WasteName"].ToString();
                            product.WasteList = dr["WasteCode"] == DBNull.Value ? null : ((List<WasteList>)new WasteList().GetObjectById(Guid.Parse(dr["WasteCode"].ToString())).Data).FirstOrDefault();
                            product.Customer = dr["Customer"] == DBNull.Value ? null : ((List<Customer>)new Customer().GetObjectById(Guid.Parse(dr["Customer"].ToString())).Data).FirstOrDefault();
                            product.Unitset = dr["Unitset"] == DBNull.Value ? null : ((List<Unitset>)new Unitset().GetObjectById(Guid.Parse(dr["Unitset"].ToString())).Data).FirstOrDefault();
                            product.MSDSStatus = dr["MSDSStatus"] == DBNull.Value ? default(int) : (int)dr["MSDSStatus"];
                            product.HazardousGoods = dr["HazardousGoods"] == DBNull.Value ? null : ((List<HazardousGoods>)new HazardousGoods().GetObjectById(Guid.Parse(dr["HazardousGoods"].ToString())).Data).FirstOrDefault();
                            product.ProductGroupType = dr["ProductGroupType"] == DBNull.Value ? default(int) : (int)dr["ProductGroupType"];
                            product.ProductType = dr["ProductType"] == DBNull.Value ? default(int) : (int)dr["ProductType"];

                            items.Add(product);
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
        public   DataResult InsertObject(Product product)
        {
            DataResult result = new DataResult();

            try
            {
                string commandString = string.Format(@"
                        INSERT INTO Product
                        (Oid,
                        Code, 
                        Name, 
                        OtherName,
                        HazardousGoods, 
                        Unitset, 
                        MSDSStatus, 
                        MSDSName, 
                        Customer , 
                        ProductType, 
                        IsActive, 
                        ProductGroupType, 
                        WasteCode, 
                        WasteName,
                        Owner)
                VALUES(
                        @Oid,
                        @Code, 
                        @Name, 
                        @OtherName,
                        @HazardousGoods, 
                        @Unitset, 
                        @MSDSStatus, 
                        @MSDSName, 
                        @Customer , 
                        @ProductType, 
                        @IsActive, 
                        @ProductGroupType, 
                        @WasteCode, 
                        @WasteName,
                        @Owner); SELECT SCOPE_IDENTITY();");

                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString,cnn))
                    {
                        cmd.Parameters.AddWithValue("Oid", product.Oid);
                        cmd.Parameters.AddWithValue("Code", product.Code ?? string.Empty);
                        cmd.Parameters.AddWithValue("Name", product.Name ?? string.Empty);
                        cmd.Parameters.AddWithValue("OtherName", product.OtherName ?? string.Empty);
                        cmd.Parameters.AddWithValue("IsActive", product.IsActive);
                        cmd.Parameters.AddWithValue("WasteName", product.WasteName ?? string.Empty);
                        cmd.Parameters.AddWithValue("ProductType", product.ProductType);
                        cmd.Parameters.AddWithValue("ProductGroupType", product.ProductGroupType);
                        cmd.Parameters.AddWithValue("MSDSStatus", product.MSDSStatus);
                        cmd.Parameters.AddWithValue("MSDSName", product.MSDSName ?? string.Empty);



                        #region AddWasteList
                        if (product.WasteList != null)
                        {
                            cmd.Parameters.AddWithValue("WasteCode", product.WasteList.Oid);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("WasteCode", DBNull.Value);
                        }
                        #endregion

                        #region AddHazardousGoods
                        if (product.HazardousGoods != null)
                        {
                            cmd.Parameters.AddWithValue("HazardousGoods", product.HazardousGoods.Oid);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("HazardousGoods", DBNull.Value);
                        }
                        #endregion

                        #region AddCustomer
                        if (product.Customer != null)
                        {
                            cmd.Parameters.AddWithValue("Customer", product.Customer.Oid);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("Customer", DBNull.Value);
                        }
                        #endregion

                        #region AddOwner
                        if (product.Owner != null)
                        {
                            cmd.Parameters.AddWithValue("Owner", product.Owner.Oid);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("Owner", DBNull.Value);
                        }
                        #endregion

                        #region AddUnitset
                        if (product.Unitset != null)
                        {
                            cmd.Parameters.AddWithValue("Unitset", product.Unitset.Oid);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("Unitset", DBNull.Value);
                        }
                        #endregion

                        cmd.ExecuteNonQuery();
                        cnn.Close();

                        result.Data = product.Oid;
                        result.Result = true;
                        result.Message = "Success";
                    }
                }
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