﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace iyibir.TMGD.WebAPIV2.Models
{
    public partial class HazardousGoods
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public DataResult GetObjectByCode(string code)
        {
            DataResult result = new DataResult();
            try
            {
                List<HazardousGoods> items = new List<HazardousGoods>();
                string commandString = string.Format("SELECT * FROM HazardousGoods WHERE Code = '{0}'", code);
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            HazardousGoods hazardousGoods = new HazardousGoods();
                            hazardousGoods.Oid = Guid.Parse(dr["Oid"].ToString());
                            hazardousGoods.Name = string.IsNullOrEmpty(dr["Name"].ToString()) ? string.Empty : dr["Name"].ToString();
                            hazardousGoods.Code = string.IsNullOrEmpty(dr["Code"].ToString()) ? string.Empty : dr["Code"].ToString();
                            hazardousGoods.UNID = string.IsNullOrEmpty(dr["UNID"].ToString()) ? string.Empty : dr["UNID"].ToString();

                            items.Add(hazardousGoods);
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
        public DataResult GetObjectByUNID(string unId)
        {
            DataResult result = new DataResult();
            try
            {
                List<HazardousGoods> items = new List<HazardousGoods>();
                string commandString = string.Format("SELECT * FROM HazardousGoods WHERE UNID = '{0}'", unId);
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            HazardousGoods hazardousGoods = new HazardousGoods();
                            hazardousGoods.Oid = Guid.Parse(dr["Oid"].ToString());
                            hazardousGoods.Name = string.IsNullOrEmpty(dr["Name"].ToString()) ? string.Empty : dr["Name"].ToString();
                            hazardousGoods.Code = string.IsNullOrEmpty(dr["Code"].ToString()) ? string.Empty : dr["Code"].ToString();
                            hazardousGoods.UNID = string.IsNullOrEmpty(dr["UNID"].ToString()) ? string.Empty : dr["UNID"].ToString();

                            items.Add(hazardousGoods);
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
        public DataResult GetObjectById(Guid Oid)
        {
            DataResult result = new DataResult();
            try
            {
                List<HazardousGoods> items = new List<HazardousGoods>();
                string commandString = string.Format("SELECT * FROM HazardousGoods WHERE Oid = '{0}'", Oid);
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            HazardousGoods hazardousGoods = new HazardousGoods();
                            hazardousGoods.Oid = Guid.Parse(dr["Oid"].ToString());
                            hazardousGoods.Name = string.IsNullOrEmpty(dr["Name"].ToString()) ? string.Empty : dr["Name"].ToString();
                            hazardousGoods.Code = string.IsNullOrEmpty(dr["Code"].ToString()) ? string.Empty : dr["Code"].ToString();
                            hazardousGoods.UNID = string.IsNullOrEmpty(dr["UNID"].ToString()) ? string.Empty : dr["UNID"].ToString();

                            items.Add(hazardousGoods);
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
                List<HazardousGoods> items = new List<HazardousGoods>();
                string commandString = string.Format("SELECT * FROM HazardousGoods");
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            HazardousGoods hazardousGoods = new HazardousGoods();
                            hazardousGoods.Oid = Guid.Parse(dr["Oid"].ToString());
                            hazardousGoods.Name = string.IsNullOrEmpty(dr["Name"].ToString()) ? string.Empty : dr["Name"].ToString();
                            hazardousGoods.Code = string.IsNullOrEmpty(dr["Code"].ToString()) ? string.Empty : dr["Code"].ToString();
                            hazardousGoods.UNID = string.IsNullOrEmpty(dr["UNID"].ToString()) ? string.Empty : dr["UNID"].ToString();

                            items.Add(hazardousGoods);
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