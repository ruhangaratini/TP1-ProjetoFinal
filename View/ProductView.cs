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
using LitePDV.Service;

namespace LitePDV.View
{
    public partial class ProductView : UserControl
    {
        private readonly ProductService _service;
        DataTable productTable = new DataTable();
        public ProductView()
        {
            InitializeComponent();
            _service = new ProductService();
        }

        private void ProductView_Load(object sender, EventArgs e)
        {
            var products = _service.GetAll();

            productTable.Columns.Add("ID");
            productTable.Columns.Add("Name");
            productTable.Columns.Add("Description");
            productTable.Columns.Add("Price");
            productTable.Columns.Add("stockQuantity");
            productTable.Columns.Add("Category");

            foreach (Product product in products)
            {
                productTable.Rows.Add(product.id, product.name, product.description, product.price, product.stockQuantity, product.category);
            }

            dataGridView2.DataSource = productTable;

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Editar Cliente";
            btn.Name = "editarButton";
            btn.Text = "Editar";
            btn.UseColumnTextForButtonValue = true;
            dataGridView2.Columns.Add(btn);

            DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();
            btn2.HeaderText = "Excluir Cliente";
            btn2.Name = "excluirButton";
            btn2.Text = "Excluir";
            btn2.UseColumnTextForButtonValue = true;
            dataGridView2.Columns.Add(btn2);
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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView2.Columns["editarButton"].Index)
            {
                // Obtém  o valor do ID
                var cellValue = dataGridView2[columnName: "ID", e.RowIndex].Value;

                //Como atualizar se esse model está sendo utilizado para inserir 
                (this.Parent.Parent as LitePDV).showModal(new RegisterCustomerModal());
                MessageBox.Show($"Você clicou em: {cellValue}");
            }

            if (e.ColumnIndex == dataGridView2.Columns["excluirButton"].Index)
            {
                var cellValue = dataGridView2[columnName: "ID", e.RowIndex].Value;

                var result = MessageBox.Show(
                    "Deseja confirmar esta ação?",
                    "Confirmação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                bool isConfirmed = result == DialogResult.Yes;

                if (isConfirmed)
                {
                    int id = Convert.ToInt32(cellValue);
                    _service.DeleteById(id);
                    MessageBox.Show("Produto excluído com sucesso!");
                }
            }
        }
    }
}
