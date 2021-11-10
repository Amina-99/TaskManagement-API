using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskmanagementAPI_Beta.Migrations
{
    public partial class AddIsDeletedToTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Task",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Task");
        }
    }
}
