using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyPlease.Migrations
{
    /// <inheritdoc />
    public partial class updatedtransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "transaction_type",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "transaction_type",
                table: "Transactions");
        }
    }
}
