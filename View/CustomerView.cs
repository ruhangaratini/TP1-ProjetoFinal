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
    public partial class CustomerView : UserControl
    {
        public CustomerView()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void NewCustomerButton_Click(object sender, EventArgs e)
        {
            (this.Parent.Parent as LitePDV).showModal(new RegisterCustomerModal());
        }

        private void CustomerView_Load(object sender, EventArgs e)
        {

        }
    }
}
