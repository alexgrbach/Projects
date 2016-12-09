using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BarBlog.BLL;
using BarBlog.Models;

namespace BarBlog.Web.Controllers
{
    public class StaticPageController : Controller
    {
        // GET: StaticPage
        public ActionResult PageIndex()
        {
            var manager = new AdminManager();
            var pages = manager.GetAllPages();
            return View(pages);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult CreatePage()
        {
            return View(new StaticPage());
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult CreatePage(StaticPage page)
        {
            var manager = new AdminManager();
            var pageCount = manager.GetAllPages().Count;
            manager.AddPage(page);
            page.PageDate = DateTime.Now;
            if (pageCount == 0)
            {
                page.PageID = 1;
            }
            else
                page.PageID = manager.GetAllPages().Count + 1;
            return RedirectToAction("Index", "Home");
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult EditPage(int id)
        {
            var manager = new AdminManager();
            var page = manager.GetPageByID(id);

            return View(page);

        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult EditPage(StaticPage page)
        {
            //if (ModelState.IsValid)
            {
                var manager = new AdminManager();
                manager.EditPage(page);

            }
            return RedirectToAction("Index", "Home");
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult DeletePage(int id)
        {
            var manager = new AdminManager();
            var page = manager.GetPageByID(id);

            return View(page);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult DeletePage(StaticPage page)
        {
            //if (ModelState.IsValid)
            {
                var manager = new AdminManager();
                manager.DeletePage(page);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult View(int id)
        {
            var manager = new AdminManager();
            var page = manager.GetPageByID(id);
            return View(page);
        }

    }
}