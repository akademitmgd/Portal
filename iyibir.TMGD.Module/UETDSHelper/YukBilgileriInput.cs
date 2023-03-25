using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iyibir.TMGD.Module.UETDSHelper
{
    public class YukBilgileriInput
    {
        public string tasimaTuruKodu { get; set; }
        public string gonderenVergiNo { get; set; }
        public string gonderenUnvan { get; set; }
        public string aliciVergiNo { get; set; }
        public string aliciUnvan { get; set; }
        public string yuklemeUlkeKodu { get; set; }
        public int yuklemeIlMernisKodu { get; set; }
        public int yuklemeIlceMernisKodu { get; set; }
        public string bosaltmaUlkeKodu { get; set; }
        public int bosaltmaIlMernisKodu { get; set; }
        public int bosalmaIlceMernisKodu { get; set; }
        public string yuklemeTarihi { get; set; }
        public string yuklemeSaati { get; set; }
        public string bosaltmaTarihi { get; set; }
        public string bosaltmaSaati { get; set; }
        public long yukCinsId { get; set; }
        public string yukCinsDigerAciklama { get; set; }
        public string yukMiktariBirimi { get; set; }
        public string yukMiktari { get; set; }
        public string firmaYukNo { get; set; }
        public string tehlikeliMaddeTasimaSekli { get; set; }
        public string unId { get; set; }
        public string muafiyetTuru { get; set; }
    }
}
