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

namespace LitePDV.View
{
    public partial class CustomerView : UserControl
    {
        private readonly ClientService _service;
        DataTable table = new DataTable();
        public CustomerView()
        {
            InitializeComponent();
            _service = new ClientService();
        }
        private void CustomerView_Load(object sender, EventArgs e)
        {
            var clients = _service.GetAll();

            table.Columns.Add("ID");
            table.Columns.Add("Name");
            table.Columns.Add("Email");
            table.Columns.Add("Phone");
            table.Columns.Add("Smartphone");
            table.Columns.Add("CPF");
            table.Columns.Add("RG");

            foreach (Client client in clients)
            {
                table.Rows.Add(client.id, client.name, client.email, client.phone, client.smartphone, client.cpf, client.rg);
            }

            dataGridView1.DataSource = table;

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
                var cellValue = dataGridView1[columnName:"ID", e.RowIndex].Value;
                
                //Como atualizar se esse model está sendo utilizado para inserir 
                (this.Parent.Parent as LitePDV).showModal(new RegisterCustomerModal());
                MessageBox.Show($"Id da linha: {cellValue}");
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
    }
}
