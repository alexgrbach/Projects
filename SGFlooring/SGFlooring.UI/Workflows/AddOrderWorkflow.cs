using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SGFlooring.BLL;
using SGFlooring.Models;
using SGFlooring.UI.DisplayElements;
using SGFlooring.Models.Responses;

namespace SGFlooring.UI.Workflows
{
    public class AddOrderWorkflow
    {
        private string _headerText;
        private readonly OrderForm _orderForm = new OrderForm();
        private readonly Lines _lines = new Lines();

        public void Execute()
        {

            CustomerOrder order = new CustomerOrder();
            OrderManager orderManager = new OrderManager();
            Prompts prompts = new Prompts();
            Wrappers wrappers = new Wrappers();

            _headerText = "Add Order";

            string date = $"{DateTime.Today.Month.ToString()}{DateTime.Today.Day.ToString()}{DateTime.Today.Year.ToString()}";

            Console.Clear();

            prompts.SetHeaderText(_headerText);

            order = prompts.GetNameFromCustomer(order);
            order = prompts.GetStateFromCustomer(order);
            order = prompts.GetProductFromCustomer(order);
            order = prompts.GetAreaFromCustomer(order);

            Console.Clear();
            _orderForm.AddOrder(order, _headerText);

            order = orderManager.SetOrderNumber(order, date);
            order = orderManager.OrderCalculations(order);
            Console.Clear();
            _orderForm.DisplayFullOrder(order, _headerText);
            Console.WriteLine();

            while (true)
            {               
                Console.WriteLine("Would you like to save this order? (Y/N)");

                switch (Console.ReadKey(false).Key)
                {
                    case ConsoleKey.Y:
                        orderManager.AddOrderToRepo(order, date);
                        Console.Clear();
                        wrappers.DrawHeader("Order Saved");
                        wrappers.DrawFooter();
                        Thread.Sleep(1000);
                        return;
                    case ConsoleKey.N:
                        Console.Clear();
                        wrappers.DrawHeader("Order not Saved");
                        wrappers.DrawFooter();
                        Thread.Sleep(1000);
                        return;
                    default:
                        Console.Clear();
                        _orderForm.DisplayFullOrder(order, _headerText);
                        Console.WriteLine();
                        Console.WriteLine("Press Y to save or N to abandon the order...");
                        break;
                }
            }
        } 
    }
}
