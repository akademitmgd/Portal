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

namespace iyibir.TMGD.Module.Controllers.VoyageNotificationTransactionControllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class VoyageNotificationTransactionListViewController : ViewController
    {
        public VoyageNotificationTransactionListViewController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
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

        private void cancelledTransaction_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            VoyageNotificationTransaction transaction = View.CurrentObject as VoyageNotificationTransaction;
            if (transaction != null)
            {
                IObjectSpace np_os = Application.CreateObjectSpace(typeof(NP_VoyageNotificationTransactionCancelled));
                NP_VoyageNotificationTransactionCancelled cancelled = np_os.CreateObject<NP_VoyageNotificationTransactionCancelled>();
                cancelled.ReferenceId = transaction.ReferenceId;

                DetailView detailView = Application.CreateDetailView(np_os, cancelled);
                detailView.ViewEditMode = ViewEditMode.Edit;
                e.View = detailView;
                e.DialogController.AcceptAction.Execute += cancelledTransaction_AcceptAction_Execute;

            }
            else
            {
                throw new UserFriendlyException("Seçili öge bulunamadı..");
            }
        }

        private void cancelledTransaction_AcceptAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            VoyageNotificationTransaction transaction = View.CurrentObject as VoyageNotificationTransaction;
            if (transaction != null)
            {
                NP_VoyageNotificationTransactionCancelled cancelled = e.CurrentObject as NP_VoyageNotificationTransactionCancelled;
                if (cancelled != null)
                {
                    if (cancelled.CancelledType == VoyageNotificationTransactionCancelledType.NA)
                        throw new UserFriendlyException("İptal türü boş geçilemez. Lütfen bir seçim yapınız..");

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
                                    UetdsService.uetdsGenelIslemSonuc sonuc = new UETDSHelper.UETDSHelper(customer.UETDSUsername,customer.UETDSPassword).YukIptalEt(transaction.ReferenceId, cancelled.CancelledType == VoyageNotificationTransactionCancelledType.ArizaNedeniIleIptal ? "2" : "1", cancelled.CancelledDescription);
                                    if (sonuc != null)
                                    {
                                        if (sonuc.sonucKodu == 0)
                                        {
                                            VoyageNotification voyageNotification = View.ObjectSpace.GetObjectByKey<VoyageNotification>(transaction.VoyageNotification.Oid);
                                            if (voyageNotification != null)
                                            {
                                                VoyageNotificationHistory history = View.ObjectSpace.CreateObject<VoyageNotificationHistory>();
                                                history.VoyageNotification = voyageNotification;
                                                history.CreatedOn = DateTime.Now;
                                                history.Message = string.Format("UNID 'li yük iptal edildi.", transaction.UnId);

                                                voyageNotification.Histories.Add(history);

                                                transaction.CancelledDate = cancelled.CancelledDate;
                                                transaction.CancelledDescription = cancelled.CancelledDescription;
                                                transaction.CancelledType = cancelled.CancelledType;
                                                transaction.Status = VoyageNotificationTransactionStatus.Cancelled;

                                                View.ObjectSpace.SetModified(voyageNotification);
                                                View.ObjectSpace.CommitChanges();
                                                View.RefreshDataSource();
                                                View.Refresh();
                                            }

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
                    throw new UserFriendlyException("İptal Seçenekleri Ekranı Bulunamadı..");
                }
            }
            else
            {
                throw new UserFriendlyException("Seçili öge bulunamadı..");
            }
        }

        private void aktivatedTransaction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            VoyageNotificationTransaction transaction = View.CurrentObject as VoyageNotificationTransaction;
            if (transaction != null)
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
                                UetdsService.uetdsGenelIslemSonuc sonuc = new UETDSHelper.UETDSHelper(customer.UETDSUsername,customer.UETDSPassword).YukAktifEt(transaction.ReferenceId);
                                if (sonuc != null)
                                {
                                    if (sonuc.sonucKodu == 0)
                                    {
                                        VoyageNotification voyageNotification = View.ObjectSpace.GetObjectByKey<VoyageNotification>(transaction.VoyageNotification.Oid);
                                        if (voyageNotification != null)
                                        {
                                            VoyageNotificationHistory history = View.ObjectSpace.CreateObject<VoyageNotificationHistory>();
                                            history.CreatedOn = DateTime.Now;
                                            history.VoyageNotification = voyageNotification;
                                            history.Message = string.Format("UNID 'li yük aktif edildi..");

                                            voyageNotification.Histories.Add(history);

                                            transaction.Status = VoyageNotificationTransactionStatus.Activated;
                                            transaction.ActivatedDate = DateTime.Now;

                                            View.ObjectSpace.SetModified(voyageNotification);
                                            View.ObjectSpace.CommitChanges();
                                            View.RefreshDataSource();
                                            View.Refresh();
                                        }
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
                throw new UserFriendlyException("Seçili öge bulunamadı..");
        }

        private void updatedTransaction_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            VoyageNotificationTransaction transaction = View.CurrentObject as VoyageNotificationTransaction;
            if (transaction != null)
            {
                IObjectSpace os = Application.CreateObjectSpace();

                IObjectSpace np_os = Application.CreateObjectSpace(typeof(NP_VoyageNotificationTransaction));
                NP_VoyageNotificationTransaction nP_VoyageNotification = np_os.CreateObject<NP_VoyageNotificationTransaction>();
                nP_VoyageNotification.ConsigneeCityMernisCode = transaction.ConsigneeCityMernisCode;
                nP_VoyageNotification.ConsigneeCountryCode = transaction.ConsigneeCountryCode;
                nP_VoyageNotification.ConsigneeCountyMernisCode = transaction.ConsigneeCountyMernisCode;
                nP_VoyageNotification.ConsigneeTitle = transaction.ConsigneeTitle;
                nP_VoyageNotification.ConsigneeVKN = transaction.ConsigneeVKN;
                nP_VoyageNotification.ConsignerCityMernisCode = transaction.ConsignerCityMernisCode;
                nP_VoyageNotification.ConsignerCountryCode = transaction.ConsignerCountryCode;
                nP_VoyageNotification.ConsignerCountyMernisCode = transaction.ConsignerCountyMernisCode;
                nP_VoyageNotification.ConsignerTitle = transaction.ConsignerTitle;
                nP_VoyageNotification.ConsignerVKN = transaction.ConsignerVKN;
                nP_VoyageNotification.FirmLoadNumber = transaction.FirmLoadNumber;
                nP_VoyageNotification.HazardousExemptionType = transaction.HazardousExemptionType;
                nP_VoyageNotification.HazardousTransportType = transaction.HazardousTransportType;
                nP_VoyageNotification.HazardousUnit = transaction.HazardousUnit;
                nP_VoyageNotification.LadingDate = transaction.LadingDate;
                nP_VoyageNotification.LadingTime = transaction.LadingTime;
                nP_VoyageNotification.LoadOtherDescription = transaction.LoadOtherDescription;
                nP_VoyageNotification.LoadQuantity = transaction.LoadQuantity;
                nP_VoyageNotification.LoadType = transaction.LoadType != null ? np_os.GetObjectByKey<LoadType>(transaction.LoadType.Oid) : null;
                nP_VoyageNotification.OtherUnit = transaction.OtherUnit;
                nP_VoyageNotification.PouringDate = transaction.PouringDate;
                nP_VoyageNotification.PouringTime = transaction.PouringTime;
                nP_VoyageNotification.ReferenceId = transaction.ReferenceId;
                nP_VoyageNotification.Status = VoyageNotificationTransactionStatus.Updated;
                nP_VoyageNotification.TransportTypeCode = transaction.TransportTypeCode;
                nP_VoyageNotification.UNId = transaction.UnId;

                DetailView detailView = Application.CreateDetailView(np_os, nP_VoyageNotification);
                detailView.ViewEditMode = ViewEditMode.Edit;
                e.View = detailView;
                e.DialogController.AcceptAction.Execute += updatedTransaction_AcceptAction_Execute;
            }
            else
            {
                throw new UserFriendlyException("Seçili öge bulunamadı..");
            }
        }

        private void updatedTransaction_AcceptAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            VoyageNotificationTransaction transaction = View.CurrentObject as VoyageNotificationTransaction;
            if (transaction != null)
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
                                NP_VoyageNotificationTransaction nP_VoyageNotification = e.CurrentObject as NP_VoyageNotificationTransaction;
                                if (nP_VoyageNotification != null)
                                {
                                    #region SettingDateAndTimeFormat
                                    string bosaltmaSaati = string.Format("{0}:{1}", nP_VoyageNotification.PouringTime.Hours.ToString().PadLeft(2, '0'), nP_VoyageNotification.PouringTime.Minutes.ToString().PadLeft(2, '0'));
                                    string bosaltmaTarihi = string.Format("{0}/{1}/{2}", nP_VoyageNotification.PouringDate.Day.ToString().PadLeft(2, '0'), nP_VoyageNotification.PouringDate.Month.ToString().PadLeft(2, '0'), nP_VoyageNotification.PouringDate.Year);

                                    string yuklemeSaati = string.Format("{0}:{1}", nP_VoyageNotification.LadingTime.Hours.ToString().PadLeft(2, '0'), nP_VoyageNotification.LadingTime.Minutes.ToString().PadLeft(2, '0'));
                                    string yuklemeTarihi = string.Format("{0}/{1}/{2}", nP_VoyageNotification.LadingDate.Day.ToString().PadLeft(2, '0'), nP_VoyageNotification.LadingDate.Month.ToString().PadLeft(2, '0'), nP_VoyageNotification.PouringDate.Year);
                                    #endregion

                                    #region SettingMuafiyetKodu
                                    string muafiyetTuru = string.Empty;
                                    switch (nP_VoyageNotification.HazardousExemptionType)
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
                                    switch (nP_VoyageNotification.TransportTypeCode)
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
                                    switch (nP_VoyageNotification.HazardousTransportType)
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
                                    string yukMiktari = nP_VoyageNotification.LoadQuantity.ToString();
                                    if (yukMiktari.Contains(','))
                                    {
                                        yukMiktari.Replace(',', '.');
                                    }

                                    #endregion

                                    #region SettingYukMiktariBirimi
                                    string yukMiktariBirimi = string.Empty;
                                    if (nP_VoyageNotification.HazardousUnit != HazardousUnit.NA)
                                    {
                                        switch (nP_VoyageNotification.HazardousUnit)
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
                                    else if (nP_VoyageNotification.OtherUnit != OtherUnit.NA)
                                    {
                                        switch (nP_VoyageNotification.OtherUnit)
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

                                    UetdsService.uetdsGenelIslemSonuc sonucYuk = new UETDSHelper.UETDSHelper(customer.UETDSUsername,customer.UETDSPassword).YukDuzenle(nP_VoyageNotification.ReferenceId, nP_VoyageNotification.ConsigneeTitle, nP_VoyageNotification.ConsigneeVKN, nP_VoyageNotification.ConsigneeCountyMernisCode, nP_VoyageNotification.ConsigneeCityMernisCode, bosaltmaSaati, bosaltmaTarihi, nP_VoyageNotification.ConsigneeCountryCode, nP_VoyageNotification.FirmLoadNumber, nP_VoyageNotification.ConsignerTitle, nP_VoyageNotification.ConsignerVKN, muafiyetTuru, tasimaTuruKodu, tehlikeliMaddeTasimaSekli, nP_VoyageNotification.UNId, nP_VoyageNotification.LoadOtherDescription, nP_VoyageNotification.LoadType.Code, nP_VoyageNotification.ConsignerCountyMernisCode, nP_VoyageNotification.ConsignerCityMernisCode, yuklemeSaati, yuklemeTarihi, nP_VoyageNotification.ConsignerCountryCode, yukMiktari, yukMiktariBirimi);
                                    if (sonucYuk != null)
                                    {
                                        if (sonucYuk.sonucKodu == 0)
                                        {
                                            transaction.UpdatedDate = DateTime.Now;
                                            transaction.UnId = nP_VoyageNotification.UNId;
                                            transaction.TransportTypeCode = nP_VoyageNotification.TransportTypeCode;
                                            transaction.Status = VoyageNotificationTransactionStatus.Updated;
                                            transaction.PouringTime = nP_VoyageNotification.PouringTime;
                                            transaction.PouringDate = nP_VoyageNotification.PouringDate;
                                            transaction.OtherUnit = nP_VoyageNotification.OtherUnit;
                                            transaction.LoadType = nP_VoyageNotification.LoadType != null ? View.ObjectSpace.GetObjectByKey<LoadType>(nP_VoyageNotification.LoadType.Oid) : null;
                                            transaction.LoadQuantity = nP_VoyageNotification.LoadQuantity;
                                            transaction.LoadOtherDescription = nP_VoyageNotification.LoadOtherDescription;
                                            transaction.LadingTime = nP_VoyageNotification.LadingTime;
                                            transaction.LadingDate = nP_VoyageNotification.LadingDate;
                                            transaction.HazardousUnit = nP_VoyageNotification.HazardousUnit;
                                            transaction.HazardousTransportType = nP_VoyageNotification.HazardousTransportType;
                                            transaction.HazardousExemptionType = nP_VoyageNotification.HazardousExemptionType;
                                            transaction.FirmLoadNumber = nP_VoyageNotification.FirmLoadNumber;

                                            View.ObjectSpace.SetModified(transaction);
                                            View.ObjectSpace.CommitChanges();
                                            View.RefreshDataSource();
                                            View.Refresh();
                                        }
                                        else
                                        {
                                            throw new UserFriendlyException(sonucYuk.sonucMesaji);
                                        }
                                    }
                                    else
                                    {
                                        throw new UserFriendlyException("Servis Yanıtı Bulunamadı..");
                                    }
                                }
                                else
                                {
                                    throw new UserFriendlyException("Güncelleme bilgileri bulunamadı..");
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
    }
}
