using Lab_5.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab_5.Data
{
    public class MoviesDbContext :DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public MoviesDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
