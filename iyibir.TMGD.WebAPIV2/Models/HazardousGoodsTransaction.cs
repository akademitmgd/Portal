using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace iyibir.TMGD.WebAPIV2.Models
{
    public partial class HazardousGoodsTransaction
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public DataResult InsertObject(HazardousGoodsTransaction hazardousGoodsTransaction)
        {
            DataResult result = new DataResult();

            try
            {
                if (hazardousGoodsTransaction != null)
                {
                    string commandString = string.Format(@"");

                    using (SqlConnection cnn = new SqlConnection(connectionString))
                    {
                        cnn.Open();
                        using (SqlCommand cmd = new SqlCommand(commandString,cnn))
                        {
                            cmd.Parameters.AddWithValue("Oid", hazardousGoodsTransaction.Oid);
                            cmd.Parameters.AddWithValue("TransactionType", hazardousGoodsTransaction.TransactionType);
                            cmd.Parameters.AddWithValue("Quantity", hazardousGoodsTransaction.Quantity ?? default(double));
                            cmd.Parameters.AddWithValue("CreatedOn", hazardousGoodsTransaction.CreatedOn ?? default(DateTime));
                            cmd.Parameters.AddWithValue("TransactionDate", hazardousGoodsTransaction.TransactionDate ?? default(DateTime));

                            #region AddProduct
                            if (hazardousGoodsTransaction.Product != null)
                            {
                                cmd.Parameters.AddWithValue("Product", hazardousGoodsTransaction.Product.Oid);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("Product", DBNull.Value);
                            }
                            #endregion

                            #region AddCustomer
                            if (hazardousGoodsTransaction.Customer != null)
                            {
                                cmd.Parameters.AddWithValue("Customer", hazardousGoodsTransaction.Customer.Oid);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("Customer", DBNull.Value);
                            }
                            #endregion

                            #region AddUnitset
                            if (hazardousGoodsTransaction.Unitset != null)
                            {
                                cmd.Parameters.AddWithValue("Unitset", hazardousGoodsTransaction.Unitset.Oid);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("Unitset", DBNull.Value);
                            }
                            #endregion

                            #region AddOwner
                            if (hazardousGoodsTransaction.Owner != null)
                            {
                                cmd.Parameters.AddWithValue("Owner", hazardousGoodsTransaction.Owner.Oid);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("Owner", DBNull.Value);
                            }
                            #endregion

                            #region AddConsignee
                            if (hazardousGoodsTransaction.Consignee != null)
                            {
                                cmd.Parameters.AddWithValue("Consignee", hazardousGoodsTransaction.Consignee.Oid);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("Consignee", DBNull.Value);
                            }
                            #endregion

                            cmd.ExecuteNonQuery();
                            cnn.Close();

                            result.Data = hazardousGoodsTransaction.Oid;
                            result.Result = true;
                            result.Message = "Success";
                        }
                    }
                }
                else
                {
                    result.Data = "Parametre boş geçilemez.";
                    result.Message = "Error";
                    result.Result = false;
                }
            }
            catch (Exception ex)
            {
                result.Data = ex.Message;
                result.Message = "Error";
                result.Result = false;
            }

            return result;
        }
    }
}