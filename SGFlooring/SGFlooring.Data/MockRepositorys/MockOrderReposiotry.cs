using SGFlooring.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Models;

namespace SGFlooring.Data.MockRepositorys
{
    public class MockOrderReposiotry : IOrderRepository
    {
        private static List<CustomerOrder> _orders;

        public MockOrderReposiotry()
        {
            if (_orders == null)
            {
                _orders = new List<CustomerOrder>()
                {
                    new CustomerOrder()
                    {
                        OrderNumber = 1,
                        CustomerName = "Billy McNugget",
                        AreaString = "100",
                        StateKey = "OH",
                        ProductKey = "Wood"

                    },
                    new CustomerOrder()
                    {
                        OrderNumber = 2,
                        CustomerName = "Ronald McDonald",
                        AreaString = "67",
                        StateKey = "OH",
                        ProductKey = "Wood"
                    },
                    new CustomerOrder()
                    {
                        OrderNumber = 3,
                        CustomerName = "Tyler Durden",
                        AreaString = "1234",
                        StateKey = "OH",
                        ProductKey = "Gold",
                    }
                };
            }

        }

        public void AddOrder(CustomerOrder order)
        {
            _orders.Add(order);
        }

        public void RemoveOrder(int orderNumber)
        {
            _orders.RemoveAt(orderNumber);
        }

        public void EditOrder(CustomerOrder order, int orderNumber)
        {
            _orders[orderNumber] = order;
        }

        public CustomerOrder GetOrderByNumber(int orderNumber)
        {
            return _orders[orderNumber];
        }

        public List<CustomerOrder> GetAllCustomerOrders()
        {
            return _orders;
        }
    }
}
