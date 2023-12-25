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
    [ImageName("BO_List")]
    [DefaultProperty("Code")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    [NavigationItem("Settings")]
    public class WasteList : BaseObject
    {
        private string _code;
        private string _name;
        private WasteListType _wasteType;
        public WasteList(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        [RuleRequiredField("RuleRequiredField for WasteList.Code", DefaultContexts.Save)]
        [RuleUniqueValue("RuleUniqueValue for WasteList.Code", DefaultContexts.Save)]
        public string Code { get=> _code; set=> SetPropertyValue(nameof(Code),ref _code,value); }

        [RuleRequiredField("RuleRequiredField for WasteList.Name", DefaultContexts.Save)]
        [Size(-1)]
        public string Name { get=> _name; set=> SetPropertyValue(nameof(Name),ref _name,value); }


        [XafDisplayName("Açıklama"), ToolTip(@"(A) İşareti: Altı haneli atık kodu hizasında ‘Açıklama’ sütununda yer alan işaret atığın kesin tehlikeli atık olduğunu belirtir. Bu şekilde işaretlenmiş olan atıklar analiz yapılmaksızın kesin tehlikeli olarak sınıflandırılır.
(M) İşareti: Altı haneli atık kodu hizasında ‘Açıklama’ sütununda yer alan işaret atığın muhtemel tehlikeli atık olduğunu belirtir.Bu şekilde işaretlenmiş olan atıkların tehlikeli olup olmadığının belirlenmesi için bu Yönetmeliğin 11inci maddesinde öngörülen atığın tehlikelilik özelliklerinin belirlenmesine yönelik çalışma yapılır.")]
        public WasteListType WasteType { get=> _wasteType; set=> SetPropertyValue(nameof(WasteType),ref _wasteType, value); }
    }
}