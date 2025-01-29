using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitePDV.Model
{
    class Client
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string smartphone { get; set; }
        public string cpf { get; set; }
        public string rg { get; set; }

        public Client() { }

        public Client(int id, string name, string email, string phone = null, string smartphone = null, string cpf = null, string rg = null)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.phone = phone;
            this.smartphone = smartphone;
            this.cpf = cpf;
            this.rg = rg;
        }

        public Client(string name, string email, string phone = null, string smartphone = null, string cpf = null, string rg = null)
        {
            this.name = name;
            this.email = email;
            this.phone = phone;
            this.smartphone = smartphone;
            this.cpf = cpf;
            this.rg = rg;
        }

        public static Client FromDictionary(Dictionary<string, dynamic> dic)
        {
            return new Client(
                name: dic["name"],
                email: dic["email"],
                phone: dic["phone"],
                smartphone: dic["smartphone"],
                cpf: dic["cpf"],
                rg: dic["rg"]
            );
        }
    }
}
