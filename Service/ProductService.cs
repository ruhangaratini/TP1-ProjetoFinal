using LitePDV.Model;
using LitePDV.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LitePDV.Service
{
    class ProductService
    {
        private readonly ProductRepository _repository;

        public ProductService()
        {
            _repository = new ProductRepository();
        }

        public List<Product> GetAll()
        {
            var products = _repository.GetAll();

            return products.ToList();
        }

        public Product GetById(int id)
        {
            if(id < 0)
            {
                return null;
            }

            var product = _repository.GetById(id);

            return product;
        }

        public void Insert(Product product)
        {
            string validation = _ValidateInsert(product);

            if (validation != "Ok")
                throw new ArgumentNullException(nameof(product), validation);
            _repository.Insert(product);
        }

        public void Update(Product product)
        {
            string validation = _ValidateProduct(product);

            if (validation != "Ok")
                throw new ArgumentNullException(nameof(product), validation);

            _repository.Update(product);
        }

        public bool DeleteById(int id)
        {
            Product product = _repository.GetById(id);

            if (product != null)
            {
                var result = _repository.DeleteById(id);
                return result;
            }

            return false;
        }

        public string _ValidateInsert(Product product)
        {
            if (product == null)
                return "O produto não pode ser nulo.";

            if (product.name == null)
                return "O nome no produto não pode ser nulo";

            if (product.stockQuantity <= 0)
                return "Quantidade do produto inválida.";

            if (product.price <= 0)
                return "O preço deve ser maior que zero.";

            return "Ok";
        }

        public string _ValidateProduct(Product product)
        {
            if (product == null)
                return "O produto não pode ser nulo.";

            if (product.name == null)
                return "O nome no produto não pode ser nulo";

            if (product.id <= 0)
                return "O ID do produto deve ser válido.";

            if (product.price <= 0)
                return "O preço deve ser maior que zero.";

            return "Ok";
        }
    }
}