using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BakeryProject.Infrastructure
{
    public class BakeryDbContextFactory : IDesignTimeDbContextFactory<BakeryDbContext>
    {
        public BakeryDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BakeryDbContext>();
            optionsBuilder.UseSqlite("Data Source=Bakery.db");
            return new BakeryDbContext(optionsBuilder.Options);
        }
    }
}
