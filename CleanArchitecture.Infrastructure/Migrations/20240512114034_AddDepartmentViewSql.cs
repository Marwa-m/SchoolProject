using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDepartmentViewSql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW ViewDepartment
                                    AS 
                                    SELECT d.DID, d.DNameAr, d.DNameEn, COUNT(s.StudentID) AS StudentCount  
                                    FROM Departments d 
                                    LEFT JOIN Students s ON d.DID = s.DID 
                                    GROUP BY d.DID, d.DNameAr, d.DNameEn");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS ViewDepartment");
        }
    }
}
