using LitePDV.Model;
using LitePDV.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitePDV.Service
{
    class OrderService
    {
        private readonly OrderRepository _repository;

        public OrderService()
        {
            _repository = new OrderRepository();
        }

        public List<Order> GetAll()
        {
            var orders = _repository.GetAll();

            return orders.ToList();
        }

        public Order GetById(int id)
        {
            if (id == 0)
            {
                return null;
            }

            var order = _repository.GetById(id);

            return order;
        }

        public Response<Order> Insert(Order order)
        {
            string validation = _Validation(order);

            if (validation != "Ok")
                return Response<Order>.FromError(validation);

            _repository.Insert(order);
            return new Response<Order>(order);
        }

        public Response<Order> Update(Order order)
        {
            string validation = _Validation(order);

            if(validation != "Ok")
                return Response<Order>.FromError(validation);

            _repository.Update(order);
            return new Response<Order>(order);
        }

        public bool DeleteById(int id)
        {
            Order order = _repository.GetById(id);

            if (order != null)
            {
                var result = _repository.DeleteById(id);
                return result;
            }

            return false;
        }

        private string _Validation(Order order)
        {
            if (order == null)
                return "O pedido não pode ser nulo.";

            if (order.items == null || !order.items.Any())
                return "O pedido deve conter ao menos um item.";

            if (order.paymentMethod.Length == 0)
                return "O método de pagamento não pode ser nulo";

            foreach (var item in order.items)
            {
                if (item.quantity <= 0)
                    return "A quantidade de um item deve ser maior que zero.";

                if (item.unitPrice <= 0)
                    return "O preço unitário de um item deve ser maior que zero.";

                order.totalValue += item.subtotal;
            }

            return "Ok";
        }
    }
}
