using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace iyibir.TMGD.WebAPIV2.Models
{
    public partial class TransportDocument
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public DataResult GetObjectById(Guid Oid)
        {
            DataResult result = new DataResult();
            try
            {
                List<TransportDocument> items = new List<TransportDocument>();
                string commandString = string.Format("SELECT * FROM TransportDocument WHERE Oid = '{0}'", Oid);
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            TransportDocument transport = new TransportDocument();
                            transport.Oid = Guid.Parse(dr["Oid"].ToString());
                            transport.Code = string.IsNullOrEmpty(dr["Code"].ToString()) ? string.Empty : dr["Code"].ToString();
                            transport.Consignee = dr["Consignee"] == DBNull.Value ? null : ((List<Consignee>)new Consignee().GetObjectById(Guid.Parse(dr["Consignee"].ToString())).Data).FirstOrDefault();
                            transport.ConsigneeAddress = string.IsNullOrEmpty(dr["ConsigneeAddress"].ToString()) ? string.Empty : dr["ConsigneeAddress"].ToString();
                            transport.ConsigneeTaxNumber = string.IsNullOrEmpty(dr["ConsigneeTaxNumber"].ToString()) ? string.Empty : dr["ConsigneeTaxNumber"].ToString();
                            transport.ConsigneeTaxOffice = string.IsNullOrEmpty(dr["ConsigneeTaxOffice"].ToString()) ? string.Empty : dr["ConsigneeTaxOffice"].ToString();
                            transport.Consigner = dr["Consigner"] == DBNull.Value ? null : ((List<Customer>)new Customer().GetObjectById(Guid.Parse(dr["Consigner"].ToString())).Data).FirstOrDefault();
                            transport.ConsignerAddress = string.IsNullOrEmpty(dr["ConsignerAddress"].ToString()) ? string.Empty : dr["ConsignerAddress"].ToString();
                            transport.ConsignerTaxNumber = string.IsNullOrEmpty(dr["ConsignerTaxNumber"].ToString()) ? string.Empty : dr["ConsignerTaxNumber"].ToString();
                            transport.ConsignerTaxOffice = string.IsNullOrEmpty(dr["ConsignerTaxOffice"].ToString()) ? string.Empty : dr["ConsignerTaxOffice"].ToString();
                            transport.CreatedDate = dr["CreatedDate"] == DBNull.Value ? default(DateTime) : (DateTime)dr["CreatedDate"];
                            //transport.CreatedTime = TimeSpan.Parse(dr["CreatedTime"].ToString());
                            transport.Description = string.IsNullOrEmpty(dr["Description"].ToString()) ? string.Empty : dr["Description"].ToString();
                            transport.Driver = dr["Driver"] == DBNull.Value ? null : ((List<VehicleDriver>)new VehicleDriver().GetObjectById(Guid.Parse(dr["Driver"].ToString())).Data).FirstOrDefault();
                            transport.IsSpecial = dr["IsSpecial"] == DBNull.Value ? false : (bool)dr["IsSpecial"];
                            transport.Owner = dr["Owner"] == DBNull.Value ? null : ((List<Employee>)new Employee().GetObjectById(Guid.Parse(dr["Owner"].ToString())).Data).FirstOrDefault();
                            transport.ScoreQuantity = dr["ScoreQuantity"] == DBNull.Value ? default(double) : (double)dr["ScoreQuantity"];
                            transport.Shipper = dr["Shipper"] == DBNull.Value ? null : ((List<Consignee>)new Consignee().GetObjectById(Guid.Parse(dr["Shipper"].ToString())).Data).FirstOrDefault();
                            transport.SpecialShipper = string.IsNullOrEmpty(dr["SpecialShipper"].ToString()) ? string.Empty : dr["SpecialShipper"].ToString();
                            transport.TransportCategory = string.IsNullOrEmpty(dr["TransportCategory"].ToString()) ? string.Empty : dr["TransportCategory"].ToString();
                            transport.TransportDocumentType = dr["TransportDocumentType"] == DBNull.Value ? default(int) : (int)dr["TransportDocumentType"];
                            transport.TunnelCode = string.IsNullOrEmpty(dr["TunnelCode"].ToString()) ? string.Empty : dr["TunnelCode"].ToString();
                            transport.Vehicle = dr["Vehicle"] == DBNull.Value ? null : ((List<Vehicle>)new Vehicle().GetObjectById(Guid.Parse(dr["Vehicle"].ToString())).Data).FirstOrDefault();

                            items.Add(transport);
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
                List<TransportDocument> items = new List<TransportDocument>();
                string commandString = string.Format("SELECT * FROM TransportDocument");
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            TransportDocument transport = new TransportDocument();
                            transport.Oid = Guid.Parse(dr["Oid"].ToString());
                            transport.Code = string.IsNullOrEmpty(dr["Code"].ToString()) ? string.Empty : dr["Code"].ToString();
                            transport.Consignee = dr["Consignee"] == DBNull.Value ? null : ((List<Consignee>)new Consignee().GetObjectById(Guid.Parse(dr["Consignee"].ToString())).Data).FirstOrDefault();
                            transport.ConsigneeAddress = string.IsNullOrEmpty(dr["ConsigneeAddress"].ToString()) ? string.Empty : dr["ConsigneeAddress"].ToString();
                            transport.ConsigneeTaxNumber = string.IsNullOrEmpty(dr["ConsigneeTaxNumber"].ToString()) ? string.Empty : dr["ConsigneeTaxNumber"].ToString();
                            transport.ConsigneeTaxOffice = string.IsNullOrEmpty(dr["ConsigneeTaxOffice"].ToString()) ? string.Empty : dr["ConsigneeTaxOffice"].ToString();
                            transport.Consigner = dr["Consigner"] == DBNull.Value ? null : ((List<Customer>)new Customer().GetObjectById(Guid.Parse(dr["Consigner"].ToString())).Data).FirstOrDefault();
                            transport.ConsignerAddress = string.IsNullOrEmpty(dr["ConsignerAddress"].ToString()) ? string.Empty : dr["ConsignerAddress"].ToString();
                            transport.ConsignerTaxNumber = string.IsNullOrEmpty(dr["ConsignerTaxNumber"].ToString()) ? string.Empty : dr["ConsignerTaxNumber"].ToString();
                            transport.ConsignerTaxOffice = string.IsNullOrEmpty(dr["ConsignerTaxOffice"].ToString()) ? string.Empty : dr["ConsignerTaxOffice"].ToString();
                            transport.CreatedDate = dr["CreatedDate"] == DBNull.Value ? default(DateTime) : (DateTime)dr["CreatedDate"];
                            transport.CreatedTime = TimeSpan.Parse(dr["CreatedTime"].ToString());
                            transport.Description = string.IsNullOrEmpty(dr["Description"].ToString()) ? string.Empty : dr["Description"].ToString();
                            transport.Driver = dr["Driver"] == DBNull.Value ? null : ((List<VehicleDriver>)new VehicleDriver().GetObjectById(Guid.Parse(dr["Driver"].ToString())).Data).FirstOrDefault();
                            transport.Owner = dr["Owner"] == DBNull.Value ? null : ((List<Employee>)new Employee().GetObjectById(Guid.Parse(dr["Owner"].ToString())).Data).FirstOrDefault();
                            transport.ScoreQuantity = dr["ScoreQuantity"] == DBNull.Value ? default(double) : (double)dr["ScoreQuantity"];
                            transport.Shipper = dr["Shipper"] == DBNull.Value ? null : ((List<Consignee>)new Consignee().GetObjectById(Guid.Parse(dr["Shipper"].ToString())).Data).FirstOrDefault();
                            transport.SpecialShipper = string.IsNullOrEmpty(dr["SpecialShipper"].ToString()) ? string.Empty : dr["SpecialShipper"].ToString();
                            transport.TransportCategory = string.IsNullOrEmpty(dr["TransportCategory"].ToString()) ? string.Empty : dr["TransportCategory"].ToString();
                            transport.TransportDocumentType = dr["TransportDocumentType"] == DBNull.Value ? default(int) : (int)dr["TransportDocumentType"];
                            transport.TunnelCode = string.IsNullOrEmpty(dr["TunnelCode"].ToString()) ? string.Empty : dr["TunnelCode"].ToString();
                            transport.Vehicle = dr["Vehicle"] == DBNull.Value ? null : ((List<Vehicle>)new Vehicle().GetObjectById(Guid.Parse(dr["Vehicle"].ToString())).Data).FirstOrDefault();
                            transport.IsSpecial = dr["IsSpecial"] == DBNull.Value ? false : (bool)dr["IsSpecial"];

                            items.Add(transport);
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

        public DataResult GetObjectByCode(Guid customerOid)
        {
            DataResult result = new DataResult();
            try
            {
                List<TransportDocument> items = new List<TransportDocument>();
                string commandString = string.Format("SELECT * FROM TransportDocument WHERE Consignee = '{0}'",customerOid);
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            TransportDocument transport = new TransportDocument();
                            transport.Oid = Guid.Parse(dr["Oid"].ToString());
                            transport.Code = string.IsNullOrEmpty(dr["Code"].ToString()) ? string.Empty : dr["Code"].ToString();
                            transport.Consignee = dr["Consignee"] == DBNull.Value ? null : ((List<Consignee>)new Consignee().GetObjectById(Guid.Parse(dr["Consignee"].ToString())).Data).FirstOrDefault();
                            transport.ConsigneeAddress = string.IsNullOrEmpty(dr["ConsigneeAddress"].ToString()) ? string.Empty : dr["ConsigneeAddress"].ToString();
                            transport.ConsigneeTaxNumber = string.IsNullOrEmpty(dr["ConsigneeTaxNumber"].ToString()) ? string.Empty : dr["ConsigneeTaxNumber"].ToString();
                            transport.ConsigneeTaxOffice = string.IsNullOrEmpty(dr["ConsigneeTaxOffice"].ToString()) ? string.Empty : dr["ConsigneeTaxOffice"].ToString();
                            transport.Consigner = dr["Consigner"] == DBNull.Value ? null : ((List<Customer>)new Customer().GetObjectById(Guid.Parse(dr["Consigner"].ToString())).Data).FirstOrDefault();
                            transport.ConsignerAddress = string.IsNullOrEmpty(dr["ConsignerAddress"].ToString()) ? string.Empty : dr["ConsignerAddress"].ToString();
                            transport.ConsignerTaxNumber = string.IsNullOrEmpty(dr["ConsignerTaxNumber"].ToString()) ? string.Empty : dr["ConsignerTaxNumber"].ToString();
                            transport.ConsignerTaxOffice = string.IsNullOrEmpty(dr["ConsignerTaxOffice"].ToString()) ? string.Empty : dr["ConsignerTaxOffice"].ToString();
                            transport.CreatedDate = dr["CreatedDate"] == DBNull.Value ? default(DateTime) : (DateTime)dr["CreatedDate"];
                            transport.CreatedTime = TimeSpan.Parse(dr["CreatedTime"].ToString());
                            transport.Description = string.IsNullOrEmpty(dr["Description"].ToString()) ? string.Empty : dr["Description"].ToString();
                            transport.Driver = dr["Driver"] == DBNull.Value ? null : ((List<VehicleDriver>)new VehicleDriver().GetObjectById(Guid.Parse(dr["Driver"].ToString())).Data).FirstOrDefault();
                            transport.Owner = dr["Owner"] == DBNull.Value ? null : ((List<Employee>)new Employee().GetObjectById(Guid.Parse(dr["Owner"].ToString())).Data).FirstOrDefault();
                            transport.ScoreQuantity = dr["ScoreQuantity"] == DBNull.Value ? default(double) : (double)dr["ScoreQuantity"];
                            transport.Shipper = dr["Shipper"] == DBNull.Value ? null : ((List<Consignee>)new Consignee().GetObjectById(Guid.Parse(dr["Shipper"].ToString())).Data).FirstOrDefault();
                            transport.SpecialShipper = string.IsNullOrEmpty(dr["SpecialShipper"].ToString()) ? string.Empty : dr["SpecialShipper"].ToString();
                            transport.TransportCategory = string.IsNullOrEmpty(dr["TransportCategory"].ToString()) ? string.Empty : dr["TransportCategory"].ToString();
                            transport.TransportDocumentType = dr["TransportDocumentType"] == DBNull.Value ? default(int) : (int)dr["TransportDocumentType"];
                            transport.TunnelCode = string.IsNullOrEmpty(dr["TunnelCode"].ToString()) ? string.Empty : dr["TunnelCode"].ToString();
                            transport.Vehicle = dr["Vehicle"] == DBNull.Value ? null : ((List<Vehicle>)new Vehicle().GetObjectById(Guid.Parse(dr["Vehicle"].ToString())).Data).FirstOrDefault();
                            transport.IsSpecial = dr["IsSpecial"] == DBNull.Value ? false : (bool)dr["IsSpecial"];

                            items.Add(transport);
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
        public DataResult InsertObject(TransportDocument transportDocument)
        {
            DataResult result = new DataResult();

            try
            {
                if (transportDocument != null)
                {
                    string commandString = string.Format(@"
                    INSERT INTO TransportDocument
                    (
                    Oid,
                    Code, 
                    CreatedDate, 
                    Owner, 
                    Consigner, 
                    ConsignerTaxOffice, 
                    ConsignerTaxNumber, 
                    ConsignerAddress, 
                    Consignee, 
                    ConsigneeTaxOffice, 
                    ConsigneeTaxNumber, 
                    ConsigneeAddress, 
                    Vehicle, 
                    Driver, 
                    TransportCategory, 
                    ScoreQuantity, 
                    TunnelCode, 
                    Description, 
                    TransportDocumentType, 
                    IsSpecial, 
                    Shipper, 
                    SpecialShipper)
                    VALUES
                    (
                    @Oid,
                    @Code, 
                    @CreatedDate, 
                    @Owner, 
                    @Consigner, 
                    @ConsignerTaxOffice, 
                    @ConsignerTaxNumber, 
                    @ConsignerAddress, 
                    @Consignee, 
                    @ConsigneeTaxOffice, 
                    @ConsigneeTaxNumber, 
                    @ConsigneeAddress, 
                    @Vehicle, 
                    @Driver, 
                    @TransportCategory, 
                    @ScoreQuantity, 
                    @TunnelCode, 
                    @Description, 
                    @TransportDocumentType, 
                    @IsSpecial, 
                    @Shipper, 
                    @SpecialShipper); SELECT SCOPE_IDENTITY();");

                    using (SqlConnection cnn = new SqlConnection(connectionString))
                    {
                        cnn.Open();
                        using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                        {
                            cmd.Parameters.AddWithValue("Oid", transportDocument.Oid);
                            cmd.Parameters.AddWithValue("Code", transportDocument.Code);
                            cmd.Parameters.AddWithValue("CreatedDate", transportDocument.CreatedDate ?? default(DateTime));
                            //cmd.Parameters.AddWithValue("CreatedTime", transportDocument.CreatedTime ?? default(TimeSpan));

                            #region AddOwner
                            if (transportDocument.Owner != null)
                            {
                                cmd.Parameters.AddWithValue("Owner", transportDocument.Owner.Oid);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("Owner", DBNull.Value);
                            }
                            #endregion

                            #region AddConsigner
                            if (transportDocument.Consigner != null)
                            {
                                cmd.Parameters.AddWithValue("Consigner", transportDocument.Consigner.Oid);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("Consigner", DBNull.Value);
                            }
                            #endregion

                            cmd.Parameters.AddWithValue("ConsignerAddress", transportDocument.ConsignerAddress);
                            cmd.Parameters.AddWithValue("ConsignerTaxNumber", transportDocument.ConsignerTaxNumber);
                            cmd.Parameters.AddWithValue("ConsignerTaxOffice", transportDocument.ConsignerTaxOffice);

                            #region AddConsignee
                            if (transportDocument.Consignee != null)
                            {
                                cmd.Parameters.AddWithValue("Consignee", transportDocument.Consignee.Oid);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("Consignee", DBNull.Value);
                            }
                            #endregion

                            cmd.Parameters.AddWithValue("ConsigneeAddress", transportDocument.ConsigneeAddress);
                            cmd.Parameters.AddWithValue("ConsigneeTaxNumber", transportDocument.ConsigneeTaxNumber);
                            cmd.Parameters.AddWithValue("ConsigneeTaxOffice", transportDocument.ConsigneeTaxOffice);

                            #region AddVehicle
                            if (transportDocument.Vehicle != null)
                            {
                                cmd.Parameters.AddWithValue("Vehicle", transportDocument.Vehicle.Oid);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("Vehicle", DBNull.Value);
                            }
                            #endregion

                            #region AddDriver
                            if (transportDocument.Driver != null)
                            {
                                cmd.Parameters.AddWithValue("Driver", transportDocument.Driver.Oid);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("Driver", DBNull.Value);
                            }
                            #endregion

                            cmd.Parameters.AddWithValue("TransportCategory", transportDocument.TransportCategory);
                            cmd.Parameters.AddWithValue("ScoreQuantity", transportDocument.ScoreQuantity ?? default(double));
                            cmd.Parameters.AddWithValue("TunnelCode", transportDocument.TunnelCode);
                            cmd.Parameters.AddWithValue("Description", transportDocument.Description);
                            cmd.Parameters.AddWithValue("TransportDocumentType", transportDocument.TransportDocumentType ?? default(int));
                            cmd.Parameters.AddWithValue("IsSpecial", transportDocument.IsSpecial);

                            #region AddShipper
                            if (transportDocument.Shipper != null)
                            {
                                cmd.Parameters.AddWithValue("Shipper", transportDocument.Shipper.Oid);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("Shipper", DBNull.Value);
                            }
                            #endregion

                            cmd.Parameters.AddWithValue("SpecialShipper", transportDocument.SpecialShipper);

                            cmd.ExecuteNonQuery();
                            cnn.Close();

                            result.Data = transportDocument.Oid;
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