using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitePDV.Model
{
    internal class Response<T>
    {
        public string message { get; set; }
        public bool success { get; }
        public T data { get; }

        public Response(T data) {
            this.data = data;
            this.success = true;
        }

        private Response(string message) {
            this.message = message;
            this.success = false;
        }

        public static Response<T> FromError(string message) {
           return new Response<T>(message);
        }

    }
}
