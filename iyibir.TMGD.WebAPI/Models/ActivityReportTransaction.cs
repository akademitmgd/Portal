using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace iyibir.TMGD.WebAPI.Models
{
    public partial class ActivityReportTransaction
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public DataResult GetObjectById(Guid Oid)
        {
            DataResult result = new DataResult();
            try
            {
                List<ActivityReportTransaction> items = new List<ActivityReportTransaction>();
                string commandString = string.Format("SELECT * FROM ActivityReportTransaction WHERE Oid = '{0}'",Oid);
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            ActivityReportTransaction transaction = new ActivityReportTransaction();
                            transaction.Oid = Guid.Parse(dr["Oid"].ToString());
                            transaction.AlinanMiktar = dr["AlinanMiktar"] == DBNull.Value ? default(double) : (double)dr["AlinanMiktar"];
                            transaction.BosaltilanMiktar = dr["BosaltilanMiktar"] == DBNull.Value ? default(double) : (double)dr["BosaltilanMiktar"];
                            transaction.DemiryoluAmbalajliTasinan = dr["DemiryoluAmbalajliTasinan"] == DBNull.Value ? default(double) : (double)dr["DemiryoluAmbalajliTasinan"];
                            transaction.DemiryoluDokmeTasinan = dr["DemiryoluDokmeTasinan"] == DBNull.Value ? default(double) : (double)dr["DemiryoluDokmeTasinan"];
                            transaction.DemiryoluTanktaTasinan = dr["DemiryoluTanktaTasinan"] == DBNull.Value ? default(double) : (double)dr["DemiryoluTanktaTasinan"];
                            transaction.DenizyoluAmbalajliTasinan = dr["DenizyoluAmbalajliTasinan"] == DBNull.Value ? default(double) : (double)dr["DenizyoluAmbalajliTasinan"];
                            transaction.DenizyoluDokmeTasinan = dr["DenizyoluDokmeTasinan"] == DBNull.Value ? default(double) : (double)dr["DenizyoluDokmeTasinan"];
                            transaction.DenizyoluTanktaTasinan = dr["DenizyoluTanktaTasinan"] == DBNull.Value ? default(double) : (double)dr["DenizyoluTanktaTasinan"];
                            transaction.DoldurulanMiktar = dr["DoldurulanMiktar"] == DBNull.Value ? default(double) : (double)dr["DoldurulanMiktar"];
                            transaction.KarayoluAmbalajliTasinan = dr["KarayoluAmbalajliTasinan"] == DBNull.Value ? default(double) : (double)dr["KarayoluAmbalajliTasinan"];
                            transaction.KarayoluDokmeTasinan = dr["KarayoluDokmeTasinan"] == DBNull.Value ? default(double) : (double)dr["KarayoluDokmeTasinan"];
                            transaction.KarayoluTanktaTasinan = dr["KarayoluTanktaTasinan"] == DBNull.Value ? default(double) : (double)dr["KarayoluTanktaTasinan"];
                            transaction.KarmaAmbalajliTasinan = dr["KarmaAmbalajliTasinan"] == DBNull.Value ? default(double) : (double)dr["KarmaAmbalajliTasinan"];
                            transaction.KarmaDokmeTasinan = dr["KarmaDokmeTasinan"] == DBNull.Value ? default(double) : (double)dr["KarmaDokmeTasinan"];
                            transaction.KarmaTanktaTasinan = dr["KarmaTanktaTasinan"] == DBNull.Value ? default(double) : (double)dr["KarmaTanktaTasinan"];
                            transaction.PaketlenenMiktar = dr["PaketlenenMiktar"] == DBNull.Value ? default(double) : (double)dr["PaketlenenMiktar"];
                            transaction.TasinanMiktar = dr["TasinanMiktar"] == DBNull.Value ? default(double) : (double)dr["TasinanMiktar"];
                            transaction.Unit = string.IsNullOrEmpty(dr["Unit"].ToString()) ? string.Empty : dr["Unit"].ToString();
                            transaction.YuklenenMiktar = dr["YuklenenMiktar"] == DBNull.Value ? default(double) : (double)dr["YuklenenMiktar"];
                            transaction.Unitset = dr["Unitset"] == DBNull.Value ? null : ((List<Unitset>)new Unitset().GetObjectById(Guid.Parse(dr["Unitset"].ToString())).Data).FirstOrDefault();
                            transaction.Class = dr["Class"] == DBNull.Value ? null : ((List<HazardousGoodsClass>)new HazardousGoodsClass().GetObjectById(Guid.Parse(dr["Class"].ToString())).Data).FirstOrDefault();
                            transaction.ActivityReport = dr["ActivityReport"] == DBNull.Value ? null : ((List<ActivityReport>)new ActivityReport().GetObjectById(Guid.Parse(dr["ActivityReport"].ToString())).Data).FirstOrDefault();

                            items.Add(transaction);
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
                List<ActivityReportTransaction> items = new List<ActivityReportTransaction>();
                string commandString = string.Format("SELECT * FROM ActivityReportTransaction");
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            ActivityReportTransaction transaction = new ActivityReportTransaction();
                            transaction.Oid = Guid.Parse(dr["Oid"].ToString());
                            transaction.AlinanMiktar = dr["AlinanMiktar"] == DBNull.Value ? default(double) : (double)dr["AlinanMiktar"];
                            transaction.BosaltilanMiktar = dr["BosaltilanMiktar"] == DBNull.Value ? default(double) : (double)dr["BosaltilanMiktar"];
                            transaction.DemiryoluAmbalajliTasinan = dr["DemiryoluAmbalajliTasinan"] == DBNull.Value ? default(double) : (double)dr["DemiryoluAmbalajliTasinan"];
                            transaction.DemiryoluDokmeTasinan = dr["DemiryoluDokmeTasinan"] == DBNull.Value ? default(double) : (double)dr["DemiryoluDokmeTasinan"];
                            transaction.DemiryoluTanktaTasinan = dr["DemiryoluTanktaTasinan"] == DBNull.Value ? default(double) : (double)dr["DemiryoluTanktaTasinan"];
                            transaction.DenizyoluAmbalajliTasinan = dr["DenizyoluAmbalajliTasinan"] == DBNull.Value ? default(double) : (double)dr["DenizyoluAmbalajliTasinan"];
                            transaction.DenizyoluDokmeTasinan = dr["DenizyoluDokmeTasinan"] == DBNull.Value ? default(double) : (double)dr["DenizyoluDokmeTasinan"];
                            transaction.DenizyoluTanktaTasinan = dr["DenizyoluTanktaTasinan"] == DBNull.Value ? default(double) : (double)dr["DenizyoluTanktaTasinan"];
                            transaction.DoldurulanMiktar = dr["DoldurulanMiktar"] == DBNull.Value ? default(double) : (double)dr["DoldurulanMiktar"];
                            transaction.KarayoluAmbalajliTasinan = dr["KarayoluAmbalajliTasinan"] == DBNull.Value ? default(double) : (double)dr["KarayoluAmbalajliTasinan"];
                            transaction.KarayoluDokmeTasinan = dr["KarayoluDokmeTasinan"] == DBNull.Value ? default(double) : (double)dr["KarayoluDokmeTasinan"];
                            transaction.KarayoluTanktaTasinan = dr["KarayoluTanktaTasinan"] == DBNull.Value ? default(double) : (double)dr["KarayoluTanktaTasinan"];
                            transaction.KarmaAmbalajliTasinan = dr["KarmaAmbalajliTasinan"] == DBNull.Value ? default(double) : (double)dr["KarmaAmbalajliTasinan"];
                            transaction.KarmaDokmeTasinan = dr["KarmaDokmeTasinan"] == DBNull.Value ? default(double) : (double)dr["KarmaDokmeTasinan"];
                            transaction.KarmaTanktaTasinan = dr["KarmaTanktaTasinan"] == DBNull.Value ? default(double) : (double)dr["KarmaTanktaTasinan"];
                            transaction.PaketlenenMiktar = dr["PaketlenenMiktar"] == DBNull.Value ? default(double) : (double)dr["PaketlenenMiktar"];
                            transaction.TasinanMiktar = dr["TasinanMiktar"] == DBNull.Value ? default(double) : (double)dr["TasinanMiktar"];
                            transaction.Unit = string.IsNullOrEmpty(dr["Unit"].ToString()) ? string.Empty : dr["Unit"].ToString();
                            transaction.YuklenenMiktar = dr["YuklenenMiktar"] == DBNull.Value ? default(double) : (double)dr["YuklenenMiktar"];
                            transaction.Unitset = dr["Unitset"] == DBNull.Value ? null : ((List<Unitset>)new Unitset().GetObjectById(Guid.Parse(dr["Unitset"].ToString())).Data).FirstOrDefault();
                            transaction.Class = dr["Class"] == DBNull.Value ? null : ((List<HazardousGoodsClass>)new HazardousGoodsClass().GetObjectById(Guid.Parse(dr["Class"].ToString())).Data).FirstOrDefault();
                            transaction.ActivityReport = dr["ActivityReport"] == DBNull.Value ? null : ((List<ActivityReport>)new ActivityReport().GetObjectById(Guid.Parse(dr["ActivityReport"].ToString())).Data).FirstOrDefault();

                            items.Add(transaction);
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
        public DataResult InsertObject(ActivityReportTransaction transaction)
        {
            DataResult result = new DataResult();

            try
            {
                if (transaction != null)
                {
                    string commandString = string.Format(@"INSERT INTO ActivityReportTransaction
                        (
                        Oid, 
                        ActivityReport, 
                        Class, 
                        AlinanMiktar, 
                        BosaltilanMiktar, 
                        DoldurulanMiktar, 
                        PaketlenenMiktar, 
                        YuklenenMiktar, 
                        TasinanMiktar, 
                        KarayoluAmbalajliTasinan, 
                        KarayoluDokmeTasinan, 
                        KarayoluTanktaTasinan, 
                        DemiryoluAmbalajliTasinan, 
                        DemiryoluDokmeTasinan, 
                        DemiryoluTanktaTasinan, 
                        DenizyoluAmbalajliTasinan, 
                        DenizyoluDokmeTasinan, 
                        DenizyoluTanktaTasinan, 
                        KarmaAmbalajliTasinan, 
                        KarmaDokmeTasinan, 
                        KarmaTanktaTasinan, 
                        Unit, 
                        Unitset
                        )
                        VALUES
                        (
                        @Oid, 
                        @ActivityReport, 
                        @Class, 
                        @AlinanMiktar, 
                        @BosaltilanMiktar, 
                        @DoldurulanMiktar, 
                        @PaketlenenMiktar, 
                        @YuklenenMiktar, 
                        @TasinanMiktar, 
                        @KarayoluAmbalajliTasinan, 
                        @KarayoluDokmeTasinan, 
                        @KarayoluTanktaTasinan, 
                        @DemiryoluAmbalajliTasinan, 
                        @DemiryoluDokmeTasinan, 
                        @DemiryoluTanktaTasinan, 
                        @DenizyoluAmbalajliTasinan, 
                        @DenizyoluDokmeTasinan, 
                        @DenizyoluTanktaTasinan, 
                        @KarmaAmbalajliTasinan, 
                        @KarmaDokmeTasinan, 
                        @KarmaTanktaTasinan, 
                        @Unit, 
                        @Unitset); SELECT SCOPE_IDENTITY();");

                    using (SqlConnection cnn = new SqlConnection(connectionString))
                    {
                        cnn.Open();
                        using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                        {
                            cmd.Parameters.AddWithValue("AlinanMiktar", transaction.AlinanMiktar ?? default(double));
                            cmd.Parameters.AddWithValue("BosaltilanMiktar", transaction.BosaltilanMiktar ?? default(double));
                            cmd.Parameters.AddWithValue("DemiryoluAmbalajliTasinan", transaction.DemiryoluAmbalajliTasinan ?? default(double));
                            cmd.Parameters.AddWithValue("DemiryoluDokmeTasinan", transaction.DemiryoluDokmeTasinan ?? default(double));
                            cmd.Parameters.AddWithValue("DemiryoluTanktaTasinan", transaction.DemiryoluTanktaTasinan ?? default(double));
                            cmd.Parameters.AddWithValue("DenizyoluAmbalajliTasinan", transaction.DenizyoluAmbalajliTasinan ?? default(double));
                            cmd.Parameters.AddWithValue("DenizyoluDokmeTasinan", transaction.DenizyoluDokmeTasinan ?? default(double));
                            cmd.Parameters.AddWithValue("DenizyoluTanktaTasinan", transaction.DenizyoluTanktaTasinan ?? default(double));
                            cmd.Parameters.AddWithValue("DoldurulanMiktar", transaction.DoldurulanMiktar ?? default(double));
                            cmd.Parameters.AddWithValue("KarayoluAmbalajliTasinan", transaction.KarayoluAmbalajliTasinan ?? default(double));
                            cmd.Parameters.AddWithValue("KarayoluDokmeTasinan", transaction.KarayoluDokmeTasinan ?? default(double));
                            cmd.Parameters.AddWithValue("KarayoluTanktaTasinan", transaction.KarayoluTanktaTasinan ?? default(double));
                            cmd.Parameters.AddWithValue("KarmaAmbalajliTasinan", transaction.KarmaAmbalajliTasinan ?? default(double));
                            cmd.Parameters.AddWithValue("KarmaDokmeTasinan", transaction.KarmaDokmeTasinan ?? default(double));
                            cmd.Parameters.AddWithValue("KarmaTanktaTasinan", transaction.KarmaTanktaTasinan ?? default(double));
                            cmd.Parameters.AddWithValue("PaketlenenMiktar", transaction.PaketlenenMiktar ?? default(double));
                            cmd.Parameters.AddWithValue("TasinanMiktar", transaction.TasinanMiktar ?? default(double));
                            cmd.Parameters.AddWithValue("Unit", transaction.Unit);
                            cmd.Parameters.AddWithValue("YuklenenMiktar", transaction.YuklenenMiktar ?? default(double));
                            cmd.Parameters.AddWithValue("Oid", transaction.Oid);

                            #region AddClass
                            if (transaction.Class != null)
                            {
                                cmd.Parameters.AddWithValue("Class", transaction.Class.Oid);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("Class", DBNull.Value);
                            }
                            #endregion

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

                            #region AddActivityReport
                            if (transaction.ActivityReport != null)
                            {
                                cmd.Parameters.AddWithValue("ActivityReport", transaction.ActivityReport.Oid);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("ActivityReport", DBNull.Value);
                            }
                            #endregion
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