using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDepartmentView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ViewDepartments",
                columns: table => new
                {
                    DID = table.Column<int>(type: "int", nullable: false),
                    DNameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DNameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ViewDepartments");
        }
    }
}
