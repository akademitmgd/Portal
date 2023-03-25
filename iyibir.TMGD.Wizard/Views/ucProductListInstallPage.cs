using System;
using System.ComponentModel;

namespace iyibir.TMGD.Wizard
{
    public partial class ucProductListInstallPage : Views.BaseWizardPage
    {
        public ucProductListInstallPage()
        {
            InitializeComponent();
        }
        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 10; i++)
            {
                System.Threading.Thread.Sleep(100);
                ((BackgroundWorker)sender).ReportProgress(i);
            }
        }
        void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressEdit.PerformStep();
        }
        void startButton_Click(object sender, EventArgs e)
        {
            if (!bgWorker.IsBusy)
            {
                startButton.Enabled = false;
                bgWorker.RunWorkerAsync();
            }
        }
        void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
                ((ViewModels.InstallPageViewModel)PageViewModel).IsComplete = true;
            WizardViewModel.PageCompleted();
        }
    }
}