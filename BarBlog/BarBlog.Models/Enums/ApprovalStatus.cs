using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BarBlog.Models.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ApprovalStatus
    {
        Pending,
        Denied,
        Approved,
        Expired
    }
}
