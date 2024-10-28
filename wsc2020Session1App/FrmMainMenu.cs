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
    public partial class FrmMainMenu : Form
    {
        public FrmMainMenu()
        {
            InitializeComponent();
        }

        private void btnuploaddata_Click(object sender, EventArgs e)
        {
            FrmUploadData frmUploadData = new FrmUploadData();
            frmUploadData.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnquery_Click(object sender, EventArgs e)
        {
            FrmQuery frmQuery = new FrmQuery();
            frmQuery.Show();
            this.Hide();
        }

        private void btnschedule_Click(object sender, EventArgs e)
        {
            FrmSchedule frmSchedule = new FrmSchedule();
            frmSchedule.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmMainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
