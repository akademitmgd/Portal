using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iyibir.TMGD.Module.ApiModel
{
     public class DBResult
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public int ReferenceId { get; set; }
        public object Data { get; set; }
    }
}
