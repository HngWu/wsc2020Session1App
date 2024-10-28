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
    public partial class FrmSchedule : Form
    {
        wsc2020Session1DbContext context = new wsc2020Session1DbContext();
        BindingSource bindingSource = new BindingSource();

        public FrmSchedule()
        {
            InitializeComponent();
        }

        private void FrmSchedule_Load(object sender, EventArgs e)
        {
            // Sort delegates by trade and name
            var sortedDelegates = context.Delegates
                .OrderBy(d => d.Trade)
                .ThenBy(d => d.Name)
                .ToList();

            // Separate non-officials and officials
            var nonOfficials = sortedDelegates.Where(d => !d.Official).ToList();
            var officials = sortedDelegates.Where(d => d.Official).ToList();

            //// Sort flights by arrival time and cost
            //var sortedFlights = context.Flights
            //    .OrderByDescending(f => f.Arr_Time)
            //    .ThenBy(f => f.Price_SGD)
            //    .ToList();

            var delegates = context.Delegates
                .OrderBy(d => d.Nationality.Trim() == "Indonesia")
                .ThenBy(d => d.Nationality.Trim() == "Singapore")
                .ThenBy(d => d.Nationality.Trim() == "Thailand")
                .ThenBy(d => d.Nationality.Trim() == "Malaysia")
                .ThenBy(d => d.Nationality.Trim() == "Philippines")
                .ThenBy(d => d.Nationality.Trim() == "Vietnam")
                .ThenBy(d => d.Nationality.Trim() == "Laos")
                .ThenBy(d => d.Nationality.Trim() == "Cambodia")
                .ThenBy(d => d.Nationality.Trim() == "Brunei")
                .ThenBy(d => d.Nationality.Trim() == "Myanmar")
                .ToList();

            delegates = delegates.OrderBy(x=>x.Official == false)
                        .ThenBy(x=>x.Trade)
                        .ThenBy(x=>x.Name)
                        .ToList();





        }
    }
}
