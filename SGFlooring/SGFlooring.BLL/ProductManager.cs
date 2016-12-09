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
        public ProductResponse GetProductResponse(string productName)
        {
            
            var response = new ProductResponse();
            var products = GetAllProduct();

            foreach (var product in products)
            {
                if (product.ProductName != productName) continue;

                response.Success = true;
                response.Product = product;
                return response;
            }

            response.Success = false;
            response.Message = "Product is not in list...";
            return response;       
        }

        public List<Product> GetAllProduct()
        {
            var repo = RepositoryFactory.CreateProductRepository();
            return repo.GetProductList();
        }
    }
}
