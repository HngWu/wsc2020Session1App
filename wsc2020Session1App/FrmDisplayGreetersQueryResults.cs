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

            var helperList = common.helperList.Select(h => new
            {
                h.Helper_ID,
                h.Helper_Name,
                h.Available_From,
                h.Available_To,
                dep_date = h.HelperFlights.Select(x=>x.Flight.Dep_Date).FirstOrDefault(),
                dep_time = h.HelperFlights.Select(x=>x.Flight.Dep_Time).FirstOrDefault(),
                arrival = h.HelperFlights.Select(x=>x.Flight.Arr_Time).FirstOrDefault(),
            }).ToList();

            bindingSource.DataSource = helperList;
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
