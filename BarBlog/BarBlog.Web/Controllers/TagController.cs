using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using BarBlog.BLL;
using BarBlog.Models;

namespace BarBlog.Web.Controllers
{
    public class TagController : Controller
    {
        // GET: Tags
        public ActionResult TagIndex()
        {
            var manager = new AdminManager();
            var tags = manager.GetAllTags();
            return View(tags);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult CreateTag()
        {
            return View(new Tag());
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult CreateTag(Tag newTag)
        {
            var manager = new AdminManager();
            manager.AddTag(newTag);
            return RedirectToAction("TagIndex","Tag");
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult EditTag(int id)
        {
            var manager = new AdminManager();
            var tag = manager.GetTagById(id);

            return View(tag);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult EditTag(Tag editedTag)
        {
            var manager = new AdminManager();
            manager.EditTag(editedTag);
            return RedirectToAction("TagIndex", "Tag");
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult DeleteTag(int id)
        {
            var manager = new AdminManager();
            var tag = manager.GetTagById(id);
            return View(tag);
            //  return RedirectToAction("TagIndex", "Tag");
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult DeleteTag(Tag tag)
        {
            var manager = new AdminManager();
            manager.DeleteTag(tag.TagID);
            return RedirectToAction("TagIndex", "Tag");
        }
    }
}