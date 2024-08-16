using Microsoft.EntityFrameworkCore.Migrations;

namespace MagazynEdu.DataAccess.Migrations
{
    public partial class AddBookCase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookCaseId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BookCases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCases", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookCaseId",
                table: "Books",
                column: "BookCaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookCases_BookCaseId",
                table: "Books",
                column: "BookCaseId",
                principalTable: "BookCases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookCases_BookCaseId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "BookCases");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookCaseId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookCaseId",
                table: "Books");
        }
    }
}
