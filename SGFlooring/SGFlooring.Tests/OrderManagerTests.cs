using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGFlooring.BLL;
using SGFlooring.Models;

namespace SGFlooring.Tests
{
    [TestFixture]
    public class OrderManagerTests
    {
       // private readonly OrderManager _orderManager = new OrderManager();

        private readonly string _date = DateTime.Today.Month.ToString() +
                                        DateTime.Today.Day.ToString() +
                                        DateTime.Today.Year.ToString();

        private readonly CustomerOrder _order = new CustomerOrder()
        {
            CustomerName = "Billy Bob Thorton",
            StateKey = "OH",
            ProductKey = "Wood",
            Area = 100m,
            AreaString = "100"
        };

        
        [Test]
        public void NumberOfOrdersInRepo()
        {
            var orderManager = new OrderManager();
            int numberOforders = orderManager.NumberOfOrdersInRepo(_date);
            Assert.AreEqual(3, numberOforders);          
        }

        [Test]
        public void NumberOfOrdersInRepoFail()
        {
            var orderManager = new OrderManager();
            int numberOforders = orderManager.NumberOfOrdersInRepo(_date);
            Assert.AreNotEqual(3, numberOforders);
        }

        [Test]
        public void SetOrderNumberTest()
        {
            var orderManager = new OrderManager();
            var testOrder = new CustomerOrder();
            testOrder = orderManager.SetOrderNumber(_order, _date);

            Assert.AreEqual(4, testOrder.OrderNumber);
        }

        [Test]
        public void OrderCalculationsTest()
        {
            var orderManager = new OrderManager();
            CustomerOrder testOrder = new CustomerOrder();
            StateManager stateManager = new StateManager();
            ProductManager productManager = new ProductManager();

            testOrder = orderManager.OrderCalculations(_order);                    
            var productResponse = productManager.GetProductResponse(_order.ProductKey);
            var laborCost = productResponse.Product.LaborCostSqFt;
            var materialCost = productResponse.Product.MaterialCostSqFt;
            var stateResponse = stateManager.GetStateResponse(_order.StateKey);

            var subTotal = (_order.Area * (materialCost + laborCost));                      
            var tax = subTotal/stateResponse.State.TaxRate;
            var total = subTotal + tax;

            Assert.AreEqual(total, testOrder.OrderTotal);
        }

        [Test]
        public void AddOrderToRepoTest()
        {
            var orderManager = new OrderManager();
            orderManager.AddOrderToRepo(_order,_date);
            Assert.AreEqual(4,orderManager.NumberOfOrdersInRepo(_date));
        }

        [Test]
        public void RemoveOrderFromRepoTest()
        {
            var orderManager = new OrderManager();
            orderManager.RemoveOrder(3, _date);
           Assert.AreEqual(2,orderManager.NumberOfOrdersInRepo(_date));
        }
    }
}
