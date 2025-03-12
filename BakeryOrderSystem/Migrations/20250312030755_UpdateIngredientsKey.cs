using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BakeryOrderSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIngredientsKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredient",
                table: "Ingredient");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Ingredient",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredient",
                table: "Ingredient",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_BreadId",
                table: "Ingredient",
                column: "BreadId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredient",
                table: "Ingredient");

            migrationBuilder.DropIndex(
                name: "IX_Ingredient_BreadId",
                table: "Ingredient");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Ingredient",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredient",
                table: "Ingredient",
                columns: new[] { "BreadId", "Id" });
        }
    }
}
