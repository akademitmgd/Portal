﻿using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace iyibir.TMGD.Module.BusinessObjects
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    [DefaultProperty("Code")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class HazardousGoodsClassCode : BaseObject
    {
        
        private string _code;
        private string _name;
        public HazardousGoodsClassCode(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

       

        [RuleRequiredField("RuleRequiredField for HazardousGoodsClassCode.Code", DefaultContexts.Save)]
        [RuleUniqueValue("RuleUniqueValue for HazardousGoodsClassCode.Code", DefaultContexts.Save)]
        public string Code { get => _code; set => SetPropertyValue(nameof(Code), ref _code, value); }

        [RuleRequiredField("RuleRequiredField for HazardousGoodsClassCode.Name", DefaultContexts.Save)]
        [VisibleInListView(false)]
        public string Name { get => _name; set => SetPropertyValue(nameof(Name), ref _name, value); }

        [Association("HazardousGoods-ClassCodes")]
        public XPCollection<HazardousGoods> HazardousGoods => GetCollection<HazardousGoods>(nameof(HazardousGoods));
    }
}