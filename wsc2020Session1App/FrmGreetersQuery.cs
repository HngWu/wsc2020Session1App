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
    public partial class FrmGreetersQuery : Form
    {
        wsc2020Session1DbContext context = new wsc2020Session1DbContext();
        BindingSource bindingSource = new BindingSource();

        public FrmGreetersQuery()
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
            var greeterId = greeteridtextfield.Text;
            var name = greeternametextfield.Text;
            
            

            if(int.TryParse(greeterId, out int greeterIdInt) == false && greeterId != "")
            {
                MessageBox.Show("Greeter ID must be a number");
                return;
            }
            else
            {



                var searchResults = context.Helpers.Where(g =>
                  (string.IsNullOrEmpty(greeterId) || g.Helper_ID.ToString().Contains(greeterId)) &&
                  (string.IsNullOrEmpty(name) || g.Helper_Name.Contains(name))).ToList();
                    


                common.helperList = searchResults;
                FrmDisplayGreetersQueryResults frmDisplayGreetersQueryResults = new FrmDisplayGreetersQueryResults();
                frmDisplayGreetersQueryResults.Show();
            }
          
        }
    }
}
