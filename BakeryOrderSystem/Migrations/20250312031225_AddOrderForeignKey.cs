using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BakeryOrderSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_BakeryOffices_BakeryOfficeId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "BakeryOfficeId",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_BakeryOffices_BakeryOfficeId",
                table: "Orders",
                column: "BakeryOfficeId",
                principalTable: "BakeryOffices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_BakeryOffices_BakeryOfficeId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "BakeryOfficeId",
                table: "Orders",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_BakeryOffices_BakeryOfficeId",
                table: "Orders",
                column: "BakeryOfficeId",
                principalTable: "BakeryOffices",
                principalColumn: "Id");
        }
    }
}
