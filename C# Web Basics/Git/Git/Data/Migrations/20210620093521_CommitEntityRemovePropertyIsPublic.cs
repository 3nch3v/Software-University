using Microsoft.EntityFrameworkCore.Migrations;

namespace Git.Data.Migrations
{
    public partial class CommitEntityRemovePropertyIsPublic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "Commits");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "Commits",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
