using Microsoft.EntityFrameworkCore.Migrations;

namespace ATS.Migrations
{
    public partial class userandAuditUserMappingsecand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "activeStatus",
                table: "User",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userCreateDate",
                table: "User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "activeStatus",
                table: "User");

            migrationBuilder.DropColumn(
                name: "name",
                table: "User");

            migrationBuilder.DropColumn(
                name: "userCreateDate",
                table: "User");
        }
    }
}
