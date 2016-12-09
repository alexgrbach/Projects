using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarBlog.Models;
using Dapper;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using BarBlog.Data.Interfaces;
using BarBlog.Data.Repos.Mock;
using BarBlog.Models.Enums;

namespace BarBlog.Data.Repos.Database
{
    public class DBPostRepository : IPostRepository
    {
        private static string _connectionString =
           ConfigurationManager.ConnectionStrings["BarBlog"].ConnectionString;

        public void AddPost(Post post)
        {
            post.User = new User();
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("PostID", post.PostID);

                p.Add("UserID", post.User.UserID);
                p.Add("CategoryID", post.PostCategory.CategoryID);
                p.Add("PostTitle", post.PostTitle);
                p.Add("PostSubTitle", post.PostSubtitle);
                p.Add("PostBody", post.PostBody);
                p.Add("PostStatus", post.Status);
                p.Add("PostDate", post.PostDate.ToShortDateString());

                cn.Execute("AddBlogPost", p,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public List<Tag> AddTagToPost(string taglist, int postId)
        {
            var repo = new TagRepo();
            var tags = new List<Tag>();
           // string tagWords = "";
            if (taglist.Length >= 1)
            {
                var tagWords = taglist.Split(',');
                foreach (var name in tagWords)
                {
                    tags.Add(repo.DoesTagExist(name, postId));
                }
            }
            return tags;
        }

        public void DeletePost(int id)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("PostID", id);

                cn.Execute("RemoveBlogPost", p,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void EditPost(Post post)
        {
            post.User = new User();
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("PostID", post.PostID);
               p.Add("UserID", post.User.UserID);
                p.Add("CategoryID", post.PostCategory.CategoryID);
                p.Add("PostTitle", post.PostTitle);
                p.Add("PostSubTitle", post.PostSubtitle);
                p.Add("PostBody", post.PostBody);
                p.Add("PostStatus", post.Status);
                p.Add("PostDate", post.PostDate.ToShortDateString());

                cn.Execute("UpdateBlogPost", p,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public List<Post> GetAllPosts()
        {
            var tagRepo = new TagRepo();
            var catRepo = new CategoryRepo();
            List<Post> posts = new List<Post>();
          
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"SELECT * From Post p INNER JOIN Categories c ON p.CategoryID = c.CategoryID";
                cmd.Connection = cn;
                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                        posts.Add(PopulateFromDataReader(dr));
                }

                // Add objects to each post
                foreach (var post in posts)
                {
                    post.PostTags = tagRepo.GetTagsByPostId(post.PostID);
                    post.placeholderText = string.Join(",", post.PostTags);
                      post.PostCategory = catRepo.GetCategoryByID(post.PostCategory.CategoryID);
                }
            }

            return posts;
        }

        public Post GetPostById(int id)
        {
            
            var tagRepo = new TagRepo();
            var catRepo = new CategoryRepo();
            var post = new Post();
            
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"SELECT * From Post p INNER JOIN Categories c ON p.CategoryID = c.CategoryID WHERE p.PostID ="+id;
                cmd.Connection = cn;
                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                        post = (PopulateFromDataReader(dr));
                }
                
            }
            // Get Tags for post and populate string placeholder
            post.PostTags = tagRepo.GetTagsByPostId(post.PostID);
            string tags = "";
            foreach (var tag in post.PostTags)
            {
                tags += tag.TagName + ",";
            }
            if (tags.Length > 0)
            {
                post.placeholderText = tags.Substring(0, tags.Length - 1);
            }
            post.PostCategory = catRepo.GetCategoryByID(post.PostCategory.CategoryID);
            return post;
        }

        public Post PopulateFromDataReader(SqlDataReader dr)
        {
            string statusCheck;
            Post post  = new Post();
            post.PostCategory = new Category();
            post.PostID = (int) dr["PostID"];
            post.PostTitle = dr["PostTitle"].ToString();
            post.PostCategory.CategoryID = (int) dr["CategoryID"];
            post.PostBody = dr["PostBody"].ToString();
            post.PostDate = (DateTime) dr["PostDate"];
           // post.Status = Enum.Parse(typeof(ApprovalStatus), dr["PostStatus"]);
            statusCheck = dr["PostStatus"].ToString();
            post.Status = (ApprovalStatus)Enum.Parse(typeof(ApprovalStatus), statusCheck);
            return post;
        }

    }
}
