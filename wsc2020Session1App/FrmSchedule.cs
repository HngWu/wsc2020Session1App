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
            #region
            // Create a list of countries in the specified order
            var countries = new List<string>
            {
                "Indonesia",
                "Singapore",
                "Thailand",
                "Malaysia",
                "Philippines",
                "Vietnam",
                "Laos",
                "Cambodia",
                "Brunei",
                "Myanmar"
            };
            int participants = 0;
            int noOfOfficials = 0;
            decimal totalEconomyCost = 0;
            decimal totalBusinessCost = 0;


            foreach (var country in countries)
            {
                var delegates = context.Delegates
                    .Where(x=>x.Nationality == country)
                .ToList();

                // Separate non-officials and officials
                var nonOfficials = delegates.Where(d => !d.Official)
                    .OrderBy(d => d.Trade)
                    .ThenBy(d => d.Name).ToList();

                var officials = delegates.Where(d => d.Official)
                    .OrderBy(d => d.Trade)
                    .ThenBy(d => d.Name).ToList();

                DateTime targetDateTime = new DateTime(2020, 7, 24, 23, 59, 0);

                var economyFlights = context.Flights
                    .Where(f => f.Dep_Date <= targetDateTime.Date && f.Arr_Time < targetDateTime.TimeOfDay)
                    .Where(x => x.Class == "E" && x.Country == country)
                    .OrderByDescending(f => f.Arr_Time)
                    .ToList();

                var businessFlights = context.Flights
                    .Where(f => f.Dep_Date <= targetDateTime.Date && f.Arr_Time < targetDateTime.TimeOfDay)
                    .Where(x => x.Class == "B" && x.Country == country)
                    .OrderByDescending(f => f.Arr_Time)
                                   .ToList();

                int delegateIndex = 0;


                foreach (var flight in economyFlights)
                {
                    var bookedSeats = context.DelegateFlights
                        .Where(df => df.flightId == flight.id)
                        .Count();
                    int availableSeats = economyFlights.Sum(f => f.Seats) - bookedSeats;



                    while (availableSeats > 0 && delegateIndex < nonOfficials.Count)
                    {
                        var delegateFlight = new DelegateFlight
                        {
                            delegateId = nonOfficials[delegateIndex].id,
                            flightId = flight.id
                        };
                        context.DelegateFlights.Add(delegateFlight);
                        context.SaveChanges();

                        participants++;
                        totalEconomyCost += flight.Price_SGD;

                        delegateIndex++;
                        availableSeats--;
                    }

                }

                int secondDelegateIndex = 0;

                foreach (var flight in businessFlights)
                {
                    var bookedSeats = context.DelegateFlights
                        .Where(df => df.flightId == flight.id)
                        .Count();
                    int availableSeats = businessFlights.Sum(f => f.Seats) - bookedSeats;



                    while (availableSeats > 0 && secondDelegateIndex < officials.Count)
                    {
                        var delegateFlight = new DelegateFlight
                        {
                            delegateId = officials[secondDelegateIndex].id,
                            flightId = flight.id
                        };
                        context.DelegateFlights.Add(delegateFlight);
                        context.SaveChanges();

                        noOfOfficials++;
                        totalBusinessCost += flight.Price_SGD;

                        secondDelegateIndex++;
                        availableSeats--;
                    }

                }



            }
            #endregion

            #region

            int helpersindex = 0;


            var greeters = context.Helpers.OrderBy(x=>x.Helper_ID).ToList();

            foreach(var flight in context.Flights)
            {
                var bookedSeats = context.DelegateFlights
                    .Where(df => df.flightId == flight.id)
                    .Count();
                int availableSeats = flight.Seats - bookedSeats;

                while (availableSeats > 0 && helpersindex < context.Helpers.Count())
                {
                    var helperFlight = new HelperFlight
                    {
                        helperId = greeters[helpersindex].Helper_ID,
                        flightId = flight.id
                    };
                    context.HelperFlights.Add(helperFlight);
                    context.SaveChangesAsync();

                    if(flight.Class == "E")
                    {
                        totalEconomyCost += flight.Price_SGD;
                    }
                    else
                    {
                        totalBusinessCost += flight.Price_SGD;
                    }

                    helpersindex++;
                    availableSeats--;
                }
            }
            #endregion

            var outputText = new StringBuilder();
            outputText.AppendLine("Scheduling...Done!");
            outputText.AppendLine($"Scheduled {participants} participants and {noOfOfficials} officials from {countries.Count} Countries");
            outputText.AppendLine($"Total cost for economy class: ${totalEconomyCost}");
            outputText.AppendLine($"Total cost for business class: ${totalBusinessCost}");

            lbdisplayoutput.Text = outputText.ToString();

        }
    }
}
