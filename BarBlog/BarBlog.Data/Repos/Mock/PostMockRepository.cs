using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarBlog.Models;
using BarBlog.Data.Interfaces;
using BarBlog.Models.Enums;

namespace BarBlog.Data.Repos.Mock
{
    class PostMockRepository : IPostRepository
    {
        private static List<Post> _posts;


        public PostMockRepository()
        {
            if (_posts == null)
            {
                _posts = new List<Post>()
                {
                    new Post()
                    {
                        PostID = 1,
                        PostTitle = "Why I am terrible",
                        User = new User
                        {
                            UserName = "Douglas Wachtel",
                            UserID = 1
                        },
                        Status = ApprovalStatus.Approved,
                        PostBody = "Lazy.",
                        PostDate = DateTime.Now,
                        PostCategory = new Category
                        {
                            CategoryID = 1,
                            CategoryName = "Test"
                        },
                        PostTags = new List<Tag>()
                        {
                            new Tag()
                            {
                                TagID = 1,
                                TagName = "#WTF"
                            },
                            new Tag()
                            {
                                TagID = 2,
                                TagName = "#Beer"
                            }
                        }
                    },

                    new Post()
                    {
                        PostID = 2,
                        PostTitle = "Test",
                        User = new User
                        {
                            UserName = "Butch Tuttus",
                            UserID = 2
                        },
                        Status = ApprovalStatus.Approved,
                        PostBody = "Blbblbllblblb.",
                        PostDate = DateTime.Now,
                        PostCategory = new Category
                        {
                            CategoryID = 1,
                            CategoryName = "Test"
                        },
                        PostTags = new List<Tag>()
                        {
                            new Tag()
                            {
                                TagID = 1,
                                TagName = "#WTF"
                            },
                            new Tag()
                            {
                                TagID = 2,
                                TagName = "#Beer"
                            }
                        }
                    }
                };
            }

        }


        public List<Post> GetAllPosts()
        {
            return _posts;
        }

        public Post GetPostById(int id)
        {
            return _posts.First(p => p.PostID == id);
        }

        public void AddPost(Post post)
        {
            _posts.Add(post);
        }

        public void EditPost(Post post)
        {
            var selectedPost = _posts.FirstOrDefault(p => p.PostID == post.PostID);
            selectedPost.PostID = post.PostID;
            selectedPost.User = post.User;
            selectedPost.PostTitle = post.PostTitle;
            selectedPost.PostBody = post.PostBody;
            selectedPost.PostCategory = post.PostCategory;
            selectedPost.Status = post.Status;
            //selectedPost.PostTags = post.PostTags;
            selectedPost.PostDate = DateTime.Now;
            selectedPost.placeholderText = post.placeholderText;


        }

        public void DeletePost(int id)
        {
            _posts.RemoveAll(p => p.PostID == id);
        }

        public void ApprovePost(Post post)
        {
            post.Status = ApprovalStatus.Approved;
        }

        public void DenyPost(Post post)
        {
            post.Status = ApprovalStatus.Denied;
        }

        public List<Tag> AddTagToPost(string taglist, int postId)
        {
            var repo = new TagMockRepository();
            var tags = new List<Tag>();
            var tagWords = taglist.Split(',');

            foreach (var name in tagWords)
            {
                tags.Add(repo.DoesTagExist(name, postId));

            }
            return tags;

        }
    }
}
