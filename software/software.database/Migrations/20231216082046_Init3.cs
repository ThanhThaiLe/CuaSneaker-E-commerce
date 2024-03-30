using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace software.database.Migrations
{
    public partial class Init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "id_ngan_hang",
                table: "erp_don_hang_ban",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "sys_tai_san",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    note = table.Column<string>(nullable: true),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: true),
                    update_by = table.Column<string>(nullable: true),
                    update_date = table.Column<DateTime>(nullable: true),
                    status_del = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_tai_san", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sys_tai_san");

            migrationBuilder.DropColumn(
                name: "id_ngan_hang",
                table: "erp_don_hang_ban");
        }
    }
}
