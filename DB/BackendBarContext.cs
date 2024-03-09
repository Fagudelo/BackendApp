using Microsoft.EntityFrameworkCore;

namespace DB
{
    public class BackendBarContext(DbContextOptions<BackendBarContext> options) : DbContext(options)
    {
        public DbSet<Beer> Beers { get; set; }
    }
}
