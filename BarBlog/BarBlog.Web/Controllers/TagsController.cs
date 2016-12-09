using BarBlog.BLL;
using BarBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BarBlog.Web.Controllers
{
    public class TagsController : ApiController
    {
        public IEnumerable<Tag> Get()
        {
            var repo = new PublicManager();
            return repo.GetTags();
        }
    }
}
