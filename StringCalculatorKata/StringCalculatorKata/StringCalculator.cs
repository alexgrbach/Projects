using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {

            bool isNeg = false;
            string negOutput = null;
            int sum = 0;
            Regex re = new Regex(@"-?\d+");
            MatchCollection mc = re.Matches(numbers);
            foreach (Match m in mc)
            {
                for (int i = 0; i < m.Groups.Count; i++)
                {

                    int tempSum = int.Parse(m.Groups[i].Value);
                    if (tempSum < 0)  
                    {

                        isNeg = true;
                        negOutput += m.Groups[i].Value + ',';
                    }
                    else if (tempSum <= 1000)
                    {
                        sum += tempSum;
                    }
                }
            }

            if (isNeg == true)
            {
                sum = -99;

                negOutput = negOutput.Substring(0, negOutput.Length - 1);
                Console.WriteLine(string.Format($"Negatives not allowed: {negOutput}"));
            }

            return sum;
        }
    }
}
 