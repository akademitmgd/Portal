using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iyibir.TMGD.Module.UETDSHelper
{
    public class SeferBilgileriInput
    {
        public string plaka1 { get; set; }
        public string plaka2 { get; set; }
        public string sofor1TCKNO { get; set; }
        public string sofor2TCKNO { get; set; }
        public string firmaSeferNo { get; set; }
        public string baslangicTarihi { get; set; }
        public string baslangicSaati { get; set; }
        public string bitisTarihi { get; set; }
        public string bitisSaati { get; set; }
        public int sonucKodu { get; set; }
        public string sonucMesaji { get; set; }
        public long seferId { get; set; }

    }
}
