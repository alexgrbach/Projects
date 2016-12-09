using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BarBlog.BLL;
using BarBlog.Models;

namespace BarBlog.Web.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        [Authorize(Roles = "Admin")]
        public ActionResult CategoryIndex()
        {
            var manager = new AdminManager();
            var _categories = manager.GetAllCategories();

            return View(_categories);
            
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View(new Category());
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            var manager = new AdminManager();
            var categoryCount = manager.GetAllCategories().Count;
            if (categoryCount == 0)
            {
                category.CategoryID = 1;
            }
            else
                category.CategoryID = manager.GetAllCategories().Count + 1;
            manager.AddCategory(category);
            return RedirectToAction("CategoryIndex", "Category");
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var manager = new AdminManager();
            var category = manager.GetCategoryByID(id);

            return View(category);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            var manager = new AdminManager();
            manager.EditCategory(category);

            return RedirectToAction("CategoryIndex", "Category");
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult DeleteCategory(int id)
        {
            var manager = new AdminManager();
            var category = manager.GetCategoryByID(id);

            return View(category);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult DeleteCategory(Category category)
        {
            var manager = new AdminManager();
            manager.DeleteCategory(category.CategoryID);

            return RedirectToAction("CategoryIndex", "Category");
        }


    }
}