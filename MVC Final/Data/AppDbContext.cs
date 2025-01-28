using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC_Final.Models;

namespace MVC_Final.Data
{
    // Make sure your DbContext inherits from IdentityDbContext<User>
    public class AppDbContext : IdentityDbContext<User>
    {
        // Constructor that takes DbContextOptions and passes it to the base class
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // If you have other entities in your project, add them as DbSets here:
        // public DbSet<OtherEntity> OtherEntities { get; set; }
    }
}