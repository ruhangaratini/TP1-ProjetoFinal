using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LitePDV.Model;
using LitePDV.Service;

namespace LitePDV.View
{
    public partial class SaleView : UserControl
    {
        private readonly OrderService _service;
        private DataTable _dataTable = new DataTable();
        String selectedItem;
        public SaleView()
        {
            InitializeComponent();
            _service = new OrderService();
        }

        private void NewSaleButton_Click_1(object sender, EventArgs e)
        {
            (this.Parent.Parent as LitePDV).showModal(new RegisterSaleModal());

            this._dataTable.Clear();
            loadTable();
            this.dataGridView1.Refresh();
        }

        public void loadTable()
        {
            var orders = _service.GetAll();

            foreach (Order order in orders)
            {
                string clientName = order.client != null ? order.client.name : "Sem Cliente";
                _dataTable.Rows.Add(order.id, clientName, order.totalValue, order.paymentMethod, order.date);
            }

            dataGridView1.DataSource = _dataTable;
        }

        private void SaleView_Load(object sender, EventArgs e)
        {
            _dataTable.Columns.Add("ID");
            _dataTable.Columns.Add("Cliente");
            _dataTable.Columns.Add("Valor total");
            _dataTable.Columns.Add("Método de pagamento");
            _dataTable.Columns.Add("Data");

            loadTable();

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Editar Venda";
            btn.Name = "editarButton";
            btn.Text = "Editar";
            btn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btn);

            DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();
            btn2.HeaderText = "Excluir Venda";
            btn2.Name = "excluirButton";
            btn2.Text = "Excluir";
            btn2.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btn2); 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["editarButton"].Index)
            {
                // Obtém  o valor do ID
                var cellValue = Convert.ToInt32(dataGridView1[columnName: "ID", e.RowIndex].Value);

                (this.Parent.Parent as LitePDV).showModal(new RegisterSaleModal(cellValue));

                this._dataTable.Clear();
                loadTable();
                this.dataGridView1.Refresh();
            }

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
                    int id = Convert.ToInt32(cellValue);
                    _service.DeleteById(id);
                    MessageBox.Show("Produto excluído com sucesso!");
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedItem = (sender as System.Windows.Forms.ComboBox).Text;
            textBox1_TextChanged(sender, e);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView idDataView = _dataTable.DefaultView;

            if (selectedItem != null)
            {
                if (selectedItem.Contains("ID"))
                {

                    idDataView.RowFilter = "ID like '%" + textBox1.Text.Trim() + "%'";
                    dataGridView1.DataSource = idDataView;
                }

                if (selectedItem.Contains("Cliente"))
                {
                    idDataView.RowFilter = "Cliente like '%" + textBox1.Text.Trim() + "%'";
                    dataGridView1.DataSource = idDataView;
                }
            }
            else
            {
                MessageBox.Show("Selecione critério para continuar");
            }
        }
    }
}
