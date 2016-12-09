using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGFlooring.Data
{
    public class ErrorLoger
    {
        public ErrorLoger(string error)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\_repos\alex-grbach-individual-work\SGFlooring\SGFlooring.UI\DataFiles\log.txt", true) )
            {
                sw.WriteLine($"{DateTime.Now.ToShortDateString()} - {DateTime.Now.ToShortTimeString()} - {error}");
                sw.Close();
            }
        }
    }
}
