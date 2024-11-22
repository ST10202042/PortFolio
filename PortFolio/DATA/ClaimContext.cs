using Microsoft.EntityFrameworkCore;

using Portfolio.Models;
namespace Portfolio.Data
{
    public class ClaimContext : DbContext
    {
        public ClaimContext(DbContextOptions<ClaimContext> options) : base(options)
        {
        }

       // public DbSet<Claim> Claims { get; set; }
    }
}
