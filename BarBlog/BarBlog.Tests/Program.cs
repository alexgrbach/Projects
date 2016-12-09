using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarBlog.BLL;
using BarBlog.Models;
using NUnit.Framework;
using BarBlog.Models.Enums;

namespace BarBlog.Tests
{
    [TestFixture]
    class Program
    {
        
        [Test]
        public void CanAddPost()
        {
            var manager = new AdminManager();
            var postCount = manager.GetAllPosts().Count;

            var toAdd = new Post();
            toAdd.PostCategory = new Category();

            toAdd.PostID = postCount + 1;
            toAdd.PostTitle = "Test Title";
            toAdd.PostBody = "Post body";
            toAdd.PostCategory.CategoryID = 1;
            toAdd.Status = ApprovalStatus.Approved;
            toAdd.PostDate = DateTime.Now;
            toAdd.PostTags = new List<Tag>();
            toAdd.User = new User();

            manager.AddPost(toAdd);

            var manager2 = new AdminManager();
            var postCount2 = manager2.GetAllPosts().Count;

            Assert.AreEqual(postCount + 1, postCount2);
        }

        [Test]
        public void CancEditPost()
        {
            var manager = new AdminManager();
            var postToEdit = manager.GetPostByID(manager.GetAllPosts().Count);
            postToEdit.PostTitle = "EditedPostTitle";
            manager.EditPost(postToEdit);
            var editCheck = manager.GetPostByID(manager.GetAllPosts().Count);
            Assert.AreEqual(postToEdit.PostTitle,editCheck.PostTitle);

        }

        [Test]
        public void CanDeletePost()
        {
            var manager = new AdminManager();
            var postCount = manager.GetAllPosts().Count;
            var toDelete = manager.GetPostByID(postCount);

            manager.DeletePost(toDelete);
            Assert.AreEqual(postCount - 1, manager.GetAllPosts().Count);
        }

        [Test]
        public void CanGetPostById()
        {
            var manager = new AdminManager();
            var post = manager.GetPostByID(1);
            Assert.AreEqual(post.PostID,1);
        }

        [Test]
        public void CanGetStaticPagesById()
        {
            var manager = new AdminManager();
            var page = manager.GetPageByID(1);
            Assert.AreEqual(page.PageID, 1);
        }

        [Test]
        public void CanAddStaticPage()
        {
            var manager = new AdminManager();
            var pageCount = manager.GetAllPages().Count;
            var toAdd = new StaticPage();

            toAdd.PageID = pageCount + 1;
            toAdd.PageTitle = "Test title";
            toAdd.PageBody = "test static page";
            toAdd.PageDate = DateTime.Now;

            manager.AddPage(toAdd);

            var secondCount = manager.GetAllPages().Count;
            Assert.AreEqual(pageCount +1, secondCount);
        }

        [Test]
        public void CancEditStaticPage()
        {
            var manager = new AdminManager();
            var toEdit = manager.GetPageByID(manager.GetAllPages().Count);
            toEdit.PageTitle = "Edited Static Page Title";

            manager.EditPage(toEdit);
            var toCheck = manager.GetPageByID(manager.GetAllPages().Count);

            Assert.AreEqual(toEdit.PageTitle, toCheck.PageTitle);
        }

        [Test]
        public void CanDeleteStaticPage()
        {
            var manager = new AdminManager();
            var pageCount = manager.GetAllPages().Count;
            var page = manager.GetPageByID(pageCount);

            manager.DeletePage(page);
            var secondCount = manager.GetAllPages().Count;

            Assert.AreEqual(pageCount -1, secondCount);

        }

        [Test]
        public void CanGetCategoryById()
        {
            var manager = new AdminManager();
            var category = manager.GetCategoryByID(1);
            Assert.AreEqual(category.CategoryID, 1);
        }

        [Test]
        public void CanAddCategory()
        {
            var manager = new AdminManager();
            var toAdd = new Category();
            var count = manager.GetAllCategories().Count;

            toAdd.CategoryID = count + 1;
            toAdd.CategoryName = "TestCategory";

            manager.AddCategory(toAdd);

            var secondCount = manager.GetAllCategories().Count;
            Assert.AreEqual(count + 1, secondCount);
        }

        [Test]
        public void CancEditCategory()
        {
            var manager = new AdminManager();
            var toEdit = manager.GetCategoryByID(manager.GetAllCategories().Count);

            toEdit.CategoryName = "EditedCategory";
            manager.EditCategory(toEdit);

            var toCheck = manager.GetCategoryByID(manager.GetAllCategories().Count);
            Assert.AreEqual(toCheck.CategoryName,toEdit.CategoryName);

        }
        [Test]
        public void CanDeleteCategory()
        {
            var manager = new AdminManager();
            var count = manager.GetAllCategories().Count;

            manager.DeleteCategory(count);

            var secondCount = manager.GetAllCategories().Count;
            Assert.AreEqual(count - 1, secondCount);
        }

        [Test]
        public void CanGetTagById()
        {
            var manager = new AdminManager();
            var tag = manager.GetTagById(1);
            Assert.AreEqual(tag.TagID, 1);
        }

        [Test]
        public void CanAddTag()
        {
            var manager =  new AdminManager();
            var toAdd = new Tag();
            var tagCount = manager.GetAllTags().Count;

            toAdd.TagID = tagCount + 1;
            toAdd.TagName = "TestTag";

            manager.AddTag(toAdd);

            var secondCount = manager.GetAllTags().Count;
            Assert.AreEqual(tagCount + 1, secondCount);
        }

        [Test]
        public void CancEditTag()
        {
            var manager = new AdminManager();
            var toEdit = manager.GetTagById(manager.GetAllTags().Count);
            toEdit.TagName = "EditedTag";

            manager.EditTag(toEdit);
            var toCheck = manager.GetTagById(manager.GetAllTags().Count);

            Assert.AreEqual(toCheck.TagName,toEdit.TagName);
        }

        [Test]
        public void CanDeleteTag()
        {
            var manager = new AdminManager();
            var count = manager.GetAllTags().Count;

            manager.DeleteTag(count);

            var secondCount = manager.GetAllTags().Count;
            Assert.AreEqual(count -1 ,secondCount);
        }

        static void Main(string[] args)
        {
            
        }
    }
}
