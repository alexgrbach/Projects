using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BarBlog.BLL;
using BarBlog.Models;
using BarBlog.Models.Enums;

namespace BarBlog.Web.Controllers
{
    public class SubordinateController : Controller
    {
        // GET: Subordinate
        [Authorize(Roles="Admin, Manager")]
        public ActionResult SubordinateIndex()
        {
            var manager = new AdminManager();
            var _posts = manager.GetAllPosts();
            return View(_posts);
        }
        [Authorize(Roles = "Admin, Manager")]
        [HttpGet]
        public ActionResult CreatePost()
        {
            return View(new Post());
        }
        [Authorize(Roles = "Admin, Manager")]
        [HttpPost]
        public ActionResult CreatePost(Post post)
        {
            var manager = new AdminManager();
            var postCount = manager.GetAllPosts().Count;
            post.PostCategory.CategoryName = manager.GetCategoryByID(post.PostCategory.CategoryID).CategoryName;
            
            post.PostDate = DateTime.Now;
            post.Status = ApprovalStatus.Pending;
            if (postCount == 0)
            {
                post.PostID = 1;
            }
            else
                post.PostID = manager.GetAllPosts().Count + 1;
            manager.AddPost(post);
            return RedirectToAction("SubordinateIndex", "Subordinate");
        }
    }
}