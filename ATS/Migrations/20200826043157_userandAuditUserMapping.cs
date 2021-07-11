using Microsoft.EntityFrameworkCore.Migrations;

namespace ATS.Migrations
{
    public partial class userandAuditUserMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "auditFeetbackPersonId",
                table: "Objections",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AuditUserMapping",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    auditId = table.Column<int>(nullable: false),
                    userId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditUserMapping", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employeeId = table.Column<string>(nullable: true),
                    firstDesignation = table.Column<string>(nullable: true),
                    currentDesignation = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    userTypeId = table.Column<string>(nullable: true),
                    joiningDate = table.Column<string>(nullable: true),
                    dateofBirth = table.Column<string>(nullable: true),
                    workplace = table.Column<string>(nullable: true),
                    mobileNo = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    imageName = table.Column<string>(nullable: true),
                    imageLocation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditUserMapping");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropColumn(
                name: "auditFeetbackPersonId",
                table: "Objections");
        }
    }
}
