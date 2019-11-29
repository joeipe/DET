using Microsoft.EntityFrameworkCore.Migrations;

namespace DET.Write.Data.Migrations
{
    public partial class roletestdelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Test",
                table: "Roles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Test",
                table: "Roles",
                nullable: true);
        }
    }
}
