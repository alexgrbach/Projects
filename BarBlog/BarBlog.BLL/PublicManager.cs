using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarBlog.Data;
using BarBlog.Models;
using BarBlog.Data.Interfaces;

namespace BarBlog.BLL
{
    public class PublicManager
    {
        private static IPostRepository _postRepo;
        private static ITagRepository _tagRepo;

        public PublicManager()
        {
            var factory = new Factory();
            _postRepo = factory.PostRepository();
            _tagRepo = factory.TagRepository();
        }

        public List<Post> GetAllPosts()
        {

            return _postRepo.GetAllPosts();
        }

        public Post GetPostByID(int id)
        {
            return _postRepo.GetPostById(id);
          
        }

        public List<Tag> GetTags()
        {
            return _tagRepo.Getall();
        }

    }
}
