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
    public class BlogPostsController : ApiController
    {
        public IEnumerable<Post> Get()
        {
            var repo = new PublicManager();
            return repo.GetAllPosts();
        }
        public Post Get(int id)
        {
            var repo = new PublicManager();
            return repo.GetPostByID(id);          
        }
    }
}
