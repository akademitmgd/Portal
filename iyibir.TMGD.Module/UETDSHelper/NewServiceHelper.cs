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
    public class NewServiceHelper
    {
        internal string Username;
        internal string Password;
        public NewServiceHelper(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public NewService.uetdsYtsUser SettingYtsUser()
        {
            NewService.uetdsYtsUser wsuser = new NewService.uetdsYtsUser();
            wsuser.kullaniciAdi = Username;
            wsuser.sifre = Password;

            return wsuser;
        }
        public NewService.UdhbUetdsEsyaWsServiceClient GetClient()
        {
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.Security.Mode = BasicHttpSecurityMode.Transport;
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;

            string uri = "https://servis.turkiye.gov.tr/services/g2g/kdgm/uetdsesya?wsdl";

            NewService.UdhbUetdsEsyaWsServiceClient client = new NewService.UdhbUetdsEsyaWsServiceClient(binding, new EndpointAddress(uri));

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

        public NewService.uetdsEsyaSeferEkleSonucV3 YeniSeferEkle(string baslangicSaati, string baslangicTarihi, string bitisSaati, string bitisTarihi, string firmaSeferNo, string plaka1, string plaka2, string sofor1TCNo, string sofor2TCNo)
        {
            NewService.uetdsYtsUser wsuser = SettingYtsUser();

            NewService.uetdsEsyaSeferBilgileriInputV3 seferBilgileriInput = SettingSeferBilgileri(baslangicSaati, baslangicTarihi, bitisSaati, bitisTarihi, firmaSeferNo, plaka1, plaka2, sofor1TCNo, sofor2TCNo);

            NewService.UdhbUetdsEsyaWsServiceClient client = GetClient();

            NewService.uetdsEsyaSeferEkleSonucV3 sonuc = client.yeniSeferEkleV3(wsuser, seferBilgileriInput);

            return sonuc;
        }

        public NewService.uetdsEsyaSeferBilgileriInputV3 SettingSeferBilgileri(string baslangicSaati, string baslangicTarihi, string bitisSaati, string bitisTarihi, string firmaSeferNo, string plaka1, string plaka2, string sofor1TCNo, string sofor2TCNo)
        {
            NewService.uetdsEsyaSeferBilgileriInputV3 seferBilgileriInput = new NewService.uetdsEsyaSeferBilgileriInputV3();
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

    }
}
