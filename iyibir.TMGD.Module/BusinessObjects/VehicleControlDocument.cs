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
using System.Net.Mail;

namespace iyibir.TMGD.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("BO_List")]
    [NavigationItem("DocumentManagement")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class VehicleControlDocument : BaseObject
    {
        private string _code;
        private DateTime _createdOn;
        private Employee _owner;
        private VehicleControlOption _vControlOption;
        private Customer _consigner;
        private Consignee _consignee;
        private string _deliveryCompany;
        private Vehicle _vehicle;
        private VehicleDriver _vehicleDriver;
        private DateTime _srcDateOfValidity;
        private DateTime _insurancePolicy;
        private string _description;
        private double _maxWeight;
        public VehicleControlDocument(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (Session.IsNewObject(this))
            {
                Owner = Session.GetObjectByKey<Employee>(SecuritySystem.CurrentUserId);
                CreatedOn = DateTime.Now;
                Consigner = Owner != null ? Owner.Customer != null ? Session.GetObjectByKey<Customer>(Owner.Customer.Oid) : null : null;

                int count = Session.GetObjects(Session.GetClassInfo<VehicleControlDocument>(), null, null, 0, true, true).Count;
                count = count + 1;
                this.Code = string.Format("{0}", count.ToString().PadLeft(4, '0'));
            }
        }

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            switch (propertyName)
            {
                case "Vehicle":
                    if (Vehicle != null)
                    {
                        InsurancePolicy = Vehicle.InsurancePolicy;
                        MaxWeight = Vehicle.MaxWeight;
                    }


                    this.RaisePropertyChangedEvent("InsurancePolicy");
                    this.RaisePropertyChangedEvent("MaxWeight");
                    break;
                case "VehicleDriver":
                    if (VehicleDriver != null)
                        SRCDateOfValidity = VehicleDriver.SRCDateOfValidity;

                    this.RaisePropertyChangedEvent("SRCDateOfValidity");
                    break;
                case "Consigner":

                    if (Consigner != null)
                    {
                        if (Consigner.DefaultVehicleDocumentTransactions.Count > 0)
                        {
                            foreach (DefaultVehicleControlDocumentTransaction item in Consigner.DefaultVehicleDocumentTransactions.Where(x => x.VControlOption == this.VControlOption).ToList())
                            {
                                VehicleControlDocumentTransaction transaction = new VehicleControlDocumentTransaction(Session);
                                transaction.VehicleControlDocument = this;
                                transaction.Question = item.Question;
                                transaction.Hint = item.Hint;

                                this.Transactions.Add(transaction);
                            }

                            this.RaisePropertyChangedEvent("Transactions");
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        protected override void OnSaving()
        {
            base.OnSaving();
            if (!Session.IsObjectMarkedDeleted(this))
            {
                if (this.Transactions.ToList().Exists(x => x.Answer == false))
                {
                    #region Head Body
                    string headBody = @"<html xmlns='http://www.w3.org/1999/xhtml'>
<head runat = 'server'> 
     <title></title>
 </head>
 <body> 
     <table> 
         <tr> 
             <td style = 'font-stretch:semi-condensed'> Firma Adı:</td>     
                 <td>Customer</td>        
                </tr>        
                <tr>        
                    <td colspan = '2' ></td>         
                 </tr>
<tr>
            <td colspan='2'>Kontrol Listesi</td>
        </ tr>
        <tr>
            <td colspan = '2'></td>
 
         </tr> ";
                    headBody = headBody.Replace("Customer", this.Consigner.Title);
                    #endregion

                    string centerBody = string.Empty;

                    #region EndBody
                    string endBody = @"</table>
</body>
</html>";
                    #endregion
                    string body = string.Empty;

                    foreach (VehicleControlDocumentTransaction item in this.Transactions)
                    {
                        if (!item.Answer)
                        {
                            centerBody += @"<tr>
            <td>ControlName :</td>
            <td>Hayır</td>
        </tr>";
                            centerBody = centerBody.Replace("ControlName", item.Question);
                        }
                    }

                    body = string.Format("{0}{1}{2}", headBody, centerBody, endBody);

                    EMailSetting eMailSetting = Session.FindObject<EMailSetting>(CriteriaOperator.Parse("IsActive = ?", true));
                    if (eMailSetting != null)
                    {
                        if (this.Consigner != null)
                        {
                            if (this.Consigner.Consultant != null)
                            {
                                if (!string.IsNullOrEmpty(this.Consigner.Consultant.EMail))
                                {
                                    MailMessage mailWithImg = new Helpers.Helper().GetMailWithOpenCase(eMailSetting.FromMailAddress, this.Consigner.Consultant.EMail, body);

                                    //set the SMTP info
                                    try
                                    {
                                        System.Net.NetworkCredential cred = new System.Net.NetworkCredential(eMailSetting.FromMailAddress, eMailSetting.FromMailAddressPassword);
                                        SmtpClient smtp = new SmtpClient(eMailSetting.SMTPAddress, eMailSetting.Port);
                                        smtp.EnableSsl = eMailSetting.UseSSL;
                                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                                        smtp.UseDefaultCredentials = false;
                                        smtp.Credentials = cred;
                                        //send the email

                                        foreach (var item in eMailSetting.VehicleControlDocumentEMailList.Where(x=> x.Customer.Oid == this.Consigner.Oid))
                                        {
                                            mailWithImg.CC.Add(item.EMail);
                                        }

                                        smtp.Send(mailWithImg);
                                    }
                                    catch (Exception ex)
                                    {
                                        throw new UserFriendlyException(ex.InnerException);
                                    }
                                }
                                else
                                    throw new UserFriendlyException("Mail Gönderilemedi. Danışmana Ait Mail Adresi Bulunamadı..");
                            }
                            else
                                throw new UserFriendlyException("Mail Gönderilemedi. Danışman Ataması Bulunamadı..");
                        }
                        else
                            throw new UserFriendlyException("Mail Gönderilemedi. Gönderici Boş Geçilemez..");
                    }
                    else
                        throw new UserFriendlyException("Mail Gönderilemedi. E-Posta Ayarları Yapılmamış..");
                }
            }
        }

        [RuleRequiredField("RuleRequiredField for VehicleControlDocument.Code", DefaultContexts.Save)]
        public string Code { get => _code; set => SetPropertyValue(nameof(Code), ref _code, value); }


        [RuleRequiredField("RuleRequiredField for VehicleControlDocument.CreatedOn", DefaultContexts.Save)]
        public DateTime CreatedOn { get => _createdOn; set => SetPropertyValue(nameof(CreatedOn), ref _createdOn, value); }

        [ModelDefault("AllowEdit", "False")]
        public Employee Owner { get => _owner; set => SetPropertyValue(nameof(Owner), ref _owner, value); }

        [ImmediatePostData]
        public VehicleControlOption VControlOption { get => _vControlOption; set => SetPropertyValue(nameof(VControlOption), ref _vControlOption, value); }

        [RuleRequiredField("RuleRequiredField for VehicleControlDocument.Consigner", DefaultContexts.Save)]
        [ImmediatePostData]
        [VisibleInDetailView(false),VisibleInListView(false)]
        public Customer Consigner { get => _consigner; set => SetPropertyValue(nameof(Consigner), ref _consigner, value); }

        [RuleRequiredField]
        [DataSourceProperty("Consigner.Consignees")]
        public Consignee Consignee { get=> _consignee; set=> SetPropertyValue(nameof(Consignee),ref _consignee,value); }

        [RuleRequiredField("RuleRequiredField for VehicleControlDocument.DeliveryCompany", DefaultContexts.Save)]
        public string DeliveryCompany { get => _deliveryCompany; set => SetPropertyValue(nameof(DeliveryCompany), ref _deliveryCompany, value); }

        [RuleRequiredField("RuleRequiredField for VehicleControlDocument.Vehicle", DefaultContexts.Save)]
        [DataSourceProperty("Consigner.Vehicles")]
        [ImmediatePostData]
        public Vehicle Vehicle { get => _vehicle; set => SetPropertyValue(nameof(Vehicle), ref _vehicle, value); }

        [RuleRequiredField("RuleRequiredField for VehicleControlDocument.VehicleDriver", DefaultContexts.Save)]
        [DataSourceProperty("Consigner.Drivers")]
        [ImmediatePostData]
        public VehicleDriver VehicleDriver { get => _vehicleDriver; set => SetPropertyValue(nameof(VehicleDriver), ref _vehicleDriver, value); }


        [ModelDefault("AllowEdit", "False")]
        public DateTime SRCDateOfValidity { get => _srcDateOfValidity; set => SetPropertyValue(nameof(SRCDateOfValidity), ref _srcDateOfValidity, value); }

        [ModelDefault("AllowEdit", "False")]
        public DateTime InsurancePolicy { get => _insurancePolicy; set => SetPropertyValue(nameof(InsurancePolicy), ref _insurancePolicy, value); }

        [ModelDefault("AllowEdit", "False"), ToolTip("3.5 tona Kadar \n Asgari Sayısı : 2 adet  Sürücü Kabininde : 2 kg İlave Bulunması Gereken : 2 kg \n 3,5 ton ile 7,5 ton arasındaysa \n Asgari Sayısı : 2 adet  Sürücü Kabininde : 2 kg İlave Bulunması Gereken : 6 kg \n 7,5 tondan fazlaysa \n Asgari Sayısı : 2 adet  Sürücü Kabininde : 2 kg İlave Bulunması Gereken : 6 kg + 6 kg", "Test", ToolTipIconType.Information)]
        public double MaxWeight { get => _maxWeight; set => SetPropertyValue(nameof(MaxWeight), ref _maxWeight, value); }
        public string Description { get => _description; set => SetPropertyValue(nameof(Description), ref _description, value); }

        [VisibleInDetailView(false),VisibleInListView(false)]
        [ModelDefault("AllowEdit","False")]
        public string Products { get {

                if (!IsLoading && !IsSaving)
                {
                    string result = string.Empty;
                    HazardousGoods.ToList().ForEach(x => result += string.Format("{0},", x.HazardousGoods.Code));
                    return result;
                }
                else
                    return string.Empty;

            } }

        [Association("VehicleControlDocument-Transactions"), DevExpress.Xpo.Aggregated]
        public XPCollection<VehicleControlDocumentTransaction> Transactions => GetCollection<VehicleControlDocumentTransaction>(nameof(Transactions));

        [Association("VehicleControlDocument-HazardousGoodsLabels"),DevExpress.Xpo.Aggregated]
        [ModelDefault("AllowEdit","False"),ModelDefault("AllowNew","False")]
        public XPCollection<VehicleControlDocumentLabel> Labels => GetCollection<VehicleControlDocumentLabel>(nameof(Labels));

        [Association("VehicleControlDocument-HazardousGoods"),DevExpress.Xpo.Aggregated]
        [ModelDefault("AllowNew", "False")]
        public XPCollection<VehicleControlDocumentHazardousGoods> HazardousGoods => GetCollection<VehicleControlDocumentHazardousGoods>(nameof(HazardousGoods));
    }
}