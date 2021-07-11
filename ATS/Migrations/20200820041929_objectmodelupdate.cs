using Microsoft.EntityFrameworkCore.Migrations;

namespace ATS.Migrations
{
    public partial class objectmodelupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "Objections");

            migrationBuilder.AddColumn<string>(
                name: "auditFeetback",
                table: "Objections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "auditFeetbackDate",
                table: "Objections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "employeeReply",
                table: "Objections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "employeeReplyDate",
                table: "Objections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "statusPending",
                table: "Objections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "statusProcess",
                table: "Objections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "statusSettled",
                table: "Objections",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "auditFeetback",
                table: "Objections");

            migrationBuilder.DropColumn(
                name: "auditFeetbackDate",
                table: "Objections");

            migrationBuilder.DropColumn(
                name: "employeeReply",
                table: "Objections");

            migrationBuilder.DropColumn(
                name: "employeeReplyDate",
                table: "Objections");

            migrationBuilder.DropColumn(
                name: "statusPending",
                table: "Objections");

            migrationBuilder.DropColumn(
                name: "statusProcess",
                table: "Objections");

            migrationBuilder.DropColumn(
                name: "statusSettled",
                table: "Objections");

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "Objections",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
