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
                name: "EFColumnsMapping",
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
                    table.PrimaryKey("PK_EFColumnsMapping", x => x.Id);
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

            migrationBuilder.InsertData(
                table: "UserAccounts",
                columns: new[] { "Id", "Name", "IsDefault" },
                values: new object[] { new Guid("51FE837B-5303-4825-81D4-F4D59D686A3C"), "Global", true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EFColumnsMapping");

            migrationBuilder.DropTable(
                name: "UserAccounts");
        }
    }
}
