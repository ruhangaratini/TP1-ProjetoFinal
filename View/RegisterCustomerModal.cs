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
        Form parentWindow;
        private readonly ClientService _service;
        public RegisterCustomerModal()
        {
            InitializeComponent();
            _service = new ClientService();
        }

        public void setParentWindow(Form form)
        {
            this.parentWindow = form;
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
            Client client = new Client();
            client.name = NameInput.Text;
            client.email = EmailInput.Text;
            client.phone = TelephoneInput.Text;
            client.smartphone = PhoneInput.Text;
            client.cpf = CpfInput.Text;
            client.rg = RgInput.Text;

            Response<Client> response = _service.Insert(client);

            if(!response.success)
            {
                MessageBox.Show(response.message);
                return;
            }

            MessageBox.Show($"{client.name} inserido(a) com sucesso!");
            NameInput.ResetText();
            EmailInput.ResetText();
            TelephoneInput.ResetText();
            PhoneInput.ResetText();
            CpfInput.ResetText();
            RgInput.ResetText();
            
        }
    }
}
