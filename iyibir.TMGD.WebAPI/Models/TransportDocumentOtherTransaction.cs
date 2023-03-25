using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace iyibir.TMGD.WebAPI.Models
{
    public partial class TransportDocumentOtherTransaction
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public DataResult GetObjectById(Guid Oid)
        {
            DataResult result = new DataResult();
            try
            {
                List<TransportDocumentOtherTransaction> items = new List<TransportDocumentOtherTransaction>();
                string commandString = string.Format("SELECT * FROM TransportDocumentOtherTransaction WHERE Oid = '{0}'", Oid);
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            TransportDocumentOtherTransaction otherTransaction = new TransportDocumentOtherTransaction();
                            otherTransaction.Oid = Guid.Parse(dr["Oid"].ToString());
                            otherTransaction.Description = string.IsNullOrEmpty(dr["Description"].ToString()) ? string.Empty : dr["Description"].ToString();
                            otherTransaction.NetWeigth = dr["NetWeigth"] == DBNull.Value ? default(double) : (double)dr["NetWeigth"];
                            otherTransaction.Quantity = dr["Quantity"] == DBNull.Value ? default(double) : (double)dr["Quantity"];
                            otherTransaction.Unitset = dr["Unitset"] == DBNull.Value ? null : ((List<Unitset>)new Unitset().GetObjectById(Guid.Parse(dr["Unitset"].ToString())).Data).FirstOrDefault();
                            otherTransaction.PackingGroup = dr["PackingGroup"] == DBNull.Value ? null : ((List<PackingGroup>)new PackingGroup().GetObjectById(Guid.Parse(dr["PackingGroup"].ToString())).Data).FirstOrDefault();
                            otherTransaction.PackagingTypes = dr["PackagingTypes"] == DBNull.Value ? null : ((List<PackagingTypes>)new PackagingTypes().GetObjectById(Guid.Parse(dr["PackagingTypes"].ToString())).Data).FirstOrDefault();
                            otherTransaction.HazardousGoodsLabel = dr["HazardousGoodsLabel"] == DBNull.Value ? null : ((List<HazardousGoodsLabel>)new HazardousGoodsLabel().GetObjectById(Guid.Parse(dr["HazardousGoodsLabel"].ToString())).Data).FirstOrDefault();
                            otherTransaction.HazardousGoodsClass = dr["HazardousGoodsClass"] == DBNull.Value ? null : ((List<HazardousGoodsClass>)new HazardousGoodsClass().GetObjectById(Guid.Parse(dr["HazardousGoodsClass"].ToString())).Data).FirstOrDefault();
                            otherTransaction.HazardousGoods = dr["HazardousGoods"] == DBNull.Value ? null : ((List<HazardousGoods>)new HazardousGoods().GetObjectById(Guid.Parse(dr["HazardousGoods"].ToString())).Data).FirstOrDefault();
                            otherTransaction.WasteCode = dr["WasteCode"] == DBNull.Value ? null : ((List<WasteList>)new WasteList().GetObjectById(Guid.Parse(dr["WasteCode"].ToString())).Data).FirstOrDefault();
                            otherTransaction.TransportDocument = dr["TransportDocument"] == DBNull.Value ? null : ((List<TransportDocument>)new TransportDocument().GetObjectById(Guid.Parse(dr["TransportDocument"].ToString())).Data).FirstOrDefault();

                            items.Add(otherTransaction);
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
                List<TransportDocumentOtherTransaction> items = new List<TransportDocumentOtherTransaction>();
                string commandString = string.Format("SELECT * FROM TransportDocumentOtherTransaction", Oid);
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            TransportDocumentOtherTransaction otherTransaction = new TransportDocumentOtherTransaction();
                            otherTransaction.Oid = Guid.Parse(dr["Oid"].ToString());
                            otherTransaction.Description = string.IsNullOrEmpty(dr["Description"].ToString()) ? string.Empty : dr["Description"].ToString();
                            otherTransaction.NetWeigth = dr["NetWeigth"] == DBNull.Value ? default(double) : (double)dr["NetWeigth"];
                            otherTransaction.Quantity = dr["Quantity"] == DBNull.Value ? default(double) : (double)dr["Quantity"];
                            otherTransaction.Unitset = dr["Unitset"] == DBNull.Value ? null : ((List<Unitset>)new Unitset().GetObjectById(Guid.Parse(dr["Unitset"].ToString())).Data).FirstOrDefault();
                            otherTransaction.PackingGroup = dr["PackingGroup"] == DBNull.Value ? null : ((List<PackingGroup>)new PackingGroup().GetObjectById(Guid.Parse(dr["PackingGroup"].ToString())).Data).FirstOrDefault();
                            otherTransaction.PackagingTypes = dr["PackagingTypes"] == DBNull.Value ? null : ((List<PackagingTypes>)new PackagingTypes().GetObjectById(Guid.Parse(dr["PackagingTypes"].ToString())).Data).FirstOrDefault();
                            otherTransaction.HazardousGoodsLabel = dr["HazardousGoodsLabel"] == DBNull.Value ? null : ((List<HazardousGoodsLabel>)new HazardousGoodsLabel().GetObjectById(Guid.Parse(dr["HazardousGoodsLabel"].ToString())).Data).FirstOrDefault();
                            otherTransaction.HazardousGoodsClass = dr["HazardousGoodsClass"] == DBNull.Value ? null : ((List<HazardousGoodsClass>)new HazardousGoodsClass().GetObjectById(Guid.Parse(dr["HazardousGoodsClass"].ToString())).Data).FirstOrDefault();
                            otherTransaction.HazardousGoods = dr["HazardousGoods"] == DBNull.Value ? null : ((List<HazardousGoods>)new HazardousGoods().GetObjectById(Guid.Parse(dr["HazardousGoods"].ToString())).Data).FirstOrDefault();
                            otherTransaction.WasteCode = dr["WasteCode"] == DBNull.Value ? null : ((List<WasteList>)new WasteList().GetObjectById(Guid.Parse(dr["WasteCode"].ToString())).Data).FirstOrDefault();
                            otherTransaction.TransportDocument = dr["TransportDocument"] == DBNull.Value ? null : ((List<TransportDocument>)new TransportDocument().GetObjectById(Guid.Parse(dr["TransportDocument"].ToString())).Data).FirstOrDefault();

                            items.Add(otherTransaction);
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

        public DataResult InsertObject(TransportDocumentOtherTransaction otherTransaction)
        {
            DataResult result = new DataResult();

            try
            {
                if (otherTransaction != null)
                {
                    string commandString = string.Format(@"
                    INSERT INTO TransportDocumentOtherTransaction
                        (
                        Oid, 
                        TransportDocument, 
                        HazardousGoods, 
                        HazardousGoodsClass, 
                        PackingGroup, 
                        Quantity, 
                        PackagingTypes, 
                        Description, 
                        NetWeigth,
                        WasteCode, 
                        HazardousGoodsLabel, 
                        Unitset
                        )
                        VALUES
                        (
                        @Oid, 
                        @TransportDocument, 
                        @HazardousGoods, 
                        @HazardousGoodsClass, 
                        @PackingGroup, 
                        @Quantity, 
                        @PackagingTypes, 
                        @Description, 
                        @NetWeigth,
                        @WasteCode, 
                        @HazardousGoodsLabel, 
                        @Unitset
                        ); SELECT SCOPE_IDENTITY();");

                    using (SqlConnection cnn = new SqlConnection(connectionString))
                    {
                        cnn.Open();
                        using (SqlCommand cmd = new SqlCommand(commandString,cnn))
                        {
                            cmd.Parameters.AddWithValue("Oid", otherTransaction.Oid);
                            cmd.Parameters.AddWithValue("Description", otherTransaction.Description);
                            cmd.Parameters.AddWithValue("NetWeigth", otherTransaction.NetWeigth ?? default(double));
                            cmd.Parameters.AddWithValue("Quantity", otherTransaction.Quantity ?? default(double));

                            #region AddWasteCode
                            if (otherTransaction.WasteCode != null)
                            {
                                cmd.Parameters.AddWithValue("WasteCode", otherTransaction.WasteCode.Oid);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("WasteCode", DBNull.Value);
                            }
                            #endregion

                            #region AddUnitset
                            if (otherTransaction.Unitset != null)
                            {
                                cmd.Parameters.AddWithValue("Unitset", otherTransaction.Unitset.Oid);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("Unitset", DBNull.Value);
                            }
                            #endregion

                            #region AddPackingGroup
                            if (otherTransaction.PackingGroup != null)
                            {
                                cmd.Parameters.AddWithValue("PackingGroup", otherTransaction.PackingGroup.Oid);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("PackingGroup", DBNull.Value);
                            }
                            #endregion

                            #region AddPackagingTypes
                            if (otherTransaction.PackagingTypes != null)
                            {
                                cmd.Parameters.AddWithValue("PackagingTypes", otherTransaction.PackagingTypes.Oid);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("PackagingTypes", DBNull.Value);
                            }
                            #endregion

                            #region AddHazardousGoodsLabel
                            if (otherTransaction.HazardousGoodsLabel != null)
                            {
                                cmd.Parameters.AddWithValue("HazardousGoodsLabel", otherTransaction.HazardousGoodsLabel.Oid);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("HazardousGoodsLabel", DBNull.Value);
                            }
                            #endregion

                            #region AddHazardousGoodsClass
                            if (otherTransaction.HazardousGoodsClass != null)
                            {
                                cmd.Parameters.AddWithValue("HazardousGoodsClass", otherTransaction.HazardousGoodsClass.Oid);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("HazardousGoodsClass", DBNull.Value);
                            }
                            #endregion

                            #region AddHazardousGoods
                            if (otherTransaction.HazardousGoods != null)
                            {
                                cmd.Parameters.AddWithValue("HazardousGoods", otherTransaction.HazardousGoods.Oid);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("HazardousGoods", DBNull.Value);
                            }
                            #endregion

                            #region AddTransportDocument
                            if (otherTransaction.TransportDocument != null)
                            {
                                cmd.Parameters.AddWithValue("TransportDocument", otherTransaction.TransportDocument.Oid);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("TransportDocument", DBNull.Value);
                            }
                            #endregion


                            var oid = cmd.ExecuteScalar();
                            cnn.Close();

                            result.Data = otherTransaction.Oid;
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