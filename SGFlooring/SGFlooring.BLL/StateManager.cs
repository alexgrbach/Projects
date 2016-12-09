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
    public class StateManager
    {

        public StateResponse GetStateResponse(string stateAbbreviation)
        {
            var response = new StateResponse();
            var states = GetAllStates();

            foreach (var state in states)
            {
                if (state.StateAbbreviation != stateAbbreviation) continue;

                response.Success = true;
                response.State = state;
                return response;
            }

            response.Success = false;
            response.Message = "You did something wrong again...";
            return response;
        }

        public List<State> GetAllStates()
        {
            var repo = RepositoryFactory.CreateStateRepository();
            return repo.GetStates();
        }
    }
}
