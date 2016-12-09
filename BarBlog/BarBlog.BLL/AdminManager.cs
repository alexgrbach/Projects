using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarBlog.Data;
using BarBlog.Data.Interfaces;
using BarBlog.Models;
using BarBlog.Models.Enums;

namespace BarBlog.BLL
{
    public class AdminManager
    {
        private static IPostRepository _postRepo;
        private static IPageRepository _pageRepo;
        private static ICategoryRepository _categoryRepo;
        private static ITagRepository _tagRepo;

        public AdminManager()
        {
            _postRepo = new Factory().PostRepository();
            _pageRepo = new Factory().PageRepository();
            _categoryRepo = new Factory().CategoryRepository();
            _tagRepo = new Factory().TagRepository();
        }

        public void AddPost(Post post)
        {
            var taglist = new List<Tag>();
            var posttags = post.placeholderText;
            if (GetAllPosts().Count != 0)
            {
                post.PostID = GetAllPosts().LastOrDefault().PostID + 1;
            }
            else
            {
                post.PostID = 1;
            }
            if (post.placeholderText != null)
            {
                taglist = _postRepo.AddTagToPost(posttags, post.PostID);
                post.PostTags = taglist;
            }
            
            post.PostDate = DateTime.Now;

            _postRepo.AddPost(post);
        }

        public List<Post> GetAllPosts()
        {

            return _postRepo.GetAllPosts();
        }

        public Post GetPostByID(int id)
        {
             return _postRepo.GetPostById(id);
        }

        public void EditPost(Post post)
        {
            var taglist = new List<Tag>();
            var posttags = post.placeholderText;
            _tagRepo.DeletePostTagsById(post.PostID);

            if (posttags != null)
            {
                taglist = _postRepo.AddTagToPost(posttags, post.PostID);
            }
            _postRepo.EditPost(post);
        }

        public void DeletePost(Post post)
        {
            _postRepo.DeletePost(post.PostID);
            _tagRepo.DeletePostTagsById(post.PostID);
        }

        public void ApprovePost(Post post)
        {
            post.Status = ApprovalStatus.Approved;
        }

        public void DenyPost(Post post)
        {
            post.Status = ApprovalStatus.Denied;
        }

        public List<StaticPage> GetAllPages()
        {
            return _pageRepo.GetAllPages();
        }

        public StaticPage GetPageByID(int id)
        {
            return GetAllPages().FirstOrDefault(p => p.PageID == id);

        }

        public void AddPage(StaticPage page)
        {
            if (GetAllPages().Count != 0)
            {
                page.PageID = GetAllPages().LastOrDefault().PageID + 1;
            }
            else
            {
                page.PageID = 1;
            }
            page.PageDate = DateTime.Now;

            _pageRepo.AddPage(page);
        }


        public void EditPage(StaticPage page)
        {
            page.PageDate = DateTime.Now;
            _pageRepo.EditPage(page);
        }

        public void DeletePage(StaticPage page)
        {
            _pageRepo.DeletePage(page.PageID);
            _tagRepo.DeletePostTagsById(page.PageID);
        }

        public List<Category> GetAllCategories()
        {
            return _categoryRepo.GetAllCategories();
        }

        public Category GetCategoryByID(int id)
        {
            return GetAllCategories().FirstOrDefault(c => c.CategoryID == id);
        }

        public void AddCategory(Category category)
        {
            if (GetAllCategories().Count != 0)
            {
                category.CategoryID = GetAllCategories().LastOrDefault().CategoryID + 1;
            }
            else
            {
                category.CategoryID = 1;
            }


            _categoryRepo.AddCategory(category);
        }

        public void EditCategory(Category category)
        {
            _categoryRepo.EditCategory(category);
        }

        public void DeleteCategory(int id)
        {
            _categoryRepo.DeleteCategory(id);
        }

        public List<Tag> GetAllTags()
        {
            return _tagRepo.Getall();
        }

        public Tag GetTagById(int id)
        {
            return GetAllTags().FirstOrDefault(t => t.TagID == id);
        }

        public void AddTag(Tag newTag)
        {
            if (GetAllTags().Count != 0)
            {
                newTag.TagID = GetAllTags().LastOrDefault().TagID + 1;
            }
            else
            {
                newTag.TagID = 1;
            }

            _tagRepo.add(newTag);
        }

        public void EditTag(Tag tag)
        {
            _tagRepo.Update(tag);
        }

        public void DeleteTag(int id)
        {   
            _tagRepo.Delete(id);
            _tagRepo.DeletePostTagsByTagId(id);
        }

        public void DeleteTagsByPostId(int postId)
        {
            _tagRepo.DeletePostTagsById(postId);
        }
    }
}


