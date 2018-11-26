using Microsoft.EntityFrameworkCore;

namespace ProjMVCAula1.Models
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext (DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        public DbSet<ProjMVCAula1.Models.Movie> Movie { get; set; }
    }
}