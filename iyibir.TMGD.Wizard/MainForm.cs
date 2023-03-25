using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors;

namespace iyibir.TMGD.Wizard
{
    public partial class MainForm : XtraForm
    {
        IWizardViewModel wizardViewModel;
        public MainForm()
        {
            InitializeComponent();
            var page = wizardViewModel.CurrentPage;
            wizardViewModel = new ViewModels.WizardViewModel(
                new IWizardPageViewModel[]{
                    new ViewModels.StartPageViewModel(),
                    new ViewModels.CustomerValidationViewModel(),
                    new ViewModels.CustomerInformationViewModel(),
                    new ViewModels.ConnectionParameterViewModel(),
                    new ViewModels.ProductListViewModel(),
                    new ViewModels.ProductInstallationViewModel(),
                    new ViewModels.SupplierListViewModel(),
                    new ViewModels.SupplierInstallationViewModel(),
                    new ViewModels.FinishPageViewModel()
                },
                windowsUIView1, this);

            windowsUIView1.AddDocument(new ucStartPage() { Text = "Start" });
            windowsUIView1.AddDocument(new ucCustomerValidationPage() { Text = "Müşteri Entegrasyonu" });
            windowsUIView1.AddDocument(new ucCustomerInformationPage() { Text = "Müşteri Bilgileri" });
            windowsUIView1.AddDocument(new ucConnectionParameterPage() { Text = "Bağlantı Parametreleri" });
            windowsUIView1.AddDocument(new ucProductListPage() { Text = "Tehlikeli Madde Ürün Listesi" });
            windowsUIView1.AddDocument(new ucProductListInstallPage() { Text = "Tehlikeli Madde Ürün Aktarımı" });
            windowsUIView1.AddDocument(new ucSupplierListPage() { Text = "Tedarikçi Listesi" });
            windowsUIView1.AddDocument(new ucSupplierListInstallPage() { Text = "Tedarikçi Aktarımı" });
            windowsUIView1.AddDocument(new ucFinishPage() { Text = "Yükleme Tamamlandı" });

            foreach (Document document in windowsUIView1.Documents)
                pageGroup.Items.Add(document);
        }
        void windowsUIView1_NavigationBarsShowing(object sender, NavigationBarsCancelEventArgs e)
        {
            e.Cancel = true;
        }
        void windowsUIView1_NavigatedTo(object sender, NavigationEventArgs e)
        {
            e.Parameter = wizardViewModel;
        }
        void windowsUIView1_QueryDocumentActions(object sender, QueryDocumentActionsEventArgs e)
        {
            e.DocumentActions.Add(new DocumentAction(
                (document) => wizardViewModel.CanPrev(),
                (document) => wizardViewModel.Prev())
            { Caption = "Back", Image = imageList1.Images[0] });
            e.DocumentActions.Add(new DocumentAction(
                (document) => wizardViewModel.CanNext(),
                (document) => wizardViewModel.Next())
            { Caption = "Next", Image = imageList1.Images[1] });
            e.DocumentActions.Add(new DocumentAction(
                (document) => wizardViewModel.CanClose(),
                (document) => wizardViewModel.Close(true))
            { Caption = "Exit", Image = imageList1.Images[2] });
        }
    }
}