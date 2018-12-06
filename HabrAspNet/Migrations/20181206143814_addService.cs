using Microsoft.EntityFrameworkCore.Migrations;

namespace HabrAspNet.Migrations
{
    public partial class addService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CommentText",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CommentText",
                table: "Comments",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
