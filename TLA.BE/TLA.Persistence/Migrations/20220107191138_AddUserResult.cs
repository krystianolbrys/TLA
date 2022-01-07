using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TLA.Persistence.Migrations
{
    public partial class AddUserResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WordId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    PostiveAnswers = table.Column<int>(type: "INTEGER", nullable: false),
                    NegativeAnswers = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserResults_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserResults_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserResults_UserId",
                table: "UserResults",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserResults_WordId",
                table: "UserResults",
                column: "WordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserResults");
        }
    }
}
