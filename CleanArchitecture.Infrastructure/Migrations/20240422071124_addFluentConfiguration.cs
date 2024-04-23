using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addFluentConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Instructors_InsManager",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Instructors_SupervisorID",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_DID",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjects_Students_StudentID",
                table: "StudentSubjects");

            migrationBuilder.DropIndex(
                name: "IX_StudentSubjects_StudentID",
                table: "StudentSubjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ins_Subjects",
                table: "Ins_Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Ins_Subjects_SubID",
                table: "Ins_Subjects");

            migrationBuilder.AlterColumn<string>(
                name: "DNameAr",
                table: "Departments",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ins_Subjects",
                table: "Ins_Subjects",
                columns: new[] { "SubID", "InsID" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjects_StudID",
                table: "StudentSubjects",
                column: "StudID");

            migrationBuilder.CreateIndex(
                name: "IX_Ins_Subjects_InsID",
                table: "Ins_Subjects",
                column: "InsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Instructors_InsManager",
                table: "Departments",
                column: "InsManager",
                principalTable: "Instructors",
                principalColumn: "InsID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Instructors_SupervisorID",
                table: "Instructors",
                column: "SupervisorID",
                principalTable: "Instructors",
                principalColumn: "InsID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_DID",
                table: "Students",
                column: "DID",
                principalTable: "Departments",
                principalColumn: "DID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjects_Students_StudID",
                table: "StudentSubjects",
                column: "StudID",
                principalTable: "Students",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Instructors_InsManager",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Instructors_SupervisorID",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_DID",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjects_Students_StudID",
                table: "StudentSubjects");

            migrationBuilder.DropIndex(
                name: "IX_StudentSubjects_StudID",
                table: "StudentSubjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ins_Subjects",
                table: "Ins_Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Ins_Subjects_InsID",
                table: "Ins_Subjects");

            migrationBuilder.AlterColumn<string>(
                name: "DNameAr",
                table: "Departments",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ins_Subjects",
                table: "Ins_Subjects",
                columns: new[] { "InsID", "SubID" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjects_StudentID",
                table: "StudentSubjects",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Ins_Subjects_SubID",
                table: "Ins_Subjects",
                column: "SubID");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Instructors_InsManager",
                table: "Departments",
                column: "InsManager",
                principalTable: "Instructors",
                principalColumn: "InsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Instructors_SupervisorID",
                table: "Instructors",
                column: "SupervisorID",
                principalTable: "Instructors",
                principalColumn: "InsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_DID",
                table: "Students",
                column: "DID",
                principalTable: "Departments",
                principalColumn: "DID");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjects_Students_StudentID",
                table: "StudentSubjects",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "StudentID");
        }
    }
}
