﻿using System;
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
    }
}