using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGFlooring.UI.DisplayElements
{
    public class Menus
    {
        private readonly Wrappers _wrappers = new Wrappers();

        public void MainMenu()
        {
            _wrappers.DrawHeader("Main Menu");
            Console.WriteLine("*");
            Console.WriteLine();
            Console.WriteLine("* 1. Display Orders");
            Console.WriteLine();
            Console.WriteLine("* 2. Add an Order");
            Console.WriteLine();
            Console.WriteLine("* 3. Edit an Order");
            Console.WriteLine();
            Console.WriteLine("* 4. Remove an Order");
            Console.WriteLine();
            Console.WriteLine("* 5. Quit");
            Console.WriteLine();
            Console.WriteLine("*");
            _wrappers.DrawFooter();
            Console.WriteLine();
        }
    }
}
