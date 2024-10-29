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
    public partial class FrmDelegatesQuery : Form
    {

        wsc2020Session1DbContext context = new wsc2020Session1DbContext();

        public FrmDelegatesQuery()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void nametextfield_TextChanged(object sender, EventArgs e)
        {
            if (nametextfield.Text == "Name")
            {
                nametextfield.Text = "";
            }
        }

        private void nationalitytextfield_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            FrmQuery frmQuery = new FrmQuery();
            frmQuery.Show();
            this.Hide();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            string passportNumber = passporttextfield.Text;
            string name = nametextfield.Text;
            string nationality = nationalitytextfield.Text;
            string trade = tradetextfield.Text;

            var searchResults = context.Delegates.Where(d =>
                (string.IsNullOrEmpty(passportNumber) || d.Passport.Contains(passportNumber)) &&
                (string.IsNullOrEmpty(name) || d.Name.Contains(name.Trim())) &&
                (string.IsNullOrEmpty(nationality) || d.Nationality.Contains(nationality)) &&
                (string.IsNullOrEmpty(trade) || d.Trade.Contains(trade))
            )
                .ToList();

            // Return the search results
            // You can use the searchResults variable to perform further operations or display the results

            common.delegateList = searchResults;

            FrmDisplayDelegateQueryResults frmDisplayDelegateQueryResults = new FrmDisplayDelegateQueryResults();
            frmDisplayDelegateQueryResults.Show();

        }
    }
}
