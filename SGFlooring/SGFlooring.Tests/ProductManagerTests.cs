using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGFlooring.BLL;

namespace SGFlooring.Tests
{
    [TestFixture]
    public class ProductManagerTests
    {
        private readonly ProductManager _productManager = new ProductManager();

        [TestCase("Wood", true)]
        [TestCase("Rubber", false)]
        [TestCase("wood",true)]
        public void GetProductResponseTest(string productName, bool expected)
        {
            var response = _productManager.GetProductResponse(productName);
            Assert.AreEqual(expected,response.Success);
        }

    }
}
