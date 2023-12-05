using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yahoo_Finance.Migrations
{
    public partial class UpdateFinanceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Symbol",
                table: "Finances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Symbol",
                table: "Finances");
        }
    }
}
