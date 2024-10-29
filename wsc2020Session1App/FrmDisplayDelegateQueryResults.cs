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

            var delegateList = common.delegateList.Select(d => new
            {
                d.Passport,
                d.Name,
                d.Nationality,
                Flight = d.DelegateFlights.Select(df => df.Flight.Flight1).FirstOrDefault(),
                Departure = d.DelegateFlights.Select(df => df.Flight.Dep_Date).FirstOrDefault() + "" + d.DelegateFlights.Select(df => df.Flight.Dep_Time).FirstOrDefault(),
                Arrival = d.DelegateFlights.Select(df => df.Flight.Dep_Date).FirstOrDefault() + "" + d.DelegateFlights.Select(df => df.Flight.Arr_Time).FirstOrDefault(),

            });

            bindingSource.DataSource = delegateList;
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
