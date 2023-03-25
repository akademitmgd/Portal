using DevExpress.XtraEditors.Controls;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace iyibir.TMGD.Wizard
{
    public partial class ucCustomerInformationPage : Views.BaseWizardPage
    {
        public ucCustomerInformationPage()
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


    }
}