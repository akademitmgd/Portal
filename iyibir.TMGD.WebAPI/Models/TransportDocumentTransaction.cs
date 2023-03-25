using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace iyibir.TMGD.WebAPI.Models
{
    public partial class TransportDocumentTransaction
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public DataResult GetObjectById(Guid Oid)
        {
            DataResult result = new DataResult();
            try
            {
                List<TransportDocumentTransaction> items = new List<TransportDocumentTransaction>();
                string commandString = string.Format("SELECT * FROM TransportDocumentTransaction WHERE Oid = '{0}'", Oid);
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            TransportDocumentTransaction transportDocumentTransaction = new TransportDocumentTransaction();
                            transportDocumentTransaction.Oid = Guid.Parse(dr["Oid"].ToString());
                            transportDocumentTransaction.Description = string.IsNullOrEmpty(dr["Description"].ToString()) ? string.Empty : dr["Description"].ToString();
                            transportDocumentTransaction.InventoryCode = string.IsNullOrEmpty(dr["InventoryCode"].ToString()) ? string.Empty : dr["InventoryCode"].ToString();
                            transportDocumentTransaction.InventoryName = string.IsNullOrEmpty(dr["InventoryName"].ToString()) ? string.Empty : dr["InventoryName"].ToString();
                            transportDocumentTransaction.NetWeigth = dr["NetWeigth"] == DBNull.Value ? default(double) : (double)dr["NetWeigth"];
                            transportDocumentTransaction.Quantity = dr["Quantity"] == DBNull.Value ? default(double) : (double)dr["Quantity"];
                            transportDocumentTransaction.Unitset = dr["Unitset"] == DBNull.Value ? null : ((List<Unitset>)new Unitset().GetObjectById(Guid.Parse(dr["Unitset"].ToString())).Data).FirstOrDefault();
                            transportDocumentTransaction.TransportDocument = dr["TransportDocument"] == DBNull.Value ? null : ((List<TransportDocument>)new TransportDocument().GetObjectById(Guid.Parse(dr["TransportDocument"].ToString())).Data).FirstOrDefault();
                            transportDocumentTransaction.PackingGroup = dr["PackingGroup"] == DBNull.Value ? null : ((List<PackingGroup>)new PackingGroup().GetObjectById(Guid.Parse(dr["PackingGroup"].ToString())).Data).FirstOrDefault();
                            transportDocumentTransaction.PackagingTypes = dr["PackagingTypes"] == DBNull.Value ? null : ((List<PackagingTypes>)new PackagingTypes().GetObjectById(Guid.Parse(dr["PackagingTypes"].ToString())).Data).FirstOrDefault();
                            transportDocumentTransaction.HazardousGoodsLabel = dr["HazardousGoodsLabel"] == DBNull.Value ? null : ((List<HazardousGoodsLabel>)new HazardousGoodsLabel().GetObjectById(Guid.Parse(dr["HazardousGoodsLabel"].ToString())).Data).FirstOrDefault();
                            transportDocumentTransaction.HazardousGoodsClass = dr["HazardousGoodsClass"] == DBNull.Value ? null : ((List<HazardousGoodsClass>)new HazardousGoodsClass().GetObjectById(Guid.Parse(dr["HazardousGoodsClass"].ToString())).Data).FirstOrDefault();
                            transportDocumentTransaction.HazardousGoods = dr["HazardousGoods"] == DBNull.Value ? null : ((List<HazardousGoods>)new HazardousGoods().GetObjectById(Guid.Parse(dr["HazardousGoods"].ToString())).Data).FirstOrDefault();

                            items.Add(transportDocumentTransaction);
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
                List<TransportDocumentTransaction> items = new List<TransportDocumentTransaction>();
                string commandString = string.Format("SELECT * FROM TransportDocumentTransaction", Oid);
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            TransportDocumentTransaction transportDocumentTransaction = new TransportDocumentTransaction();
                            transportDocumentTransaction.Oid = Guid.Parse(dr["Oid"].ToString());
                            transportDocumentTransaction.Description = string.IsNullOrEmpty(dr["Description"].ToString()) ? string.Empty : dr["Description"].ToString();
                            transportDocumentTransaction.InventoryCode = string.IsNullOrEmpty(dr["InventoryCode"].ToString()) ? string.Empty : dr["InventoryCode"].ToString();
                            transportDocumentTransaction.InventoryName = string.IsNullOrEmpty(dr["InventoryName"].ToString()) ? string.Empty : dr["InventoryName"].ToString();
                            transportDocumentTransaction.NetWeigth = dr["NetWeigth"] == DBNull.Value ? default(double) : (double)dr["NetWeigth"];
                            transportDocumentTransaction.Quantity = dr["Quantity"] == DBNull.Value ? default(double) : (double)dr["Quantity"];
                            transportDocumentTransaction.Unitset = dr["Unitset"] == DBNull.Value ? null : ((List<Unitset>)new Unitset().GetObjectById(Guid.Parse(dr["Unitset"].ToString())).Data).FirstOrDefault();
                            transportDocumentTransaction.TransportDocument = dr["TransportDocument"] == DBNull.Value ? null : ((List<TransportDocument>)new TransportDocument().GetObjectById(Guid.Parse(dr["TransportDocument"].ToString())).Data).FirstOrDefault();
                            transportDocumentTransaction.PackingGroup = dr["PackingGroup"] == DBNull.Value ? null : ((List<PackingGroup>)new PackingGroup().GetObjectById(Guid.Parse(dr["PackingGroup"].ToString())).Data).FirstOrDefault();
                            transportDocumentTransaction.PackagingTypes = dr["PackagingTypes"] == DBNull.Value ? null : ((List<PackagingTypes>)new PackagingTypes().GetObjectById(Guid.Parse(dr["PackagingTypes"].ToString())).Data).FirstOrDefault();
                            transportDocumentTransaction.HazardousGoodsLabel = dr["HazardousGoodsLabel"] == DBNull.Value ? null : ((List<HazardousGoodsLabel>)new HazardousGoodsLabel().GetObjectById(Guid.Parse(dr["HazardousGoodsLabel"].ToString())).Data).FirstOrDefault();
                            transportDocumentTransaction.HazardousGoodsClass = dr["HazardousGoodsClass"] == DBNull.Value ? null : ((List<HazardousGoodsClass>)new HazardousGoodsClass().GetObjectById(Guid.Parse(dr["HazardousGoodsClass"].ToString())).Data).FirstOrDefault();
                            transportDocumentTransaction.HazardousGoods = dr["HazardousGoods"] == DBNull.Value ? null : ((List<HazardousGoods>)new HazardousGoods().GetObjectById(Guid.Parse(dr["HazardousGoods"].ToString())).Data).FirstOrDefault();

                            items.Add(transportDocumentTransaction);
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

        public DataResult InsertObject(TransportDocumentTransaction transaction)
        {
            DataResult result = new DataResult();

            try
            {
                if (transaction != null)
                {
                    string commandString = string.Format(@"
                    INSERT INTO TransportDocumentTransaction
                        (
                        Oid, 
                        TransportDocument, 
                        HazardousGoods, 
                        Quantity, 
                        PackagingTypes, 
                        Description, 
                        NetWeigth,
                        HazardousGoodsClass, 
                        PackingGroup, 
                        InventoryCode, 
                        InventoryName, 
                        HazardousGoodsLabel, 
                        Unitset
                        )
                        VALUES
                        (
                        @Oid, 
                        @TransportDocument, 
                        @HazardousGoods, 
                        @Quantity, 
                        @PackagingTypes, 
                        @Description, 
                        @NetWeigth,
                        @HazardousGoodsClass, 
                        @PackingGroup, 
                        @InventoryCode, 
                        @InventoryName, 
                        @HazardousGoodsLabel, 
                        @Unitset
                        ); SELECT SCOPE_IDENTITY();");

                    using (SqlConnection cnn = new SqlConnection(connectionString))
                    {
                        cnn.Open();
                        using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                        {
                            cmd.Parameters.AddWithValue("Oid", transaction.Oid);
                            cmd.Parameters.AddWithValue("Description", transaction.Description);
                            cmd.Parameters.AddWithValue("InventoryCode", transaction.InventoryCode);
                            cmd.Parameters.AddWithValue("InventoryName", transaction.InventoryName);
                            cmd.Parameters.AddWithValue("NetWeigth", transaction.NetWeigth ?? default(double));
                            cmd.Parameters.AddWithValue("Quantity", transaction.Quantity ?? default(double));

                            #region AddUnitset
                            if (transaction.Unitset != null)
                            {
                                cmd.Parameters.AddWithValue("Unitset", transaction.Unitset.Oid);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("Unitset", DBNull.Value);
                            }
                            #endregion

                            #region AddTransportDocument
                            if (transaction.TransportDocument != null)
                            {
                                cmd.Parameters.AddWithValue("TransportDocument", transaction.TransportDocument.Oid);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("TransportDocument", DBNull.Value);
                            }
                            #endregion

                            #region AddPackingGroup
                            if (transaction.PackingGroup != null)
                            {
                                cmd.Parameters.AddWithValue("PackingGroup", transaction.PackingGroup.Oid);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("PackingGroup", DBNull.Value);
                            }
                            #endregion

                            #region AddPackagingTypes
                            if (transaction.PackagingTypes != null)
                            {
                                cmd.Parameters.AddWithValue("PackagingTypes", transaction.PackagingTypes.Oid);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("PackagingTypes", DBNull.Value);
                            }
                            #endregion

                            #region AddHazardousGoodsLabel
                            if (transaction.HazardousGoodsLabel != null)
                            {
                                cmd.Parameters.AddWithValue("HazardousGoodsLabel", transaction.HazardousGoodsLabel.Oid);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("HazardousGoodsLabel", DBNull.Value);
                            }
                            #endregion

                            #region AddHazardousGoodsClass
                            if (transaction.HazardousGoodsClass != null)
                            {
                                cmd.Parameters.AddWithValue("HazardousGoodsClass", transaction.HazardousGoodsClass.Oid);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("HazardousGoodsClass", DBNull.Value);
                            }
                            #endregion

                            #region AddHazardousGoods
                            if (transaction.HazardousGoods != null)
                            {
                                cmd.Parameters.AddWithValue("HazardousGoods", transaction.HazardousGoods.Oid);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("HazardousGoods", DBNull.Value);
                            }
                            #endregion

                            var oid = cmd.ExecuteScalar();
                            cnn.Close();

                            result.Data = transaction.Oid;
                            result.Result = true;
                            result.Message = "Success";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Data = ex.Message;
                result.Result = false;
                result.Message = "Error";
            }

            return result;
        }
    }
}