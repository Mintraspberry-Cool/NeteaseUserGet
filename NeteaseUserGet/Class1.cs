using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeteaseUserGet
{
    public class Root
    {
        public string name { get; set; }
    }
    public class Root2
    {
        public int code { get; set; }
        public string message { get; set; }
        public object entity { get; set; }

    }
    public class Root3
    {
        public string entity_id { get; set; }
        public string name { get; set; }
        public string avatar_image_url { get; set; }
        public long register_time { get; set; }
        public long login_time { get; set; }
        public long logout_time { get; set; }
        public string signature { get; set; }
    }
}
