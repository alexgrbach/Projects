using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarBlog.Data.Interfaces;
using BarBlog.Models;

namespace BarBlog.Data.Repos.Mock
{
    public class TagMockRepository : ITagRepository
    {
        private static List<Tag> _tags;

        public TagMockRepository()
        {
            if (_tags == null)
            {
                _tags = new List<Tag>()
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
                    };
            }
        }
        public void add(Tag tag)
        {
            _tags.Add(tag);
        }

        public void Delete(int id)
        {
            _tags.RemoveAll(t => t.TagID == id);
        }

        public Tag Get(int id)
        {
            return _tags.FirstOrDefault(t => t.TagID == id);
        }

        public List<Tag> Getall()
        {
            return _tags;
        }

        public List<Tag> GetTagsByPostId(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Tag tag)
        {
            var selectedTag = _tags.FirstOrDefault(t => t.TagID == tag.TagID);
            selectedTag.TagID = tag.TagID;
            selectedTag.TagName = tag.TagName;
        }

        public Tag DoesTagExist(string tagname, int postId)
        {

            var tagToReturn = new Tag();
            var newtag = new Tag();
            var oldTags = Getall();

            for (int i = 0; i < oldTags.Count; i++)
            {
                //foreach (var tag in oldTags)
                //{

                if (tagname == oldTags[i].TagName)
                {

                    tagToReturn = oldTags[i];
                    break;
                }
            }
            if (tagToReturn.TagName == null)
            {
                
                newtag.TagName = tagname;
                newtag.TagID = oldTags.Max(t => t.TagID) + 1;
                add(newtag);
            }

            tagToReturn = newtag;
            
            return tagToReturn;
        }

        public void DeletePostTagsById(int postId)
        {
            throw new NotImplementedException();
        }

        public void DeletePostTagsByTagId(int tagId)
        {
            throw new NotImplementedException();
        }
    }
}
