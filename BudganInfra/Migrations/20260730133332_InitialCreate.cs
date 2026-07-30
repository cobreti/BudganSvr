using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudganInfra.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ColumnsMapping",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CardNumberColumnIndex = table.Column<int>(type: "int", nullable: false),
                    CardNumberColumnText = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateInscriptionColumnIndex = table.Column<int>(type: "int", nullable: false),
                    DateInscriptionColumnText = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AmountColumnIndex = table.Column<int>(type: "int", nullable: false),
                    AmountColumnText = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DescriptionColumnIndex = table.Column<int>(type: "int", nullable: false),
                    DescriptionColumnText = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColumnsMapping", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ColumnsMappingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_ColumnsMapping_ColumnsMappingId",
                        column: x => x.ColumnsMappingId,
                        principalTable: "ColumnsMapping",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountReferenceBalance",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountReferenceBalance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountReferenceBalance_Account_Id",
                        column: x => x.Id,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_ColumnsMappingId",
                table: "Account",
                column: "ColumnsMappingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountReferenceBalance");

            migrationBuilder.DropTable(
                name: "UserAccounts");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "ColumnsMapping");
        }
    }
}
