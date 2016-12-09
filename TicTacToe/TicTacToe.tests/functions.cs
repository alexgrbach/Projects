using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TicTacToe.tests
{
    [TestFixture]
    class functionsTest
    {
        [Test]
        public void checkWinner_TestNumbers()
        {
            char[,] input = { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
            functions test = new functions();
            Assert.AreEqual(false, test.checkWinner(input));
        }
        [Test]
        public void checkWinner_Test_X_i1()
        {
            char[,] input = { { 'X', 'X', 'X' }, { '4', '5', '6' }, { '7', '8', '9' } };
            functions test = new functions();
            Assert.AreEqual(true, test.checkWinner(input));
        }

        [Test]
        public void checkWinner_Test_X_i2()
        {
            char[,] input = { { '1', '2', '3' }, { 'X', 'X', 'X' }, { '7', '8', '9' } };
            functions test = new functions();
            Assert.AreEqual(true, test.checkWinner(input));
        }
        [Test]
        public void checkWinner_Test_X_i3()
        {
            char[,] input = { { '1', '2', '3' }, { '4', '5', '6' }, { 'X', 'X', 'X' } };
            functions test = new functions();
            Assert.AreEqual(true, test.checkWinner(input));
        }
        [Test]
        public void checkWinner_Test_X_j1()
        {
            char[,] input = { { 'X', '2', '3' }, { 'X', '5', '6' }, { 'X', '8', '9' } };
            functions test = new functions();
            Assert.AreEqual(true, test.checkWinner(input));
        }
        [Test]
        public void checkWinner_Test_X_j2()
        {
            char[,] input = { { '1', 'X', '3' }, { '4', 'X', '6' }, { '7', 'X', '9' } };
            functions test = new functions();
            Assert.AreEqual(true, test.checkWinner(input));
        }
        [Test]
        public void checkWinner_Test_X_j3()
        {
            char[,] input = { { '1', '2', 'X' }, { '4', '5', 'X' }, { '7', '8', 'X' } };
            functions test = new functions();
            Assert.AreEqual(true, test.checkWinner(input));
        }
        [Test]
        public void checkWinner_Test_O_i1()
        {
            char[,] input = { { 'O', 'O', 'O' }, { '4', '5', '6' }, { '7', '8', '9' } };
            functions test = new functions();
            Assert.AreEqual(true, test.checkWinner(input));
        }
        [Test]
        public void checkWinner_Test_O_i2()
        {
            char[,] input = { { '1', '2', '3' }, { 'O', 'O', 'O' }, { '7', '8', '9' } };
            functions test = new functions();
            Assert.AreEqual(true, test.checkWinner(input));
        }
        [Test]
        public void checkWinner_Test_O_i3()
        {
            char[,] input = { { '1', '2', '3' }, { '4', '5', '6' }, { 'O', 'O', 'O' } };
            functions test = new functions();
            Assert.AreEqual(true, test.checkWinner(input));
        }
        [Test]
        public void checkWinner_Test_O_j1()
        {
            char[,] input = { { 'O', '2', '3' }, { 'O', '5', '6' }, { 'O', '8', '9' } };
            functions test = new functions();
            Assert.AreEqual(true, test.checkWinner(input));
        }
        [Test]
        public void checkWinner_Test_O_j2()
        {
            char[,] input = { { '1', 'O', '3' }, { '4', 'O', '6' }, { '7', 'O', '9' } };
            functions test = new functions();
            Assert.AreEqual(true, test.checkWinner(input));
        }
        [Test]
        public void checkWinner_Test_O_j3()
        {
            char[,] input = { { '1', '2', 'O' }, { '4', '5', 'O' }, { '7', '8', 'O' } };
            functions test = new functions();
            Assert.AreEqual(true, test.checkWinner(input));
        }
        [Test]
        public void checkWinner_Test_Diag_X_1()
        {
            char[,] input = { { 'X', '2', '3' }, { '4', 'X', '6' }, { '7', '8', 'X' } };
            functions test = new functions();
            Assert.AreEqual(true, test.checkWinner(input));
        }
        [Test]
        public void checkWinner_Test_Diag_X_2()
        {
            char[,] input = { { '1', '2', 'X' }, { '4', 'X', '6' }, { 'X', '8', '9' } };
            functions test = new functions();
            Assert.AreEqual(true, test.checkWinner(input));
        }
        [Test]
        public void checkWinner_Test_Diag_O_1()
        {
            char[,] input = { { 'O', '2', '3' }, { '4', 'O', '6' }, { '7', '8', 'O' } };
            functions test = new functions();
            Assert.AreEqual(true, test.checkWinner(input));
        }
        [Test]
        public void checkWinner_Test_Diag_O_2()
        {
            char[,] input = { { '1', '2', 'O' }, { '4', 'O', '6' }, { 'O', '8', '9' } };
            functions test = new functions();
            Assert.AreEqual(true, test.checkWinner(input));
        }
        [TestCase(true, 1)]
        [TestCase(true, 9)]
        [TestCase(true, 4)]
        [TestCase(true, 8)]
        [TestCase(false, 0)]
        [TestCase(false, 10)]
        [TestCase(false, -31)]
        [TestCase(false, 999)]
        public void checkBoard_test(bool expected, int input)
        {
            char[,] arr = { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
            functions test = new functions();
            Assert.AreEqual(expected, test.checkBoard(input, arr));
        }
        [TestCase(false, 1)]
        [TestCase(false, 2)]
        [TestCase(false, 3)]
        [TestCase(false, 4)]
        [TestCase(false, 5)]
        [TestCase(false, 6)]
        [TestCase(false, 7)]
        [TestCase(false, 8)]
        [TestCase(false, 9)]
        public void checkBoard_test_X_Picked(bool expected, int input)
        {
            char[,] arr = { { 'X', 'X', 'X' }, { 'X', 'X', 'X' }, { 'X', 'X', 'X' } };
            functions test = new functions();
            Assert.AreEqual(expected, test.checkBoard(input, arr));
        }
        [TestCase(false, 1)]
        [TestCase(false, 2)]
        [TestCase(false, 3)]
        [TestCase(false, 4)]
        [TestCase(false, 5)]
        [TestCase(false, 6)]
        [TestCase(false, 7)]
        [TestCase(false, 8)]
        [TestCase(false, 9)]
        public void checkBoard_test_O_Picked(bool expected, int input)
        {
            char[,] arr = { { 'O', 'O', 'O' }, { 'O', 'O', 'O' }, { 'O', 'O', 'O' } };
            functions test = new functions();
            Assert.AreEqual(expected, test.checkBoard(input, arr));
        }
    }

}

