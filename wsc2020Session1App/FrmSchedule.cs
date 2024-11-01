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
            var greeters = context.Helpers.OrderBy(x => x.Helper_ID).ToList();
            var greetersIndex = 0;
            var noOfGreeters = 0;
            var totalFlights = new List<string>();

            foreach (var country in countries)
            {
                var delegates = context.Delegates
                    .Where(x=>x.Nationality == country)
                .ToList();

                // Separate non-officials and officials
                var nonOfficials = delegates.Where(d => !d.Official)
                    .OrderBy(d => d.Trade)
                    .ThenBy(d => d.Name)
                    .ToList();

                var officials = delegates.Where(d => d.Official)
                    .OrderBy(d => d.Trade)
                    .ThenBy(d => d.Name)
                    .ToList();

                DateTime targetDateTime = new DateTime(2020, 7, 24, 23, 59, 0);

                var economyFlights = context.Flights
                    .Join(
                        context.FlightTypes,
                        flight => flight.id,
                        flightType => flightType.flightId,
                        (flight, flightType) => new
                        {
                            id = flight.id,
                            city = flight.City,
                            dep_date = flight.Dep_Date,
                            dep_time = flight.Dep_Time,
                            arr_time = flight.Arr_Time,
                            country = flight.Country,
                            seats = flightType.seats,
                            price = flightType.price,
                            classId = flightType.classId,
                            flightId = flight.Flight1
                        }
                    )
                    .Where(f => f.dep_date <= targetDateTime.Date && f.arr_time <= targetDateTime.TimeOfDay)
                    .Where(x => x.country == country && x.classId == 3)
                    .OrderByDescending(f => f.dep_date)
                    .ThenByDescending(f => f.arr_time)
                    .ToList();

                var businessFlights = context.Flights
                    .Join(
                        context.FlightTypes,
                        flight => flight.id,
                        flightType => flightType.flightId,
                        (flight, flightType) => new
                        {
                            id = flight.id,
                            city = flight.City,
                            dep_date = flight.Dep_Date,
                            dep_time = flight.Dep_Time,
                            arr_time = flight.Arr_Time,
                            country = flight.Country,
                            seats = flightType.seats,
                            price = flightType.price,
                            classId = flightType.classId,
                            flightId = flight.Flight1
                        }
                    )
                    .Where(f => f.dep_date <= targetDateTime.Date && f.arr_time <= targetDateTime.TimeOfDay)
                    .Where(x => x.country == country && x.classId == 4)
                    .OrderByDescending(f => f.dep_date)
                    .ThenByDescending(f => f.arr_time).ThenByDescending(f => f.dep_date)
                    .ToList();


                int delegateIndex = 0;


                foreach (var flight in economyFlights)
                {
                    var bookedSeats = context.DelegateFlights
                        .Where(df => df.flightId == flight.id && df.classId == 3)
                        .Count();
                    int availableSeats = flight.seats - bookedSeats;



                    while (availableSeats > 0 && delegateIndex < nonOfficials.Count)
                    {
                        var delegateFlight = new DelegateFlight
                        {
                            delegateId = nonOfficials[delegateIndex].id,
                            flightId = flight.id,
                            classId = 3
                        };
                        context.DelegateFlights.Add(delegateFlight);
                        context.SaveChanges();

                        participants++;
                        totalEconomyCost += flight.price;

                        delegateIndex++;
                        availableSeats--;

                        if (!totalFlights.Contains(flight.flightId))
                        {
                            totalFlights.Add(flight.flightId);
                        }
                    }


                }

                int secondDelegateIndex = 0;

                foreach (var flight in businessFlights)
                {
                    var bookedSeats = context.DelegateFlights
                        .Where(df => df.flightId == flight.id && df.classId == 4)
                        .Count();
                    int availableSeats = flight.seats - bookedSeats;



                    while (availableSeats > 0 && secondDelegateIndex < officials.Count)
                    {
                        var delegateFlight = new DelegateFlight
                        {
                            delegateId = officials[secondDelegateIndex].id,
                            flightId = flight.id,
                            classId = 4
                        };
                        context.DelegateFlights.Add(delegateFlight);
                        context.SaveChanges();

                        noOfOfficials++;
                        totalBusinessCost += flight.price;

                        secondDelegateIndex++;
                        availableSeats--;

                        if (!totalFlights.Contains(flight.flightId))
                        {
                            totalFlights.Add(flight.flightId);
                        }
                    }
                }




            }
            #endregion

            foreach (var flight in totalFlights)
            {
                var checkflight = context.Flights.Where(x => x.Flight1 == flight).FirstOrDefault();

                var helpersUsed = context.HelperFlights.Select(x=>x.helperId).ToList();
                var helpers = context.Helpers
                    .Where(x =>x.Available_From < checkflight.Arr_Time && x.Available_To > checkflight.Arr_Time)
                    .OrderBy(x => x.Helper_ID)
                    .ToList();

                var choosenHelper = helpersUsed.Count == 0 ? helpers.OrderBy(x => x.Helper_ID).FirstOrDefault() : helpers.Where(x => !helpersUsed.Contains(x.Helper_ID)).OrderBy(x => x.Helper_ID).FirstOrDefault();
                


                var flightGreeter = new HelperFlight
                {
                    flightId = context.Flights.Where(x=>x.Flight1 == flight).Select(x=>x.id).FirstOrDefault(),
                    helperId = choosenHelper.Helper_ID,
                };
                context.HelperFlights.Add(flightGreeter);
                context.SaveChanges();

                
                noOfGreeters++;
               
            }


            var outputText = new StringBuilder();
            outputText.AppendLine("Scheduling...Done!");
            outputText.AppendLine($"Scheduled {participants} participants and {noOfOfficials} officials from {countries.Count} Countries");
            outputText.AppendLine($"Total Number of greeters assigned: {noOfGreeters}");
            outputText.AppendLine($"Total cost for economy class: ${totalEconomyCost}");
            outputText.AppendLine($"Total cost for business class: ${totalBusinessCost}");

            lbdisplayoutput.Text = outputText.ToString();

        }
    }
}
