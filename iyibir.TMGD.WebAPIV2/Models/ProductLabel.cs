using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace iyibir.TMGD.WebAPIV2.Models
{
    public partial class ProductLabel
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public DataResult InsertObject(ProductLabel productLabel)
        {
            DataResult result = new DataResult();

            try
            {
                if (productLabel != null)
                {
                    string commandString = string.Format(@"
                    INSERT INTO ProductLabel
                        (Oid, 
                        Product, 
                        LabelImage)
                    VALUES
                        (@Oid, 
                        @Product, 
                        @LabelImage); SELECT SCOPE_IDENTITY();");

                    using (SqlConnection cnn = new SqlConnection(connectionString))
                    {
                        cnn.Open();
                        using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                        {
                            cmd.Parameters.AddWithValue("Oid", productLabel.Oid);
                            cmd.Parameters.AddWithValue("LabelImage", productLabel.LabelImage);

                            #region AddProduct
                            if (productLabel.Product != null)
                            {
                                cmd.Parameters.AddWithValue("Product", productLabel.Product.Oid);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("Product", DBNull.Value);
                            }
                            #endregion

                            cmd.ExecuteNonQuery();
                            cnn.Close();

                            result.Data = productLabel.Oid;
                            result.Result = true;
                            result.Message = "Success";
                        }
                    }
                }
                else
                {
                    result.Message = "Error";
                    result.Data = "Parametre boş geçilemez.";
                    result.Result = false;
                }
            }
            catch (Exception ex)
            {
                result.Message = "Error";
                result.Data = ex.Message;
                result.Result = false;
            }

            return result;
        }
    }
}