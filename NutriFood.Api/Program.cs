using Microsoft.EntityFrameworkCore;
using NutriFood.Api.Filters;
using NutriFood.Application.Services.Abstractions;
using NutriFood.Application.Services.Implementations;
using NutriFood.Domain.Repositories;
using NutriFood.Infrastructure.Persistence.Context;
using NutriFood.Infrastructure.Persistence.Repositories;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add<ResponseResultFilter>());
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<NutriFoodDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("NutriFoodDb")));

builder.Services.AddScoped<IAdequacyAttributeValueRepository, AdequacyAttributeValueRepository>();
builder.Services.AddScoped<IAdequacyPercentageRepository, AdequacyPercentageRepository>();
builder.Services.AddScoped<IFoodRepository, FoodRepository>();
builder.Services.AddScoped<IFoodAttributeValueRepository, FoodAttributeValueRepository>();
builder.Services.AddScoped<IFoodMenuRepository, FoodMenuRepository>();
builder.Services.AddScoped<IMealPlanRepository, MealPlanRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.AddScoped<IRecipeFoodRepository, RecipeFoodRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped(typeof(ICrudRepository<,>), typeof(EfCrudRepository<,>));
builder.Services.AddScoped(typeof(IReadOnlyService<,>), typeof(ReadOnlyService<,>));
builder.Services.AddScoped(typeof(ICrudService<,>), typeof(CrudService<,>));

builder.Services.AddScoped<IAdequacyAttributeValueService, AdequacyAttributeValueService>();
builder.Services.AddScoped<IAdequacyPercentageService, AdequacyPercentageService>();
builder.Services.AddScoped<IFoodService, FoodService>();
builder.Services.AddScoped<IFoodAttributeValueService, FoodAttributeValueService>();
builder.Services.AddScoped<IFoodMenuService, FoodMenuService>();
builder.Services.AddScoped<IMealPlanService, MealPlanService>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddScoped<IRecipeFoodService, RecipeFoodService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/api/saludo", () => "¡Hola desde Scalar en .NET 10!");

app.Run();
