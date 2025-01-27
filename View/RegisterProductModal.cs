using LitePDV.Model;
using LitePDV.Service;
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
    public partial class RegisterProductModal : Form
    {
        private readonly ProductService _service;
        public RegisterProductModal()
        {
            InitializeComponent();
            _service = new ProductService();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void CloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ProductNameInput.Text != null && PriceInput.Text != null && QuantityInput.Text != null)
            {
                Product product = new Product();
                product.name = ProductNameInput.Text;
                product.price = double.Parse(PriceInput.Text);
                product.stockQuantity = int.Parse(QuantityInput.Text);
                product.category = CategoryInput.Text;
                product.description = descriptionBox.Text;

                _service.Insert(product);
                MessageBox.Show($"{product.name} inserido(a) com sucesso!");

                ProductNameInput.ResetText();
                CategoryInput.ResetText();
                PriceInput.ResetText();
                QuantityInput.ResetText();
                descriptionBox.ResetText();
                
            }
        }
    }
}
