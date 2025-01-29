using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LitePDV.Repository;
using LitePDV.Service;
using LitePDV.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LitePDV.View
{
    public partial class CustomerView : UserControl
    {
        String selectedItem;
        private readonly ClientService _service;
        DataTable clientTable = new DataTable();
        public CustomerView()
        {
            InitializeComponent();
            _service = new ClientService();
        }
        private void CustomerView_Load(object sender, EventArgs e)
        {
            var clients = _service.GetAll();

            clientTable.Columns.Add("ID");
            clientTable.Columns.Add("Name");
            clientTable.Columns.Add("Email");
            clientTable.Columns.Add("Phone");
            clientTable.Columns.Add("Smartphone");
            clientTable.Columns.Add("CPF");
            clientTable.Columns.Add("RG");

            foreach (Client client in clients)
            {
                clientTable.Rows.Add(client.id, client.name, client.email, client.phone, client.smartphone, client.cpf, client.rg);
            }

            dataGridView1.DataSource = clientTable;

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Editar Cliente";
            btn.Name = "editarButton";
            btn.Text = "Editar";
            btn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btn);

            DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();
            btn2.HeaderText = "Excluir Cliente";
            btn2.Name = "excluirButton";
            btn2.Text = "Excluir";
            btn2.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btn2);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedItem = (sender as System.Windows.Forms.ComboBox).Text;
            textBox1_TextChanged(sender, e);
        }

        private void NewCustomerButton_Click(object sender, EventArgs e)
        {
            (this.Parent.Parent as LitePDV).showModal(new RegisterCustomerModal());
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["editarButton"].Index)
            {
                // Obtém  o valor do ID
                var cellValue = Convert.ToInt32(dataGridView1[columnName: "ID", e.RowIndex].Value);
                
                //Como atualizar se esse model está sendo utilizado para inserir 
                (this.Parent.Parent as LitePDV).showModal(new RegisterCustomerModal(cellValue));
            }

            if(e.ColumnIndex == dataGridView1.Columns["excluirButton"].Index)
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
                    MessageBox.Show("Cliente excluído com sucesso!");               
                }
            }
        }

        private void flowLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView idDataView = clientTable.DefaultView;

            if (selectedItem != null)
            {
                if (selectedItem.Contains("ID"))
                {

                    idDataView.RowFilter = "ID like '%" + textBox1.Text.Trim() + "%'";
                    dataGridView1.DataSource = idDataView;
                }

                if (selectedItem.Contains("Name"))
                {
                    idDataView.RowFilter = "Name like '%" + textBox1.Text.Trim() + "%'";
                    dataGridView1.DataSource = idDataView;
                }

                if (selectedItem.Contains("CPF"))
                {
                    idDataView.RowFilter = "CPF like '%" + textBox1.Text.Trim() + "%'";
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
