using System;
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
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Editors;

namespace iyibir.TMGD.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("BO_Localization")]
    [DefaultProperty("Name")]
    [Appearance("City Delete", AppearanceItemType = "Action", TargetItems = "Delete", Visibility = ViewItemVisibility.Hide)]
    [Appearance("City Edit", AppearanceItemType = "Action", TargetItems = "Edit", Visibility = ViewItemVisibility.Hide)]
    [Appearance("City New", AppearanceItemType = "Action", TargetItems = "New", Visibility = ViewItemVisibility.Hide)]
    public class City : BaseObject
    {
        private Country _country;
        private string _name;
        private string _code;
        private double _longitude;
        private double _latitude;
        private string _mernisCode;
        public City(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        [ModelDefault("AllowEdit", "False")]
        public string Code
        {
            get { return _code; }
            set { SetPropertyValue("Code", ref _code, value); }
        }

        [ModelDefault("AllowEdit", "False")]
        public string Name
        {
            get { return _name; }
            set { SetPropertyValue("Name", ref _name, value); }
        }

        [ModelDefault("AllowEdit", "False")]
        [Association("Cities-Country")]
        public Country Country
        {
            get { return _country; }
            set { SetPropertyValue("Country", ref _country, value); }
        }

        [ModelDefault("AllowEdit", "False")]
        public double Longitude
        {
            get { return _longitude; }
            set { SetPropertyValue("Longitude", ref _longitude, value); }
        }

        [ModelDefault("AllowEdit", "False")]
        public double Latitude
        {
            get { return _latitude; }
            set { SetPropertyValue("Latitude", ref _latitude, value); }
        }

        [RuleRequiredField("RuleRequiredField for City.MernisCode",DefaultContexts.Save)]
        public string MernisCode { get=>_mernisCode; set=>SetPropertyValue(nameof(MernisCode),ref _mernisCode,value); }

        [ModelDefault("AllowEdit", "False")]
        [Association("Counties-City")]
        public XPCollection<County> Counties
        {
            get { return GetCollection<County>("Counties"); }
        }
    }
}