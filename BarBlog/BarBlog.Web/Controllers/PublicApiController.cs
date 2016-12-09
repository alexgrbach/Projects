using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BarBlog.BLL;
using BarBlog.Models;
using BarBlog.Models.Enums;

namespace BarBlog.Web.Controllers
{
    public class PublicApiController : ApiController
    {
        public IEnumerable<Post> Get()
        {
            var repo = new PublicManager();
            var results = repo.GetAllPosts();
            return results.Where(p => p.Status == ApprovalStatus.Approved).ToList();
        }
        public Post Get(int id)
        {
            var repo = new PublicManager();
            return repo.GetPostByID(id);
        }
    }
}
