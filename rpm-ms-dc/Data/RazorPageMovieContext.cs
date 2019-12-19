using System;
using Microsoft.EntityFrameworkCore;

namespace rpm_ms_dc.Data
{
    public class RazorPageMovieContext : DbContext
    {
        public RazorPageMovieContext(DbContextOptions<RazorPageMovieContext> options) : base(options)
        {
        }

        public DbSet<Models.Movie> Movie { get; set; }
    }
}
