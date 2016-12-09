using SGFlooring.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Models;
using SGFlooring.Models.Responses;

namespace SGFlooring.Data.FileRepository
{
    public class FileStateRepository : IStateRepository
    {

        private readonly string _taxListFile = ConfigurationManager.AppSettings["TaxRepoLocation"].ToString();
        private static List<State> _states;


        /// <summary>
        /// Loads the file state repo into memory
        /// </summary>
        public FileStateRepository()
        {
            if (_states == null)
            {
                _states = new List<State>();

                if (File.Exists(_taxListFile))
                {
                    using (StreamReader sr = File.OpenText(_taxListFile))
                    {
                        sr.ReadLine();

                        string inputLine = "";
                        while ((inputLine = sr.ReadLine()) != null)
                        {
                            string[] inputParts = inputLine.Split(',');
                            State newState = new State()
                            {
                                StateAbbreviation = inputParts[0],
                                StateName = inputParts[1],                                
                                TaxRate = decimal.Parse(inputParts[2])
                            };
                            _states.Add(newState);
                        }
                    }
                    //pops the first element off the list because the first line is not needed
                    //_states.RemoveAt(0);
                }
                else
                {
                    new ErrorLoger("Tax list file not found");
                    throw new FileNotFoundException("Tax list file not found. Please check the repo");
                }
            }
        }

        /// <summary>
        /// Gets all states in list
        /// </summary>
        /// <returns>List of states</returns>
        public List<State> GetStates()
        {
            return _states;
        }
    }
}
