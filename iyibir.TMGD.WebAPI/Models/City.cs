using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace iyibir.TMGD.WebAPI.Models
{
    public partial class City
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public DataResult GetObjectById(Guid Oid)
        {
            DataResult result = new DataResult();
            try
            {
                List<City> items = new List<City>();
                string commandString = string.Format("SELECT * FROM City WHERE Oid = '{0}'", Oid);
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            City city = new City();
                            city.Oid = Guid.Parse(dr["Oid"].ToString());
                            city.Name = string.IsNullOrEmpty(dr["Name"].ToString()) ? string.Empty : dr["Name"].ToString();
                            city.Code = string.IsNullOrEmpty(dr["Code"].ToString()) ? string.Empty : dr["Code"].ToString();
                            city.Country = dr["Country"] == DBNull.Value ? null : ((List<Country>)new Country().GetObjectById(Guid.Parse(dr["Country"].ToString())).Data).FirstOrDefault();

                            items.Add(city);
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
                List<City> items = new List<City>();
                string commandString = string.Format("SELECT * FROM City");
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            City city = new City();
                            city.Oid = Guid.Parse(dr["Oid"].ToString());
                            city.Name = string.IsNullOrEmpty(dr["Name"].ToString()) ? string.Empty : dr["Name"].ToString();
                            city.Code = string.IsNullOrEmpty(dr["Code"].ToString()) ? string.Empty : dr["Code"].ToString();
                            city.Country = dr["Country"] == DBNull.Value ? null : ((List<Country>)new Country().GetObjectById(Guid.Parse(dr["Country"].ToString())).Data).FirstOrDefault();

                            items.Add(city);
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

        public DataResult InsertObject(City city)
        {
            DataResult result = new DataResult();

            try
            {
                if (city != null)
                {
                    Guid Oid = Guid.Empty;

                    string commandString = string.Format(@"
                INSERT INTO City 
               (
                Oid,
                Code,
                Name,
                Country)
                VALUES
                (
                @Oid,
                @Code,
                @Name,
                @Country
                ); SELECT SCOPE_IDENTITY();");

                    using (SqlConnection cnn = new SqlConnection(connectionString))
                    {
                        cnn.Open();
                        using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                        {
                            cmd.Parameters.AddWithValue("Oid", city.Oid);
                            cmd.Parameters.AddWithValue("Code", city.Code);
                            cmd.Parameters.AddWithValue("Name", city.Name);

                            if (city.Country != null)
                            {
                                cmd.Parameters.AddWithValue("Country", city.Country.Oid);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("Country", DBNull.Value);
                            }

                            var oid = cmd.ExecuteScalar();
                            cnn.Close();
                        }
                    }

                    result.Data = city.Oid;
                    result.Message = "Success";
                    result.Result = true;
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