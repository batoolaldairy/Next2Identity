using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Next2Identity.Models;
using System.Reflection.Metadata;

namespace Next2Identity.Data
{
    public class Next2DbContext : IdentityDbContext
    {
        public Next2DbContext(DbContextOptions<Next2DbContext> options) : base(options)
        {


        }
        public DbSet<Product> products { get; set; }
        
        public DbSet<Category> categories { get; set; }
    }
}
