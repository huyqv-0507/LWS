using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuckyWheelStradex.Migrations
{
    public partial class AddLotteryCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LotteryCode",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LotteryCode",
                table: "Players");
        }
    }
}
