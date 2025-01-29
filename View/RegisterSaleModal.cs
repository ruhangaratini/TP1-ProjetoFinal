using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LitePDV.Components;
using LitePDV.Model;
using LitePDV.Service;

namespace LitePDV.View
{
    public partial class RegisterSaleModal : Form
    {
        private readonly OrderService _orderService = new OrderService();
        private readonly ClientService _clientService = new ClientService();
        private readonly ProductService _productService = new ProductService();
        private DataTable _dataTable = new DataTable();
        private int _orderId;

        public RegisterSaleModal()
        {
            InitializeComponent();
        }

        public RegisterSaleModal(int id)
        {
            InitializeComponent();
            _orderId = id;
        }

        private void CloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegisterSaleModal_Load(object sender, EventArgs e)
        {
            var clients = _clientService.GetAll();
            var products = _productService.GetAll();

            foreach (var client in clients)
            {
                CustomerBox.Items.Add(new ComboBoxItem<Client>(client.name, client));
            }

            foreach (var product in products)
            {
                ProductBox.Items.Add(new ComboBoxItem<Product>(product.name, product));
            }
        }

        private void AddProduct_Click(object sender, EventArgs e)
        {
            if(ProductBox.SelectedItem == null)
            {
                MessageBox.Show("Selecione um produto");
                return;
            }

            Product product = (ProductBox.SelectedItem as ComboBoxItem<Product>).Value;
            int quantity;

            if (!int.TryParse(QuantityInput.Text, out quantity))
            {
                MessageBox.Show("Informe uma quantidade válida");
                return;
            }

            if(quantity > product.stockQuantity)
            {
                MessageBox.Show($"Quantidade em estoque insuficiente (saldo final: {product.stockQuantity - quantity})");
                return;
            }

            _dataTable.Rows.Add(product.id, product.name, product.price, quantity, product.price * quantity);
        }

        private void flowLayoutPanel11_Paint(object sender, PaintEventArgs e)
        {
            _dataTable.Columns.Add("ID");
            _dataTable.Columns.Add("Produto");
            _dataTable.Columns.Add("Valor Unitário");
            _dataTable.Columns.Add("Quantidade");
            _dataTable.Columns.Add("Valor Total");

            dataGridView1.DataSource = _dataTable;

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Excluir Cliente";
            btn.Name = "excluirButton";
            btn.Text = "Excluir";
            btn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btn);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["excluirButton"].Index)
            {
                var cellValue = dataGridView1[columnName: "ID", e.RowIndex].Value;

                var result = MessageBox.Show(
                    "Deseja confirmar esta ação?",
                    "Confirmação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                bool isConfirmed = result == DialogResult.Yes;

                if (isConfirmed)
                {
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                    MessageBox.Show("Produto excluído com sucesso!");
                }
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                new OrderItem();
            }
        }
    }
}
