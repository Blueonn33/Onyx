using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Onyx.Migrations
{
    /// <inheritdoc />
    public partial class Questions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Quizes",
                table: "Quizes");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Quizes");

            migrationBuilder.RenameTable(
                name: "Quizes",
                newName: "Quizzes");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Quizzes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "Quizzes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Quizzes",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<string>(
                name: "ImageMimeType",
                table: "Quizzes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TimeLimit",
                table: "Quizzes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Quizzes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quizzes",
                table: "Quizzes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AswerA = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AswerB = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AswerC = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AswerD = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CorrectAnswer = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Completed = table.Column<bool>(type: "bit", nullable: false),
                    QuestionNumber = table.Column<int>(type: "int", nullable: false),
                    QuizId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_UserId",
                table: "Quizzes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuizId",
                table: "Questions",
                column: "QuizId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_AspNetUsers_UserId",
                table: "Quizzes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_AspNetUsers_UserId",
                table: "Quizzes");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quizzes",
                table: "Quizzes");

            migrationBuilder.DropIndex(
                name: "IX_Quizzes_UserId",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "Completed",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "ImageMimeType",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "TimeLimit",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Quizzes");

            migrationBuilder.RenameTable(
                name: "Quizzes",
                newName: "Quizes");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Quizes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Quizes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quizes",
                table: "Quizes",
                column: "Id");
        }
    }
}
