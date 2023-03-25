using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iyibir.TMGD.WizardControl.Model
{
    public class Product
    {
        public Guid Oid { get; set; }
        public int ProductGroupType { get; set; }
        public int ProductType { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string OtherName { get; set; }
        public HazardousGoods HazardousGoods { get; set; }
        public Unitset Unitset { get; set; }
        public int MSDSStatus { get; set; }
        public string MSDSName { get; set; }
        public Customer Customer { get; set; }
        public WasteList WasteList { get; set; }
        public string WasteCode { get; set; }
        public string WasteName { get; set; }
        public bool IsActive { get; set; }
        public Employee Owner { get; set; }

    }
}
