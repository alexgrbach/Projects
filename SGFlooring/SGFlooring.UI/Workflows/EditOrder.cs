using SGFlooring.UI.DisplayElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SGFlooring.BLL;
using SGFlooring.Models;
using SGFlooring.Models.Responses;

namespace SGFlooring.UI.Workflows
{
    public class EditOrder
    {
        private readonly OrderForm _orderForm = new OrderForm();
        private readonly Prompts _prompts = new Prompts();
        private readonly DisplayFullList _displayFullList = new DisplayFullList();
        private readonly Wrappers _wrappers = new Wrappers();
        private const string HeaderText = "Edit Order";
        

        public void Execute()
        {
            Console.Clear();
            var orderManager = new OrderManager();
            _prompts.EditMode();
            _prompts.SetHeaderText(HeaderText);

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
            
            CustomerOrder orderEdit = new CustomerOrder();

            _prompts.SetHeaderText(HeaderText);
            //_orderForm.AddOrder(orderEdit, HeaderText);

            CustomerOrder order = orderResponse.Order;
            orderManager.OrderCalculations(order);
            //sets the new values to the old ones for reuse
            orderEdit.CustomerName = order.CustomerName;
            orderEdit.AreaString = order.AreaString;
            orderEdit.Area = order.Area;
            orderEdit.StateKey = order.StateKey;
            orderEdit.ProductKey = order.ProductKey;
            orderEdit.OrderNumber = order.OrderNumber;

            _orderForm.AddOrder(orderEdit, HeaderText);          
            orderEdit = _prompts.GetNameFromCustomer(orderEdit);
            Console.Clear();
            _orderForm.AddOrder(orderEdit, HeaderText);
            orderEdit = _prompts.GetStateFromCustomer(orderEdit);
            Console.Clear();
            _orderForm.AddOrder(orderEdit, HeaderText);
            orderEdit = _prompts.GetProductFromCustomer(orderEdit);
            Console.Clear();
            _orderForm.AddOrder(orderEdit, HeaderText);
            orderEdit = _prompts.GetAreaFromCustomer(orderEdit);

            Console.Clear();
            orderEdit = orderManager.OrderCalculations(orderEdit);
            _orderForm.DisplayFullOrder(orderEdit, HeaderText);
            

            while(true)
            {
                Console.WriteLine("Save edited order (Y/N)");
                switch (Console.ReadKey(false).Key)
                {
                    case ConsoleKey.Y:
                        
                        orderManager.EditOrder(orderEdit, orderNumber, date);
                        Console.Clear();
                        _wrappers.DrawHeader("Changes saved");
                        _wrappers.DrawFooter();
                        Thread.Sleep(1000);
                        return;
                    case ConsoleKey.N:
                        Console.Clear();
                        _wrappers.DrawHeader("Changes not saved");
                        _wrappers.DrawFooter();
                        Thread.Sleep(1000);
                        return;
                    default:
                        Console.Clear();
                        _orderForm.AddOrder(orderEdit, HeaderText);
                        Console.WriteLine("Press either Y or N");
                        continue;
                }
            }       
        }
    }
}
