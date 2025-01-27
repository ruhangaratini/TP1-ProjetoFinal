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

        public void Insert(Order order)
        {
            string validation = _Validation(order);

            if (validation != "Ok")
                throw new ArgumentNullException(nameof(order), validation);

            foreach (var item in order.items)
            {
                if (item.quantity <= 0)
                    throw new ArgumentException("A quantidade de um item deve ser maior que zero.");

                if (item.unitPrice <= 0)
                    throw new ArgumentException("O preço unitário de um item deve ser maior que zero.");

                order.totalValue += item.subtotal;
            }

            _repository.Insert(order);
        }

        public void Update(Order order)
        {
            string validation = _Validation(order);

            if (validation != "Ok")
                throw new ArgumentNullException(nameof(order), validation);

            _repository.Update(order);
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

            if (order.paymentMethod == null)
                return "O nome no ordere não pode ser nulo";    

            return "Ok";
        }
    }
}
