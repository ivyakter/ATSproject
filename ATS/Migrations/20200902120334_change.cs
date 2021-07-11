using Microsoft.EntityFrameworkCore.Migrations;

namespace ATS.Migrations
{
    public partial class change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "auditFeetbackPersonId",
                table: "Objections");

            migrationBuilder.AddColumn<string>(
                name: "auditFeetbackPersonEmpId",
                table: "Objections",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "auditFeetbackPersonEmpId",
                table: "Objections");

            migrationBuilder.AddColumn<int>(
                name: "auditFeetbackPersonId",
                table: "Objections",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
