using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddGetSalarySumFunction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION GetSalarySummation()
                                    RETURNS DECIMAL(18,2)
                                    AS
                                    BEGIN
                                        DECLARE @salary DECIMAL(18,2);
                                        SELECT @salary = SUM(salary) FROM Instructors;
                                        RETURN @salary;
                                    END;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS GetSalarySummation");
        }
    }
}
