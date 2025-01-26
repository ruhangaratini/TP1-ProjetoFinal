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
    public partial class RegisterCustomerModal : Form, Modal
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
            if (this.Location.X < this.parentWindow.Location.X) {
                this.Location = this.parentWindow.Location;
            }
        }
    }
}
