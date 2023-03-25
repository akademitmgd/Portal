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

namespace iyibir.TMGD.Module.BusinessObjects
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class VehicleControlDocumentTransaction : BaseObject
    {
        private VehicleControlDocument _vehicleControlDocument;
        private string _question;
        private bool _answer;
        private string _hint;
        private string _description;
        private HazardousGoodsLabel _hazardousGoodsLabel;
        public VehicleControlDocumentTransaction(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        [Association("VehicleControlDocument-Transactions")]
        public VehicleControlDocument VehicleControlDocument { get => _vehicleControlDocument; set => SetPropertyValue(nameof(VehicleControlDocument), ref _vehicleControlDocument, value); }

        [RuleRequiredField("RuleRequiredField for VehicleControlDocumentTransaction.Question", DefaultContexts.Save)]
        [Size(450)]
        public string Question { get => _question; set => SetPropertyValue(nameof(Question), ref _question, value); }
        public bool Answer { get => _answer; set => SetPropertyValue(nameof(Answer), ref _answer, value); }

        [Browsable(false)]
        public string Hint { get => _hint; set => SetPropertyValue(nameof(Hint), ref _hint, value); }
        public string Description { get => _description; set => SetPropertyValue(nameof(Description), ref _description, value); }

        [VisibleInDetailView(false)]
        [ModelDefault("AllowEdit","False")]
        public HazardousGoodsLabel HazardousGoodsLabel { get=>_hazardousGoodsLabel; set=> SetPropertyValue(nameof(HazardousGoodsLabel),ref _hazardousGoodsLabel,value); }
    }
}