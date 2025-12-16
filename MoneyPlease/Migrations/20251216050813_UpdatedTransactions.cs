using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyPlease.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedTransactions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cost",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "LastUpdatedAt",
                table: "Transactions",
                newName: "last_updated");

            migrationBuilder.AlterColumn<DateTime>(
                name: "last_updated",
                table: "Transactions",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<decimal>(
                name: "amount",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "amount",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "last_updated",
                table: "Transactions",
                newName: "LastUpdatedAt");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedAt",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<decimal>(
                name: "cost",
                table: "Transactions",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
