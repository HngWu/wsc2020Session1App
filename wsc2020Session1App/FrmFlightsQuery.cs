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
    public partial class FrmFlightsQuery : Form
    {
        wsc2020Session1DbContext context = new wsc2020Session1DbContext();

        public FrmFlightsQuery()
        {
            InitializeComponent();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            FrmQuery frmQuery = new FrmQuery();
            frmQuery.Show();
            this.Hide();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            string flightNumber = flighttextfield.Text;
            string departure = departturecitytextfeild.Text;

            var searchResults = context.Flights.Where(f => 
            (string.IsNullOrEmpty(flightNumber) || f.Flight1.Contains(flightNumber)) && 
            (string.IsNullOrEmpty(departure) || f.City.Contains(departure)))
                .ToList();
            
            common.flightList = searchResults;
            FrmDisplayFlightQueryResults frmDisplayFlightQueryResults = new FrmDisplayFlightQueryResults();
            frmDisplayFlightQueryResults.Show();



        }
    }
}
