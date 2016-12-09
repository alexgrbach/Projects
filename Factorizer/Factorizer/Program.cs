using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            functions func = new functions();
            Console.Write("Yo this is factorizer\nI give you the factors of any number\n\nTell me a number to factorize for you! ");
            string input = Console.ReadLine();
            int validInput;
            int sum = 1;
            bool isValid;
            do
            {
                isValid = int.TryParse(input, out validInput);
                if (!isValid)
                {
                    Console.Write("Come on man input a number! ");
                    input = Console.ReadLine();
                    //isValid = int.TryParse(input, out validInput);
                }
            } while (!isValid);
            Console.WriteLine();
            Console.WriteLine("1");
            Console.WriteLine(validInput);
            Console.WriteLine();
            int count1 = 2; 
            for (int i = 2; i < Math.Sqrt(validInput); i++)
            {
                if (validInput % i == 0)
                {
                    Console.WriteLine(i);
                    count1++;
                    Console.WriteLine(validInput / i);
                    count1++;
                    sum += (validInput / i);
                    Console.WriteLine();
                    sum += i;
                         
                }
                if ((validInput % (i + 1) == 0) && i == (Math.Sqrt(validInput) -1))//gets 1 instance of the middle number in the output
                {
                    Console.WriteLine($"{Math.Sqrt(validInput)}^2");
                    Console.WriteLine();
                    sum += (i + 1);
                    count1++; 
                }
            }
            Console.WriteLine("====================");
            int count2 = 0;
            for (int i = 2; i < validInput; i++)
            {
                if (validInput % i == 0)
                {
                    count2++;
                    Console.WriteLine(i);
                }
            }
            //Console.WriteLine("--------------------");
            //int count3 = 0;
            //for (int i = 2; i < (validInput / 2); i++)
            //{
            //    if (validInput % i == 0)
            //    {
            //        count3++;
            //        Console.WriteLine(i);
            //        count3++;
            //        Console.WriteLine(validInput / i);
            //    }
            //}
            Console.WriteLine($"You have {count1} factors for {validInput} dammit!");
            if (sum == validInput)
            {
                Console.WriteLine($"{ validInput } is a perfect number");
            }
            else if(sum == 1)
            {
                Console.WriteLine($"{ validInput } is a prime number");
            }
            Console.Write("\nPress any key to exit");
            Console.ReadLine();
        }
    }
}
