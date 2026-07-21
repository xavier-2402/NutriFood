using Microsoft.EntityFrameworkCore;
using NutriFood.Domain.Entities;
using NutriFood.Infrastructure.Persistence.Configurations;

namespace NutriFood.Infrastructure.Persistence.Context
{
    public class NutriFoodDbContext : DbContext
    {
        public NutriFoodDbContext(DbContextOptions<NutriFoodDbContext> options)
        : base(options)
        {
        }

        public DbSet<AdequacyAttributeValue> AdequacyAttributeValues { get; set; }

        public DbSet<AdequacyPercentage> AdequacyPercentages { get; set; }

        public DbSet<Food> Foods { get; set; }

        public DbSet<FoodAttribute> FoodAttributes { get; set; }

        public DbSet<FoodAttributeValue> FoodAttributeValues { get; set; }

        public DbSet<FoodCategory> FoodCategories { get; set; }

        public DbSet<FoodClassification> FoodClassifications { get; set; }

        public DbSet<FoodMenu> FoodMenus { get; set; }

        public DbSet<MealPlan> MealPlans { get; set; }

        public DbSet<MealTime> MealTimes { get; set; }

        public DbSet<MeasureUnit> MeasureUnits { get; set; }

        public DbSet<Menu> Menus { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<RecipeFood> RecipeFoods { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AdequacyAttributeValueConfiguration());
            modelBuilder.ApplyConfiguration(new AdequacyPercentageConfiguration());
            modelBuilder.ApplyConfiguration(new FoodConfiguration());
            modelBuilder.ApplyConfiguration(new FoodAttributeConfiguration());
            modelBuilder.ApplyConfiguration(new FoodAttributeValueConfiguration());
            modelBuilder.ApplyConfiguration(new FoodCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new FoodClassificationConfiguration());
            modelBuilder.ApplyConfiguration(new FoodMenuConfiguration());
            modelBuilder.ApplyConfiguration(new MealPlanConfiguration());
            modelBuilder.ApplyConfiguration(new MealTimeConfiguration());
            modelBuilder.ApplyConfiguration(new MeasureUnitConfiguration());
            modelBuilder.ApplyConfiguration(new MenuConfiguration());
            modelBuilder.ApplyConfiguration(new PatientConfiguration());
            modelBuilder.ApplyConfiguration(new RecipeConfiguration());
            //modelBuilder.ApplyConfiguration(new RecipeFoodConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

    }
}
