using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SGFlooring.Data;

namespace SGFlooring.BLL
{
    public class DirectoryManager
    {

        public bool CheckDate(string date)
        {
            var directoryInformation = RepositoryFactory.CreateDirectoryInformation();
            var orderDates = directoryInformation.GetAllOrderDates();
            return orderDates.Contains(TranslateDate(date));
        }

        public string TranslateDate(string date)
        {
            //strips out all delimiters
            return Regex.Replace(date, "[^0-9]", "");
        }

        public List<string> OrderDateList()
        {
            var directoryInforamtion = RepositoryFactory.CreateDirectoryInformation();
            var formattedDateList = new List<string>();
            foreach (var date in directoryInforamtion.GetAllOrderDates())
            {
                string month = date.Substring(0, 2);
                string day = date.Substring(2, 2);
                string year = date.Substring(4, 4);
                formattedDateList.Add($@"{month}/{day}/{year}");
            }
            return formattedDateList;
        }
    }
}
