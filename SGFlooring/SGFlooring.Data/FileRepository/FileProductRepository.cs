using SGFlooring.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Models;
using SGFlooring.Models.Responses;

namespace SGFlooring.Data.FileRepository
{
    public class FileProductRepository : IProductRepository
    {
        //private const string ProdListFile = @"..\..\SGFlooring.UI\DataFiles\Products.txt";
        private readonly string _prodListFile = ConfigurationManager.AppSettings["ProductRepoLocation"].ToString();
        private static List<Product> _products;

        /// <summary>
        /// Loads the file product repo into memory
        /// </summary>
        public FileProductRepository()
        {
            if (_products == null)
            {
                _products = new List<Product>();

                if (File.Exists(_prodListFile))
                {
                    using (StreamReader sr = File.OpenText(_prodListFile))
                    {
                        sr.ReadLine();

                        string inputLine = "";
                        while ((inputLine = sr.ReadLine()) != null)
                        {
                            string[] inputParts = inputLine.Split(',');
                            Product newProduct = new Product()
                            {
                                ProductName = inputParts[0],
                                MaterialCostSqFt = decimal.Parse(inputParts[1]),
                                LaborCostSqFt = decimal.Parse(inputParts[2])
                            };

                            _products.Add(newProduct);
                        }

                    }
                    //pops the first element off the list because the first line is not needed
                    //_products.RemoveAt(0);
                }
                else
                {
                    new ErrorLoger("Product ListFile Not Found");
                    throw new FileNotFoundException("Product List File not found");
                }
            }
        }

        /// <summary>
        /// gets all the products in the list
        /// </summary>
        /// <returns>List of products</returns>
        public List<Product> GetProductList()
        {
            return _products;
        }
    }
}
