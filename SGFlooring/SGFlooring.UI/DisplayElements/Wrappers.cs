using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGFlooring.UI.DisplayElements
{
    public class Wrappers
    {
        private readonly Lines _lines = new Lines();

        public void DrawHeader(string title)
        {
            int formTitlePadding = (_lines.DrawLine(LineTypes.Stars).Length / 2 + title.Length / 2) + 1;
            Console.WriteLine(_lines.DrawLine(LineTypes.Stars));
            Console.WriteLine();
            Console.WriteLine(title.PadLeft(formTitlePadding, ' '));
            Console.WriteLine();
        }

        public void DrawFooter()
        {
            Console.WriteLine();
            Console.WriteLine(_lines.DrawLine(LineTypes.Stars));
        }
    }
}
