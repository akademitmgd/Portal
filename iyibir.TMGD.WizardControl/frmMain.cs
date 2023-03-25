using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors;
using iyibir.TMGD.WizardControl.Model;
using IyibirDLL;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iyibir.TMGD.WizardControl
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        internal static string ConnectionString = string.Empty;
        internal static bool IsConnected = false;
        List<LG_ITEMS> items;
        List<LG_CLCARD> suppliers;
        BackgroundWorker backgroundWorkerProduct;
        BackgroundWorker backgroundWorkerSupplier;
        internal static string token;
        internal static Customer customer;
        internal static Employee owner;
        public frmMain()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            items = new List<LG_ITEMS>();
            suppliers = new List<LG_CLCARD>();
            wizardControl1.NextClick += WizardControl1_NextClick;
            wizardPageConnectionParameter.AllowNext = false;


            #region BG Product
            backgroundWorkerProduct = new BackgroundWorker();
            backgroundWorkerProduct.WorkerReportsProgress = true;
            backgroundWorkerProduct.WorkerSupportsCancellation = true;
            backgroundWorkerProduct.DoWork += BackgroundWorkerProduct_DoWork;
            backgroundWorkerProduct.ProgressChanged += BackgroundWorkerProduct_ProgressChanged;
            backgroundWorkerProduct.RunWorkerCompleted += BackgroundWorkerProduct_RunWorkerCompleted;
            #endregion

            #region BG Supplier
            backgroundWorkerSupplier = new BackgroundWorker();
            backgroundWorkerSupplier.WorkerReportsProgress = true;
            backgroundWorkerSupplier.WorkerSupportsCancellation = true;
            backgroundWorkerSupplier.DoWork += BackgroundWorkerSupplier_DoWork;
            backgroundWorkerSupplier.ProgressChanged += BackgroundWorkerSupllier_ProgressChanged;
            backgroundWorkerSupplier.RunWorkerCompleted += BackgroundWorkerSupplier_RunWorkerCompleted;
            #endregion
        }



        private void WizardControl1_NextClick(object sender, DevExpress.XtraWizard.WizardCommandButtonClickEventArgs e)
        {
            if (wizardControl1.SelectedPage == welcomeWizardPage1)
            {
                if (!string.IsNullOrEmpty(txtLicenseNumber.Text))
                {
                    var value = (JArray)new Helper().GetCustomer(Guid.Parse(txtLicenseNumber.Text), token).Data;

                    customer = value.ToObject<List<Customer>>().FirstOrDefault();
                    if (customer == null)
                    {
                        wizardControl1.SelectedPage = welcomeWizardPage1;
                        XtraMessageBox.Show(string.Format("{0} Lisans Numarasına Ait Müşteri Bulunamadı..", txtLicenseNumber.Text));
                    }
                    else
                    {
                        txtCustomerCode.Text = customer.Code;
                        txtCustomerName.Text = customer.Title;
                        txtCustomerEmail.Text = customer.EMail;
                        txtCustomerTelephone.Text = customer.Telephone;

                        var employee = (JArray)new Helper().GetEmployee(customer.Oid, token).Data;

                        owner = employee.ToObject<List<Employee>>().FirstOrDefault();
                    }
                }
                else
                    wizardControl1.SelectedPage = welcomeWizardPage1;
            }
        }

        private void wizardControl1_FinishClick(object sender, CancelEventArgs e)
        {
            Application.ExitThread();
        }

        private static bool canCloseFunc(DialogResult parameter)
        {
            return parameter != DialogResult.Cancel;
        }

        private void wizardControl1_CancelClick(object sender, CancelEventArgs e)
        {
            this.Close();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            FlyoutAction action = new FlyoutAction() { Description = "Yükleme Kapatılacaktır. Devam Etmek İstiyor musunuz?" };
            Predicate<DialogResult> predicate = canCloseFunc;
            FlyoutCommand command1 = new FlyoutCommand() { Text = "Kapat", Result = DialogResult.Yes };
            FlyoutCommand command2 = new FlyoutCommand() { Text = "Vazgeç", Result = DialogResult.No };
            action.Commands.Add(command1);
            action.Commands.Add(command2);
            FlyoutProperties properties = new FlyoutProperties();
            properties.ButtonSize = new Size(80, 25);
            properties.Style = FlyoutStyle.MessageBox;
            if (FlyoutDialog.Show(this, action, properties, predicate) == DialogResult.Yes) e.Cancel = false;
            else e.Cancel = true;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (IsConnect(txtServerName.Text, txtUserId.Text, txtPassword.Text, txtDatabase.Text))
            {
                ConnectionString = string.Format("Data Source={0};User Id={1};Password={2};Initial Catalog={3}", txtServerName.Text, txtUserId.Text, txtPassword.Text, txtDatabase.Text);
                IsConnected = true;
                wizardPageConnectionParameter.AllowNext = true;
                XtraMessageBox.Show("Bağlantı Başarılı.. Devam Etmek İleri Tıklayınız..");
            }
            else
            {
                ConnectionString = string.Format("Data Source={0};User Id={1};Password={2};Initial Catalog={3}", txtServerName.Text, txtUserId.Text, txtPassword.Text, txtDatabase.Text);
                XtraMessageBox.Show("Bağlantı bilgileri geçersiz. Lütfen tekrar deneyiniz..");
            }
        }

        public bool IsConnect(string serverName, string userId, string password, string database)
        {
            string connectionString = string.Format("Data Source={0};User Id={1};Password={2};Initial Catalog={3}", serverName, userId, password, database);
            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public void GetItems(string connectionString, int FirmNr)
        {
            items.AddRange(new LG_ITEMS(connectionString, FirmNr, 1).GetObjects().Where(x => !string.IsNullOrEmpty(x.SPECODE)).ToList());
        }

        public void GetSuppliers(string connectionString, int FirmNr)
        {
            suppliers.AddRange(new LG_CLCARD(connectionString, FirmNr, 1).GetObjects());//.Where(x => !string.IsNullOrEmpty(x.SPECODE)).ToList();
        }

        private void wizardControl1_SelectedPageChanging(object sender, DevExpress.XtraWizard.WizardPageChangingEventArgs e)
        {
            if (!string.IsNullOrEmpty(ConnectionString))
            {

                switch (e.Page.Name)
                {
                    case "wizardPageConnectionParameter":

                        break;
                    case "wizardPageCustomerInfo":
                        break;
                    case "wizardPageProductList":
                        GetItems(ConnectionString, Convert.ToInt32(ConfigurationManager.AppSettings["FirmNumber"].ToString()));
                        gridControlProductList.DataSource = items;
                        gridView1.BestFitColumns();
                        break;
                    case "wizardPageSupplierList":
                        GetSuppliers(ConnectionString, Convert.ToInt32(ConfigurationManager.AppSettings["FirmNumber"].ToString()));
                        gridControlSupplierList.DataSource = suppliers;
                        gridView2.BestFitColumns();
                        break;
                    case "wizardPageProductInstall":
                        progressBarControl1.Properties.Step = 1;
                        progressBarControl1.Properties.PercentView = true;
                        progressBarControl1.Properties.Maximum = items.Count;
                        progressBarControl1.Properties.Minimum = 0;

                        backgroundWorkerProduct.RunWorkerAsync();

                        break;
                    case "wizardPageSupplierInstall":
                        progressBarControl2.Properties.Step = 1;
                        progressBarControl2.Properties.PercentView = true;
                        progressBarControl2.Properties.Maximum = suppliers.Count;
                        progressBarControl2.Properties.Minimum = 0;

                        backgroundWorkerSupplier.RunWorkerAsync();
                        break;
                    default:
                        break;
                }
            }
        }

        private void BackgroundWorkerProduct_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarControl1.PerformStep();
            progressBarControl1.Update();
        }

        private void BackgroundWorkerSupllier_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarControl2.PerformStep();
            progressBarControl2.Update();
        }

        private void BackgroundWorkerProduct_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblProductStatus.Text = "Aktarım Tamamlandı..";
        }

        private void BackgroundWorkerSupplier_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblSupplierStatus.Text = "Aktarım Tamamlandı..";
        }

        public void InsertProduct()
        {
            foreach (var product in items)
            {
                //TO DO WEB API Insert
                new Helper().InsertProduct(product, token, customer, owner);
                System.Threading.Thread.Sleep(2000);
                lblProductStatus.Text = string.Format("{0} Aktarılıyor..", product.NAME);
                backgroundWorkerProduct.ReportProgress(9);
            }
        }

        public void InsertSupplier()
        {
            foreach (var supplier in suppliers)
            {
                //TO DO WEB API Insert
               DataResult result = new Helper().InsertConsignee(supplier, token, customer);
                System.Threading.Thread.Sleep(2000);
                lblSupplierStatus.Text = string.Format("{0} Aktarılıyor..", supplier.DEFINITION_);
                backgroundWorkerSupplier.ReportProgress(9);
            }
        }

        private void BackgroundWorkerProduct_DoWork(object sender, DoWorkEventArgs e)
        {
            InsertProduct();
        }

        private void BackgroundWorkerSupplier_DoWork(object sender, DoWorkEventArgs e)
        {
            InsertSupplier();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            token = new Helper().GetToken();
            if (string.IsNullOrEmpty(token))
                throw new Exception("Uzak Sunucu ile bağlantı kurulamadı..");
        }
    }
}