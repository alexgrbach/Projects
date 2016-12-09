using SGFlooring.Models;
using SGFlooring.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGFlooring.Data.Interfaces
{
    public interface IStateRepository
    {
        /// <summary>
        /// Loads list of states
        /// </summary>
        /// <returns>List of states</returns>
        List<State> GetStates();
    }
}
