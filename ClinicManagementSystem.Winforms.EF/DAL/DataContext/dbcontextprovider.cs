using Microsoft.EntityFrameworkCore;

namespace DAL.DataContext
{
    public static class DbContextProvider
    {
        public static AppDbContext CreateContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(
                "Server=localhost\\SQLEXPRESS;Database=CMS;Trusted_Connection=True;TrustServerCertificate=True;"
            );
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}