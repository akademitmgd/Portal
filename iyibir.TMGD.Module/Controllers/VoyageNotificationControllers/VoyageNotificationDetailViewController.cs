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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iyibir.TMGD.Module.Controllers.VoyageNotificationControllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class VoyageNotificationDetailViewController : ViewController
    {
        public VoyageNotificationDetailViewController()
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

        private void approveVoyageNotificationTransactions_Execute(object sender, SimpleActionExecuteEventArgs e)
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

                            List<UetdsService.uetdsEsyaYukBilgileriInputV3> yukBilgileriInputList = new List<UetdsService.uetdsEsyaYukBilgileriInputV3>();

                            foreach (VoyageNotificationTransaction item in voyageNotification.Transactions.OrderBy(x => x.LineNumber))
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
                                        muafiyetTuru = "YOK";
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

                                UetdsService.uetdsEsyaYukBilgileriInputV3 yukBilgi = new UETDSHelper.UETDSHelper(customer.UETDSUsername, customer.UETDSPassword).SettingYukBilgileri(item.ConsigneeTitle, item.ConsigneeVKN, item.ConsigneeCountyMernisCode, item.ConsigneeCityMernisCode, bosaltmaSaati, bosaltmaTarihi, item.ConsigneeCountryCode, item.FirmLoadNumber, item.ConsignerTitle, item.ConsignerVKN, muafiyetTuru, tasimaTuruKodu, tehlikeliMaddeTasimaSekli, item.UnId, item.LoadOtherDescription, item.LoadType.Code, item.ConsignerCountyMernisCode, item.ConsignerCityMernisCode, yuklemeSaati, yuklemeTarihi, item.ConsignerCountryCode, yukMiktari, yukMiktariBirimi);

                                yukBilgileriInputList.Add(yukBilgi);

                            }


                            if (yukBilgileriInputList.Count > 0)
                            {
                                UetdsService.uetdsEsyaYeniYukEkleSonucV3 sonucYuk = new UETDSHelper.UETDSHelper(customer.UETDSUsername, customer.UETDSPassword).SefereYukEkle(voyageNotification.ReferenceId, yukBilgileriInputList.ToArray());
                                if (sonucYuk != null)
                                {
                                    if (sonucYuk.sonucKodu == 0)
                                    {
                                        foreach (UetdsService.uetdsEsyaSonucV3 esyaSonuc in sonucYuk.uetdsEsyaSonuc.ToList().OrderBy(x => x.sira))
                                        {
                                            VoyageNotificationTransaction transaction = voyageNotification.Transactions.FirstOrDefault(x => x.LineNumber == esyaSonuc.sira);
                                            if (transaction != null)
                                            {
                                                transaction.Status = VoyageNotificationTransactionStatus.Sent;
                                                transaction.ReferenceId = esyaSonuc.yukId;

                                                history = View.ObjectSpace.CreateObject<VoyageNotificationHistory>();
                                                history.CreatedOn = DateTime.Now;
                                                history.Message = string.Format("{0} Un Id'li yük sefere eklenmiştir.", transaction.UnId);
                                                history.VoyageNotification = voyageNotification;

                                                voyageNotification.Histories.Add(history);
                                            }
                                            else
                                            {
                                                history = View.ObjectSpace.CreateObject<VoyageNotificationHistory>();
                                                history.CreatedOn = DateTime.Now;
                                                history.Message = string.Format("{0} sıra numaralı yük bulunamadı.", esyaSonuc.sira);
                                                history.VoyageNotification = voyageNotification;

                                                voyageNotification.Histories.Add(history);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        history = View.ObjectSpace.CreateObject<VoyageNotificationHistory>();
                                        history.CreatedOn = DateTime.Now;

                                        foreach (var item in sonucYuk.uetdsEsyaSonuc)
                                        {
                                            history.Message += string.Format("{0}\n", item.sonucMesaji);
                                        }

                                        history.VoyageNotification = voyageNotification;

                                        voyageNotification.Histories.Add(history);
                                    }
                                }
                                else
                                {
                                    history = View.ObjectSpace.CreateObject<VoyageNotificationHistory>();
                                    history.CreatedOn = DateTime.Now;
                                    history.Message = "Sefere Yük Ekleme Servisi yanıtı bulunamadı..";
                                    history.VoyageNotification = voyageNotification;

                                    voyageNotification.Histories.Add(history);
                                }

                                View.ObjectSpace.SetModified(voyageNotification);
                                View.ObjectSpace.CommitChanges();
                                View.RefreshDataSource();
                                View.Refresh();
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
            else
            {
                throw new UserFriendlyException("Sefer bulunamadı..");
            }
        }
    }
}
