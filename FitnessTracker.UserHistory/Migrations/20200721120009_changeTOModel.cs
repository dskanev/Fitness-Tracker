using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessTracker.UserHistory.Migrations
{
    public partial class changeTOModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalCalories",
                table: "UserHistory",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalCalories",
                table: "UserHistory");
        }
    }
}
