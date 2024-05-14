using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDepartmentProcedureSql : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.RenameTable(
            //    name: "ViewDepartments",
            //    newName: "ViewDepartment");

            migrationBuilder.Sql(@"CREATE proc DepartmentStudentCountProc
                                 @DID int
                                    AS 
                                    begin
                                CREATE TABLE #temp(DID int,DNameAr nvarchar(50),DNameEn nvarchar(50),StudentCount int)
                                insert into #temp
                                    SELECT d.DID, d.DNameAr, d.DNameEn, COUNT(s.StudentID) AS StudentCount  
                                    FROM Departments d 
                                    LEFT JOIN Students s ON d.DID = s.DID 
                                    WHERE d.DID=case when @DID=0 THEN d.DID ELSE @DID END
                                    GROUP BY d.DID, d.DNameAr, d.DNameEn
                                        end
                                    SELECT * from #temp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.RenameTable(
            //    name: "ViewDepartment",
            //    newName: "ViewDepartments");
            migrationBuilder.Sql("DROP PROC IF EXISTS DepartmentStudentCountProc");
        }
    }
}
