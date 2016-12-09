using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarBlog.Models;

namespace BarBlog.Data.Interfaces
{
 public interface IPostRepository
    {
        List<Post> GetAllPosts();
        Post GetPostById(int id);
        void AddPost(Post post);
        void EditPost(Post post);
        void DeletePost(int id);
        List<Tag> AddTagToPost(string tags, int postId);


    }
}
