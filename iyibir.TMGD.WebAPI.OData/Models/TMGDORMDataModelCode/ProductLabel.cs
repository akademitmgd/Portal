using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace iyibir.TMGD.WebAPI.OData.Models.iyibir_TMGD
{

    public partial class ProductLabel
    {
        public ProductLabel(Session session) : base(session) { }
        //public ProductLabel() : base(XpoDefault.Session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
