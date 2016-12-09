using BarBlog.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarBlog.Models;
using Dapper;

namespace BarBlog.Data.Repos.Database
{
    public class TagRepo : ITagRepository
    {
        private static string _connectionString =
         ConfigurationManager.ConnectionStrings["BarBlog"].ConnectionString;

        public void add(Tag tag)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                var c = new DynamicParameters();

                c.Add("TagID", tag.TagID);
                c.Add("TagName", tag.TagName);

                cn.Execute("AddTag", c,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                var c = new DynamicParameters();
                c.Add("TagID", id);

                cn.Execute("RemoveTag", c,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public Tag Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Tag> Getall()
        {
            List<Tag> tags = new List<Tag>();
            using (var cn = new SqlConnection(_connectionString))
            {
                tags = cn.Query<Tag>("GetAllTags",
                    commandType: CommandType.StoredProcedure).ToList();
            }
            return tags;
        }

        public void Update(Tag tag)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                var c = new DynamicParameters();
                c.Add("TagID", tag.TagID);
                c.Add("TagName", tag.TagName);

                cn.Execute("UpdateTag", c,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public List<Tag> GetTagsByPostId(int id)
        {
            List<Tag> tags = new List<Tag>();
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                var c = new DynamicParameters();
                c.Add("PostID", id);

                tags = cn.Query<Tag>("GetTagsByPostID", c,
                    commandType: CommandType.StoredProcedure).ToList();
            }

            return tags;
        }

        public Tag DoesTagExist(string tagname, int postId)
        {

            var tagtoreturn = new Tag();
            var newtag = new Tag();
            var allTags = Getall();
            var tagCheck = new Tag();

            // Check if tag exists 
            for (int i = 0; i < allTags.Count; i++)
            {
                if (allTags[i].TagName == tagname)
                {
                    tagtoreturn = allTags[i];
                }

            }
            // if tag does not already exist, create it
            if (tagtoreturn.TagName == null)
            {
                newtag.TagName = tagname;
                if (allTags.Count == 0)
                {
                    newtag.TagID = 1;
                }
                else
                {
                    newtag.TagID = allTags.Max(t => t.TagID) + 1;
                }
                add(newtag);

                tagtoreturn = newtag;
            }

            // Add post tags 
            AddPostTag(tagtoreturn.TagID, postId);

            return tagtoreturn;
        }

        public void AddPostTag(int tagID, int postID)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                var c = new DynamicParameters();

                c.Add("TagID", tagID);
                c.Add("PostID", postID);

                cn.Execute("AddPostTag", c,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void DeletePostTagsById(int postId)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                var c = new DynamicParameters();
                c.Add("PostID", postId);

                cn.Execute("RemovePostTags", c,
                    commandType: CommandType.StoredProcedure);
            }

        }

        public void DeletePostTagsByTagId(int tagId)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                var c = new DynamicParameters();
                c.Add("TagID", tagId);

                cn.Execute("RemovePostTagsByTagID", c,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
