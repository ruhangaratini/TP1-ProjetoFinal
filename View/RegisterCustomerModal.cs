using LitePDV.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LitePDV.View
{
    public partial class RegisterCustomerModal : Form
    {
        Form parentWindow;

        public RegisterCustomerModal()
        {
            InitializeComponent();
        }

        public void setParentWindow(Form form)
        {
            this.parentWindow = form;
        }

        private void RegisterCustomerModal_Load(object sender, EventArgs e)
        {

        }

        private void RegisterCustomerModal_Move(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void CloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
