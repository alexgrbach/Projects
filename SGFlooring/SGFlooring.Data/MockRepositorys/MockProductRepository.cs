using SGFlooring.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Models.Responses;
using SGFlooring.Models;

namespace SGFlooring.Data.MockRepositorys
{
    public class MockProductRepository : IProductRepository
    {
        private static List<Product> _products;

        public MockProductRepository()
        {
            if (_products == null)
            {
                _products = new List<Product>()
                {
                    new Product()
                    {
                      ProductName = "Wood",
                      LaborCostSqFt = 1m,
                      MaterialCostSqFt = 2m
                    },
                    new Product()
                    {
                        ProductName = "Gold",
                        LaborCostSqFt = 100m,
                        MaterialCostSqFt = 9001m
                    },
                    new Product()
                    {
                        ProductName = "Marble",
                        LaborCostSqFt = 20m,
                        MaterialCostSqFt = 30m       
                    }                 
                };
            }

        }

        public List<Product> GetProductList()
        {
            return _products;
        }
    }
}
