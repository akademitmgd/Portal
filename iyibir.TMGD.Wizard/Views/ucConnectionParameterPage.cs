using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace iyibir.TMGD.Wizard
{
    public partial class ucConnectionParameterPage : Views.BaseWizardPage
    {
        internal static string ConnectionString = string.Empty;
        public ucConnectionParameterPage()
        {
            InitializeComponent();
        }
        void textEdit1_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            
        }
        void textEdit1_EditValueChanged(object sender, System.EventArgs e)
        {
            //((ViewModels.CustomerValidationViewModel)PageViewModel).Code = textEdit1.EditValue as string;
            //WizardViewModel.PageCompleted();
        }

        private void btnConnectionControl_Click(object sender, System.EventArgs e)
        {
            if (IsConnect(txtServerName.Text, txtUserId.Text, txtPassword.Text, txtDatabase.Text))
            {
                ((ViewModels.ConnectionParameterViewModel)PageViewModel).IsConnected = true;
                WizardViewModel.PageCompleted();
            }                
            else
                XtraMessageBox.Show("Bağlantı bilgileri geçersiz. Lütfen tekrar deneyiniz..");
        }

        public bool IsConnect(string serverName, string userId, string password, string database)
        {
            string connectionString = string.Format("Data Source={0};User Id={1};Password={2};Initial Catalog={3}", serverName, userId, password, database);
            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    ConnectionString = connectionString;
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}