using DevExpress.XtraEditors.Controls;
using System;
using System.Windows.Forms;

namespace iyibir.TMGD.Wizard
{
    public partial class ucCustomerValidationPage : Views.BaseWizardPage
    {
        public ucCustomerValidationPage()
        {
            InitializeComponent();

        }

        private void txt1_EditValueChanged(object sender, System.EventArgs e)
        {
            //if (!string.IsNullOrEmpty(txt1.Text) && txt1.Text.Length == 36)
            //{
            //    string license = string.Format("{0}", txt1.Text);

            //    if (WizardViewModel.CanNext())
            //    {
            //        if (license == "12345678-1234-1234-1234-123456789abc")
            //        {
            //            WizardViewModel.PageCompleted();
            //        }
            //        else
            //            WizardViewModel.Prev();
            //    }
            //}
        }

    }

    public class CustomerTemplate
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string EMail { get; set; }
        public string Telephone { get; set; }
    }
}