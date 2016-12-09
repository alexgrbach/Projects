using SGFlooring.Models;
using SGFlooring.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGFlooring.Data.Interfaces
{
    public interface IOrderRepository
    {
        /// <summary>
        /// Gets the order by the order number
        /// </summary>
        /// <param name="orderNumber">Order Number to retreive</param>
        /// <param name="fileName">filename of where the order lives</param>
        /// <returns>account object representing the number</returns>
        CustomerOrder GetOrderByNumber(int orderNumber);

        /// <summary>
        /// adds order to the repo
        /// </summary>
        /// <param name="order">object that is added to the repo</param>
        /// <returns>true if order was added successfully</returns>
        void AddOrder(CustomerOrder order);

        /// <summary>
        /// Deletes orders
        /// </summary>
        /// <param name="orderNumber">object that is deleted from the repo</param>
        /// <returns>true if order was deleted successfully</returns>
        void RemoveOrder(int orderNumber);

        /// <summary>
        /// Edits order
        /// </summary>
        /// <param name="order">object that is being edited</param>
        /// <param name="orderNumber">position of object in list</param>
        /// <returns>True </returns>
        void EditOrder(CustomerOrder order, int orderNumber);

        /// <summary>
        /// Gets all customer orders 
        /// </summary>
        /// <returns>A list of customer orders</returns>
        List<CustomerOrder> GetAllCustomerOrders();

    }
}
