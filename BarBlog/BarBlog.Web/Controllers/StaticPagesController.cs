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
    public class StaticPagesController : ApiController
    {
        public IEnumerable<StaticPage> Get()
        {
            var repo = new AdminManager();
            return repo.GetAllPages();
        }
    }
}
