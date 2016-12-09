using System;
using SGFlooring.BLL;
using SGFlooring.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.UI.DisplayElements;

namespace SGFlooring.UI.Workflows
{
    public class MainMenu
    {
        public bool Display()
        {
            
            bool isValid;
            Menus menus = new Menus();
            menus.MainMenu();
            var displayOrder = new DisplayOrder();
            var addOrder = new AddOrderWorkflow();
            var removeOrder = new RemoveOrder();
            var editOrder = new EditOrder();
            //addOrder.Execute(false);
           
            Console.Write($"Please press a key 1-5: ");

            do
            {
                isValid = true;
                ConsoleKey input = Console.ReadKey(false).Key;    
                   
                switch (input)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:                       
                        displayOrder.Execute();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        
                        addOrder.Execute();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Console.Clear();
                        editOrder.Execute();                        
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        removeOrder.Execute();
                        //remove order
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        //probably needs to close out of files here
                        return false;
                        
                    default:
                        
                        isValid = false;
                        Console.Clear();
                        menus.MainMenu();
                        Console.WriteLine("You did something wrong...");
                        Console.Write("Please press a key 1-5: ");
                        
                        break;
                }
            } while (!isValid);
            return true;
        }
    }
}
