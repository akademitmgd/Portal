using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iyibir.TMGD.Wizard.ViewModels
{
    class ConnectionParameterViewModel : IWizardPageViewModel
    {
        public string ServerName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }
        public bool IsConnected { get; set; }
        public bool IsComplete
        {
            get { return IsConnected; }
        }

        public bool CanReturn { get { return true; } }
    }
}
