
namespace iyibir.TMGD.Wizard.ViewModels
{
    class InstallPageViewModel : IWizardPageViewModel
    {
        public bool IsComplete
        {
            get;
            set;
        }
        public bool CanReturn { get { return !IsComplete; } }
    }
}