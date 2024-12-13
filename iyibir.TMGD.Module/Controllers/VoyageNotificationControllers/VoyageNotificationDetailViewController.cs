using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using iyibir.TMGD.Module.BusinessObjects;
using UETDS.Module;
using UETDSClient;

namespace iyibir.TMGD.Module.Controllers.VoyageNotificationControllers;

public partial class VoyageNotificationDetailViewController : ViewController
{
    public VoyageNotificationDetailViewController()
    {
        InitializeComponent();
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

                        List<uetdsEsyaYukBilgileriInputV3> yukBilgileriInputList = new List<uetdsEsyaYukBilgileriInputV3>();

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
                            string yukMiktari = item.LoadQuantity.ToString();//25,5
                            if (yukMiktari.Contains(','))
                            {
                               yukMiktari = yukMiktari.Replace(',', '.');
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

                            uetdsEsyaYukBilgileriInputV3 yukBilgi = new uetdsEsyaYukBilgileriInputV3() {

                                aliciUnvan = item.ConsigneeTitle,
                                aliciVergiNo = item.ConsigneeVKN,
                                bosaltmaIlceMernisKodu = item.ConsigneeCountyMernisCode,
                                bosaltmaIlMernisKodu = item.ConsigneeCityMernisCode,
                                bosaltmaSaati = bosaltmaSaati,
                                bosaltmaTarihi = bosaltmaTarihi,
                                bosaltmaUlkeKodu = item.ConsigneeCountryCode,
                                bozulabilirGidaYukCinsId = string.Empty,
									firmaYukNo = item.FirmLoadNumber,
									gonderenUnvan = item.ConsignerTitle,
									gonderenVergiNo = item.ConsignerVKN,
									muafiyetTuru = muafiyetTuru,
									tasimaTuruKodu = tasimaTuruKodu,
									tehlikeliMaddeTasimaSekli = tehlikeliMaddeTasimaSekli,
									unId = item.UnId,
									yukCinsDigerAciklama = item.LoadOtherDescription,
									yukCinsId = item.LoadType.Code,
									yuklemeIlceMernisKodu = item.ConsignerCountyMernisCode,
									yuklemeIlMernisKodu = item.ConsignerCityMernisCode,
									yuklemeSaati = yuklemeSaati,
									yuklemeTarihi = yuklemeTarihi,
									yuklemeUlkeKodu = item.ConsignerCountryCode,
									yukMiktari = yukMiktari,
                                yukMiktariBirimi = yukMiktariBirimi
								};

                                
                                //customer.UETDSUsername, customer.UETDSPassword).SettingYukBilgileri(item.ConsigneeTitle, item.ConsigneeVKN, item.ConsigneeCountyMernisCode, item.ConsigneeCityMernisCode, bosaltmaSaati, bosaltmaTarihi, item.ConsigneeCountryCode, item.FirmLoadNumber, item.ConsignerTitle, item.ConsignerVKN, muafiyetTuru, tasimaTuruKodu, tehlikeliMaddeTasimaSekli, item.UnId, item.LoadOtherDescription, item.LoadType.Code, item.ConsignerCountyMernisCode, item.ConsignerCityMernisCode, yuklemeSaati, yuklemeTarihi, item.ConsignerCountryCode, yukMiktari, yukMiktariBirimi);

                            yukBilgileriInputList.Add(yukBilgi);

                        }


                        if (yukBilgileriInputList.Count > 0)
                        {
                            var client = UETDSProvider.GetClient(customer.UETDSUsername, customer.UETDSPassword);

								sefereYukEkleV3Request request = new sefereYukEkleV3Request();
								request.yukBilgileriInputList = yukBilgileriInputList.ToArray();
                            request.seferId = voyageNotification.ReferenceId;
                            request.wsuser = UETDSProvider.GetWsUser(customer.UETDSUsername, customer.UETDSPassword);

								uetdsEsyaYeniYukEkleSonucV3 sonucYuk = UETDSProvider.sefereYukEkleV3(client, request);
								

								//UetdsService.uetdsEsyaYeniYukEkleSonucV3 sonucYuk = new UETDSHelper.UETDSHelper(customer.UETDSUsername, customer.UETDSPassword).SefereYukEkle(voyageNotification.ReferenceId, yukBilgileriInputList.ToArray());
                            if (sonucYuk != null)
                            {
                                if (sonucYuk.sonucKodu == 0)
                                {
                                    foreach (uetdsEsyaSonucV3 esyaSonuc in sonucYuk.uetdsEsyaSonuc.ToList().OrderBy(x => x.sira))
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
