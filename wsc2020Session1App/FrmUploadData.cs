using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wsc2020Session1App
{
    public partial class FrmUploadData : Form
    {
        wsc2020Session1DbContext context = new wsc2020Session1DbContext();

        public FrmUploadData()
        {
            InitializeComponent();
        }

        private void btnreturntomain_Click(object sender, EventArgs e)
        {
            FrmMainMenu frmMainMenu = new FrmMainMenu();
            frmMainMenu.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btngreeters_Click(object sender, EventArgs e)
        {
            FileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "CSV Files|*.csv";
            fileDialog.Title = "Select a CSV File";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = fileDialog.FileName;
                try
                {  
                    using (var reader = new StreamReader(filePath))
                    {
                        var csvheaders = reader.ReadLine().Split(',');
                        var headers = new List<string>();

                        foreach (var header in csvheaders)
                        {
                            headers.Add(header.Trim());
                        }

                        if (headers[0] != "Helper ID" || headers[1] != "Helper Name" || headers[2] != "Available From" || headers[3] != "Available To")
                        {
                            MessageBox.Show("Invalid file format");
                            return;
                        }
                        else
                        {
                            while (!reader.EndOfStream)
                            {
                                var line = reader.ReadLine();
                                var values = line.Split(',');

                                var greeter = new Helper
                                {
                                    Helper_ID = int.Parse(values[0]),
                                    Helper_Name = values[1],
                                    Available_From = TimeSpan.Parse(values[2]),
                                    Available_To = TimeSpan.Parse(values[3]),
                                };
                                context.Helpers.Add(greeter);
                                context.SaveChanges();
                            }
                            MessageBox.Show("File uploaded successfully");
                        }
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading file: " + ex.Message);
                }




            }
        }

        private void btnflights_Click(object sender, EventArgs e)
        {
            FileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "CSV Files|*.csv";
            fileDialog.Title = "Select a CSV File";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = fileDialog.FileName;
                try
                {
                    using (var reader = new StreamReader(filePath))
                    {
                        var csvheaders = reader.ReadLine().Split(',');
                        var headers = new List<string>();

                        foreach (var header in csvheaders)
                        {
                            headers.Add(header.Trim());
                        }

                        if (headers[0] != "City" || headers[1] != "Country" || headers[2] != "Flight" || headers[3] != "Dep. Date" || headers[4] != "Dep. Time" || headers[5] != "Arr. Time" || headers[6] != "Class" || headers[7] != "Seats" || headers[8] != "Price(SGD)")
                        {
                            MessageBox.Show("Invalid file format");
                            return;
                        }
                        else
                        {
                            while (!reader.EndOfStream)
                            {
                                var line = reader.ReadLine();
                                var values = line.Split(',');

                                int classChoice;

                                if (values[6] == "E")
                                {
                                    classChoice = 1;

                                }
                                else
                                {
                                    classChoice = 2;
                                }

                                var flight = new Flight
                                {
                                    City = values[0],
                                    Country = values[1],
                                    Flight1 = values[2],
                                    Dep_Date = DateTime.ParseExact(values[3], "yyyy:MM:dd", System.Globalization.CultureInfo.InvariantCulture),
                                    Dep_Time = TimeSpan.Parse(values[4]),
                                    Arr_Time = TimeSpan.Parse(values[5]),
                                    Class = classChoice.ToString(),
                                    //TODO: change to int
                                    Seats = int.Parse(values[7]),
                                    Price_SGD = decimal.Parse(values[8]),
                                };
                               
                                context.Flights.Add(flight);
                                context.SaveChanges();
                            }
                            MessageBox.Show("File uploaded successfully");
                        }
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading file: " + ex.Message);
                }




            }
        }

        private void btndelegatefile_Click(object sender, EventArgs e)
        {
            FileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "CSV Files|*.csv";
            fileDialog.Title = "Select a CSV File";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = fileDialog.FileName;
                try
                {
                    using(var reader = new StreamReader(filePath))
                    {
                        var csvheaders = reader.ReadLine().Split(',');

                        var headers = new List<string>();

                        foreach (var header in csvheaders)
                        {
                            headers.Add(header.Trim());
                        }


                        if (headers[0] != "Passport" || headers[1] != "Name" || headers[2] != "Nationality" || headers[3] != "Trade" || headers[4] != "Official")
                        {
                               MessageBox.Show("Invalid file format");
                                return;
                        }
                        else
                        {
                            while (!reader.EndOfStream)
                            {
                                var line = reader.ReadLine();
                                var values = line.Split(',');

                                var official = false;

                                if (values[4] == "Y")
                                {
                                    official = true;
                                }


                                var newDelegate = new Delegate
                                {
                                    Passport = values[0],
                                    Name = values[1],
                                    Nationality = values[2],
                                    Trade = values[3],
                                    Official = official,

                                };

                                context.Delegates.Add(newDelegate);
                                context.SaveChanges();
                            }
                            MessageBox.Show("File uploaded successfully");
                        }

                       

                    }


                }
                catch (Exception ex)
                {
                     MessageBox.Show("Error reading file: " + ex.Message);
                }




            }
        }
    }
}
