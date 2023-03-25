using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace iyibir.TMGD.WebAPI.Models
{
    public partial class CustomerWasteInventory
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public DataResult GetObjectById(Guid Oid)
        {
            DataResult result = new DataResult();
            try
            {
                List<CustomerWasteInventory> items = new List<CustomerWasteInventory>();
                string commandString = string.Format("SELECT * FROM CustomerWasteInventory WHERE Oid = '{0}'", Oid);
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            CustomerWasteInventory wasteInventory = new CustomerWasteInventory();
                            wasteInventory.Oid = Guid.Parse(dr["Oid"].ToString());
                            wasteInventory.AdrStatus = dr["AdrStatus"] == DBNull.Value ? default(int) : (int)dr["AdrStatus"];
                            wasteInventory.MSDSName = string.IsNullOrEmpty(dr["MSDSName"].ToString()) ? string.Empty : dr["MSDSName"].ToString();
                            wasteInventory.WasteName = string.IsNullOrEmpty(dr["WasteName"].ToString()) ? string.Empty : dr["WasteName"].ToString();
                            wasteInventory.Shipper = string.IsNullOrEmpty(dr["Shipper"].ToString()) ? string.Empty : dr["Shipper"].ToString();
                            wasteInventory.DisposalFirm = string.IsNullOrEmpty(dr["DisposalFirm"].ToString()) ? string.Empty : dr["DisposalFirm"].ToString();
                            wasteInventory.Description = string.IsNullOrEmpty(dr["Description"].ToString()) ? string.Empty : dr["Description"].ToString();
                            wasteInventory.Customer = dr["Customer"] == DBNull.Value ? null : ((List<Customer>)new Customer().GetObjectById(Guid.Parse(dr["Customer"].ToString())).Data).FirstOrDefault();
                            wasteInventory.HazardousGoods = dr["HazardousGoods"] == DBNull.Value ? null : ((List<HazardousGoods>)new HazardousGoods().GetObjectById(Guid.Parse(dr["HazardousGoods"].ToString())).Data).FirstOrDefault();
                            wasteInventory.PackagingTypes = dr["PackagingTypes"] == DBNull.Value ? null : ((List<PackagingTypes>)new PackagingTypes().GetObjectById(Guid.Parse(dr["PackagingTypes"].ToString())).Data).FirstOrDefault();
                            wasteInventory.PackingGroup = dr["PackingGroup"] == DBNull.Value ? null : ((List<PackingGroup>)new PackingGroup().GetObjectById(Guid.Parse(dr["PackingGroup"].ToString())).Data).FirstOrDefault();
                            wasteInventory.WasteCode = dr["WasteCode"] == DBNull.Value ? null : ((List<WasteList>)new WasteList().GetObjectById(Guid.Parse(dr["WasteCode"].ToString())).Data).FirstOrDefault();
                            wasteInventory.WastePhysicalState = dr["WastePhysicalState"] == DBNull.Value ? null : ((List<WastePhysicalState>)new WastePhysicalState().GetObjectById(Guid.Parse(dr["WastePhysicalState"].ToString())).Data).FirstOrDefault();
                            items.Add(wasteInventory);
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
                List<CustomerWasteInventory> items = new List<CustomerWasteInventory>();
                string commandString = string.Format("SELECT * FROM CustomerWasteInventory");
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            CustomerWasteInventory wasteInventory = new CustomerWasteInventory();
                            wasteInventory.Oid = Guid.Parse(dr["Oid"].ToString());
                            wasteInventory.AdrStatus = dr["AdrStatus"] == DBNull.Value ? default(int) : (int)dr["AdrStatus"];
                            wasteInventory.MSDSName = string.IsNullOrEmpty(dr["MSDSName"].ToString()) ? string.Empty : dr["MSDSName"].ToString();
                            wasteInventory.WasteName = string.IsNullOrEmpty(dr["WasteName"].ToString()) ? string.Empty : dr["WasteName"].ToString();
                            wasteInventory.Shipper = string.IsNullOrEmpty(dr["Shipper"].ToString()) ? string.Empty : dr["Shipper"].ToString();
                            wasteInventory.DisposalFirm = string.IsNullOrEmpty(dr["DisposalFirm"].ToString()) ? string.Empty : dr["DisposalFirm"].ToString();
                            wasteInventory.Description = string.IsNullOrEmpty(dr["Description"].ToString()) ? string.Empty : dr["Description"].ToString();
                            wasteInventory.Customer = dr["Customer"] == DBNull.Value ? null : ((List<Customer>)new Customer().GetObjectById(Guid.Parse(dr["Customer"].ToString())).Data).FirstOrDefault();
                            wasteInventory.HazardousGoods = dr["HazardousGoods"] == DBNull.Value ? null : ((List<HazardousGoods>)new HazardousGoods().GetObjectById(Guid.Parse(dr["HazardousGoods"].ToString())).Data).FirstOrDefault();
                            wasteInventory.PackagingTypes = dr["PackagingTypes"] == DBNull.Value ? null : ((List<PackagingTypes>)new PackagingTypes().GetObjectById(Guid.Parse(dr["PackagingTypes"].ToString())).Data).FirstOrDefault();
                            wasteInventory.PackingGroup = dr["PackingGroup"] == DBNull.Value ? null : ((List<PackingGroup>)new PackingGroup().GetObjectById(Guid.Parse(dr["PackingGroup"].ToString())).Data).FirstOrDefault();
                            wasteInventory.WasteCode = dr["WasteCode"] == DBNull.Value ? null : ((List<WasteList>)new WasteList().GetObjectById(Guid.Parse(dr["WasteCode"].ToString())).Data).FirstOrDefault();
                            wasteInventory.WastePhysicalState = dr["WastePhysicalState"] == DBNull.Value ? null : ((List<WastePhysicalState>)new WastePhysicalState().GetObjectById(Guid.Parse(dr["WastePhysicalState"].ToString())).Data).FirstOrDefault();
                            items.Add(wasteInventory);
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

        public DataResult GetObjectByCustomerAndWasteCode(string customerCode, string wasteCode)
        {
            DataResult result = new DataResult();

            try
            {
                List<CustomerWasteInventory> items = new List<CustomerWasteInventory>();
                string commandString = string.Format("SELECT * FROM CustomerWasteInventory WHERE Customer = '{0}' AND WasteCode = '{1}'", ((List<Customer>)new Customer().GetObjectByCode(customerCode).Data).FirstOrDefault().Oid, ((List<WasteList>)new WasteList().GetObjectByCode(wasteCode).Data).FirstOrDefault().Oid);
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            CustomerWasteInventory wasteInventory = new CustomerWasteInventory();
                            wasteInventory.Oid = Guid.Parse(dr["Oid"].ToString());
                            wasteInventory.AdrStatus = dr["AdrStatus"] == DBNull.Value ? default(int) : (int)dr["AdrStatus"];
                            wasteInventory.MSDSName = string.IsNullOrEmpty(dr["MSDSName"].ToString()) ? string.Empty : dr["MSDSName"].ToString();
                            wasteInventory.WasteName = string.IsNullOrEmpty(dr["WasteName"].ToString()) ? string.Empty : dr["WasteName"].ToString();
                            wasteInventory.Shipper = string.IsNullOrEmpty(dr["Shipper"].ToString()) ? string.Empty : dr["Shipper"].ToString();
                            wasteInventory.DisposalFirm = string.IsNullOrEmpty(dr["DisposalFirm"].ToString()) ? string.Empty : dr["DisposalFirm"].ToString();
                            wasteInventory.Description = string.IsNullOrEmpty(dr["Description"].ToString()) ? string.Empty : dr["Description"].ToString();
                            wasteInventory.Customer = dr["Customer"] == DBNull.Value ? null : ((List<Customer>)new Customer().GetObjectById(Guid.Parse(dr["Customer"].ToString())).Data).FirstOrDefault();
                            wasteInventory.HazardousGoods = dr["HazardousGoods"] == DBNull.Value ? null : ((List<HazardousGoods>)new HazardousGoods().GetObjectById(Guid.Parse(dr["HazardousGoods"].ToString())).Data).FirstOrDefault();
                            wasteInventory.PackagingTypes = dr["PackagingTypes"] == DBNull.Value ? null : ((List<PackagingTypes>)new PackagingTypes().GetObjectById(Guid.Parse(dr["PackagingTypes"].ToString())).Data).FirstOrDefault();
                            wasteInventory.PackingGroup = dr["PackingGroup"] == DBNull.Value ? null : ((List<PackingGroup>)new PackingGroup().GetObjectById(Guid.Parse(dr["PackingGroup"].ToString())).Data).FirstOrDefault();
                            wasteInventory.WasteCode = dr["WasteCode"] == DBNull.Value ? null : ((List<WasteList>)new WasteList().GetObjectById(Guid.Parse(dr["WasteCode"].ToString())).Data).FirstOrDefault();
                            wasteInventory.WastePhysicalState = dr["WastePhysicalState"] == DBNull.Value ? null : ((List<WastePhysicalState>)new WastePhysicalState().GetObjectById(Guid.Parse(dr["WastePhysicalState"].ToString())).Data).FirstOrDefault();
                            items.Add(wasteInventory);
                        }
                    }
                }

                result.Data = items;
                result.Result = true;
                result.Message = "Success";
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