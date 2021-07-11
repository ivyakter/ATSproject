using Microsoft.EntityFrameworkCore.Migrations;

namespace ATS.Migrations
{
    public partial class addre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "reauditFeetback",
                table: "Objections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "reauditFeetbackDate",
                table: "Objections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "reauditFeetbackPersonEmpId",
                table: "Objections",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "reauditFeetback",
                table: "Objections");

            migrationBuilder.DropColumn(
                name: "reauditFeetbackDate",
                table: "Objections");

            migrationBuilder.DropColumn(
                name: "reauditFeetbackPersonEmpId",
                table: "Objections");
        }
    }
}
