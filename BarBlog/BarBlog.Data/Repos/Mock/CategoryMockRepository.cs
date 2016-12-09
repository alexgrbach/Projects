using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarBlog.Models;
using BarBlog.Data.Interfaces;

namespace BarBlog.Data.Repos.Mock
{
    public class CategoryMockRepository : ICategoryRepository
    {
        private static List<Category> _categories;

        public CategoryMockRepository()
        {
            if (_categories == null)
            {
                _categories = new List<Category>()
                    {
                        new Category()
                        {
                            CategoryID = 1,
                            CategoryName = "Personal"
                        },
                        new Category()
                        {
                            CategoryID = 2,
                            CategoryName = "Review"
                        }
                    };
            }
        }

        public List<Category> GetAllCategories()
        {
            return _categories;
        }

        public void AddCategory(Category category)
        {
            _categories.Add(category);
        }

        public void DeleteCategory(int id)
        {
            _categories.RemoveAll(c => c.CategoryID == id);
        }

        public void EditCategory(Category category)
        {
            var selectedCategory = _categories.FirstOrDefault(c => c.CategoryID == category.CategoryID);
            selectedCategory.CategoryID = category.CategoryID;
            selectedCategory.CategoryName = category.CategoryName;
        }
}
    }

