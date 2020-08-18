using Microsoft.EntityFrameworkCore.Migrations;


namespace MyDotNetIsBetterThanYours.Data.Migrations
{

    public partial class ChangeInUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Points",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "AnwswersPoints",
                table: "User",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuestionPoints",
                table: "User",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnwswersPoints",
                table: "User");

            migrationBuilder.DropColumn(
                name: "QuestionPoints",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }

}