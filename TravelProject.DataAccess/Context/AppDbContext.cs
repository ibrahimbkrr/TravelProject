using Microsoft.EntityFrameworkCore;
using TravelProject.Entity.Entities;

namespace TravelProject.DataAccess.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<HomePage> HomePages { get; set; }
        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}