using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
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
using iyibir.TMGD.Module.UETDSHelper;

namespace iyibir.TMGD.Module.Controllers.UetdsTestControllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class UetdsTestListViewController : ViewController
    {
        public UetdsTestListViewController()
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

        private void uetdsTest_Execute(object sender, SimpleActionExecuteEventArgs e)
        {

            BasicHttpBinding binding = new BasicHttpBinding();
            binding.Security.Mode = BasicHttpSecurityMode.Transport;
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;

            string uri = "https://servis.turkiye.gov.tr/services/g2g/kdgm/test/uetdsesya";

            UEDTSTestService.UdhbUetdsEsyaWsServiceClient client = new UEDTSTestService.UdhbUetdsEsyaWsServiceClient(binding, new EndpointAddress(uri));


            client.ClientCredentials.UserName.UserName = "859272";
            client.ClientCredentials.UserName.Password = "FREPP1B73K";

            client.Open();

            UEDTSTestService.uetdsYtsUser wsuser = SettingYtsUser();

            UetdsService.uetdsEsyaParamEsyaTurSonuc sonuc = new UETDSHelper.UETDSHelper("859272", "FREPP1B73K").GetYukTuru(1.ToString());
        }

        private static UEDTSTestService.uetdsYtsUser SettingYtsUser()
        {
            UEDTSTestService.uetdsYtsUser wsuser = new UEDTSTestService.uetdsYtsUser();
            wsuser.kullaniciAdi = "859272";
            wsuser.sifre = "FREPP1B73K";

            return wsuser;
        }

        private static UEDTSTestService.uetdsEsyaSeferBilgileriInputV3 SettingSeferBilgileri()
        {
            UEDTSTestService.uetdsEsyaSeferBilgileriInputV3 seferBilgileriInput = new UEDTSTestService.uetdsEsyaSeferBilgileriInputV3();
            seferBilgileriInput.baslangicSaati = "";
            seferBilgileriInput.baslangicTarihi = DateTime.Now.ToString();
            seferBilgileriInput.sofor2TCNo = "11111111111";

            return seferBilgileriInput;
        }
    }
}
