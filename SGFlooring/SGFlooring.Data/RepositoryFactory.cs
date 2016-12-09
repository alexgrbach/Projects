using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Data.FileRepository;
using SGFlooring.Data.Interfaces;
using SGFlooring.Data.MockRepositorys;

namespace SGFlooring.Data
{
    public static class RepositoryFactory
    {

        public static IOrderRepository CreateOrderRepository(string filename)
        {
            IOrderRepository repo;

            string mode = ConfigurationManager.AppSettings["mode"].ToString();

            switch (mode.ToUpper())
            {
                case "TEST":
                    repo = new MockOrderReposiotry();
                    break;
                case "PROD":
                    repo = new FileOrderRepository(filename);
                    break;
                default:
                    new ErrorLoger("You chose the wrong mode go into app.config and change the mode to either TEST or PROD");
                    throw new Exception("Wrong Mode Dumbass");
            }
            return repo;
        }

        public static IProductRepository CreateProductRepository()
        {
            IProductRepository repo;

            string mode = ConfigurationManager.AppSettings["mode"].ToString();

            switch (mode.ToUpper())
            {
                case "TEST":
                    repo = new MockProductRepository();
                    break;
                case "PROD":
                    repo = new FileProductRepository();
                    break;
                default:
                    new ErrorLoger("Go into app.config and set mode either to PROD or TEST");
                    throw new Exception("You did something wrong");
            }
            return repo;
        }

        public static IStateRepository CreateStateRepository()
        {
            IStateRepository repo;

            string mode = ConfigurationManager.AppSettings["mode"].ToString();

            switch (mode.ToUpper())
            {
                case "TEST":
                    repo = new MockStateRepository();
                    break;
                case "PROD":
                    repo = new FileStateRepository();
                    break;
                default:
                    new ErrorLoger("Go into app.config and set mode either to PROD or TEST");
                    throw new Exception("You did something wrong");
            }
            return repo;
        }

        public static IDirectoryInformation CreateDirectoryInformation()
        {
            IDirectoryInformation info;

            string mode = ConfigurationManager.AppSettings["mode"].ToString();

            switch (mode.ToUpper())
            {

                case "TEST":
                    info = new MockDirectoryInformation();
                    break;
                case "PROD":
                    info = new FileDirectoryInformation();
                    break;
                default:
                    new ErrorLoger("Go into app.config and set mode either to PROD or TEST");
                    throw new Exception("You did something wrong");
            }
            return info;
        }

    }
}
