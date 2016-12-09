using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Data.Interfaces;

namespace SGFlooring.Data.FileRepository
{
    public class FileDirectoryInformation : IDirectoryInformation
    {
        private List<string> _orderDates;
        private const string FileDirectory = @"C:\_repos\alex-grbach-individual-work\SGFlooring\SGFlooring.UI\DataFiles\CustomerRepo\";


        public FileDirectoryInformation()
        {
            if (_orderDates == null)
            {
                _orderDates = new List<string>();
                if (Directory.Exists(FileDirectory))
                {
                    string[] files = Directory.GetFiles(FileDirectory);

                    foreach (var file in files)
                    {
                        //filename Orders_MMDDYYYY.txt
                        string[] fileNameString = file.Split('_');
                        fileNameString = fileNameString[2].Split('.');
                        _orderDates.Add(fileNameString[0]);
                    }
                }
                else
                {
                    new ErrorLoger("soemthing went wrong");
                    throw new SystemException("DriectoryNotFound");
                }

            }

        }

        public List<string> GetAllOrderDates()
        {
            return _orderDates;
        }
    }
}
