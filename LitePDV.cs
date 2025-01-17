﻿using LitePDV.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LitePDV
{
    public partial class LitePDV : Form
    {

        public LitePDV()
        {
            InitializeComponent();
        }

        private void setMainScreen(UserControl control)
        {
            if (control == null)
                return;

            control.Dock = DockStyle.Fill;
            this.MainScreen.Controls.Clear();
            this.MainScreen.Controls.Add(control);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void MenuDashboard_Click(object sender, EventArgs e)
        {
            this.setMainScreen(new DashboardView());
        }

        private void MenuCustomer_Click(object sender, EventArgs e)
        {
            this.setMainScreen(new CustomerView());
        }
    }
}
