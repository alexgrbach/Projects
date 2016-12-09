using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarBlog.Models.Enums;

namespace BarBlog.Models
{
    public class User
    {
        public int? UserID { get; set; }
        public string UserName { get; set; }
        public Permissions Permission { get; set; }
        public string Password { get; set; }
    }
}
