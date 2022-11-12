using IsaacLewisSite.Models;
using Microsoft.EntityFrameworkCore;

namespace IsaacLewisSite
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Story> Stories { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
    }
}
