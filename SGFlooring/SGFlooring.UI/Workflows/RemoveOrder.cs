using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SGFlooring.BLL;
using SGFlooring.Models.Responses;
using SGFlooring.UI.DisplayElements;

namespace SGFlooring.UI.Workflows
{
    public class RemoveOrder
    {
        private readonly Lines _lines = new Lines();
        private readonly OrderForm _orderForm = new OrderForm();
        private readonly Prompts _prompts = new Prompts();
        private readonly DisplayFullList _displayFullList = new DisplayFullList();
        private readonly Wrappers _wrappers = new Wrappers();

        public void Execute()
        {
            Console.Clear();

            var orderManager = new OrderManager();

            _displayFullList.Products();
            _prompts.SetHeaderText("Remove Order");

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
           
            if (orderNumber < 0 || orderNumber > orderManager.NumberOfOrdersInRepo(date))
            {
                Console.Clear();
                
                _wrappers.DrawHeader("Invalid Entry...");
                Console.WriteLine("Returning to the main menu");
                _wrappers.DrawFooter();
                Thread.Sleep(1000);
                
                return;
            }

            CustomerOrderResponse orderResponse = orderManager.DisplayCustomerOrder(orderNumber, date);

            if (!orderResponse.Success)
            {
                Console.Clear();
                _wrappers.DrawHeader(orderResponse.Message);
                _wrappers.DrawFooter();
                Thread.Sleep(1000);
                return;
            }
            Console.Clear();
            _orderForm.DisplayFullOrder(orderResponse.Order, $"Remove Order?");
            Console.WriteLine();
            while (true)
            {
                Console.Write("Are you sure you want to remove this order? (Y/N) ");               
                switch (Console.ReadKey(false).Key)
                {
                    case ConsoleKey.Y:
                        Console.Clear();
                        orderManager.RemoveOrder(orderNumber, date);
                        _wrappers.DrawHeader("Order has been removed");
                        _wrappers.DrawFooter();
                        Thread.Sleep(1000);
                        return;
                    case ConsoleKey.N:
                        Console.Clear();
                        _wrappers.DrawHeader("Order has not been removed");
                        _wrappers.DrawFooter();
                        Thread.Sleep(1000);
                        return;
                    default:
                        Console.Clear();
                        _orderForm.DisplayFullOrder(orderResponse.Order, $"Remove Order #{orderNumber}?");
                        Console.WriteLine();
                        Console.WriteLine("Please press the Y or N key...");
                        continue;
                }
            }
           




        }
    }
}
