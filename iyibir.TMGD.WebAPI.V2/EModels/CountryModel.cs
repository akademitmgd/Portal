using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace iyibir.TMGD.WebAPI.V2.EModels
{
    public class CountryModel
    {
        public Guid Oid { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

    }
}