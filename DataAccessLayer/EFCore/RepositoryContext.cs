using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
        }
        DbSet<About> Abouts { get; set; }
        DbSet<Blog> Blogs { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<Contact> Contacts { get; set; }
        DbSet<Author> Authors { get; set; }
        DbSet<Admin> Admins { get; set; }
        DbSet<SubscribeMail> SubscribeMail {get;set;}

    }
}
