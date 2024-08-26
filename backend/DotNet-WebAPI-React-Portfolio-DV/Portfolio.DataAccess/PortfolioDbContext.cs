using Microsoft.EntityFrameworkCore;
using Portfolio.DataAccess.Entities;

namespace Portfolio.DataAccess
{
    public class PortfolioDbContext : DbContext
    {
        public DbSet<PortfolioEntity> Portfolios { get; set; }

        public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options)
            : base(options)
        {

        }
    }
}
