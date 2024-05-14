using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddGetInstrucotrsFunction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION GetInstructorsData()
                                   
                                    RETURNS @Instructors TABLE
                                    (
	                                    InsId INT,
	                                    NameAr NVARCHAR(50),
	                                    NameEn NVARCHAR(50)
                                    )
                                    AS
                                    BEGIN
	                                    INSERT INTO @Instructors
	                                    SELECT InsId, NameAr, NameEn
	                                    FROM Instructors
	                                   
	                                    RETURN;
                                    END;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS GetInstructorsData");
        }

    }
}
