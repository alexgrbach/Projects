using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGFlooring.Models
{
    public class CustomerOrder
    {
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public string AreaString { get; set; }
        public decimal Area { get; set; }
        public decimal LaborCostTotal { get; set; }
        public decimal MaterialCostTotal { get; set; }
        public decimal OrderTax { get; set; }
        public decimal OrderTotal { get; set; }
        public string StateKey { get; set; }
        public string ProductKey { get; set; }
    }
}
