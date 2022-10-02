using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FPSTracker.Models;

namespace FPSTracker.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<UserName> UserName { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Match> Matchs { get; set; }
    }
}