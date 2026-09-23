using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NutriFood.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddRecipeFoodAttributeValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "FoodAttributes",
                newName: "food_attributes");

            migrationBuilder.CreateTable(
                name: "recipe_food_attribute_values",
                columns: table => new
                {
                    recipe_id = table.Column<int>(type: "integer", nullable: false),
                    food_id = table.Column<int>(type: "integer", nullable: false),
                    attribute_id = table.Column<short>(type: "smallint", nullable: false),
                    value = table.Column<double>(type: "double precision", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    crea_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    crea_usr = table.Column<short>(type: "smallint", nullable: false),
                    mod_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    mod_usr = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipe_food_attribute_values", x => new { x.recipe_id, x.food_id, x.attribute_id });
                    table.ForeignKey(
                        name: "FK_recipe_food_attribute_values_food_attributes_attribute_id",
                        column: x => x.attribute_id,
                        principalTable: "food_attributes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_recipe_food_attribute_values_recipe_foods_recipe_id_food_id",
                        columns: x => new { x.recipe_id, x.food_id },
                        principalTable: "recipe_foods",
                        principalColumns: new[] { "recipe_id", "food_id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_recipe_food_attribute_values_attribute_id",
                table: "recipe_food_attribute_values",
                column: "attribute_id");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "recipe_food_attribute_values");

            migrationBuilder.RenameTable(
                name: "food_attributes",
                newName: "FoodAttributes");
        }
    }
}
