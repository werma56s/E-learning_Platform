using Microsoft.EntityFrameworkCore.Migrations;

namespace ELearningPlatform.Migrations
{
    public partial class CorrectRolesBetweenCoursesAndQuiz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coursess_Quizzes_QuizID",
                table: "Coursess");

            migrationBuilder.DropIndex(
                name: "IX_Coursess_QuizID",
                table: "Coursess");

            migrationBuilder.DropColumn(
                name: "QuizID",
                table: "Coursess");

            migrationBuilder.AddColumn<int>(
                name: "CoursesID",
                table: "Quizzes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_CoursesID",
                table: "Quizzes",
                column: "CoursesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_Coursess_CoursesID",
                table: "Quizzes",
                column: "CoursesID",
                principalTable: "Coursess",
                principalColumn: "CoursesID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_Coursess_CoursesID",
                table: "Quizzes");

            migrationBuilder.DropIndex(
                name: "IX_Quizzes_CoursesID",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "CoursesID",
                table: "Quizzes");

            migrationBuilder.AddColumn<int>(
                name: "QuizID",
                table: "Coursess",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Coursess_QuizID",
                table: "Coursess",
                column: "QuizID");

            migrationBuilder.AddForeignKey(
                name: "FK_Coursess_Quizzes_QuizID",
                table: "Coursess",
                column: "QuizID",
                principalTable: "Quizzes",
                principalColumn: "QuizID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
