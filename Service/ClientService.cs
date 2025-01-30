using LitePDV.Model;
using LitePDV.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace LitePDV.Service
{
    class ClientService
    {
        private readonly ClientRepository _repository;

        public ClientService()
        {
            _repository = new ClientRepository();
        }

        public List<Client> GetAll()
        {
            var clients = _repository.GetAll();

            return clients.ToList();
        }

        public Client GetById(int id)
        {
            if(id == 0)
            {
                return null;
            }

            var client = _repository.GetById(id);

            return client;
        }

        public Response<Client> Insert(Client client)
        {
            string validation = _Validation(client);

            if (validation != "Ok")
                return Response<Client>.FromError(validation);

            _repository.Insert(client);
            return new Response<Client>(client);
        }

        public Response<Client> Update(Client client)
        {
            string validation = _Validation(client);

            if (validation != "Ok")
                return Response<Client>.FromError(validation);

            _repository.Update(client);
            return new Response<Client>(client);
        }

        public bool DeleteById(int id)
        {
            Client client = _repository.GetById(id);

            if (client != null)
            {
                var result = _repository.DeleteById(id);
                return result;
            }

            return false;
        }

        private string _Validation(Client client)
        {
            if (client == null)
                return "O cliente não pode ser nulo.";

            if (client.name.Trim().Length == 0)
                return "O nome no cliente não pode ser nulo";

            if (!Regex.IsMatch(client.email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                return "Email inválido. Verifique e tente novamente.";

            if (client.cpf.Contains(" ") && client.cpf != "")
                return "CPF inválido. Verifique e tente novamente.";

            if (client.rg.Trim().Contains(" ") && client.rg.Replace(",", "").Replace("-","").Trim().Length > 0)
                return "RG inválido. Verifique e tente novamente.";

            return "Ok";
        }
    }
}

