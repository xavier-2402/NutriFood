using System.Text.Json.Serialization;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using NutriFood.Api.Filters;
using NutriFood.Api.Middleware;
using NutriFood.Application.Services.Abstractions;
using NutriFood.Application.Services.Implementations;
using NutriFood.Application.Validators;
using NutriFood.Domain.Repositories;
using NutriFood.Infrastructure.Persistence.Context;
using NutriFood.Infrastructure.Persistence.Repositories;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add<ResponseResultFilter>())
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddValidatorsFromAssemblyContaining<PatientCreateRequestValidator>();

var connectionString = builder.Configuration.GetConnectionString("NutriFoodDb")
    ?? builder.Configuration["ConnectionStrings__NutriFoodDb"]
    ?? builder.Configuration["NUTRIFOOD_CONNECTION_STRING"]
    ?? builder.Configuration["DATABASE_URL"];

builder.Services.AddDbContext<NutriFoodDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<IAdequacyAttributeValueRepository, AdequacyAttributeValueRepository>();
builder.Services.AddScoped<IAdequacyPercentageRepository, AdequacyPercentageRepository>();
builder.Services.AddScoped<IFoodRepository, FoodRepository>();
builder.Services.AddScoped<IFoodAttributeValueRepository, FoodAttributeValueRepository>();
builder.Services.AddScoped<IFoodMenuRepository, FoodMenuRepository>();
builder.Services.AddScoped<IMealPlanRepository, MealPlanRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.AddScoped<IRecipeFoodRepository, RecipeFoodRepository>();
builder.Services.AddScoped<IRecipeFoodAttributeValueRepository, RecipeFoodAttributeValueRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped(typeof(ICrudRepository<,>), typeof(EfCrudRepository<,>));

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

builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddScoped<IMeasureUnitService, MeasureUnitService>();
builder.Services.AddScoped<IMealTimeService, MealTimeService>();
builder.Services.AddScoped<IFoodClassificationService, FoodClassificationService>();
builder.Services.AddScoped<IFoodCategoryService, FoodCategoryService>();
builder.Services.AddScoped<IFoodAttributeService, FoodAttributeService>();

builder.Services.AddOpenApi();

var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>()
    ?? builder.Configuration["Cors__AllowedOrigins"]?.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
    ?? builder.Configuration["ALLOWED_ORIGINS"]?.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

if (allowedOrigins is null || allowedOrigins.Length == 0)
{
    allowedOrigins = ["http://localhost:4200"];
}

builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontendPolicy", policy =>
        policy.WithOrigins(allowedOrigins)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseCors("FrontendPolicy");

app.UseAuthorization();

app.MapControllers();

app.MapGet("/api/saludo", () => "¡Hola desde Scalar en .NET 10!");

app.Run();
