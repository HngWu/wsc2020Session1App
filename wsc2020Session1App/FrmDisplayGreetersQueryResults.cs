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
    public partial class FrmDisplayGreetersQueryResults : Form
    {
        wsc2020Session1DbContext context = new wsc2020Session1DbContext();
        BindingSource bindingSource = new BindingSource();

        public FrmDisplayGreetersQueryResults()
        {
            InitializeComponent();
            bindingSource.DataSource = common.helperList;
            dgvgreeters.DataSource = bindingSource;
        }

        private void dgvdelegate_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Hide();

        }
    }
}
