using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarBlog.Models;
using BarBlog.Data.Interfaces;
using Dapper;

namespace BarBlog.Data.Repos.Database
{
    public class StaticPageRepo : IPageRepository
    {

        private static string _connectionString =
          ConfigurationManager.ConnectionStrings["BarBlog"].ConnectionString;

        public List<StaticPage> GetAllPages()
        {
            List<StaticPage> pages = new List<StaticPage>();
            using (var cn = new SqlConnection(_connectionString))
            {
                pages = cn.Query<StaticPage>("GetAllStaticPages",
                    commandType: CommandType.StoredProcedure).ToList();
            }
            return pages;
        }

        public StaticPage GetStaticPageById(int id)
        {
            var page = new StaticPage();
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("StaticPageID", id);
                page = cn.QuerySingle<StaticPage>("GetStaticPage", p,
                    commandType: CommandType.StoredProcedure);
            }
            return page;
        }

        public void AddPage(StaticPage page)
        {
         //   page.User = new User();
            
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("PageID", page.PageID);
             //   p.Add("UserID", page.User.UserID);
              //  p.Add("CategoryID", page.PageCategory.CategoryID);
                p.Add("PageTitle", page.PageTitle);
                //p.Add("PostSubTitle", post.PostSubtitle);
                p.Add("PageBody",page.PageBody);
                //p.Add("PostStatus", post.Status);
                p.Add("PageDate", page.PageDate);

                cn.Execute("AddStaticPage", p,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void EditPage(StaticPage page)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("PageID", page.PageID);
          //      p.Add("UserID", page.User.UserID);
                p.Add("PageBody", page.PageBody);
                //p.Add("StaticPageStatus", page. ); Pages don't have a status; for some reason they have them in the database
                p.Add("PageTitle", page.PageTitle);
                p.Add("PageDate", page.PageDate.ToShortDateString());
                cn.Execute("UpdateStaticPage", p,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void DeletePage(int id)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("PageID", id);

                cn.Execute("RemoveStaticPages", p,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
