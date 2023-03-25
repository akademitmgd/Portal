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
    public class AuditDeterminationLegalStatuteTransaction : BaseObject
    {
        private AuditDeterminationLegalStatute _auditDeterminationLegalStatute;
        private string _auditDetermination;
        private string _result;
        private FileData _documentData;
        public AuditDeterminationLegalStatuteTransaction(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        [Association("LegalStatute-Transactions")]
        public AuditDeterminationLegalStatute AuditDeterminationLegalStatute { get=> _auditDeterminationLegalStatute; set=> SetPropertyValue(nameof(AuditDeterminationLegalStatute),ref _auditDeterminationLegalStatute,value); }

        [RuleRequiredField("RuleRequiredField for AuditDeterminationLegalStatuteTransaction.AuditDetermination", DefaultContexts.Save)]
        [Size(-1)]
        public string AuditDetermination { get=> _auditDetermination; set=> SetPropertyValue(nameof(AuditDetermination),ref _auditDetermination,value); }

        [RuleRequiredField("RuleRequiredField for AuditDeterminationLegalStatuteTransaction.Result", DefaultContexts.Save)]
        [Size(-1)]
        public string Result { get=> _result; set=> SetPropertyValue(nameof(Result),ref _result,value); }

        
        [ExpandObjectMembers(ExpandObjectMembers.Never)]
        public FileData FileData { get => _documentData; set => SetPropertyValue("FileData", ref _documentData, value); }

        [VisibleInListView(true)]
        [ImageEditor(ListViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorFixedHeight = 500, DetailViewImageEditorFixedWidth = 500)]
        public byte[] Image
        {
            get { return GetPropertyValue<byte[]>(nameof(Image)); }
            set { SetPropertyValue<byte[]>(nameof(Image), value); }
        }

        [VisibleInListView(true)]
        [ImageEditor(ListViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorFixedHeight = 500, DetailViewImageEditorFixedWidth = 500)]
        public byte[] Image1
        {
            get { return GetPropertyValue<byte[]>(nameof(Image1)); }
            set { SetPropertyValue<byte[]>(nameof(Image1), value); }
        }

        [VisibleInListView(true)]
        [ImageEditor(ListViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorFixedHeight = 500, DetailViewImageEditorFixedWidth = 500)]
        public byte[] Image2
        {
            get { return GetPropertyValue<byte[]>(nameof(Image2)); }
            set { SetPropertyValue<byte[]>(nameof(Image2), value); }
        }
    }
}