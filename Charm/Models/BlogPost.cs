using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Charm.Models
{
    public class BlogPost
    {
        public BlogPost()
        {
            this.Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public System.DateTimeOffset Created { get; set; }
        public Nullable<System.DateTimeOffset> Updated { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        [AllowHtml]
        public string Blog { get; set; }
        public string MediaUrl { get; set; }


        public virtual ICollection<Comment> Comments { get; set; }
        }

    public class BlogPostDBContext : DbContext
    {
        public DbSet<BlogPost> Posts { get; set; }
    }
}
