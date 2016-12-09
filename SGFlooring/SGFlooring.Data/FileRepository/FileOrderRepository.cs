using SGFlooring.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Models.Responses;
using SGFlooring.Models;

namespace SGFlooring.Data.FileRepository
{
    public class FileOrderRepository : IOrderRepository
    {
        private List<CustomerOrder> _orders;
        private static string _fullPath;

        public FileOrderRepository(string date)
        {
            _fullPath = $@"C:\_repos\alex-grbach-individual-work\SGFlooring\SGFlooring.UI\DataFiles\CustomerRepo\Orders_{date}.txt";

            if (_orders == null)
            {
                _orders = new List<CustomerOrder>();
                if (File.Exists(_fullPath))
                {
                    using (StreamReader sr = File.OpenText(_fullPath))
                    {
                        sr.ReadLine();
                        string inputLine = "";
                        while ((inputLine = sr.ReadLine()) != null)
                        {
                            string[] inputParts = inputLine.Split(',');
                            CustomerOrder order = new CustomerOrder()
                            {
                                OrderNumber = int.Parse(inputParts[0]),
                                CustomerName = inputParts[1],
                                StateKey = inputParts[2],
                                ProductKey = inputParts[3],
                                AreaString = inputParts[4]
                            };

                            _orders.Add(order);
                        }

                    }
                }
                else
                {
                    using (StreamWriter sw = new StreamWriter(_fullPath, false))
                    {
                        // write the header line
                        sw.WriteLine("OrderNumber,CustomerName,StateKey,ProductKey,Area");
                    }
                }
            }
        }

        public void AddOrder(CustomerOrder order)
        {
            _orders.Add(order);
            WriteFile();
        }

        public void RemoveOrder(int orderNumber)
        {
            
            _orders.RemoveAt(orderNumber);
            if (_orders.Count == 0)
            {
                File.Delete(_fullPath);
            }
            else
            {
                WriteFile();
            }
        }

        public void EditOrder(CustomerOrder order, int orderNumber)
        {
            _orders[orderNumber] = order;
            WriteFile();
        }

        public List<CustomerOrder> GetAllCustomerOrders()
        {
            return _orders;
        }

        public CustomerOrder GetOrderByNumber(int orderNumber)
        {
            return _orders[orderNumber];
        }

        public void WriteFile()
        {

            using (StreamWriter sw = new StreamWriter(_fullPath, false))
            {
                // write the header line
                sw.WriteLine("OrderNumber,CustomerName,StateKey,ProductKey,Area");

                foreach (var order in _orders)
                {
                    sw.WriteLine($"{order.OrderNumber},{order.CustomerName},{order.StateKey},{order.ProductKey},{order.AreaString}");
                }
            }
        }
    }
}
