using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarBlog.Models;

namespace BarBlog.Data.Interfaces
{
 public interface IPageRepository
    {
        List<StaticPage> GetAllPages();
        StaticPage GetStaticPageById(int id);
        void AddPage(StaticPage page);
        void EditPage(StaticPage page);
        void DeletePage(int id);
        
    }
}
