using DevExpress.XtraEditors.Controls;
using iyibir.TMGD.Wizard.ViewModels;
using IyibirDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace iyibir.TMGD.Wizard
{
    public partial class ucProductListPage : Views.BaseWizardPage
    {
        public ucProductListPage()
        {
            InitializeComponent();
        }

        public List<LG_ITEMS> GetItems(string connectionString, int FirmNr)
        {
            return new LG_ITEMS(connectionString, FirmNr, 1).GetObjects();//.Where(x => !string.IsNullOrEmpty(x.SPECODE)).ToList();
        }

        private void ucProductListPage_Load(object sender, EventArgs e)
        {
           
           
        }

        private void gridControl1_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ucConnectionParameterPage.ConnectionString))
            {
                gridControl1.DataSource = this.GetItems(ucConnectionParameterPage.ConnectionString, 1);
                gridView1.BestFitColumns();
            }
        }
    }
}