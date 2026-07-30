using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Text.Json;

namespace NutriFood.Infrastructure.Persistence.Context
{
    public class NutriFoodDbContextFactory : IDesignTimeDbContextFactory<NutriFoodDbContext>
    {
        public NutriFoodDbContext CreateDbContext(string[] args)
        {
            var connectionString = GetConnectionString();

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException(
                    "Configure ConnectionStrings:NutriFoodDb in NutriFood.Api/appsettings.Development.json " +
                    "or set the NUTRIFOOD_CONNECTION_STRING environment variable.");
            }

            var optionsBuilder = new DbContextOptionsBuilder<NutriFoodDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new NutriFoodDbContext(optionsBuilder.Options);
        }

        private static string? GetConnectionString()
        {
            var environmentConnectionString = Environment.GetEnvironmentVariable("NUTRIFOOD_CONNECTION_STRING");

            if (!string.IsNullOrWhiteSpace(environmentConnectionString))
            {
                return environmentConnectionString;
            }

            var settingsPath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "NutriFood.Api",
                "appsettings.Development.json");

            if (!File.Exists(settingsPath))
            {
                return null;
            }

            using var document = JsonDocument.Parse(File.ReadAllText(settingsPath));

            return document.RootElement
                .GetProperty("ConnectionStrings")
                .GetProperty("NutriFoodDb")
                .GetString();
        }
    }
}
