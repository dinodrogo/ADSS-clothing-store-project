using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothingStoreProject.Migrations
{
    public partial class UpdatedTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Clothes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Clothes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Clothes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Clothes");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Clothes");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Clothes");
        }
    }
}
