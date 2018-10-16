using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskTracker.DAL.Migrations
{
    public partial class AddUserSessionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserSessions",
                columns: table => new
                {
                    UserSessionId = table.Column<int>(nullable: false),
                    AccessToken = table.Column<string>(nullable: true),
                    AccessSecret = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSessions", x => x.UserSessionId);
                    table.ForeignKey(
                        name: "FK_UserSessions_AuthClientConfigs_UserSessionId",
                        column: x => x.UserSessionId,
                        principalTable: "AuthClientConfigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSessions");
        }
    }
}
