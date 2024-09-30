using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace software.database.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "sys_nha_cung_cap",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    hinh_thuc = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1"),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true, defaultValueSql: "getutcdate()"),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    status_del = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_nha_cung_cap", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_sys_nha_cung_cap_code",
                schema: "dbo",
                table: "sys_nha_cung_cap",
                column: "code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sys_nha_cung_cap",
                schema: "dbo");
        }
    }
}
