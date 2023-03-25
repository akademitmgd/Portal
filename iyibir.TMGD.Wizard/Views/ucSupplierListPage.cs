using DevExpress.XtraEditors.Controls;
using System.Windows.Forms;

namespace iyibir.TMGD.Wizard
{
    public partial class ucSupplierListPage : Views.BaseWizardPage
    {
        public ucSupplierListPage()
        {
            InitializeComponent();
        }
        void textEdit1_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            //if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            //    textEdit1.EditValue = folderBrowserDialog1.SelectedPath;
        }
        void textEdit1_EditValueChanged(object sender, System.EventArgs e)
        {
            //((ViewModels.OptionsPageViewModel)PageViewModel).Path = textEdit1.EditValue as string;
            WizardViewModel.PageCompleted();
        }
    }
}