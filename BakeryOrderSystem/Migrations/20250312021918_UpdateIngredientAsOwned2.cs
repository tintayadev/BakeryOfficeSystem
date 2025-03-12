using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BakeryOrderSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIngredientAsOwned2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Breads_BreadId",
                table: "Ingredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredients",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_BreadId",
                table: "Ingredients");

            migrationBuilder.RenameTable(
                name: "Ingredients",
                newName: "Ingredient");

            migrationBuilder.AlterColumn<int>(
                name: "BreadId",
                table: "Ingredient",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_Breads_BreadId",
                table: "Ingredient",
                column: "BreadId",
                principalTable: "Breads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_Breads_BreadId",
                table: "Ingredient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredient",
                table: "Ingredient");

            migrationBuilder.RenameTable(
                name: "Ingredient",
                newName: "Ingredients");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Ingredients",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "BreadId",
                table: "Ingredients",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredients",
                table: "Ingredients",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_BreadId",
                table: "Ingredients",
                column: "BreadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Breads_BreadId",
                table: "Ingredients",
                column: "BreadId",
                principalTable: "Breads",
                principalColumn: "Id");
        }
    }
}
