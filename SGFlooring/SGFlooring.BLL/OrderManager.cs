using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Data;
using SGFlooring.Data.Interfaces;
using SGFlooring.Models;
using SGFlooring.Models.Responses;

namespace SGFlooring.BLL
{
    public class OrderManager
    {
        /// <summary>
        /// Gets Customer order to display
        /// </summary>
        /// <param name="orderNumber">The number of the order that you want to display</param>
        /// <param name="date">Date of customer order that is to be displayed</param>
        /// <returns>A customer order response.</returns>
        public CustomerOrderResponse DisplayCustomerOrder(int orderNumber, string date)
        {
            CustomerOrderResponse response = new CustomerOrderResponse();
            orderNumber--;         
            var repo = RepositoryFactory.CreateOrderRepository(date);
            var order = repo.GetOrderByNumber(orderNumber);

            if (order != null)
            {
                response.Success = true;
                response.Order = order;
            }
            else
            {
                response.Success = false;
                response.Message = $"Order Number: {orderNumber} not found";
                new ErrorLoger("Something is really broken if you are seeing this error");
            }
            return response;
        }

        /// <summary>
        /// Adds order to the current repository
        /// </summary>
        /// <param name="order">Order to be passed to the repo.</param>
        /// <param name="date">Date of order to add</param>
        public void AddOrderToRepo(CustomerOrder order, string date)
        {
            order = OrderCalculations(order);
            var repo = RepositoryFactory.CreateOrderRepository(date);
            repo.AddOrder(order);
        }

        /// <summary>
        /// Calculates parts of the Customer Order
        /// </summary>
        /// <param name="order">Order that the calcualtions are to be preformed on.</param>
        /// <returns>Updated order.</returns>
        public CustomerOrder OrderCalculations(CustomerOrder order)
        {

            var stateManager = new StateManager();          
            var stateResponse = stateManager.GetStateResponse(order.StateKey);   
                        
            var productManager = new ProductManager();
            var productRepsonse = productManager.GetProductResponse(order.ProductKey);

            order.Area = decimal.Parse(order.AreaString);
            order.MaterialCostTotal = order.Area*productRepsonse.Product.MaterialCostSqFt;
            order.LaborCostTotal = order.Area*productRepsonse.Product.LaborCostSqFt;
            decimal subTotal = order.MaterialCostTotal + order.LaborCostTotal;
            order.OrderTax = subTotal/stateResponse.State.TaxRate;
            order.OrderTotal = subTotal + order.OrderTax;         
       
            return order;
        }

        public CustomerOrder SetOrderNumber(CustomerOrder order, string date)
        {

            try
            {
                order.OrderNumber = (GetAllOrders(date)[NumberOfOrdersInRepo(date) -1].OrderNumber) + 1;
            }
            catch (ArgumentOutOfRangeException)
            {
                order.OrderNumber = 1;
            }

            return order;
        }

        /// <summary>
        /// Removes the order passed from the repo.
        /// </summary>
        /// <param name="orderNumber">Order that is to be removed.</param>
        /// <param name="date">date or order to be removed</param>
        /// <returns>A CustomerOrderResponse.</returns>
        public CustomerOrderResponse RemoveOrder(int orderNumber, string date)
        {
            var repo = RepositoryFactory.CreateOrderRepository(date);
            //subtract 1 to account for the offset
            orderNumber--;
            repo.RemoveOrder(orderNumber);
            return new CustomerOrderResponse() {Success = true};
        }

        /// <summary>
        /// Puts edited edited order into old spot
        /// </summary>
        /// <param name="order"></param>
        /// <param name="orderNumber"></param>\
        /// <param name="date">date where the data lives</param>
        public void EditOrder(CustomerOrder order, int orderNumber, string date)
        {
            var repo = RepositoryFactory.CreateOrderRepository(date);
            //subtract 1 to accout for the offset
            orderNumber--;
            repo.EditOrder(order, orderNumber);
        }
        
        /// <summary>
        /// Gets the number of orders in the current repository.
        /// </summary>
        /// <returns>The number of orders.</returns>
        public int NumberOfOrdersInRepo(string date)
        {          
            return GetAllOrders(date).Count;
        }

        /// <summary>
        /// Gets a list of all the current orders.
        /// </summary>
        /// <returns>List of customer orders.</returns>
        public List<CustomerOrder> GetAllOrders(string date)
        {
            var repo = RepositoryFactory.CreateOrderRepository(date);
            var orders = repo.GetAllCustomerOrders();
            var calculatedOrderList = new List<CustomerOrder>();
            foreach (var order in orders)
            {
                 calculatedOrderList.Add(OrderCalculations(order));;        
            }           
            return calculatedOrderList;
        }
    }
}
