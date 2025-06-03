using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Onyx.Migrations
{
    /// <inheritdoc />
    public partial class QuestionChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AswerD",
                table: "Questions",
                newName: "AnswerD");

            migrationBuilder.RenameColumn(
                name: "AswerC",
                table: "Questions",
                newName: "AnswerC");

            migrationBuilder.RenameColumn(
                name: "AswerB",
                table: "Questions",
                newName: "AnswerB");

            migrationBuilder.RenameColumn(
                name: "AswerA",
                table: "Questions",
                newName: "AnswerA");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AnswerD",
                table: "Questions",
                newName: "AswerD");

            migrationBuilder.RenameColumn(
                name: "AnswerC",
                table: "Questions",
                newName: "AswerC");

            migrationBuilder.RenameColumn(
                name: "AnswerB",
                table: "Questions",
                newName: "AswerB");

            migrationBuilder.RenameColumn(
                name: "AnswerA",
                table: "Questions",
                newName: "AswerA");
        }
    }
}
