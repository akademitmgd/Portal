using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using iyibir.TMGD.Module.BusinessObjects;
using iyibir.TMGD.Module.NonPersistentObjects;

namespace iyibir.TMGD.Module.Controllers.VoyageNotificationControllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class VoyageNotificationListViewController : ViewController
    {
        public VoyageNotificationListViewController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            new Helpers.Helper().FilterVoyageNotificationDocument(View, SecuritySystem.CurrentUser as Employee);
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        private void updatedVoyageNotification_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            VoyageNotification voyageNotification = View.CurrentObject as VoyageNotification;
            if (voyageNotification != null)
            {
                IObjectSpace np_os = Application.CreateObjectSpace(typeof(NP_VoyageNotification));

                NP_VoyageNotification nP_Voyage = np_os.CreateObject<NP_VoyageNotification>();
                nP_Voyage.Driver1TCKN = voyageNotification.Driver1TCKN;
                nP_Voyage.Driver2TCKN = voyageNotification.Driver2TCKN;
                nP_Voyage.EndDate = voyageNotification.EndDate;
                nP_Voyage.EndTime = voyageNotification.EndTime;
                nP_Voyage.FirmVoyageNumber = voyageNotification.FirmVoyageNumber;
                nP_Voyage.Plate1 = voyageNotification.Plate1;
                nP_Voyage.Plate2 = voyageNotification.Plate2;
                nP_Voyage.ReferenceId = voyageNotification.ReferenceId;
                nP_Voyage.StartDate = voyageNotification.StartDate;
                nP_Voyage.StartTime = voyageNotification.StartTime;
                nP_Voyage.Status = VoyageNotificationStatus.Updated;
                nP_Voyage.UpdatedDate = DateTime.Now;


                foreach (VoyageNotificationTransaction item in voyageNotification.Transactions)
                {
                    NP_VoyageNotificationTransaction transaction = np_os.CreateObject<NP_VoyageNotificationTransaction>();
                    transaction.ConsigneeCityMernisCode = item.ConsigneeCityMernisCode;
                    transaction.ConsigneeCountryCode = item.ConsigneeCountryCode;
                    transaction.ConsigneeCountyMernisCode = item.ConsigneeCountyMernisCode;
                    transaction.ConsigneeTitle = item.ConsigneeTitle;
                    transaction.ConsigneeVKN = item.ConsigneeVKN;
                    transaction.ConsignerCityMernisCode = item.ConsignerCityMernisCode;
                    transaction.ConsignerCountryCode = item.ConsignerCountryCode;
                    transaction.ConsignerCountyMernisCode = item.ConsignerCountyMernisCode;
                    transaction.ConsignerTitle = item.ConsignerTitle;
                    transaction.ConsignerVKN = item.ConsignerVKN;
                    transaction.FirmLoadNumber = item.FirmLoadNumber;
                    transaction.HazardousExemptionType = item.HazardousExemptionType;
                    transaction.HazardousTransportType = item.HazardousTransportType;
                    transaction.HazardousUnit = item.HazardousUnit;
                    transaction.LadingDate = item.LadingDate;
                    transaction.LadingTime = item.LadingTime;
                    transaction.LoadOtherDescription = item.LoadOtherDescription;
                    transaction.LoadQuantity = item.LoadQuantity;
                    transaction.LoadType = item.LoadType != null ? np_os.GetObjectByKey<LoadType>(item.LoadType.Oid) : null;
                    transaction.OtherUnit = item.OtherUnit;
                    transaction.PouringDate = item.PouringDate;
                    transaction.PouringTime = item.PouringTime;
                    transaction.ReferenceId = item.ReferenceId;
                    transaction.Status = VoyageNotificationTransactionStatus.Updated;
                    transaction.TransportTypeCode = item.TransportTypeCode;
                    transaction.UNId = item.UnId;

                    nP_Voyage.Transations.Add(transaction);
                }

                DetailView detailView = Application.CreateDetailView(np_os, nP_Voyage);
                detailView.ViewEditMode = ViewEditMode.Edit;
                e.View = detailView;
                e.DialogController.AcceptAction.Execute += updatedVoyageNotification_AcceptAction_Execute;
            }
            else
            {
                throw new UserFriendlyException("Seçili öge bulunamadı..");
            }
        }

        private void updatedVoyageNotification_AcceptAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            VoyageNotification voyageNotification = View.CurrentObject as VoyageNotification;
            if (voyageNotification != null)
            {
                NP_VoyageNotification nP_Voyage = e.CurrentObject as NP_VoyageNotification;
                if (nP_Voyage != null)
                {
                    Employee employee = SecuritySystem.CurrentUser as Employee;
                    if (employee != null)
                    {
                        if (employee.EmployeeType == EmployeeType.Customer)
                        {
                            Customer customer = employee.Customer;
                            if (customer != null)
                            {
                                if (!string.IsNullOrEmpty(customer.UETDSUsername) && !string.IsNullOrEmpty(customer.UETDSPassword))
                                {
                                    string baslangicSaati = string.Format("{0}:{1}", nP_Voyage.StartTime.Hours.ToString().PadLeft(2, '0'), nP_Voyage.StartTime.Minutes.ToString().PadLeft(2, '0'));
                                    string baslangicTarihi = string.Format("{0}/{1}/{2}", nP_Voyage.StartDate.Day.ToString().PadLeft(2, '0'), nP_Voyage.StartDate.Month.ToString().PadLeft(2, '0'), nP_Voyage.StartDate.Year);

                                    string bitisSaati = string.Format("{0}:{1}", nP_Voyage.EndTime.Hours.ToString().PadLeft(2, '0'), nP_Voyage.EndTime.Minutes.ToString().PadLeft(2, '0'));
                                    string bitisTarihi = string.Format("{0}/{1}/{2}", nP_Voyage.EndDate.Day.ToString().PadLeft(2, '0'), nP_Voyage.EndDate.Month.ToString().PadLeft(2, '0'), nP_Voyage.StartDate.Year);

                                    UetdsService.uetdsGenelIslemSonuc sonucSefer = new UETDSHelper.UETDSHelper(customer.UETDSUsername, customer.UETDSPassword).SeferDuzenle(nP_Voyage.ReferenceId, baslangicSaati, baslangicTarihi, bitisSaati, bitisTarihi, nP_Voyage.FirmVoyageNumber, nP_Voyage.Plate1, nP_Voyage.Plate2, nP_Voyage.Driver1TCKN, nP_Voyage.Driver2TCKN);
                                    if (sonucSefer != null)
                                    {
                                        if (sonucSefer.sonucKodu == 0)
                                        {
                                            foreach (NP_VoyageNotificationTransaction item in nP_Voyage.Transations)
                                            {
                                                #region SettingDateAndTimeFormat
                                                string bosaltmaSaati = string.Format("{0}:{1}", item.PouringTime.Hours.ToString().PadLeft(2, '0'), item.PouringTime.Minutes.ToString().PadLeft(2, '0'));
                                                string bosaltmaTarihi = string.Format("{0}/{1}/{2}", item.PouringDate.Day.ToString().PadLeft(2, '0'), item.PouringDate.Month.ToString().PadLeft(2, '0'), item.PouringDate.Year);

                                                string yuklemeSaati = string.Format("{0}:{1}", item.LadingTime.Hours.ToString().PadLeft(2, '0'), item.LadingTime.Minutes.ToString().PadLeft(2, '0'));
                                                string yuklemeTarihi = string.Format("{0}/{1}/{2}", item.LadingDate.Day.ToString().PadLeft(2, '0'), item.LadingDate.Month.ToString().PadLeft(2, '0'), item.PouringDate.Year);
                                                #endregion

                                                #region SettingMuafiyetKodu
                                                string muafiyetTuru = string.Empty;
                                                switch (item.HazardousExemptionType)
                                                {
                                                    case HazardousExemptionType.NA:
                                                        break;
                                                    case HazardousExemptionType.No:
                                                        muafiyetTuru = "1";
                                                        break;
                                                    case HazardousExemptionType.ThreeDotThree:
                                                        muafiyetTuru = "33";
                                                        break;
                                                    case HazardousExemptionType.ThreeDotFour:
                                                        muafiyetTuru = "34";
                                                        break;
                                                    case HazardousExemptionType.ThreeDotFive:
                                                        muafiyetTuru = "35";
                                                        break;
                                                    case HazardousExemptionType.OneDotOneDotThreeDotSix:
                                                        muafiyetTuru = "1136";
                                                        break;
                                                    default:
                                                        break;
                                                }
                                                #endregion

                                                #region SettingTasimaTuruKodu
                                                string tasimaTuruKodu = string.Empty;
                                                switch (item.TransportTypeCode)
                                                {
                                                    case TransportTypeCode.NA:
                                                        break;
                                                    case TransportTypeCode.Hazardous:
                                                        tasimaTuruKodu = "1";
                                                        break;
                                                    case TransportTypeCode.Normal:
                                                        tasimaTuruKodu = "2";
                                                        break;
                                                    default:
                                                        break;
                                                }
                                                #endregion

                                                #region SettingTehlikeliMaddeTasimaSekli
                                                string tehlikeliMaddeTasimaSekli = string.Empty;
                                                switch (item.HazardousTransportType)
                                                {
                                                    case HazardousTransportType.NA:
                                                        break;
                                                    case HazardousTransportType.Package:
                                                        tehlikeliMaddeTasimaSekli = "1";
                                                        break;
                                                    case HazardousTransportType.Tank:
                                                        tehlikeliMaddeTasimaSekli = "2";
                                                        break;
                                                    case HazardousTransportType.Bulk:
                                                        tehlikeliMaddeTasimaSekli = "3";
                                                        break;
                                                    default:
                                                        break;
                                                }
                                                #endregion

                                                #region SettingYukMiktari
                                                string yukMiktari = item.LoadQuantity.ToString();
                                                if (yukMiktari.Contains(','))
                                                {
                                                    yukMiktari.Replace(',', '.');
                                                }

                                                #endregion

                                                #region SettingYukMiktariBirimi
                                                string yukMiktariBirimi = string.Empty;
                                                if (item.HazardousUnit != HazardousUnit.NA)
                                                {
                                                    switch (item.HazardousUnit)
                                                    {
                                                        case HazardousUnit.NA:
                                                            break;
                                                        case HazardousUnit.MG:
                                                            yukMiktariBirimi = "MG";
                                                            break;
                                                        case HazardousUnit.L:
                                                            yukMiktariBirimi = "L";
                                                            break;
                                                        case HazardousUnit.KG:
                                                            yukMiktariBirimi = "KG";
                                                            break;
                                                        default:
                                                            break;
                                                    }
                                                }
                                                else if (item.OtherUnit != OtherUnit.NA)
                                                {
                                                    switch (item.OtherUnit)
                                                    {
                                                        case OtherUnit.NA:
                                                            break;
                                                        case OtherUnit.AD:
                                                            yukMiktariBirimi = "AD";
                                                            break;
                                                        case OtherUnit.PK:
                                                            yukMiktariBirimi = "PK";
                                                            break;
                                                        case OtherUnit.KG:
                                                            yukMiktariBirimi = "KG";
                                                            break;
                                                        case OtherUnit.TON:
                                                            yukMiktariBirimi = "TON";
                                                            break;
                                                        default:
                                                            break;
                                                    }
                                                }
                                                #endregion

                                                UetdsService.uetdsGenelIslemSonuc sonucYuk = new UETDSHelper.UETDSHelper(customer.UETDSUsername, customer.UETDSPassword).YukDuzenle(item.ReferenceId, item.ConsigneeTitle, item.ConsigneeVKN, item.ConsigneeCountyMernisCode, item.ConsigneeCityMernisCode, bosaltmaSaati, bosaltmaTarihi, item.ConsigneeCountryCode, item.FirmLoadNumber, item.ConsignerTitle, item.ConsignerVKN, muafiyetTuru, tasimaTuruKodu, tehlikeliMaddeTasimaSekli, item.UNId, item.LoadOtherDescription, item.LoadType.Code, item.ConsignerCountyMernisCode, item.ConsignerCityMernisCode, yuklemeSaati, yuklemeTarihi, item.ConsignerCountryCode, yukMiktari, yukMiktariBirimi);
                                                if (sonucYuk != null)
                                                {
                                                    if (sonucYuk.sonucKodu == 0)
                                                    {
                                                        VoyageNotificationTransaction transaction = voyageNotification.Transactions.FirstOrDefault(x => x.ReferenceId == item.ReferenceId);
                                                        if (transaction != null)
                                                        {
                                                            transaction.UpdatedDate = DateTime.Now;
                                                            transaction.UnId = item.UNId;
                                                            transaction.TransportTypeCode = item.TransportTypeCode;
                                                            transaction.Status = VoyageNotificationTransactionStatus.Updated;
                                                            transaction.PouringTime = item.PouringTime;
                                                            transaction.PouringDate = item.PouringDate;
                                                            transaction.OtherUnit = item.OtherUnit;
                                                            transaction.LoadType = item.LoadType != null ? View.ObjectSpace.GetObjectByKey<LoadType>(item.LoadType.Oid) : null;
                                                            transaction.LoadQuantity = item.LoadQuantity;
                                                            transaction.LoadOtherDescription = item.LoadOtherDescription;
                                                            transaction.LadingTime = item.LadingTime;
                                                            transaction.LadingDate = item.LadingDate;
                                                            transaction.HazardousUnit = item.HazardousUnit;
                                                            transaction.HazardousTransportType = item.HazardousTransportType;
                                                            transaction.HazardousExemptionType = item.HazardousExemptionType;
                                                            transaction.FirmLoadNumber = item.FirmLoadNumber;
                                                            transaction.VoyageNotification = voyageNotification;

                                                            VoyageNotificationHistory history = View.ObjectSpace.CreateObject<VoyageNotificationHistory>();
                                                            history.Message = string.Format("{0} UNID'li yük düzenlendi.", item.UNId);
                                                            history.VoyageNotification = voyageNotification;
                                                            history.CreatedOn = DateTime.Now;

                                                            voyageNotification.Histories.Add(history);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        throw new UserFriendlyException(sonucYuk.sonucMesaji);
                                                    }
                                                }
                                                else
                                                {
                                                    throw new UserFriendlyException("Yuk düzenle metodu servis yanıtı bulunamadı..");
                                                }
                                            }

                                            voyageNotification.UpdatedDate = DateTime.Now;
                                            voyageNotification.Status = VoyageNotificationStatus.Updated;
                                            voyageNotification.Driver1TCKN = nP_Voyage.Driver1TCKN;
                                            voyageNotification.Driver2TCKN = nP_Voyage.Driver2TCKN;
                                            voyageNotification.EndDate = nP_Voyage.EndDate;
                                            voyageNotification.EndTime = nP_Voyage.EndTime;
                                            voyageNotification.FirmVoyageNumber = nP_Voyage.FirmVoyageNumber;
                                            voyageNotification.Plate1 = nP_Voyage.Plate1;
                                            voyageNotification.Plate2 = nP_Voyage.Plate2;
                                            voyageNotification.StartDate = nP_Voyage.StartDate;
                                            voyageNotification.StartTime = nP_Voyage.StartTime;

                                            VoyageNotificationHistory voyageHistory = View.ObjectSpace.CreateObject<VoyageNotificationHistory>();
                                            voyageHistory.CreatedOn = DateTime.Now;
                                            voyageHistory.Message = "Sefer Düzenlendi.";
                                            voyageHistory.VoyageNotification = voyageNotification;

                                            voyageNotification.Histories.Add(voyageHistory);

                                            View.ObjectSpace.SetModified(voyageNotification);
                                            View.ObjectSpace.CommitChanges();
                                            View.RefreshDataSource();
                                            View.Refresh();
                                        }
                                        else
                                        {
                                            throw new UserFriendlyException(sonucSefer.sonucMesaji);
                                        }
                                    }
                                    else
                                    {
                                        throw new UserFriendlyException("Servis Yanıtı Bulunamadı..");
                                    }
                                }
                                else
                                    throw new UserFriendlyException("U-ETDS Kullanıcı Giriş Bilgileri Bulunamadı.. Lütfen Kontrol Ediniz..");

                            }
                            else
                                throw new UserFriendlyException("Kayıtlı Müşteri Bilgisi Bulunamadı.. Lütfen Kontrol Ediniz..");
                        }
                        else
                            throw new UserFriendlyException("Müşteri Türünde Olmayan Kullanıcılar İşlem Yapma Yetkisine Sahip Değildir..");
                    }

                }
                else
                {
                    throw new UserFriendlyException("Güncelleme bilgileri bulunamadı..");
                }
            }
            else
            {
                throw new UserFriendlyException("Seçili öge bulunamadı..");
            }
        }

        private void aktivatedVoyageNotification_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            VoyageNotification voyageNotification = View.CurrentObject as VoyageNotification;
            if (voyageNotification != null)
            {
                Employee employee = SecuritySystem.CurrentUser as Employee;
                if (employee != null)
                {
                    if (employee.EmployeeType == EmployeeType.Customer)
                    {
                        Customer customer = employee.Customer;
                        if (customer != null)
                        {
                            if (!string.IsNullOrEmpty(customer.UETDSUsername) && !string.IsNullOrEmpty(customer.UETDSPassword))
                            {
                                UetdsService.uetdsGenelIslemSonuc sonuc = new UETDSHelper.UETDSHelper(customer.UETDSUsername, customer.UETDSPassword).SeferAktifEt(voyageNotification.ReferenceId);
                                if (sonuc != null)
                                {
                                    if (sonuc.sonucKodu == 0)
                                    {
                                        voyageNotification.Status = VoyageNotificationStatus.Activated;
                                        voyageNotification.ActivatedDate = DateTime.Now;

                                        //foreach (VoyageNotificationTransaction transaction in voyageNotification.Transactions)
                                        //{
                                        //    transaction.Status = VoyageNotificationTransactionStatus.Activated;
                                        //    transaction.ActivatedDate = DateTime.Now;
                                        //}

                                        VoyageNotificationHistory history = View.ObjectSpace.CreateObject<VoyageNotificationHistory>();
                                        history.VoyageNotification = voyageNotification;
                                        history.CreatedOn = DateTime.Now;
                                        history.Message = string.Format("{0} Id'li sefer iptal edilmiştir.", voyageNotification.ReferenceId);

                                        voyageNotification.Histories.Add(history);


                                        View.ObjectSpace.SetModified(voyageNotification);
                                        View.ObjectSpace.CommitChanges();
                                        View.RefreshDataSource();
                                        View.Refresh();
                                    }
                                    else
                                    {
                                        throw new UserFriendlyException(sonuc.sonucMesaji);
                                    }
                                }
                                else
                                {
                                    throw new UserFriendlyException("Servis Yanıtı Bulunamadı..");
                                }
                            }
                            else
                                throw new UserFriendlyException("U-ETDS Kullanıcı Giriş Bilgileri Bulunamadı.. Lütfen Kontrol Ediniz..");

                        }
                        else
                            throw new UserFriendlyException("Kayıtlı Müşteri Bilgisi Bulunamadı.. Lütfen Kontrol Ediniz..");
                    }
                    else
                        throw new UserFriendlyException("Müşteri Türünde Olmayan Kullanıcılar İşlem Yapma Yetkisine Sahip Değildir..");
                }
            }
            else
            {
                throw new UserFriendlyException("Seçili öge bulunamadı..");
            }
        }

        private void cancelledVoyageNotification_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            VoyageNotification voyageNotification = View.CurrentObject as VoyageNotification;
            if (voyageNotification != null)
            {
                IObjectSpace np_os = Application.CreateObjectSpace(typeof(NP_VoyageNotificationTransactionCancelled));
                NP_VoyageNotificationTransactionCancelled cancelled = np_os.CreateObject<NP_VoyageNotificationTransactionCancelled>();
                cancelled.ReferenceId = voyageNotification.ReferenceId;
                cancelled.CancelledDate = DateTime.Now;

                DetailView detailView = Application.CreateDetailView(np_os, cancelled);
                detailView.ViewEditMode = ViewEditMode.Edit;
                e.View = detailView;
                e.DialogController.AcceptAction.Execute += cancelledVoyageNotification_AcceptAction_Execute;
            }
            else
            {
                throw new UserFriendlyException("Seçili öge bulunamadı..");
            }
        }

        private void cancelledVoyageNotification_AcceptAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            VoyageNotification voyageNotification = View.CurrentObject as VoyageNotification;
            if (voyageNotification != null)
            {
                NP_VoyageNotificationTransactionCancelled cancelled = e.CurrentObject as NP_VoyageNotificationTransactionCancelled;
                if (cancelled != null)
                {
                    Employee employee = SecuritySystem.CurrentUser as Employee;
                    if (employee != null)
                    {
                        if (employee.EmployeeType == EmployeeType.Customer)
                        {
                            Customer customer = employee.Customer;
                            if (customer != null)
                            {
                                if (!string.IsNullOrEmpty(customer.UETDSUsername) && !string.IsNullOrEmpty(customer.UETDSPassword))
                                {
                                    UetdsService.uetdsGenelIslemSonuc sonuc = new UETDSHelper.UETDSHelper(customer.UETDSUsername, customer.UETDSPassword).SeferIptalEt(cancelled.ReferenceId, cancelled.CancelledType == VoyageNotificationTransactionCancelledType.ArizaNedeniIleIptal ? "2" : "1", cancelled.CancelledDescription);
                                    if (sonuc != null)
                                    {
                                        if (sonuc.sonucKodu == 0)
                                        {
                                            voyageNotification.Status = VoyageNotificationStatus.Cancelled;
                                            voyageNotification.CancelledDate = cancelled.CancelledDate;
                                            voyageNotification.CancelledType = cancelled.CancelledType;
                                            voyageNotification.CancelledDescription = cancelled.CancelledDescription;

                                            //foreach (VoyageNotificationTransaction transaction in voyageNotification.Transactions)
                                            //{
                                            //    transaction.Status = VoyageNotificationTransactionStatus.Cancelled;
                                            //    transaction.CancelledDate = DateTime.Now;
                                            //    transaction.CancelledDescription = cancelled.CancelledDescription;
                                            //    transaction.CancelledType = cancelled.CancelledType;
                                            //}

                                            VoyageNotificationHistory history = View.ObjectSpace.CreateObject<VoyageNotificationHistory>();
                                            history.VoyageNotification = voyageNotification;
                                            history.CreatedOn = DateTime.Now;
                                            history.Message = string.Format("{0} Id 'li Sefer İptal Edildi.", voyageNotification.ReferenceId);

                                            View.ObjectSpace.SetModified(voyageNotification);
                                            View.ObjectSpace.CommitChanges();
                                            View.RefreshDataSource();
                                            View.Refresh();
                                        }
                                        else
                                        {
                                            throw new UserFriendlyException(sonuc.sonucMesaji);
                                        }
                                    }
                                    else
                                    {
                                        throw new UserFriendlyException("Servis Yanıtı Bulunamadı..");
                                    }
                                }
                                else
                                    throw new UserFriendlyException("U-ETDS Kullanıcı Giriş Bilgileri Bulunamadı.. Lütfen Kontrol Ediniz..");

                            }
                            else
                                throw new UserFriendlyException("Kayıtlı Müşteri Bilgisi Bulunamadı.. Lütfen Kontrol Ediniz..");
                        }
                        else
                            throw new UserFriendlyException("Müşteri Türünde Olmayan Kullanıcılar İşlem Yapma Yetkisine Sahip Değildir..");
                    }
                }
                else
                {
                    throw new UserFriendlyException("İptal seçenekleri bulunamadı..");
                }
            }
            else
            {
                throw new UserFriendlyException("Seçili öge bulunamadı..");
            }
        }

        private void approveVoyageNotification_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            try
            {
                VoyageNotification voyageNotification = View.CurrentObject as VoyageNotification;
                if (voyageNotification != null)
                {
                    Employee employee = SecuritySystem.CurrentUser as Employee;
                    if (employee.EmployeeType == EmployeeType.Customer)
                    {
                        Customer customer = employee.Customer;
                        if (customer != null)
                        {
                            if (!string.IsNullOrEmpty(customer.UETDSUsername) && !string.IsNullOrEmpty(customer.UETDSPassword))
                            {
                                VoyageNotificationHistory history = null;

                                string baslangicSaati = string.Format("{0}:{1}", voyageNotification.StartTime.Hours.ToString().PadLeft(2, '0'), voyageNotification.StartTime.Minutes.ToString().PadLeft(2, '0'));
                                string baslangicTarihi = string.Format("{0}/{1}/{2}", voyageNotification.StartDate.Day.ToString().PadLeft(2, '0'), voyageNotification.StartDate.Month.ToString().PadLeft(2, '0'), voyageNotification.StartDate.Year);

                                string bitisSaati = string.Format("{0}:{1}", voyageNotification.EndTime.Hours.ToString().PadLeft(2, '0'), voyageNotification.EndTime.Minutes.ToString().PadLeft(2, '0'));
                                string bitisTarihi = string.Format("{0}/{1}/{2}", voyageNotification.EndDate.Day.ToString().PadLeft(2, '0'), voyageNotification.EndDate.Month.ToString().PadLeft(2, '0'), voyageNotification.EndDate.Year);

                                //NewService.uetdsEsyaSeferEkleSonucV3 sonuc = new UETDSHelper.NewServiceHelper(customer.UETDSUsername, customer.UETDSPassword).YeniSeferEkle(baslangicSaati, baslangicTarihi, bitisSaati, bitisTarihi, voyageNotification.FirmVoyageNumber, voyageNotification.Plate1, voyageNotification.Plate2, voyageNotification.Driver1TCKN, voyageNotification.Driver2TCKN);
                                UetdsService.uetdsEsyaSeferEkleSonucV3 sonuc = new UETDSHelper.UETDSHelper(customer.UETDSUsername, customer.UETDSPassword).YeniSeferEkle(baslangicSaati, baslangicTarihi, bitisSaati, bitisTarihi, voyageNotification.FirmVoyageNumber, voyageNotification.Plate1, voyageNotification.Plate2, voyageNotification.Driver1TCKN, voyageNotification.Driver2TCKN);
                                if (sonuc != null)
                                {
                                    if (sonuc.sonucKodu == 0)
                                    {
                                        #region OldCode
                                        //List<UetdsService.uetdsEsyaYukBilgileriInputV3> yukBilgileriInputList = new List<UetdsService.uetdsEsyaYukBilgileriInputV3>();

                                        //foreach (VoyageNotificationTransaction item in voyageNotification.Transactions.OrderBy(x => x.LineNumber))
                                        //{
                                        //    #region SettingDateAndTimeFormat
                                        //    string bosaltmaSaati = string.Format("{0}:{1}", item.PouringTime.Hours.ToString().PadLeft(2, '0'), item.PouringTime.Minutes.ToString().PadLeft(2, '0'));
                                        //    string bosaltmaTarihi = string.Format("{0}/{1}/{2}", item.PouringDate.Day.ToString().PadLeft(2, '0'), item.PouringDate.Month.ToString().PadLeft(2, '0'), item.PouringDate.Year);

                                        //    string yuklemeSaati = string.Format("{0}:{1}", item.LadingTime.Hours.ToString().PadLeft(2, '0'), item.LadingTime.Minutes.ToString().PadLeft(2, '0'));
                                        //    string yuklemeTarihi = string.Format("{0}/{1}/{2}", item.LadingDate.Day.ToString().PadLeft(2, '0'), item.LadingDate.Month.ToString().PadLeft(2, '0'), item.PouringDate.Year);
                                        //    #endregion

                                        //    #region SettingMuafiyetKodu
                                        //    string muafiyetTuru = string.Empty;
                                        //    switch (item.HazardousExemptionType)
                                        //    {
                                        //        case HazardousExemptionType.NA:
                                        //            break;
                                        //        case HazardousExemptionType.No:
                                        //            muafiyetTuru = "1";
                                        //            break;
                                        //        case HazardousExemptionType.ThreeDotThree:
                                        //            muafiyetTuru = "33";
                                        //            break;
                                        //        case HazardousExemptionType.ThreeDotFour:
                                        //            muafiyetTuru = "34";
                                        //            break;
                                        //        case HazardousExemptionType.ThreeDotFive:
                                        //            muafiyetTuru = "35";
                                        //            break;
                                        //        case HazardousExemptionType.OneDotOneDotThreeDotSix:
                                        //            muafiyetTuru = "1136";
                                        //            break;
                                        //        default:
                                        //            break;
                                        //    }
                                        //    #endregion

                                        //    #region SettingTasimaTuruKodu
                                        //    string tasimaTuruKodu = string.Empty;
                                        //    switch (item.TransportTypeCode)
                                        //    {
                                        //        case TransportTypeCode.NA:
                                        //            break;
                                        //        case TransportTypeCode.Hazardous:
                                        //            tasimaTuruKodu = "1";
                                        //            break;
                                        //        case TransportTypeCode.Normal:
                                        //            tasimaTuruKodu = "2";
                                        //            break;
                                        //        default:
                                        //            break;
                                        //    }
                                        //    #endregion

                                        //    #region SettingTehlikeliMaddeTasimaSekli
                                        //    string tehlikeliMaddeTasimaSekli = string.Empty;
                                        //    switch (item.HazardousTransportType)
                                        //    {
                                        //        case HazardousTransportType.NA:
                                        //            break;
                                        //        case HazardousTransportType.Package:
                                        //            tehlikeliMaddeTasimaSekli = "1";
                                        //            break;
                                        //        case HazardousTransportType.Tank:
                                        //            tehlikeliMaddeTasimaSekli = "2";
                                        //            break;
                                        //        case HazardousTransportType.Bulk:
                                        //            tehlikeliMaddeTasimaSekli = "3";
                                        //            break;
                                        //        default:
                                        //            break;
                                        //    }
                                        //    #endregion

                                        //    #region SettingYukMiktari
                                        //    string yukMiktari = item.LoadQuantity.ToString();
                                        //    if (yukMiktari.Contains(','))
                                        //    {
                                        //        yukMiktari.Replace(',', '.');
                                        //    }

                                        //    #endregion

                                        //    #region SettingYukMiktariBirimi
                                        //    string yukMiktariBirimi = string.Empty;
                                        //    if (item.HazardousUnit != HazardousUnit.NA)
                                        //    {
                                        //        switch (item.HazardousUnit)
                                        //        {
                                        //            case HazardousUnit.NA:
                                        //                break;
                                        //            case HazardousUnit.MG:
                                        //                yukMiktariBirimi = "MG";
                                        //                break;
                                        //            case HazardousUnit.L:
                                        //                yukMiktariBirimi = "L";
                                        //                break;
                                        //            case HazardousUnit.KG:
                                        //                yukMiktariBirimi = "KG";
                                        //                break;
                                        //            default:
                                        //                break;
                                        //        }
                                        //    }
                                        //    else if (item.OtherUnit != OtherUnit.NA)
                                        //    {
                                        //        switch (item.OtherUnit)
                                        //        {
                                        //            case OtherUnit.NA:
                                        //                break;
                                        //            case OtherUnit.AD:
                                        //                yukMiktariBirimi = "AD";
                                        //                break;
                                        //            case OtherUnit.PK:
                                        //                yukMiktariBirimi = "PK";
                                        //                break;
                                        //            case OtherUnit.KG:
                                        //                yukMiktariBirimi = "KG";
                                        //                break;
                                        //            case OtherUnit.TON:
                                        //                yukMiktariBirimi = "TON";
                                        //                break;
                                        //            default:
                                        //                break;
                                        //        }
                                        //    }
                                        //    #endregion

                                        //    UetdsService.uetdsEsyaYukBilgileriInputV3 yukBilgi = new UETDSHelper.UETDSHelper(customer.UETDSUsername, customer.UETDSPassword).SettingYukBilgileri(item.ConsigneeTitle, item.ConsigneeVKN, item.ConsigneeCountyMernisCode, item.ConsigneeCityMernisCode, bosaltmaSaati, bosaltmaTarihi, item.ConsigneeCountryCode, item.FirmLoadNumber, item.ConsignerTitle, item.ConsignerVKN, muafiyetTuru, tasimaTuruKodu, tehlikeliMaddeTasimaSekli, item.UnId, item.LoadOtherDescription, item.LoadType.Code, item.ConsignerCountyMernisCode, item.ConsignerCityMernisCode, yuklemeSaati, yuklemeTarihi, item.ConsignerCountryCode, yukMiktari, yukMiktariBirimi);

                                        //    yukBilgileriInputList.Add(yukBilgi);

                                        //    //UetdsService.uetdsEsyaYeniYukEkleSonucV3 sonucYuk = new UETDSHelper.UETDSHelper(customer.UETDSUsername, customer.UETDSPassword).SefereYukEkle(sonuc.seferId, item.ConsigneeTitle, item.ConsigneeVKN, item.ConsigneeCountyMernisCode, item.ConsigneeCityMernisCode, bosaltmaSaati, bosaltmaTarihi, item.ConsigneeCountryCode, item.FirmLoadNumber, item.ConsignerTitle, item.ConsignerVKN, muafiyetTuru, tasimaTuruKodu, tehlikeliMaddeTasimaSekli, item.UnId, item.LoadOtherDescription, item.LoadType.Code, item.ConsignerCountyMernisCode, item.ConsignerCityMernisCode, yuklemeSaati, yuklemeTarihi, item.ConsignerCountryCode, yukMiktari, yukMiktariBirimi);

                                        //}


                                        //if (yukBilgileriInputList.Count > 0)
                                        //{
                                        //    UetdsService.uetdsEsyaYeniYukEkleSonucV3 sonucYuk = new UETDSHelper.UETDSHelper(customer.UETDSUsername, customer.UETDSPassword).SefereYukEkle(sonuc.seferId, yukBilgileriInputList.ToArray());
                                        //    if (sonucYuk != null)
                                        //    {
                                        //        if (sonucYuk.sonucKodu == 0)
                                        //        {
                                        //            foreach (UetdsService.uetdsEsyaSonucV3 esyaSonuc in sonucYuk.uetdsEsyaSonuc.ToList().OrderBy(x => x.sira))
                                        //            {
                                        //                VoyageNotificationTransaction transaction = voyageNotification.Transactions.FirstOrDefault(x => x.LineNumber == esyaSonuc.sira);
                                        //                if (transaction != null)
                                        //                {
                                        //                    transaction.Status = VoyageNotificationTransactionStatus.Sent;
                                        //                    transaction.ReferenceId = esyaSonuc.yukId;

                                        //                    history = View.ObjectSpace.CreateObject<VoyageNotificationHistory>();
                                        //                    history.CreatedOn = DateTime.Now;
                                        //                    history.Message = string.Format("{0} Un Id'li yük sefere eklenmiştir.", transaction.UnId);
                                        //                    history.VoyageNotification = voyageNotification;

                                        //                    voyageNotification.Histories.Add(history);
                                        //                }
                                        //                else
                                        //                {
                                        //                    history = View.ObjectSpace.CreateObject<VoyageNotificationHistory>();
                                        //                    history.CreatedOn = DateTime.Now;
                                        //                    history.Message = string.Format("{0} sıra numaralı yük bulunamadı.", esyaSonuc.sira);
                                        //                    history.VoyageNotification = voyageNotification;

                                        //                    voyageNotification.Histories.Add(history);
                                        //                }
                                        //            }
                                        //        }
                                        //        else
                                        //        {
                                        //            history = View.ObjectSpace.CreateObject<VoyageNotificationHistory>();
                                        //            history.CreatedOn = DateTime.Now;

                                        //            foreach (var item in sonucYuk.uetdsEsyaSonuc)
                                        //            {
                                        //                history.Message += string.Format("{0}\n", item.sonucMesaji);
                                        //            }

                                        //            history.VoyageNotification = voyageNotification;

                                        //            voyageNotification.Histories.Add(history);
                                        //        }
                                        //    }
                                        //    else
                                        //    {
                                        //        history = View.ObjectSpace.CreateObject<VoyageNotificationHistory>();
                                        //        history.CreatedOn = DateTime.Now;
                                        //        history.Message = "Sefere Yük Ekleme Servisi yanıtı bulunamadı..";
                                        //        history.VoyageNotification = voyageNotification;

                                        //        voyageNotification.Histories.Add(history);
                                        //    }
                                        //} 
                                        #endregion

                                        voyageNotification.ReferenceId = sonuc.seferId;
                                        voyageNotification.Status = VoyageNotificationStatus.Sent;
                                        voyageNotification.TransportDocument.Status = TransportDocumentStatus.Send;
                                        voyageNotification.TransportReferenceId = sonuc.seferId;

                                        history = View.ObjectSpace.CreateObject<VoyageNotificationHistory>();
                                        history.CreatedOn = DateTime.Now;
                                        history.Message = "Sefer Bildirimi Başarılı.";
                                        history.VoyageNotification = voyageNotification;

                                        voyageNotification.Histories.Add(history);
                                    }
                                    else
                                    {
                                        history = View.ObjectSpace.CreateObject<VoyageNotificationHistory>();
                                        history.CreatedOn = DateTime.Now;
                                        history.Message = sonuc.sonucMesaji;
                                        history.VoyageNotification = voyageNotification;

                                        voyageNotification.Histories.Add(history);
                                    }
                                }
                                else
                                {
                                    history = View.ObjectSpace.CreateObject<VoyageNotificationHistory>();
                                    history.CreatedOn = DateTime.Now;
                                    history.Message = "Sefer Ekleme  Servisi yanıtı bulunamadı..";
                                    history.VoyageNotification = voyageNotification;

                                    voyageNotification.Histories.Add(history);
                                }

                                View.ObjectSpace.SetModified(voyageNotification);
                                View.ObjectSpace.CommitChanges();
                                View.RefreshDataSource();
                                View.Refresh();
                            }
                            else
                                throw new UserFriendlyException("U-ETDS Kullanıcı Giriş Bilgileri Bulunamadı.. Lütfen Kontrol Ediniz..");
                        }
                        else
                            throw new UserFriendlyException("Kayıtlı Müşteri Bilgisi Bulunamadı.. Lütfen Kontrol Ediniz..");
                    }
                    else
                        throw new UserFriendlyException("Müşteri Türünde Olmayan Kullanıcılar İşlem Yapma Yetkisine Sahip Değildir..");
                }
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(ex.Message);
            }
        }
    }
}
