using LitePDV.Model;
using LitePDV.View;
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

        private void setMainScreen(Button sender, UserControl control)
        {
            if (control == null || sender == null)
                return;

            foreach (Panel p in this.SideBarMenu.Controls.OfType<Panel>())
            {
                foreach (Control c in p.Controls)
                {
                    if(c.Name.Contains("Menu"))
                    {
                        c.BackColor = SystemColors.ControlLight;
                    }
                }
            }

            sender.BackColor = SystemColors.Control;

            control.Dock = DockStyle.Fill;
            this.MainScreen.Controls.Clear();
            this.MainScreen.Controls.Add(control);
        }

        public void showModal(Form form)
        {
            form.BackColor = SystemColors.ControlLightLight;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.WindowState = FormWindowState.Normal;
            form.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void MenuDashboard_Click(object sender, EventArgs e)
        {
            this.setMainScreen((Button) sender, new DashboardView());
        }

        private void MenuCustomer_Click(object sender, EventArgs e)
        {
            this.setMainScreen((Button) sender, new CustomerView());
        }

        private void MenuProduct_Click(object sender, EventArgs e)
        {
            this.setMainScreen((Button) sender, new ProductView());
        }

        private void MenuSale_Click(object sender, EventArgs e)
        {
            this.setMainScreen((Button) sender, new SaleView());
        }

        private void LitePDV_Load(object sender, EventArgs e)
        {
            this.setMainScreen(this.MenuDashboard, new DashboardView());
        }

        private void MainScreen_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
