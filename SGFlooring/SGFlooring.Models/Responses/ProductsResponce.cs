using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGFlooring.Models.Responses
{
    public class ProductResponce
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Products Product { get; set; }
    }
}
