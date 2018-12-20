using Microsoft.EntityFrameworkCore.Migrations;

namespace HabrAspNet.Migrations
{
    public partial class changeSizePost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PostPreview",
                table: "Posts",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "PostName",
                table: "Posts",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PostPreview",
                table: "Posts",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "PostName",
                table: "Posts",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
