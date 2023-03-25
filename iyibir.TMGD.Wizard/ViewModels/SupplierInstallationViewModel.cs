using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iyibir.TMGD.Wizard.ViewModels
{
    class SupplierInstallationViewModel : IWizardPageViewModel
    {
        public bool IsComplete
        {
            get { return !string.IsNullOrEmpty(""); }
        }

        public bool CanReturn { get { return true; } }
    }
}
