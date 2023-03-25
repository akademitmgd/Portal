using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iyibir.TMGD.Wizard.ViewModels
{
    class CustomerValidationViewModel : IWizardPageViewModel
    {
        public string License { get; set; }

        public bool IsValid { get; set; }

        public bool IsComplete { get {
                return true;
            
            } }

        public bool CanReturn { get { return true; } }
    }
}
