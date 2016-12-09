using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Data;
using SGFlooring.Models;
using SGFlooring.Models.Responses;

namespace SGFlooring.BLL
{
    public class ProductManager
    {
        public ProductsResponce GetProductsResponce(string productName)
        {
            
            var response = new ProductsResponce();
            var products = GetAllProducts();

            foreach (var product in products)
            {
                if (product.ProductName != productName) continue;

                response.Success = true;
                response.Product = product;
                return response;
            }

            response.Success = false;
            response.Message = "Product does not exist";
            return response;       
        }

        public List<Products> GetAllProducts()
        {
            var repo = RepositoryFactory.CreateProductRepository();
            return repo.GetProductsList();

        }
    }
}
