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
        private int? productId;
        public RegisterProductModal()
        {
            InitializeComponent();
            _service = new ProductService();
        }

        public RegisterProductModal(int id)
        {
            InitializeComponent();
            _service = new ProductService();
            productId = id;
            Product product = _service.GetById(id);
            ProductNameInput.Text = product.name;
            CategoryInput.Text = product.category;
            PriceInput.Text = Convert.ToString(product.price);
            QuantityInput.Text = Convert.ToString(product.stockQuantity);
            descriptionBox.Text = product.description;
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
            Response<Product> response;
            Product product = new Product();
            product.name = ProductNameInput.Text;
            product.price = double.TryParse(PriceInput.Text, out double price) ? price : 0.0;
            product.stockQuantity = int.TryParse(QuantityInput.Text, out int quantity) ? quantity : 0;
            product.category = CategoryInput.Text;
            product.description = descriptionBox.Text;

            if (productId == null)
            {
                response = _service.Insert(product);
            }
            else
            {
                product.id = (int)productId;
                response = _service.Update(product);
            }

            if (!response.success)
            {
                MessageBox.Show(response.message);
                return;
            }

            String palavra = productId == null ? "inserido" : "atualizado";

            MessageBox.Show($"{product.name} {palavra}(a) com sucesso!");
            ProductNameInput.ResetText();
            CategoryInput.ResetText();
            PriceInput.ResetText();
            QuantityInput.ResetText();
            descriptionBox.ResetText();

            this.Close();
        }
    }
}
