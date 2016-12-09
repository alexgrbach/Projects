using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarBlog.Models;
using BarBlog.Data.Interfaces;

namespace BarBlog.Data.Repos.Mock
{
    class PageMockRepository : IPageRepository
    {
        private static List<StaticPage> _staticPages;

        public PageMockRepository()
        {
            if (_staticPages == null)
            {
                _staticPages = new List<StaticPage>()
                {
                    new StaticPage()
                    {
                        PageID = 1,
                        PageTitle = "Static 1",
                        PageDate = DateTime.Parse("11/30/16"),
                        PageBody = "<h2>Static test page 1</h2><p>Placeholder text for first static page</p>"

                    },
                    new StaticPage()
                    {
                        PageID = 2,
                        PageTitle = "Static 2",
                        PageDate = DateTime.Parse("11/30/16"),
                        PageBody = "<h2>Static test page 2</h2><p>Placeholder text for second static page</p>"
                    }
                };

            }
        }

        public StaticPage GetStaticPageById(int id)
        {
            var page = new StaticPage();
            page = _staticPages.FirstOrDefault(p => p.PageID == id);
            return page;

        }
        public List<StaticPage> GetAllPages()
        {
            return _staticPages;
        }

        public void AddPage(StaticPage page)
        {
            _staticPages.Add(page);
        }

        public void EditPage(StaticPage page)
        {
            var selectedPage = _staticPages.FirstOrDefault(p => p.PageID == page.PageID);
            selectedPage.PageID = page.PageID;
           // selectedPage.User = page.User;
            selectedPage.PageTitle = page.PageTitle;
            selectedPage.PageBody = page.PageBody;
          //  selectedPage.PageCategory = page.PageCategory;
            //selectedPage.Status = Page.Status;
            //selectedPage.PageTags = Page.PageTags;
            selectedPage.PageDate = DateTime.Now;
        }

        public void DeletePage(int id)
        {
            _staticPages.RemoveAll(p => p.PageID == id);
        }
    }
}

