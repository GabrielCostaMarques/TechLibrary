using Microsoft.EntityFrameworkCore;
using TechLibrary.Api.Entities;

namespace TechLibrary.Api.Infrastructure
{
    public class TechLibraryDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }  
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\gabri\\Downloads\\TechLibraryDb.db");


        }
    }
}
