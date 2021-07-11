using Microsoft.EntityFrameworkCore.Migrations;

namespace ATS.Migrations
{
    public partial class usertablechangename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "years");

            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
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
                    imageLocation = table.Column<string>(nullable: true),
                    activeStatus = table.Column<bool>(nullable: false),
                    userCreateDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDetails");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    activeStatus = table.Column<bool>(type: "bit", nullable: false),
                    currentDesignation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateofBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    employeeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    firstDesignation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imageLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    joiningDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userCreateDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userTypeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    workplace = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "years",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_years", x => x.id);
                });
        }
    }
}
