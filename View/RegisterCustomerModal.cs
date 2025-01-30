using LitePDV.Model;
using LitePDV.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LitePDV.View
{
    public partial class RegisterCustomerModal : Form
    {
        private int? clientId;
        private readonly ClientService _service;
        public RegisterCustomerModal()
        {
            InitializeComponent();
            _service = new ClientService();
        }

        public RegisterCustomerModal(int id)
        {
            InitializeComponent();
            _service = new ClientService();
            clientId = id;
            Client client = _service.GetById(id);
            NameInput.Text = client.name;
            EmailInput.Text = client.email;
            PhoneInput.Text = client.smartphone;
            TelephoneInput.Text = client.phone;
            CpfInput.Text = client.cpf;
            RgInput.Text = client.rg;
        }

        private void RegisterCustomerModal_Load(object sender, EventArgs e)
        {

        }

        private void RegisterCustomerModal_Move(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void CloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Response<Client> response;
            Client client = new Client();
            client.name = NameInput.Text;
            client.email = EmailInput.Text;
            client.phone = TelephoneInput.Text;
            client.smartphone = PhoneInput.Text;
            client.cpf = CpfInput.Text;
            client.rg = RgInput.Text;

            if(clientId == null)
            {
                response = _service.Insert(client);
            } else
            {
                client.id = (int)clientId;
                response = _service.Update(client);
            }

            if(!response.success)
            {
                MessageBox.Show(response.message);
                return;
            }

            String palavra = clientId == null ? "inserido" : "atualizado";

            MessageBox.Show($"{client.name} {palavra} (a) com sucesso!");
            this.Close();
        }
    }
}
