using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BarBlog.BLL;
using BarBlog.Models;

namespace BarBlog.Web.Controllers
{
    public class CategorySelectorController : ApiController
    {
        public IEnumerable<Category> Get()
        {
            var repo = new AdminManager();
            return repo.GetAllCategories();
        }

        public Category Get(int id)
        {
            var repo = new AdminManager();
            return repo.GetCategoryByID(id);
        }

    }
}
