using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NutriFood.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddFoodAttributeSoftDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "active",
                table: "FoodAttributes",
                type: "boolean",
                nullable: false,
                defaultValue: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "active",
                table: "FoodAttributes");

        }
    }
}
