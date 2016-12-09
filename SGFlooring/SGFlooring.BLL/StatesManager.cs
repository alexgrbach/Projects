using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Data;
using SGFlooring.Models;
using SGFlooring.Models.Responses;

namespace SGFlooring.BLL
{
    public class StatesManager
    {

        private static Dictionary<string, States> GetStateDictionary()
        {          
            var repo = RepositoryFactory.CreateStateRepository();
            var states = repo.CreateStateDictionary();
            return states;
        }

        public Dictionary<string, States> DisplayStateDictionary()
        {
            return GetStateDictionary();
        }
        
        public StateResponse GetStateResponse(string stateKey)
        {
            var response = new StateResponse();
            var states = GetStateDictionary();
            States state;


            if (states.TryGetValue(stateKey.ToUpper(), out state))
            {              
                response.Success = true;
                response.State = state;
            }
            else
            {
                response.Success = false;
                response.Message = "State does not exist in dictionary";
            }
            return response;
        }
    }
}
