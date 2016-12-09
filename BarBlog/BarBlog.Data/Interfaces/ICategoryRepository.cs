using System.Collections.Generic;
using BarBlog.Models;

namespace BarBlog.Data.Interfaces
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategories();
        void AddCategory(Category category);
        void DeleteCategory(int id);
        void EditCategory(Category category);
    }
}