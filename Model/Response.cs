using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitePDV.Model
{
    internal class Response<T>
    {
        public bool success;
        public T data { get; set; }
        public string message;
        public int affectedRows { get; set; }
        public int insertedId { get; set; }

        private Response(string message)
        {
            this.message = message;
            success = false;
        }

        public Response(T data)
        {
            this.data = data;
            this.success = true;
        }

        public Response() {}

        public static Response<T> FromError(string message)
        {
            return new Response<T>(message);
        }

    }
}
