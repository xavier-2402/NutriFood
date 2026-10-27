# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy solution and project files
COPY NutriFood.sln ./
COPY NutriFood.Api/NutriFood.Api.csproj NutriFood.Api/
COPY NutriFood.Application/NutriFood.Application.csproj NutriFood.Application/
COPY NutriFood.Domain/NutriFood.Domain.csproj NutriFood.Domain/
COPY NutriFood.Infrastructure/NutriFood.Infrastructure.csproj NutriFood.Infrastructure/

# Restore dependencies
RUN dotnet restore NutriFood.sln

# Copy all source code
COPY . .

# Build and publish
WORKDIR /src/NutriFood.Api
RUN dotnet publish NutriFood.Api.csproj -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

# Environment variables
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

# Copy published app
COPY --from=build /app/publish .

# Run the app
ENTRYPOINT ["dotnet", "NutriFood.Api.dll"]
