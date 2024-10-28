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
    public partial class FrmDisplayDelegateQueryResults : Form
    {
        wsc2020Session1DbContext context = new wsc2020Session1DbContext();
        BindingSource bindingSource = new BindingSource();


        public FrmDisplayDelegateQueryResults()
        {
            InitializeComponent();
            bindingSource.DataSource = common.delegateList;
            dgvdelegate.DataSource = bindingSource;
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dgvdelegate_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
