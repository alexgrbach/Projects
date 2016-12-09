using SGFlooring.Models;
using SGFlooring.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGFlooring.Data.Interfaces
{
    public interface IProductRepository
    {

        /// <summary>
        /// Creates a list of products 
        /// </summary>
        /// <returns>Product List</returns>
        List<Product> GetProductList();

    }
}
