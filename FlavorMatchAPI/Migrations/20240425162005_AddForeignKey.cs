using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlavorMatchAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ingredients",
                table: "Dishes");

            migrationBuilder.AddColumn<int>(
                name: "IngredientID",
                table: "Dishes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_IngredientID",
                table: "Dishes",
                column: "IngredientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Ingredients_IngredientID",
                table: "Dishes",
                column: "IngredientID",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Ingredients_IngredientID",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_IngredientID",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "IngredientID",
                table: "Dishes");

            migrationBuilder.AddColumn<string>(
                name: "Ingredients",
                table: "Dishes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
