using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using BarBlog.Models.Enums;


namespace BarBlog.Models
{
   public class Post
    {
        [RegularExpression(@"^\d+$")]
        public int PostID { get; set; }
      
        public User User { get; set; }

        [Required(ErrorMessage = "Please enter a title.")]
        [DisplayName("Post Title")]
        public string PostTitle { get; set; }

        [Required]
        [DisplayName("Post Subtitle")]
        public string PostSubtitle { get; set; }

        public DateTime PostDate { get; set; }

        [AllowHtml]
        [Required(ErrorMessage = "Please enter some text for this post!")]
        [DisplayName("Post Body")]
        public string PostBody { get; set; }

        public List<Tag> PostTags { get; set; }

        public DateTime? ExpirationDate { get; set; }
        public Category PostCategory { get; set; }
        public ApprovalStatus Status { get; set; }
        public string placeholderText { get; set; }


    }
}
