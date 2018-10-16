using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskTracker.DAL.Migrations
{
    public partial class AuthClientConfigSchemaChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PrivateKey",
                table: "AuthClientConfigs",
                newName: "Salt");

            migrationBuilder.AddColumn<string>(
                name: "ConsumerKey",
                table: "AuthClientConfigs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConsumerSecret",
                table: "AuthClientConfigs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Digest",
                table: "AuthClientConfigs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConsumerKey",
                table: "AuthClientConfigs");

            migrationBuilder.DropColumn(
                name: "ConsumerSecret",
                table: "AuthClientConfigs");

            migrationBuilder.DropColumn(
                name: "Digest",
                table: "AuthClientConfigs");

            migrationBuilder.RenameColumn(
                name: "Salt",
                table: "AuthClientConfigs",
                newName: "PrivateKey");
        }
    }
}
