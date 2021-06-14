using Microsoft.EntityFrameworkCore.Migrations;

namespace ELearningPlatform.Migrations
{
    public partial class CorrectRelationsInCoursesAndAddTableQuizAndRelationsBetweenCoursesAndQuziAndBetweenQuziAndQuestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coursess_Coursess_CoursesID1",
                table: "Coursess");

            migrationBuilder.DropForeignKey(
                name: "FK_Questionss_Coursess_CoursesID",
                table: "Questionss");

            migrationBuilder.DropIndex(
                name: "IX_Questionss_CoursesID",
                table: "Questionss");

            migrationBuilder.DropIndex(
                name: "IX_Coursess_CoursesID1",
                table: "Coursess");

            migrationBuilder.DropColumn(
                name: "CoursesID",
                table: "Questionss");

            migrationBuilder.DropColumn(
                name: "CoursesID1",
                table: "Coursess");

            migrationBuilder.AddColumn<int>(
                name: "QuizID",
                table: "Coursess",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    QuizID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    QuestionsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.QuizID);
                    table.ForeignKey(
                        name: "FK_Quizzes_Questionss_QuestionsID",
                        column: x => x.QuestionsID,
                        principalTable: "Questionss",
                        principalColumn: "QuestionsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coursess_QuizID",
                table: "Coursess",
                column: "QuizID");

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_QuestionsID",
                table: "Quizzes",
                column: "QuestionsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Coursess_Quizzes_QuizID",
                table: "Coursess",
                column: "QuizID",
                principalTable: "Quizzes",
                principalColumn: "QuizID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coursess_Quizzes_QuizID",
                table: "Coursess");

            migrationBuilder.DropTable(
                name: "Quizzes");

            migrationBuilder.DropIndex(
                name: "IX_Coursess_QuizID",
                table: "Coursess");

            migrationBuilder.DropColumn(
                name: "QuizID",
                table: "Coursess");

            migrationBuilder.AddColumn<int>(
                name: "CoursesID",
                table: "Questionss",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CoursesID1",
                table: "Coursess",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questionss_CoursesID",
                table: "Questionss",
                column: "CoursesID");

            migrationBuilder.CreateIndex(
                name: "IX_Coursess_CoursesID1",
                table: "Coursess",
                column: "CoursesID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Coursess_Coursess_CoursesID1",
                table: "Coursess",
                column: "CoursesID1",
                principalTable: "Coursess",
                principalColumn: "CoursesID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questionss_Coursess_CoursesID",
                table: "Questionss",
                column: "CoursesID",
                principalTable: "Coursess",
                principalColumn: "CoursesID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
