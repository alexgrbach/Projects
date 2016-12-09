using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.UI.Workflows;

namespace SGFlooring.UI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var mainMenu = new MainMenu();
            while (mainMenu.Display())
            {
                Console.Clear();
            }
        }
    }
}
