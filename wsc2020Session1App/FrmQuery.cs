using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wsc2020Session1App
{
    public partial class FrmQuery : Form
    {
        public FrmQuery()
        {
            InitializeComponent();
        }

        private void btnreturntomain_Click(object sender, EventArgs e)
        {
            FrmMainMenu frmMainMenu = new FrmMainMenu();    
            frmMainMenu.Show();
            this.Hide();
        }

        private void btndelegate_Click(object sender, EventArgs e)
        {
            FrmDelegatesQuery frmDelegatesQuery = new FrmDelegatesQuery();
            frmDelegatesQuery.Show();
            this.Hide();
        }

        private void btnflights_Click(object sender, EventArgs e)
        {
            FrmFlightsQuery frmFlightsQuery = new FrmFlightsQuery();
            frmFlightsQuery.Show();
            this.Hide();
        }

        private void btngreeters_Click(object sender, EventArgs e)
        {
            FrmGreetersQuery frmGreetersQuery = new FrmGreetersQuery();
            frmGreetersQuery.Show();
            this.Hide();
        }
    }
}
