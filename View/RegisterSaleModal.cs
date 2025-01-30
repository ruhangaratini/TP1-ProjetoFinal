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
        private String selectedClient;
        private Order _order;

        public RegisterSaleModal()
        {
            InitializeComponent();
        }

        public RegisterSaleModal(int id)
        {
            InitializeComponent();
            _order = _orderService.GetById(id);
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

            CustomerBox.DataSource = clients;
            CustomerBox.DisplayMember = "Name";
            CustomerBox.ValueMember = "ID";

            if(_order != null)
            {
                CustomerBox.SelectedIndex = clients.FindIndex((c => c.id == _order.client.id));
            }

            PaymentMethodInput.SelectedItem = _order?.paymentMethod ?? "Cartão de Crédito";

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
            else
            {
                product.stockQuantity -= quantity;
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

            if(_order != null)
            {
                foreach(var item in _order.items)
                {
                    _dataTable.Rows.Add(item.product.id, item.product.name, item.unitPrice, item.quantity, item.subtotal);
                }
            }

            dataGridView1.DataSource = _dataTable;

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Excluir Venda";
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
            Response<Order> response;
            List<OrderItem> items = new List<OrderItem>();
            Order order = new Order();
            var products = _productService.GetAll();

            foreach (DataRow row in _dataTable.Rows)
            {
                Product product = new Product();
                product.id = Convert.ToInt32(row["ID"]);
                items.Add(new OrderItem(
                    quantity: Convert.ToInt32(row["Quantidade"]),
                    unitPrice: Convert.ToDouble(row["Valor Unitário"]),
                    subtotal: Convert.ToDouble(row["Valor Total"]),
                    product: product,
                    idOrder: 0
                ));
            }
            
            order.client = _clientService.GetById(Convert.ToInt16(CustomerBox.SelectedValue));
            order.date = DateTime.Now;
            order.totalValue = 0;
            order.paymentMethod = PaymentMethodInput.Text;
            order.items = items;

            if (_order == null)
            {
                response = _orderService.Insert(order);
            }
            else
            {
                order.id = _order.id;
                response = _orderService.Update(order);
            }

            if (!response.success)
            {
                MessageBox.Show(response.message);
                return;
            }

            String palavra = _order == null ? "inserida" : "atualizada";
            MessageBox.Show($"Venda {palavra} com sucesso!");

            foreach (Product product in products)
            {
                foreach(OrderItem item in items){
                    if(product.id == item.product.id)
                    {
                        product.stockQuantity = product.stockQuantity - item.quantity;
                        _productService.Update(product);
                    }
                }
            }

            this.Close();
        }

        private void CustomerBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedClient = (sender as System.Windows.Forms.ComboBox).Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView idDataView = _dataTable.DefaultView;

            idDataView.RowFilter = "Produto like '%" + textBox1.Text.Trim() + "%'";
            dataGridView1.DataSource = idDataView;
            
        }
    }
}
