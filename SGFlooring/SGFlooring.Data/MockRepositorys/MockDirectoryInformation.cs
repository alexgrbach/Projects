using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Data.Interfaces;

namespace SGFlooring.Data.MockRepositorys
{
    public class MockDirectoryInformation : IDirectoryInformation
    {
        private List<string> _orderDates;

        public MockDirectoryInformation()
        {
            if (_orderDates == null)
            {
                _orderDates = new List<string>();
                string month = DateTime.Today.Month.ToString();
                string day = DateTime.Today.Day.ToString();
                string year = DateTime.Today.Year.ToString();
                _orderDates.Add($"{month}{day}{year}");
            }
        }

        public List<string> GetAllOrderDates()
        {
            return _orderDates;
        }
    }
}
