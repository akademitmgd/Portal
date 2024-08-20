using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;

namespace iyibir.TMGD.Module.UETDSHelper
{
    public class UETDSHelper
    {
        internal string Username;
        internal string Password;
        public UETDSHelper(string username, string password)
        {
            Username = username;
            Password = password;
        }
        public UetdsService.UdhbUetdsEsyaWsServiceClient GetClient()
        {
            try
            {
                BasicHttpBinding binding = new BasicHttpBinding();
                binding.Security.Mode = BasicHttpSecurityMode.Transport;
                binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;

                string uri = "https://servis.turkiye.gov.tr/services/g2g/kdgm/uetdsesya?wsdl";

                UetdsService.UdhbUetdsEsyaWsServiceClient client = new UetdsService.UdhbUetdsEsyaWsServiceClient(binding, new EndpointAddress(uri));

                client.ClientCredentials.UserName.UserName = Username;
                client.ClientCredentials.UserName.Password = Password;

                client.ClientCredentials.ServiceCertificate.SslCertificateAuthentication = new X509ServiceCertificateAuthentication()
                {
                    CertificateValidationMode = X509CertificateValidationMode.None,
                    RevocationMode = System.Security.Cryptography.X509Certificates.X509RevocationMode.NoCheck
                };

                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

                return client;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            #region 24.05.2022 çalışan kodlar
            //BasicHttpBinding binding = new BasicHttpBinding();
            //binding.Security.Mode = BasicHttpSecurityMode.Transport;
            //binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;

            //string uri = "https://servis.turkiye.gov.tr/services/g2g/kdgm/uetdsesya?wsdl";

            //UetdsService.UdhbUetdsEsyaWsServiceClient client = new UetdsService.UdhbUetdsEsyaWsServiceClient(binding, new EndpointAddress(uri));

            //client.ClientCredentials.UserName.UserName = Username;
            //client.ClientCredentials.UserName.Password = Password;

            //return client; 
            #endregion
        }
        public UetdsService.uetdsYtsUser SettingYtsUser()
        {
            UetdsService.uetdsYtsUser wsuser = new UetdsService.uetdsYtsUser();
            wsuser.kullaniciAdi = Username;
            wsuser.sifre = Password;

            return wsuser;
        }
        public UetdsService.uetdsEsyaSeferBilgileriInputV3 SettingSeferBilgileri(string baslangicSaati, string baslangicTarihi, string bitisSaati, string bitisTarihi, string firmaSeferNo, string plaka1, string plaka2, string sofor1TCNo, string sofor2TCNo)
        {
            UetdsService.uetdsEsyaSeferBilgileriInputV3 seferBilgileriInput = new UetdsService.uetdsEsyaSeferBilgileriInputV3();
            seferBilgileriInput.baslangicSaati = baslangicSaati;
            seferBilgileriInput.baslangicTarihi = baslangicTarihi;
            seferBilgileriInput.bitisSaati = bitisSaati;
            seferBilgileriInput.bitisTarihi = bitisTarihi;
            seferBilgileriInput.firmaSeferNo = firmaSeferNo;
            seferBilgileriInput.plaka1 = plaka1;
            seferBilgileriInput.plaka2 = plaka2;
            seferBilgileriInput.sofor1TCNo = sofor1TCNo;
            seferBilgileriInput.sofor2TCNo = sofor2TCNo;

            return seferBilgileriInput;
        }
        public UetdsService.uetdsEsyaSeferEkleSonucV3 YeniSeferEkle(string baslangicSaati, string baslangicTarihi, string bitisSaati, string bitisTarihi, string firmaSeferNo, string plaka1, string plaka2, string sofor1TCNo, string sofor2TCNo)
        {
            try
            {
                UetdsService.uetdsYtsUser wsuser = SettingYtsUser();

                UetdsService.uetdsEsyaSeferBilgileriInputV3 seferBilgileriInput = SettingSeferBilgileri(baslangicSaati, baslangicTarihi, bitisSaati, bitisTarihi, firmaSeferNo, plaka1, plaka2, sofor1TCNo, sofor2TCNo);

                UetdsService.UdhbUetdsEsyaWsServiceClient client = GetClient();

                UetdsService.uetdsEsyaSeferEkleSonucV3 sonuc = client.yeniSeferEkleV3(wsuser, seferBilgileriInput);
                

                return sonuc;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public UetdsService.uetdsGenelPdfSonuc SeferRaporu(long seferId)
        {
            UetdsService.uetdsYtsUser wsuser = SettingYtsUser();

            UetdsService.UdhbUetdsEsyaWsServiceClient client = GetClient();

            UetdsService.uetdsGenelPdfSonuc sonuc = client.seferRaporuV3(wsuser, seferId);

            return sonuc;
        }

        public UetdsService.uetdsEsyaYeniYukEkleSonucV3 SefereYukEkle(long seferId, string aliciUnvan, string aliciVergiNo, string bosaltmaIlceMernisKodu, string bosaltmaIlMernisKodu, string bosaltmaSaati, string bosaltmaTarihi, string bosaltmaUlkeKodu, string firmaYukNo, string gonderenUnvan, string gonderenVergiNo, string muafiyetTuru, string tasimaTuruKodu, string tehlikeliMaddeTasimaSekli, string unId, string yukCinsDigerAciklama, string yukCinsId, string yuklemeIlceMernisKodu, string yuklemeIlMernisKodu, string yuklemeSaati, string yuklemeTarihi, string yuklemeUlkeKodu, string yukMiktari, string yukMiktariBirimi)
        {
            UetdsService.UdhbUetdsEsyaWsServiceClient client = GetClient();

            UetdsService.uetdsYtsUser wsuser = SettingYtsUser();

            UetdsService.uetdsEsyaYukBilgileriInputV3 yukBilgileriInput = SettingYukBilgileri(aliciUnvan, aliciVergiNo, bosaltmaIlceMernisKodu, bosaltmaIlMernisKodu, bosaltmaSaati, bosaltmaTarihi, bosaltmaUlkeKodu, firmaYukNo, gonderenUnvan, gonderenVergiNo, muafiyetTuru, tasimaTuruKodu, tehlikeliMaddeTasimaSekli, unId, yukCinsDigerAciklama, yukCinsId, yuklemeIlceMernisKodu, yuklemeIlMernisKodu, yuklemeSaati, yuklemeTarihi, yuklemeUlkeKodu, yukMiktari, yukMiktariBirimi);

            List<UetdsService.uetdsEsyaYukBilgileriInputV3> list = new List<UetdsService.uetdsEsyaYukBilgileriInputV3>();
            list.Add(yukBilgileriInput);

            UetdsService.uetdsEsyaYukBilgileriInputV3[] yukBilgileriInputList = list.ToArray();

            UetdsService.uetdsEsyaYeniYukEkleSonucV3 sonuc = client.sefereYukEkleV3(wsuser, seferId, yukBilgileriInputList);

            return sonuc;
        }
        public UetdsService.uetdsEsyaYukBilgileriInputV3 SettingYukBilgileri(string aliciUnvan, string aliciVergiNo, string bosaltmaIlceMernisKodu, string bosaltmaIlMernisKodu, string bosaltmaSaati, string bosaltmaTarihi, string bosaltmaUlkeKodu, string firmaYukNo, string gonderenUnvan, string gonderenVergiNo, string muafiyetTuru, string tasimaTuruKodu, string tehlikeliMaddeTasimaSekli, string unId, string yukCinsDigerAciklama, string yukCinsId, string yuklemeIlceMernisKodu, string yuklemeIlMernisKodu, string yuklemeSaati, string yuklemeTarihi, string yuklemeUlkeKodu, string yukMiktari, string yukMiktariBirimi)
        {
            UetdsService.uetdsEsyaYukBilgileriInputV3 yukBilgileriInput = new UetdsService.uetdsEsyaYukBilgileriInputV3();
            yukBilgileriInput.aliciUnvan = aliciUnvan;
            yukBilgileriInput.aliciVergiNo = aliciVergiNo;
            yukBilgileriInput.bosaltmaIlceMernisKodu = bosaltmaIlceMernisKodu;
            yukBilgileriInput.bosaltmaIlMernisKodu = bosaltmaIlMernisKodu;
            yukBilgileriInput.bosaltmaSaati = bosaltmaSaati;
            yukBilgileriInput.bosaltmaTarihi = bosaltmaTarihi;
            yukBilgileriInput.bosaltmaUlkeKodu = bosaltmaUlkeKodu;
            yukBilgileriInput.firmaYukNo = firmaYukNo;
            yukBilgileriInput.gonderenUnvan = gonderenUnvan;
            yukBilgileriInput.gonderenVergiNo = gonderenVergiNo;
            yukBilgileriInput.muafiyetTuru = muafiyetTuru;
            yukBilgileriInput.tasimaTuruKodu = tasimaTuruKodu;
            yukBilgileriInput.tehlikeliMaddeTasimaSekli = tehlikeliMaddeTasimaSekli;
            yukBilgileriInput.unId = unId;
            yukBilgileriInput.yukCinsDigerAciklama = yukCinsDigerAciklama;
            yukBilgileriInput.yukCinsId = yukCinsId;
            yukBilgileriInput.yuklemeIlceMernisKodu = yuklemeIlceMernisKodu;
            yukBilgileriInput.yuklemeIlMernisKodu = yuklemeIlMernisKodu;
            yukBilgileriInput.yuklemeSaati = yuklemeSaati;
            yukBilgileriInput.yuklemeTarihi = yuklemeTarihi;
            yukBilgileriInput.yuklemeUlkeKodu = yuklemeUlkeKodu;
            yukBilgileriInput.yukMiktari = yukMiktari;
            yukBilgileriInput.yukMiktariBirimi = yukMiktariBirimi;

            return yukBilgileriInput;
        }

        public UetdsService.uetdsEsyaYeniYukEkleSonucV3 SefereYukEkle(long seferId, UetdsService.uetdsEsyaYukBilgileriInputV3[] yukBilgileriInputList)
        {
            UetdsService.UdhbUetdsEsyaWsServiceClient client = GetClient();

            UetdsService.uetdsYtsUser wsuser = SettingYtsUser();

            UetdsService.uetdsEsyaYeniYukEkleSonucV3 sonuc = client.sefereYukEkleV3(wsuser, seferId, yukBilgileriInputList);

            return sonuc;
        }

        public UetdsService.uetdsEsyaParamYukBirimiSonuc GetYukBirimi(string tasimaTuruKodu)
        {
            UetdsService.UdhbUetdsEsyaWsServiceClient client = GetClient();

            UetdsService.uetdsYtsUser wsuser = SettingYtsUser();

            UetdsService.uetdsEsyaParamYukBirimiSonuc sonuc = client.paramYukBirimi(wsuser, tasimaTuruKodu);

            return sonuc;
        }
        public UetdsService.uetdsEsyaParamEsyaTurSonuc GetYukTuru(string tasimaTuruKodu)
        {
            UetdsService.uetdsYtsUser wsuser = SettingYtsUser();

            UetdsService.UdhbUetdsEsyaWsServiceClient client = GetClient();

            UetdsService.uetdsEsyaParamEsyaTurSonuc sonuc = client.paramYukTuru(wsuser, tasimaTuruKodu);

            return sonuc;
        }
        public UetdsService.uetdsEsyaParamTehlikeliMaddeTasimaSekliSonuc GetTehlikeliMaddeTasimaSekli()
        {
            UetdsService.uetdsYtsUser wsuser = SettingYtsUser();

            UetdsService.UdhbUetdsEsyaWsServiceClient client = GetClient();

            UetdsService.uetdsEsyaParamTehlikeliMaddeTasimaSekliSonuc sonuc = client.paramTehlikeliMaddeTasimaSekli(wsuser);

            return sonuc;
        }
        public UetdsService.uetdsEsyaParamMuafiyetTuruSonuc GetTehlikeliMaddeMuafiyetTurleri()
        {
            UetdsService.uetdsYtsUser wsuser = SettingYtsUser();

            UetdsService.UdhbUetdsEsyaWsServiceClient client = GetClient();

            UetdsService.uetdsEsyaParamMuafiyetTuruSonuc sonuc = client.paramTehlikeMaddeMuafiyetTurleri(wsuser);

            return sonuc;
        }
        public UetdsService.uetdsEsyaParamTasimaTuruSonuc GetTasimaTurleri()
        {
            UetdsService.uetdsYtsUser wsuser = SettingYtsUser();

            UetdsService.UdhbUetdsEsyaWsServiceClient client = GetClient();

            UetdsService.uetdsEsyaParamTasimaTuruSonuc sonuc = client.paramTasimaTurleri(wsuser);

            return sonuc;
        }
        public UetdsService.uetdsEsyaSeferDetayiSonucV3 GetSeferDetayi(long seferId)
        {
            UetdsService.uetdsYtsUser wsuser = SettingYtsUser();

            UetdsService.UdhbUetdsEsyaWsServiceClient client = GetClient();

            UetdsService.uetdsEsyaSeferDetayiSonucV3 sonuc = client.seferDetayiV3(wsuser, seferId);

            return sonuc;
        }
        public UetdsService.uetdsMuayeneSorguSonuc AracMuayeneBilgileri(string plaka)
        {
            UetdsService.uetdsYtsUser wsuser = SettingYtsUser();

            UetdsService.UdhbUetdsEsyaWsServiceClient client = GetClient();

            UetdsService.uetdsMuayeneSorguSonuc sonuc = client.aracMuayeneSorgula(wsuser, plaka);

            return sonuc;
        }
        public UetdsService.uetdsFirmaSonuc YetkiBelgesiKontrol(string plate)
        {
            UetdsService.uetdsYtsUser wsuser = SettingYtsUser();

            UetdsService.UdhbUetdsEsyaWsServiceClient client = GetClient();

            UetdsService.uetdsFirmaSonuc sonuc = client.yetkiBelgesiKontrol(wsuser, plate);

            return sonuc;
        }
        public UetdsService.uetdsMesSorguSonuc MeslekiYeterlilikSorgula(string kimlikNo)
        {
            UetdsService.uetdsYtsUser wsuser = SettingYtsUser();

            UetdsService.UdhbUetdsEsyaWsServiceClient client = GetClient();

            UetdsService.uetdsMesSorguSonuc sonuc = client.meslekiYeterlilikSorgula(wsuser, kimlikNo);

            return sonuc;
        }
        public UetdsService.uetdsEsyaParamIptalTuruSonuc IptalTurleri()
        {
            UetdsService.uetdsYtsUser wsuser = SettingYtsUser();

            UetdsService.UdhbUetdsEsyaWsServiceClient client = GetClient();

            UetdsService.uetdsEsyaParamIptalTuruSonuc sonuc = client.iptalTurleri(wsuser);

            return sonuc;
        }
        public UetdsService.uetdsGenelIslemSonuc YukIptalEt(long yukId, string yukIptalTurKodu, string yukIptalAciklama)
        {
            UetdsService.uetdsYtsUser wsuser = SettingYtsUser();

            UetdsService.UdhbUetdsEsyaWsServiceClient client = GetClient();

            UetdsService.uetdsGenelIslemSonuc sonuc = client.yukIptalEtV3(wsuser, yukId, yukIptalTurKodu, yukIptalAciklama);

            return sonuc;
        }
        public UetdsService.uetdsGenelIslemSonuc YukAktifEt(long yukId)
        {
            UetdsService.uetdsYtsUser wsuser = SettingYtsUser();

            UetdsService.UdhbUetdsEsyaWsServiceClient client = GetClient();

            UetdsService.uetdsGenelIslemSonuc sonuc = client.yukAktifEtV3(wsuser, yukId);

            return sonuc;
        }
        public UetdsService.uetdsGenelIslemSonuc SeferIptalEt(long seferId, string seferIptalTurKodu, string seferIptalAciklama)
        {
            UetdsService.uetdsYtsUser wsuser = SettingYtsUser();

            UetdsService.UdhbUetdsEsyaWsServiceClient client = GetClient();

            UetdsService.uetdsGenelIslemSonuc sonuc = client.seferIptalEtV3(wsuser, seferId, seferIptalTurKodu, seferIptalAciklama);

            return sonuc;
        }
        public UetdsService.uetdsGenelIslemSonuc SeferAktifEt(long seferId)
        {
            UetdsService.uetdsYtsUser wsuser = SettingYtsUser();

            UetdsService.UdhbUetdsEsyaWsServiceClient client = GetClient();

            UetdsService.uetdsGenelIslemSonuc sonuc = client.seferAktifEtV3(wsuser, seferId);

            return sonuc;
        }
        public UetdsService.uetdsGenelIslemSonuc SeferDuzenle(long seferId, string baslangicSaati, string baslangicTarihi, string bitisSaati, string bitisTarihi, string firmaSeferNo, string plaka1, string plaka2, string sofor1TCNo, string sofor2TCNo)
        {
            UetdsService.uetdsYtsUser wsuser = SettingYtsUser();

            UetdsService.UdhbUetdsEsyaWsServiceClient client = GetClient();

            UetdsService.uetdsEsyaSeferBilgileriInputV3 seferBilgileriInput = SettingSeferBilgileri(baslangicSaati, baslangicTarihi, bitisSaati, bitisTarihi, firmaSeferNo, plaka1, plaka2, sofor1TCNo, sofor2TCNo);

            UetdsService.uetdsGenelIslemSonuc sonuc = client.seferDuzenleV3(wsuser, seferId, seferBilgileriInput);

            return sonuc;
        }
        public UetdsService.uetdsGenelIslemSonuc YukDuzenle(long yukId, string aliciUnvan, string aliciVergiNo, string bosaltmaIlceMernisKodu, string bosaltmaIlMernisKodu, string bosaltmaSaati, string bosaltmaTarihi, string bosaltmaUlkeKodu, string firmaYukNo, string gonderenUnvan, string gonderenVergiNo, string muafiyetTuru, string tasimaTuruKodu, string tehlikeliMaddeTasimaSekli, string unId, string yukCinsDigerAciklama, string yukCinsId, string yuklemeIlceMernisKodu, string yuklemeIlMernisKodu, string yuklemeSaati, string yuklemeTarihi, string yuklemeUlkeKodu, string yukMiktari, string yukMiktariBirimi)
        {
            UetdsService.uetdsYtsUser wsuser = SettingYtsUser();

            UetdsService.UdhbUetdsEsyaWsServiceClient client = GetClient();

            UetdsService.uetdsEsyaYukBilgileriInputV3 yukBilgileriInput = SettingYukBilgileri(aliciUnvan, aliciVergiNo, bosaltmaIlceMernisKodu, bosaltmaIlMernisKodu, bosaltmaSaati, bosaltmaTarihi, bosaltmaUlkeKodu, firmaYukNo, gonderenUnvan, gonderenVergiNo, muafiyetTuru, tasimaTuruKodu, tehlikeliMaddeTasimaSekli, unId, yukCinsDigerAciklama, yukCinsId, yuklemeIlceMernisKodu, yuklemeIlMernisKodu, yuklemeSaati, yuklemeTarihi, yuklemeUlkeKodu, yukMiktari, yukMiktariBirimi);

            UetdsService.uetdsGenelIslemSonuc sonuc = client.yukDuzenleV3(wsuser, yukId, yukBilgileriInput);

            return sonuc;
        }

    }
}
