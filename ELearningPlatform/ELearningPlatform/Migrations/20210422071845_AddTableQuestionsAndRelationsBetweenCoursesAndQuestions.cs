using Microsoft.EntityFrameworkCore.Migrations;

namespace ELearningPlatform.Migrations
{
    public partial class AddTableQuestionsAndRelationsBetweenCoursesAndQuestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CoursesID1",
                table: "Coursess",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Questionss",
                columns: table => new
                {
                    QuestionsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QTitle = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Qa = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Qb = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Qc = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Qd = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Qcorect = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CoursesID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questionss", x => x.QuestionsID);
                    table.ForeignKey(
                        name: "FK_Questionss_Coursess_CoursesID",
                        column: x => x.CoursesID,
                        principalTable: "Coursess",
                        principalColumn: "CoursesID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coursess_CoursesID1",
                table: "Coursess",
                column: "CoursesID1");

            migrationBuilder.CreateIndex(
                name: "IX_Questionss_CoursesID",
                table: "Questionss",
                column: "CoursesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Coursess_Coursess_CoursesID1",
                table: "Coursess",
                column: "CoursesID1",
                principalTable: "Coursess",
                principalColumn: "CoursesID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coursess_Coursess_CoursesID1",
                table: "Coursess");

            migrationBuilder.DropTable(
                name: "Questionss");

            migrationBuilder.DropIndex(
                name: "IX_Coursess_CoursesID1",
                table: "Coursess");

            migrationBuilder.DropColumn(
                name: "CoursesID1",
                table: "Coursess");
        }
    }
}
