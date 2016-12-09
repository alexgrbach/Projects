using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.BLL;

namespace SGFlooring.UI.DisplayElements
{
    public class DisplayFullList
    {
        private readonly Lines _lines = new Lines();
        private readonly Wrappers _wrappers = new Wrappers();

        /// <summary>
        /// Displays all states in the list
        /// </summary>
        public void States()
        {
            const string headFormat = "{0, 2} = {1,-10}";

            var statesManager = new StateManager();
            Console.WriteLine("Current service area");
            Console.WriteLine("====================");

            foreach (var state in statesManager.GetAllStates())
            {
                Console.WriteLine(headFormat, state.StateAbbreviation, state.StateName);
            }
        }

        /// <summary>
        /// Displays all Products in list
        /// </summary>
        public void Products()
        {
            string line = _lines.DrawLine(LineTypes.Equals);
            const string sectionHead = "Current Products";
            const string headFormat = "{0,-10}{1, 8:C}{2,-20}";
            var productsManager = new ProductManager();
            Console.WriteLine();
            Console.WriteLine(sectionHead.PadLeft((line.Length / 2 + sectionHead.Length / 2) + 1, ' '));
            Console.WriteLine(line);

            foreach (var product in productsManager.GetAllProduct())
            {
                Console.WriteLine(headFormat, product.ProductName, product.LaborCostSqFt + product.MaterialCostSqFt, "/SqFt Installed");
                //Console.WriteLine($"{product.ProductName}\t\t{(product.LaborCostSqFt + product.MaterialCostSqFt):C}/SqFt installed.");
            }
        }

        /// <summary>
        /// Displays all orders in list of orders
        /// <param name="headerText">Text you want to show in the header</param>
        /// </summary>
        public void Orders(string headerText, string date)
        {
            var ops = new OrderManager();
            string headFormat = "{0, 1}. {1, -20} Total: {2,-10:C}";
            int orderNumber = 0;

            _wrappers.DrawHeader(headerText);
            
            foreach (var order in ops.GetAllOrders(date))
            {
                orderNumber++;
                Console.WriteLine(headFormat, orderNumber, order.CustomerName, order.OrderTotal);

            }
            _wrappers.DrawFooter();
            Console.WriteLine();
        }

        public void Files()
        { 
            var directoryManager = new DirectoryManager();
            foreach (var days in directoryManager.OrderDateList())
            {
                Console.WriteLine(days);
            }
        }
    }
}
