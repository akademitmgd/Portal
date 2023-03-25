using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iyibir.TMGD.WebAPI.Models
{
    public partial class ActivityReportTransaction
    {
        public Guid Oid { get; set; }
        public ActivityReport ActivityReport { get; set; }
        public HazardousGoodsClass Class { get; set; }
        public Nullable<double> AlinanMiktar { get; set; }
        public Nullable<double> BosaltilanMiktar { get; set; }
        public Nullable<double> DoldurulanMiktar { get; set; }
        public Nullable<double> PaketlenenMiktar { get; set; }
        public Nullable<double> YuklenenMiktar { get; set; }
        public Nullable<double> TasinanMiktar { get; set; }
        public Nullable<double> KarayoluAmbalajliTasinan { get; set; }
        public Nullable<double> KarayoluDokmeTasinan { get; set; }
        public Nullable<double> KarayoluTanktaTasinan { get; set; }
        public Nullable<double> DemiryoluAmbalajliTasinan { get; set; }
        public Nullable<double> DemiryoluDokmeTasinan { get; set; }
        public Nullable<double> DemiryoluTanktaTasinan { get; set; }
        public Nullable<double> DenizyoluAmbalajliTasinan { get; set; }
        public Nullable<double> DenizyoluDokmeTasinan { get; set; }
        public Nullable<double> DenizyoluTanktaTasinan { get; set; }
        public Nullable<double> KarmaAmbalajliTasinan { get; set; }
        public Nullable<double> KarmaDokmeTasinan { get; set; }
        public Nullable<double> KarmaTanktaTasinan { get; set; }
        public string Unit { get; set; }
        public Unitset Unitset { get; set; }
    }
}