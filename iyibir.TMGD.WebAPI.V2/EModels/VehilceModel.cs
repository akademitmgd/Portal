using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace iyibir.TMGD.WebAPI.V2.EModels
{
    [DataContract]
    public class VehilceModel
    {
        [DataMember]
        public Guid Oid { get; set; }

        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public int MyProperty { get; set; }
    }
}