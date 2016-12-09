using BarBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarBlog.Data.Interfaces
{
    public interface ITagRepository
    {
        List<Tag> Getall();
        Tag Get(int id);
        void add(Tag tag);
        void Update(Tag tag);
        void Delete(int id);
        List<Tag> GetTagsByPostId(int id);
        void DeletePostTagsById(int postId);
        void DeletePostTagsByTagId(int tagId);
    }
}
