using Microsoft.EntityFrameworkCore;


namespace MovieStoreMVC.Models
{
    public class MovieStoreContext : DbContext
    {
        public MovieStoreContext(DbContextOptions<MovieStoreContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
