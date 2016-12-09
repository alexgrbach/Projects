using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SGFlooring.BLL;
using SGFlooring.Models;
using SGFlooring.Models.Responses;

namespace SGFlooring.UI.DisplayElements
{
    public class Prompts
    {

        private readonly OrderForm _orderForm = new OrderForm();
        private readonly DisplayFullList _displayFullList = new DisplayFullList();
        private static string _headerText = "Set your headerText";
        private bool _edit;
        

        /// <summary>
        /// Displays all orders in a repo and prompts the user to pick an order number
        /// </summary>
        /// <returns>an order number</returns>
        public int GetOrderNumberFromUser(string date)
        {
            int orderNumber;
            Console.Clear();

            _displayFullList.Orders(_headerText, date);
            Console.Write("Plese select an order: ");


            if (!int.TryParse(Console.ReadLine(), out orderNumber))
            {
                return -1;
            }
            return orderNumber;
        }

        /// <summary>
        /// Prompts the user for a name and adds it to an order
        /// </summary>
        /// <param name="order">Order that the name is being added to</param>
        /// <param name="headerText">Text to display on the header</param>
        /// <returns>Updated customer order</returns>
        public CustomerOrder GetNameFromCustomer(CustomerOrder order)
        {
    
            string customerName;
            Console.Clear();
            _orderForm.AddOrder(order, _headerText);
            Console.WriteLine();
            Regex rgx = new Regex(@"^[a-zA-Z0-9 -]*$");
            bool isMatch;
            do
            {
                Console.Write("Please enter the customers name: ");
                customerName = Console.ReadLine();
                isMatch = rgx.IsMatch(customerName);
                //rgx.Replace(customerName, "");
                if (string.IsNullOrWhiteSpace(customerName) && !_edit)
                {
                    Console.Clear();
                    _orderForm.AddOrder(order, _headerText);
                    Console.WriteLine();
                    Console.WriteLine("You have to enter something...");
                }
                else if(string.IsNullOrEmpty(customerName) && _edit)
                {
                    return order;
                }
                else if(!isMatch)
                {
                    Console.Clear();
                    _orderForm.AddOrder(order, _headerText);
                    Console.WriteLine();
                    Console.WriteLine("No Super Special characters aloud in names...\nHyphens are cool though");
                }
            }
            while ((string.IsNullOrWhiteSpace(customerName) && !_edit) || !isMatch);

            
            //Returns customername with capital values because it is a proper noun!

            string[] customerNameArray = customerName.Split(' ');
            string formattedName = null;
            foreach (var name in customerNameArray)
            {
               formattedName += name.ToUpper().First() + name.Substring(1) + " ";
            }

            order.CustomerName = formattedName;
            return order;
        }

        /// <summary>
        /// Prompts the user for an area and adds it to an order
        /// </summary>
        /// <param name="order">Order that is to be updated </param>
        /// <param name="headerText">Text that is to be displayed on the header</param>
        /// <returns>Updated customer order</returns>
        public CustomerOrder GetAreaFromCustomer(CustomerOrder order)
        {

            Console.Clear();
            _orderForm.AddOrder(order, _headerText);
            Console.WriteLine();
            Console.Write($"How many square feet of {order.ProductKey} does the customer want? ");

            string input = Console.ReadLine();
        
            if (string.IsNullOrEmpty(input) && _edit)
            {
                return order;
            }

            decimal area;
            bool isValid = decimal.TryParse(input, out area);

            while(!isValid || area <= 0)
            {
                Console.Clear();
                _orderForm.AddOrder(order, _headerText);
                Console.WriteLine();
                Console.WriteLine("Please enter a number...");
                Console.Write($"How many square feet of {order.ProductKey} does the customer want? ");
                input = Console.ReadLine();
                isValid = decimal.TryParse(input, out area);
            }

            order.Area = area;
            order.AreaString = input;
            return order;

        }

        /// <summary>
        /// Prompts the user for a state and adds it to an order
        /// </summary>
        /// <param name="order">Order that is to be updated </param>
        /// <param name="headerText">Text that is to be displayed on the header</param>
        /// <returns>Updated customer order</returns>
        public CustomerOrder GetStateFromCustomer(CustomerOrder order)
        {
            string input;
            Console.Clear();
            _orderForm.AddOrder(order, _headerText);
            Console.WriteLine();
            _displayFullList.States();
            Console.WriteLine();

            var ops = new StateManager();
            StateResponse response;

            do
            {
                Console.Write("Please enter customers state abbrevation: ");
                input = Console.ReadLine().ToUpper();
                if (string.IsNullOrEmpty(input) && _edit)
                {
                    return order;
                }
                response = ops.GetStateResponse(input);
                if (!response.Success)
                {
                    Console.Clear();
                    _orderForm.AddOrder(order, _headerText);
                    Console.WriteLine();
                    _displayFullList.States();
                    Console.WriteLine();
                    Console.WriteLine(response.Message);
                }
            } while (!response.Success);

            order.StateKey = input;
            return order;
        }

        /// <summary>
        /// Prompts the user for a product and adds it to an order
        /// </summary>
        /// <param name="order">Order that is to be updated </param>
        /// <param name="headerText">Text that is to be displayed on the header</param>
        /// <returns>Updated customer order</returns>
        public CustomerOrder GetProductFromCustomer(CustomerOrder order)
        {
            
            Console.Clear();
            _orderForm.AddOrder(order, _headerText);
            Console.WriteLine();
            _displayFullList.Products();
            Console.WriteLine();

            var ops = new ProductManager();
            ProductResponse response;
            string input;
            do
            {
                Console.Write("Please enter a product: ");
                input = Console.ReadLine();

                if (string.IsNullOrEmpty(input) && _edit)
                {
                    return order;
                }

                if (!string.IsNullOrWhiteSpace(input))
                {
                    //Formating to match key
                    input = (input.ToUpper().First() + input.Substring(1).ToLower());
                }

                response = ops.GetProductResponse(input);

                if (!response.Success)
                {
                    Console.Clear();
                    _orderForm.AddOrder(order, _headerText);
                    Console.WriteLine();
                    _displayFullList.Products();
                    Console.WriteLine();
                    Console.WriteLine(response.Message);
                }
            } while (!response.Success);


            order.ProductKey = input;
            return order;
        }

        /// <summary>
        /// Gets the Order date from the customer
        /// </summary>
        /// <returns>Validated date or null if invalid</returns>
        public string GetDateFromCustomer()
        {
            Console.Clear();
            var wrappers = new Wrappers();
            wrappers.DrawHeader("Order Dates");
            _displayFullList.Files();
            wrappers.DrawFooter();
            var directoryManager = new DirectoryManager();
            Console.WriteLine();
            Console.Write("Please pick a date from the list: ");
            string input = Console.ReadLine();
            if (!directoryManager.CheckDate(input))
            {
                return null;
            }
            return directoryManager.TranslateDate(input);       
        }

        /// <summary>
        /// Sets header text for prompts
        /// </summary>
        /// <param name="headerText">Text that is displayed in header</param>
        public void SetHeaderText(string headerText)
        {
            _headerText = headerText;
        }

        /// <summary>
        /// Sets the edit bool to chagne the prompts 
        /// </summary>
        /// <param name="edit">Set true in edit mode</param>
        public void EditMode()
        {
            _edit = true;
        }   
    }
}
