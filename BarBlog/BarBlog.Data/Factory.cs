using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using BarBlog.Data.Interfaces;
using BarBlog.Data.Repos.Database;
using BarBlog.Data.Repos.Mock;

namespace BarBlog.Data
{
    public class Factory
    {
        private string _mode;

        public Factory()
        {
            _mode = WebConfigurationManager.AppSettings["Mode"].ToUpper();
        }

        public IPostRepository PostRepository()
        {
            switch (_mode)
            {
                case "MOCK":
                    return new PostMockRepository();
                case "DB":
                    return new DBPostRepository();
                default:
                    throw new NotSupportedException();
            }
        }

        public IPageRepository PageRepository()
        {
            switch (_mode)
            {
                case "MOCK":
                    return new PageMockRepository();
                case "DB":
                    return new StaticPageRepo();
                default:
                    throw new NotSupportedException();
            }
        }

        public ICategoryRepository CategoryRepository()
        {
            switch (_mode)
            {
                case "MOCK":
                    return new CategoryMockRepository();
                case "DB":
                    return new CategoryRepo();
                // return new DBPostRepository();
                default:
                    throw new NotSupportedException();
            }
        }
        public ITagRepository TagRepository()
        {
            switch (_mode)
            {
                case "MOCK":
                    return new TagMockRepository();
                case "DB":
                     return new TagRepo();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
