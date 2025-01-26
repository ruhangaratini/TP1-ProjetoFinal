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
    public partial class ProductView : UserControl
    {
        public ProductView()
        {
            InitializeComponent();
        }

        private void NewProductButton_Click(object sender, EventArgs e)
        {
            (this.Parent.Parent as LitePDV).showModal(new RegisterProductModal());
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void NewProductButton_Click_1(object sender, EventArgs e)
        {
            (this.Parent.Parent as LitePDV).showModal(new RegisterProductModal());
        }
    }
}
