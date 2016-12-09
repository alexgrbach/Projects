using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata.test
{
    [TestFixture]
    class StringCalculatorTests
    {
        [Test]
        public void Add_EmptyString_Zero()
        {
            StringCalculator calc = new StringCalculator();
            Assert.AreEqual(0, calc.Add(""));
        }
        [Test]
        public void Add_SingleNumber_ReturnNumber()
        {
            StringCalculator calc = new StringCalculator();
            int sum = calc.Add("1");
            Assert.AreEqual(1, sum);
        }
        [Test]
        public void Add_TwoNumbers_ReturnSums()
        {
            StringCalculator calc = new StringCalculator();
            int sum = calc.Add("1,2");
            Assert.AreEqual(3, sum);
        }
        [TestCase("3" , 3)]
        [TestCase("1,2,3", 6)]
        [TestCase("1,2,3,4,5,6", 21)]
        [TestCase("1001,2",2)]
        [TestCase("1000,2",1002)]
        [TestCase("//[***]\n1***2***3", 6)]
        [TestCase("//[*][%]\n1*2%3", 6)]
        [TestCase("//[****][%]\n1****2%3", 6)]
        public void Add_Unknown_ReturnSum(string numbers, int expected)
        {
            StringCalculator calc = new StringCalculator();
            int sum = calc.Add(numbers);
            Assert.AreEqual(expected, sum);
        }
        [TestCase("//;\n1;2", 3)]
        public void add_Delimiter(string numbers, int expected)
        {
            StringCalculator calc = new StringCalculator();
            int sum = calc.Add(numbers);
            Assert.AreEqual(expected, sum);
        }
        [TestCase( "-1,2", -99)]
        [TestCase("2,-4,3,-5", -99)]
        public void add_negitiveNumber(string numbers, int expected)
        {
            StringCalculator calc = new StringCalculator();
            int sum = calc.Add(numbers);
            Assert.AreEqual(expected, sum);
        }
    }
}

