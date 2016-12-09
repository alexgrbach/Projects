using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGFlooring.BLL;

namespace SGFlooring.Tests
{
    [TestFixture]
    public class StateManagerTests
    {
        private readonly StateManager _stateManager = new StateManager();

        [TestCase("OH", true)]
        [TestCase("NZ", false)]
        [TestCase("OH",false)]
        public void GetStateResponseTest(string stateAbbreviation, bool expected)
        {
            var responce = _stateManager.GetStateResponse(stateAbbreviation);
            Assert.AreEqual(expected,responce.Success);
        }
    }
}
