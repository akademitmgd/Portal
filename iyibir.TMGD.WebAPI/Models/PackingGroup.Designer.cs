﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iyibir.TMGD.WebAPI.Models
{
    public partial class PackingGroup
    {
        public Guid Oid { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

    }
}