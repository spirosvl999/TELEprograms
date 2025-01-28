using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC_Final.Models;

namespace MVC_Final.Data
{
    // Make sure your DbContext inherits from IdentityDbContext<User>
    public class AppDbContext : DbContext
    {
        // Constructor that takes DbContextOptions and passes it to the base class
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Define a DbSet for your custom User model
        public DbSet<User> Users { get; set; }
    }
}