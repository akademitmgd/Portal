
namespace iyibir.TMGD.Wizard.ViewModels
{
    class FinishPageViewModel : IWizardPageViewModel
    {
        public bool IsComplete { get { return true; } }
        public bool CanReturn { get { return false; } }
    }
}