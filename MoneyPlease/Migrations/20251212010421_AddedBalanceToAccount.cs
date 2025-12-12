using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyPlease.Migrations
{
    /// <inheritdoc />
    public partial class AddedBalanceToAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "balance",
                table: "Account",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "balance",
                table: "Account");
        }
    }
}
