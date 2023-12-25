using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace iyibir.TMGD.Module.BusinessObjects
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    [NavigationItem(false)]
    public class VehicleControlDocumentHazardousGoods : BaseObject
    {
        private VehicleControlDocument _vehicleControlDocument;
        private HazardousGoods _hazardousGoods;
        public VehicleControlDocumentHazardousGoods(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        [Association("VehicleControlDocument-HazardousGoods")]
        public VehicleControlDocument VehicleControlDocument { get=> _vehicleControlDocument; set=> SetPropertyValue(nameof(VehicleControlDocument),ref _vehicleControlDocument,value); }
        public HazardousGoods HazardousGoods { get=> _hazardousGoods; set=> SetPropertyValue(nameof(HazardousGoods),ref _hazardousGoods,value); }
    }
}