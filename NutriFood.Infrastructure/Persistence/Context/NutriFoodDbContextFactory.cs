using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NutriFood.Infrastructure.Persistence.Context
{
    public class NutriFoodDbContextFactory : IDesignTimeDbContextFactory<NutriFoodDbContext>
    {
        public NutriFoodDbContext CreateDbContext(string[] args)
        {
            var connectionString = Environment.GetEnvironmentVariable("NUTRIFOOD_CONNECTION_STRING");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException(
                    "Set the NUTRIFOOD_CONNECTION_STRING environment variable before running EF Core commands.");
            }

            var optionsBuilder = new DbContextOptionsBuilder<NutriFoodDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new NutriFoodDbContext(optionsBuilder.Options);
        }
    }
}
