using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace iyibir.TMGD.WebAPI.Models
{
    public partial class CustomerInventory
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public DataResult GetObjectByCustomerAndInventoryCode(string inventoryCode, string customerCode)
        {
            DataResult result = new DataResult();

            try
            {
                List<CustomerInventory> items = new List<CustomerInventory>();
                string commandString = string.Format("SELECT * FROM CustomerInventory WHERE InventoryCode = '{0}' AND Customer = '{1}'", inventoryCode, ((List<Customer>)new Customer().GetObjectByCode(customerCode).Data).FirstOrDefault().Oid);
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            CustomerInventory inventory = new CustomerInventory();
                            inventory.Oid = Guid.Parse(rdr["Oid"].ToString());
                            inventory.InventoryCode = string.IsNullOrEmpty(rdr["InventoryCode"].ToString()) ? string.Empty : rdr["InventoryCode"].ToString();
                            inventory.InventoryName = string.IsNullOrEmpty(rdr["InventoryName"].ToString()) ? string.Empty : rdr["InventoryName"].ToString();
                            inventory.LastYearIntakeUnit = string.IsNullOrEmpty(rdr["LastYearIntakeUnit"].ToString()) ? string.Empty : rdr["LastYearIntakeUnit"].ToString();
                            inventory.MSDSName = string.IsNullOrEmpty(rdr["MSDSName"].ToString()) ? string.Empty : rdr["MSDSName"].ToString();
                            inventory.PackagingQuantityUnit = string.IsNullOrEmpty(rdr["PackagingQuantityUnit"].ToString()) ? string.Empty : rdr["PackagingQuantityUnit"].ToString();
                            inventory.Shipper = string.IsNullOrEmpty(rdr["Shipper"].ToString()) ? string.Empty : rdr["Shipper"].ToString();
                            inventory.Supplier = string.IsNullOrEmpty(rdr["Supplier"].ToString()) ? string.Empty : rdr["Supplier"].ToString();

                            inventory.Unloader = rdr["Unloader"] == DBNull.Value ? false : (bool)rdr["Unloader"];
                            inventory.TankContainer = rdr["TankContainer"] == DBNull.Value ? false : (bool)rdr["TankContainer"];
                            inventory.Packer = rdr["Packer"] == DBNull.Value ? false : (bool)rdr["Packer"];
                            inventory.Loader = rdr["Loader"] == DBNull.Value ? false : (bool)rdr["Loader"];
                            inventory.IsWaste = rdr["IsWaste"] == DBNull.Value ? false : (bool)rdr["IsWaste"];
                            inventory.Filler = rdr["Filler"] == DBNull.Value ? false : (bool)rdr["Filler"];
                            inventory.Carrier = rdr["Carrier"] == DBNull.Value ? false : (bool)rdr["Carrier"];
                            inventory.Consignee = rdr["Consignee"] == DBNull.Value ? false : (bool)rdr["Consignee"];
                            inventory.Consignor = rdr["Consignor"] == DBNull.Value ? false : (bool)rdr["Consignor"];

                            //.Customer = (Customer)new Customer().GetObjectByCode(customerCode).Data;
                            inventory.Customer = rdr["Customer"] == DBNull.Value ? null : ((List<Customer>)new Customer().GetObjectById(Guid.Parse(rdr["Customer"].ToString())).Data).FirstOrDefault();
                            inventory.PackingGroup = rdr["PackingGroup"] == DBNull.Value ? null : ((List<PackingGroup>)new PackingGroup().GetObjectById(Guid.Parse(rdr["PackingGroup"].ToString())).Data).FirstOrDefault();
                            inventory.PackagingTypes = rdr["PackagingTypes"] == DBNull.Value ? null : ((List<PackagingTypes>)new PackagingTypes().GetObjectById(Guid.Parse(rdr["PackagingTypes"].ToString())).Data).FirstOrDefault();
                            inventory.FactoryDepartment = rdr["FactoryDepartment"] == DBNull.Value ? null : ((List<FactoryDepartment>)new FactoryDepartment().GetObjectById(Guid.Parse(rdr["FactoryDepartment"].ToString())).Data).FirstOrDefault();
                            //inventory.DefaultLabel1 = rdr["DefaultLabel1"] == DBNull.Value ? null : ((List<DefaultLabel>)new DefaultLabel().GetObjectById(Guid.Parse(rdr["DefaultLabel1"].ToString())).Data).FirstOrDefault();
                            //inventory.DefaultLabel2 = rdr["DefaultLabel2"] == DBNull.Value ? null : ((List<DefaultLabel>)new DefaultLabel().GetObjectById(Guid.Parse(rdr["DefaultLabel2"].ToString())).Data).FirstOrDefault();
                            //inventory.DefaultLabel3 = rdr["DefaultLabel3"] == DBNull.Value ? null : ((List<DefaultLabel>)new DefaultLabel().GetObjectById(Guid.Parse(rdr["DefaultLabel3"].ToString())).Data).FirstOrDefault();
                            //inventory.DefaultLabel4 = rdr["DefaultLabel4"] == DBNull.Value ? null : ((List<DefaultLabel>)new DefaultLabel().GetObjectById(Guid.Parse(rdr["DefaultLabel4"].ToString())).Data).FirstOrDefault();
                            inventory.HazardousGoods = rdr["HazardousGoods"] == DBNull.Value ? null : ((List<HazardousGoods>)new HazardousGoods().GetObjectById(Guid.Parse(rdr["HazardousGoods"].ToString())).Data).FirstOrDefault();

                            items.Add(inventory);
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
        public DataResult GetObjects()
        {
            DataResult result = new DataResult();

            try
            {
                List<CustomerInventory> items = new List<CustomerInventory>();
                string commandString = string.Format("SELECT * FROM CustomerInventory");
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            CustomerInventory inventory = new CustomerInventory();
                            inventory.Oid = Guid.Parse(rdr["Oid"].ToString());
                            inventory.InventoryCode = string.IsNullOrEmpty(rdr["InventoryCode"].ToString()) ? string.Empty : rdr["InventoryCode"].ToString();
                            inventory.InventoryName = string.IsNullOrEmpty(rdr["InventoryName"].ToString()) ? string.Empty : rdr["InventoryName"].ToString();
                            inventory.LastYearIntakeUnit = string.IsNullOrEmpty(rdr["LastYearIntakeUnit"].ToString()) ? string.Empty : rdr["LastYearIntakeUnit"].ToString();
                            inventory.MSDSName = string.IsNullOrEmpty(rdr["MSDSName"].ToString()) ? string.Empty : rdr["MSDSName"].ToString();
                            inventory.PackagingQuantityUnit = string.IsNullOrEmpty(rdr["PackagingQuantityUnit"].ToString()) ? string.Empty : rdr["PackagingQuantityUnit"].ToString();
                            inventory.Shipper = string.IsNullOrEmpty(rdr["Shipper"].ToString()) ? string.Empty : rdr["Shipper"].ToString();
                            inventory.Supplier = string.IsNullOrEmpty(rdr["Supplier"].ToString()) ? string.Empty : rdr["Supplier"].ToString();
                            inventory.Unloader = rdr["Unloader"] == DBNull.Value ? false : (bool)rdr["Unloader"];
                            inventory.TankContainer = rdr["TankContainer"] == DBNull.Value ? false : (bool)rdr["TankContainer"];
                            inventory.Packer = rdr["Packer"] == DBNull.Value ? false : (bool)rdr["Packer"];
                            inventory.Loader = rdr["Loader"] == DBNull.Value ? false : (bool)rdr["Loader"];
                            inventory.IsWaste = rdr["IsWaste"] == DBNull.Value ? false : (bool)rdr["IsWaste"];
                            inventory.Filler = rdr["Filler"] == DBNull.Value ? false : (bool)rdr["Filler"];
                            inventory.Carrier = rdr["Carrier"] == DBNull.Value ? false : (bool)rdr["Carrier"];
                            inventory.Consignee = rdr["Consignee"] == DBNull.Value ? false : (bool)rdr["Consignee"];
                            inventory.Consignor = rdr["Consignor"] == DBNull.Value ? false : (bool)rdr["Consignor"];
                            inventory.Customer = rdr["Customer"] == DBNull.Value ? null : (Customer)new Customer().GetObjectById(Guid.Parse(rdr["Customer"].ToString())).Data;
                            inventory.PackingGroup = rdr["PackingGroup"] == DBNull.Value ? null : (PackingGroup)new PackingGroup().GetObjectById(Guid.Parse(rdr["PackingGroup"].ToString())).Data;
                            inventory.PackagingTypes = rdr["PackagingTypes"] == DBNull.Value ? null : (PackagingTypes)new PackagingTypes().GetObjectById(Guid.Parse(rdr["PackagingTypes"].ToString())).Data;
                            inventory.FactoryDepartment = rdr["FactoryDepartment"] == DBNull.Value ? null : (FactoryDepartment)new FactoryDepartment().GetObjectById(Guid.Parse(rdr["FactoryDepartment"].ToString())).Data;
                            inventory.DefaultLabel1 = rdr["DefaultLabel1"] == DBNull.Value ? null : (DefaultLabel)new DefaultLabel().GetObjectById(Guid.Parse(rdr["DefaultLabel1"].ToString())).Data;
                            inventory.DefaultLabel2 = rdr["DefaultLabel2"] == DBNull.Value ? null : (DefaultLabel)new DefaultLabel().GetObjectById(Guid.Parse(rdr["DefaultLabel2"].ToString())).Data;
                            inventory.DefaultLabel3 = rdr["DefaultLabel3"] == DBNull.Value ? null : (DefaultLabel)new DefaultLabel().GetObjectById(Guid.Parse(rdr["DefaultLabel3"].ToString())).Data;
                            inventory.DefaultLabel4 = rdr["DefaultLabel4"] == DBNull.Value ? null : (DefaultLabel)new DefaultLabel().GetObjectById(Guid.Parse(rdr["DefaultLabel4"].ToString())).Data;
                            inventory.HazardousGoods = rdr["HazardousGoods"] == DBNull.Value ? null : (HazardousGoods)new HazardousGoods().GetObjectById(Guid.Parse(rdr["HazardousGoods"].ToString())).Data;

                            items.Add(inventory);
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