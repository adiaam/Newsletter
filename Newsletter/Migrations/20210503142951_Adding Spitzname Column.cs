using Microsoft.EntityFrameworkCore.Migrations;

namespace Newsletter.Migrations
{
    public partial class AddingSpitznameColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Spitzname",
                table: "Newsletters",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Spitzname",
                table: "Newsletters");
        }
    }
}
