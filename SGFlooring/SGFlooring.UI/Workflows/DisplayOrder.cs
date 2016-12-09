using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SGFlooring.BLL;
using SGFlooring.Models;
using SGFlooring.UI.DisplayElements;

namespace SGFlooring.UI.Workflows
{
    public class DisplayOrder
    {
        
        private readonly OrderForm _orderForm = new OrderForm();
        private readonly Prompts _prompts = new Prompts();
        private readonly Wrappers _wrappers = new Wrappers();
        


        /// <summary>
        /// Displays a list of all orders, prompts the user to choose one to see detailed information about it
        /// </summary>
        public void Execute()
        {
            Console.Clear();
            _prompts.SetHeaderText("Display Order");

            string date = _prompts.GetDateFromCustomer();

            if (date == null)
            {
                Console.Clear();
                _wrappers.DrawHeader("Invalid date");
                Console.WriteLine("Returning to the main menu");
                _wrappers.DrawFooter();
                Thread.Sleep(1000);
                return;
            }

            int orderNumber = _prompts.GetOrderNumberFromUser(date);
            var orderManager = new OrderManager();

            if (orderNumber < 0 || orderNumber > orderManager.NumberOfOrdersInRepo(date))
            {
                Console.Clear();
                _wrappers.DrawHeader("Invalid Entry...");
                Console.WriteLine("Returning to the main menu");
                _wrappers.DrawFooter();
                Thread.Sleep(1000);
                return;
            }

            var customerOrder = RetreiveOrderByNumber(orderNumber, date);
           
            Console.Clear();

            _orderForm.DisplayFullOrder(customerOrder, $"Order #{customerOrder.OrderNumber}");
            Console.WriteLine();
            Console.Write("Press any key to go back to the main menu...");
            Console.ReadKey();
        }

        /// <summary>
        /// Gets the detailed order information
        /// </summary>
        /// <param name="orderNumber">Number of order you want to display</param>
        /// <param name="date">Date where the repo lives</param>
        /// <returns>an order</returns>
        private static CustomerOrder RetreiveOrderByNumber(int orderNumber, string date)
        {
            var ops = new OrderManager();
            var response = ops.DisplayCustomerOrder(orderNumber, date);
            if (response.Success)
            {
                return response.Order;
            }          
            Console.WriteLine("Error Occurred!!!!");
            Console.WriteLine(response.Message);
            Console.WriteLine("Go away now...");
            Console.ReadLine();         
            return null;
        }
    }
    
}
