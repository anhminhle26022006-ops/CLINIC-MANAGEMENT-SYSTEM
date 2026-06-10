using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DAL.DataContext
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(
                "Server=localhost\\SQLEXPRESS;Database=CMS;Trusted_Connection=True;TrustServerCertificate=True;"
            );
            return new AppDbContext(optionsBuilder.Options); // ← .Options chứ không phải .Build()
        }
    }
}