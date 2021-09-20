using h94type.API.Models;
using Microsoft.EntityFrameworkCore;

namespace h94type.API.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
            
        }
        public DbSet<Text> Texts {get; set;}
        public DbSet<Genre> Genres { get; set; }
    }
}