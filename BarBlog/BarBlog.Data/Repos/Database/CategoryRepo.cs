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
using BarBlog.Data.Interfaces;

namespace BarBlog.Data.Repos.Database
{
    public class CategoryRepo: ICategoryRepository
    {
        private static string _connectionString =
           ConfigurationManager.ConnectionStrings["BarBlog"].ConnectionString;

        public List<Category> GetAllCategories()
        {
            List<Category> categories = new List<Category>();
            using (var cn = new SqlConnection(_connectionString))
            {
                categories = cn.Query<Category>("GetAllCategories",
                    commandType: CommandType.StoredProcedure).ToList();
            }
            return categories;
        }

        public Category GetCategoryByID(int id)
        {
            var category = new Category();
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("CategoryID", id);
                category = cn.QuerySingle<Category>("GetCategory", p,
                    commandType: CommandType.StoredProcedure);
            }
            return category;
        }

        public void AddCategory(Category category)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                var c = new DynamicParameters();

                c.Add("CategoryID", category.CategoryID);
                c.Add("CategoryName", category.CategoryName);

                cn.Execute("AddCategory", c,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteCategory(int id)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                var c = new DynamicParameters();
                c.Add("CategoryID", id);

                cn.Execute("RemoveCategory", c,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void EditCategory(Category category)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                var c = new DynamicParameters();
                c.Add("CategoryID", category.CategoryID);
                c.Add("CategoryName", category.CategoryName);

                cn.Execute("UpdateCategory", c,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
