using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iyibir.TMGD.Wizard.ViewModels
{
    class CustomerInformationViewModel : IWizardPageViewModel
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string EMail { get; set; }
        public string Telephone { get; set; }
        public bool IsComplete
        {
            get { return true; }
        }

        public bool CanReturn { get { return true; } }
    }
}
