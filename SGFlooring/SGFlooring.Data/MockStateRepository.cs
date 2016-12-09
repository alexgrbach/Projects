using SGFlooring.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Models;
using SGFlooring.Models.Responses;

namespace SGFlooring.Data.MockRepositorys
{
    public class MockStateRepository : IStateRepository
    {
        private static List<State> _states;

        public MockStateRepository()
        {
            if (_states == null)
            {
                _states = new List<State>()
                {
                    new State()
                    {
                        StateName = "Ohio",
                        StateAbbreviation = "OH",
                        TaxRate = 6.75m
                        
                    },
                    new State()
                    {
                        StateName = "North Dakota",
                        StateAbbreviation = "ND",
                        TaxRate = 2m

                    },
                    new State()
                    {
                        StateName = "New York",
                        StateAbbreviation = "NY",
                        TaxRate = 8m
                    }
                };
            }

        }

        public List<State> GetStates()
        {
            return _states;
        }
    }
}
