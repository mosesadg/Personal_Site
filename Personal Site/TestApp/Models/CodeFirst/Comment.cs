using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public int PostID { get; set; }
        public string AuthorID { get; set; }
        public string Body { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Updated {get; set;}
        public string UpdatedReason {get;set;}

        public virtual Post Post {get;set;}
        public virtual ApplicationUser Author { get; set; }




    }
}