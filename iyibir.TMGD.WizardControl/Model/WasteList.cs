using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iyibir.TMGD.WizardControl.Model
{
    public class WasteList
    {
        public Guid Oid { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int WasteListType { get; set; }
    }
}
