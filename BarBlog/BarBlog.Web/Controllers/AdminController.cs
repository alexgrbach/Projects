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
    public class AdminController : Controller
    {
        // GET: Admin
        [Authorize(Roles="Admin")]
        public ActionResult Index()
        {
            var manager = new AdminManager();
            var _posts = manager.GetAllPosts();          
            return View(_posts);          
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult CreatePost()
        {
            return View(new Post());
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult CreatePost(Post post)
        {
           
                var manager = new AdminManager();
                var postCount = manager.GetAllPosts().Count;
            post.PostCategory.CategoryName = manager.GetCategoryByID(post.PostCategory.CategoryID).CategoryName;
            post.Status = ApprovalStatus.Approved;

                manager.AddPost(post);

                post.PostDate = DateTime.Now;
                if (postCount == 0)
                {
                    post.PostID = 1;
                }
                else
                    post.PostID = manager.GetAllPosts().Count + 1;
                
            
            return RedirectToAction("Index", "Home");
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult EditPost(int id)
        {
            var manager = new AdminManager();
            var post = manager.GetPostByID(id);

            return View(post);

        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult EditPost(Post post)
        {
//if (ModelState.IsValid)
            {
                var manager = new AdminManager();
                post.PostDate = DateTime.Now;
                post.PostCategory.CategoryName = manager.GetCategoryByID(post.PostCategory.CategoryID).CategoryName;
                manager.EditPost(post);
                
            }
            return RedirectToAction("Index", "Home");
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult DeletePost(int id)
        {
            var manager = new AdminManager();
            var post = manager.GetPostByID(id);

            return View(post);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult DeletePost(Post post)
        {
            //if (ModelState.IsValid)
            {
                var manager = new AdminManager();
                manager.DeletePost(post);
            }
            return RedirectToAction("Index", "Home");
        }

        

    }
}