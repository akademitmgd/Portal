﻿using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace iyibir.TMGD.WebAPI.OData.Models.iyibir_TMGD
{

    public partial class Activity
    {
        public Activity(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
