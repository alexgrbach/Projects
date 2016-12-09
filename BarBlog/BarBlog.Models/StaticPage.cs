using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BarBlog.Models
{
    public class StaticPage
    {
        [RegularExpression(@"^\d+$")]
        public int PageID { get; set; }
        [Required]
        [DisplayName("Page Title")]
        public string PageTitle { get; set; }
        public DateTime PageDate { get; set; }
        [AllowHtml]
        [Required]
        [DisplayName("Page Body")]
        public string PageBody { get; set; }
        public List<Tag> PageTags { get; set; }
        public DateTime? ExpirationDate { get; set; }
       // public Category PageCategory { get; set; }
       // public bool IsApproved { get; set; } //this is probably extraneous
       // public User User { get; set; }
    }
}
