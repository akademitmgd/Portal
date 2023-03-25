using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace iyibir.TMGD.API.Models.iyibir_TMGD
{

    public partial class HazardousGoodsMixedPackingProvision
    {
        public HazardousGoodsMixedPackingProvision(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
