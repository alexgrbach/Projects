using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.BLL;
using SGFlooring.Models;

namespace SGFlooring.UI.DisplayElements
{
    public class OrderForm
    {
        private readonly Lines _lines = new Lines();
        private readonly Wrappers _wrappers = new Wrappers();

        
        /// <summary>
        /// Displays order with all the details
        /// </summary>
        /// <param name="order">The order you want to display.</param>
        /// <param name="headerText">What you want the header to say.</param>
        public void DisplayFullOrder(CustomerOrder order, string headerText)
        {
            OrderManager orderManager = new OrderManager();
            order = orderManager.OrderCalculations(order);
            _wrappers.DrawHeader(headerText);
            DrawCustomerInformation(order);
            DrawProductInformation(order);
            DrawTotalInformation(order);
            _wrappers.DrawFooter();
        }

        public void AddOrder(CustomerOrder order, string headderText)
        {
            _wrappers.DrawHeader(headderText);
            DrawCustomerInformation(order);
            _wrappers.DrawFooter();
        }

        private static void DrawCustomerInformation(CustomerOrder order)
        {
            Console.WriteLine($"Name: {order.CustomerName}");
            Console.WriteLine($"State: {order.StateKey}");           
            Console.WriteLine($"Floor Type: {order.ProductKey}");
            Console.WriteLine($"Amount Purchased (SqFt): {order.AreaString} ");
        }

        private static void DrawProductInformation(CustomerOrder order)
        {
            var productsManager = new ProductManager();
            var productsResponse = productsManager.GetProductResponse(order.ProductKey);
            Console.WriteLine($"Material cost per SqFt: {productsResponse.Product.MaterialCostSqFt:C}");
            Console.WriteLine($"Labor cost per SqFt: {productsResponse.Product.LaborCostSqFt:C}");
        }

        private void DrawTotalInformation(CustomerOrder order)
        {
            var statesManager = new StateManager();
            var stateResponse = statesManager.GetStateResponse(order.StateKey);
            Console.WriteLine(_lines.DrawLine(LineTypes.Equals));
            Console.WriteLine();
            Console.WriteLine($"Total Material Cost: {order.MaterialCostTotal:C}");
            Console.WriteLine($"Total Labor Cost: {order.LaborCostTotal:C}");
            Console.WriteLine($"Subtotal: {(order.MaterialCostTotal + order.LaborCostTotal):C}");
            Console.WriteLine($"{stateResponse.State.StateName}'s tax rate is {stateResponse.State.TaxRate}%");
            Console.WriteLine($"Tax: {order.OrderTax:C}");
            Console.WriteLine(_lines.DrawLine(LineTypes.Equals));
            Console.WriteLine();
            Console.WriteLine($"Order Total: {order.OrderTotal:C}");
        }

    }
}
