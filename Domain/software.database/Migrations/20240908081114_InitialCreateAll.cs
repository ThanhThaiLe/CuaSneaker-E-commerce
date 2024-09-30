using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace software.database.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateAll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "erp_don_hang_ban",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    unsigned_name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    loai_don_hang = table.Column<long>(type: "bigint", nullable: false),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ngay_dat_hang = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    phuong_thuc_thanh_toan = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    id_ngan_hang = table.Column<long>(type: "bigint", nullable: true),
                    tai_khoan_ngan_hang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ten_ngan_hang = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    loai_chuyen_khoan = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    thanh_tien_truoc_thue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    thanh_tien_sau_thue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    tien_thue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ty_le_vat = table.Column<int>(type: "int", nullable: false),
                    id_ty_le_vat = table.Column<long>(type: "bigint", nullable: false),
                    trang_thai_thanh_toan = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    trang_thai_xuat_hang = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    so_ngay_du_kien_giao = table.Column<int>(type: "int", nullable: false, defaultValueSql: "0"),
                    ngay_du_kien_giao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    thanh_tien_van_chuyen_truoc_thue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    thanh_tien_van_chuyen_sau_thue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    tien_thue_van_chuyen = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ty_le_vat_van_chuyen = table.Column<int>(type: "int", nullable: false),
                    id_ty_le_vat_van_chuyen = table.Column<long>(type: "bigint", nullable: false),
                    id_don_vi_van_chuyen = table.Column<long>(type: "bigint", nullable: false),
                    ma_don_van_chuyen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    id_tinh_khach_hang_nhan = table.Column<long>(type: "bigint", nullable: false),
                    id_quan_khach_hang_nhan = table.Column<long>(type: "bigint", nullable: false),
                    dia_chi_cu_the_khach_hang_nhan = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    full_name_khach_hang_nhan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    first_name_khach_hang_nhan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    last_name_khach_hang_nhan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email_khach_hang_nhan = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    phone_khach_hang_nhan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    id_quan_khach_hang_dat = table.Column<long>(type: "bigint", nullable: false),
                    id_tinh_khach_hang_dat = table.Column<long>(type: "bigint", nullable: false),
                    dia_chi_cu_the_khach_hang_dat = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    full_name_khach_hang_dat = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    first_name_khach_hang_dat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    last_name_khach_hang_dat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email_khach_hang_dat = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    phone_khach_hang_dat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    id_kho = table.Column<long>(type: "bigint", nullable: false),
                    ten_kho = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    code_kho = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true, defaultValueSql: "getutcdate()"),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status_del = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_erp_don_hang_ban", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "erp_don_hang_ban_chi_tiet",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_don_hang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_san_pham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ten_san_pham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ma_san_pham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_nhan_hieu = table.Column<long>(type: "bigint", nullable: false),
                    id_size = table.Column<long>(type: "bigint", nullable: false),
                    id_color = table.Column<long>(type: "bigint", nullable: false),
                    id_don_vi_tinh = table.Column<long>(type: "bigint", nullable: false),
                    so_luong = table.Column<long>(type: "bigint", nullable: false),
                    don_gia = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    thanh_tien_sau_chiet_khau = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    thanh_tien_chiet_khau = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    thanh_tien_truoc_chiet_khau = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    chiet_khau = table.Column<int>(type: "int", nullable: true),
                    id_chiet_khau = table.Column<long>(type: "bigint", nullable: true),
                    id_voucher = table.Column<long>(type: "bigint", nullable: true),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true, defaultValueSql: "getutcdate()"),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    status_del = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_erp_don_hang_ban_chi_tiet", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "erp_don_hang_mua",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    unsigned_name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    loai_don_hang = table.Column<long>(type: "bigint", nullable: false),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ngay_dat_hang = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    phuong_thuc_thanh_toan = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    id_ngan_hang = table.Column<long>(type: "bigint", nullable: true),
                    tai_khoan_ngan_hang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ten_ngan_hang = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    loai_chuyen_khoan = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    thanh_tien_truoc_thue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    thanh_tien_sau_thue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    tien_thue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ty_le_vat = table.Column<int>(type: "int", nullable: false),
                    id_ty_le_vat = table.Column<long>(type: "bigint", nullable: false),
                    trang_thai_thanh_toan = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    trang_thai_xuat_hang = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    so_ngay_du_kien_giao = table.Column<int>(type: "int", nullable: false, defaultValueSql: "0"),
                    ngay_du_kien_giao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    thanh_tien_van_chuyen_truoc_thue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    thanh_tien_van_chuyen_sau_thue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    tien_thue_van_chuyen = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ty_le_vat_van_chuyen = table.Column<int>(type: "int", nullable: false),
                    id_ty_le_vat_van_chuyen = table.Column<long>(type: "bigint", nullable: false),
                    id_don_vi_van_chuyen = table.Column<long>(type: "bigint", nullable: false),
                    ma_don_van_chuyen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    id_tinh_khach_hang_nhan = table.Column<long>(type: "bigint", nullable: false),
                    id_quan_khach_hang_nhan = table.Column<long>(type: "bigint", nullable: false),
                    dia_chi_cu_the_khach_hang_nhan = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    full_name_khach_hang_nhan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    first_name_khach_hang_nhan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    last_name_khach_hang_nhan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email_khach_hang_nhan = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    phone_khach_hang_nhan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    id_quan_khach_hang_dat = table.Column<long>(type: "bigint", nullable: false),
                    id_tinh_khach_hang_dat = table.Column<long>(type: "bigint", nullable: false),
                    dia_chi_cu_the_khach_hang_dat = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    full_name_khach_hang_dat = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    first_name_khach_hang_dat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    last_name_khach_hang_dat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email_khach_hang_dat = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    phone_khach_hang_dat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    id_kho = table.Column<long>(type: "bigint", nullable: false),
                    ten_kho = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    code_kho = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true, defaultValueSql: "getutcdate()"),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status_del = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_erp_don_hang_mua", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "erp_don_hang_mua_chi_tiet",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_don_hang = table.Column<long>(type: "bigint", nullable: false),
                    id_mat_hang = table.Column<long>(type: "bigint", nullable: false),
                    ten_mat_hang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ma_mat_hang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_nhan_hieu = table.Column<long>(type: "bigint", nullable: false),
                    id_don_vi_tinh = table.Column<long>(type: "bigint", nullable: false),
                    so_luong = table.Column<long>(type: "bigint", nullable: false),
                    don_gia = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    thanh_tien_sau_chiet_khau = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    thanh_tien_chiet_khau = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    thanh_tien_truoc_chiet_khau = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    chiet_khau = table.Column<int>(type: "int", nullable: true),
                    id_chiet_khau = table.Column<long>(type: "bigint", nullable: true),
                    id_voucher = table.Column<long>(type: "bigint", nullable: true),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true, defaultValueSql: "getutcdate()"),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    status_del = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_erp_don_hang_mua_chi_tiet", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "erp_don_vi_van_chuyen",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true, defaultValueSql: "getutcdate()"),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    status_del = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_erp_don_vi_van_chuyen", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "erp_hoa_don_ban_hang",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    id_don_hang_ban = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    so_seri = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    so_hoa_don = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    loai_hoa_don = table.Column<int>(type: "int", nullable: false),
                    ngay_ghi_hoa_don = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    trang_thai_phat_sinh = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1"),
                    id_hoa_don_thay_the = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hinh_thuc_doi_tuong = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1"),
                    id_doi_tuong = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true, defaultValueSql: "getutcdate()"),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status_del = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_erp_hoa_don_ban_hang", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "erp_hoa_don_ban_hang_chi_tiet",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_don_hang_ban = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    loai_hoa_don = table.Column<int>(type: "int", nullable: false),
                    id_hoa_don_ban = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_mat_hang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_don_vi_tinh = table.Column<long>(type: "bigint", nullable: true),
                    so_luong = table.Column<int>(type: "int", nullable: false),
                    don_gia = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    thanh_tien_truoc_thue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    thanh_tien_thue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    id_vat = table.Column<long>(type: "bigint", nullable: true),
                    gia_tri_vat = table.Column<int>(type: "int", nullable: true),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true, defaultValueSql: "getutcdate()"),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status_del = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_erp_hoa_don_ban_hang_chi_tiet", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "erp_loai_nhap_xuat",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    loai_nhap_xuat = table.Column<int>(type: "int", nullable: false),
                    nguon = table.Column<int>(type: "int", nullable: false),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true, defaultValueSql: "getutcdate()"),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status_del = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_erp_loai_nhap_xuat", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "erp_loai_thu_chi",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    loai = table.Column<int>(type: "int", nullable: false),
                    is_system = table.Column<bool>(type: "bit", nullable: true),
                    stt = table.Column<int>(type: "int", nullable: true),
                    ma_tai_khoan_no_tien_mat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ma_tai_khoan_co_tien_mat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ma_tai_khoan_co_chuyen_khoan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ma_tai_khoan_no_chuyen_khoan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true, defaultValueSql: "getutcdate()"),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status_del = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_erp_loai_thu_chi", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "erp_mat_hang",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    xuat_xu = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    id_nhan_hieu = table.Column<long>(type: "bigint", nullable: true),
                    thuoc_tinh = table.Column<int>(type: "int", nullable: true),
                    ma_vach = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    unsigned_name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    tien_te = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    barcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    qrcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    don_vi_tinh_quy_doi = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    id_loai_san_pham = table.Column<long>(type: "bigint", nullable: false),
                    id_don_vi_tinh = table.Column<long>(type: "bigint", nullable: false),
                    gia_ban_le = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    gia_ban_si = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    gia_von = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    he_so_quy_doi = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    gia_tri_vat = table.Column<int>(type: "int", nullable: true),
                    ty_le_chiet_khau = table.Column<int>(type: "int", nullable: true),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true, defaultValueSql: "getutcdate()"),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status_del = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_erp_mat_hang", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "erp_nhap_kho",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    unsigned_name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    nguon = table.Column<int>(type: "int", nullable: true),
                    hinh_thuc_doi_tuong = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1"),
                    id_doi_tuong = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ten_doi_tuong = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ma_so_thue = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    dien_thoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    dia_chi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    id_phieu_chuyen_kho = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_don_hang_ban = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_don_hang_mua = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_loai_nhap = table.Column<long>(type: "bigint", nullable: true),
                    id_kho = table.Column<long>(type: "bigint", nullable: true),
                    ngay_nhap = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    is_sinh_tu_dong = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    loai = table.Column<int>(type: "int", nullable: true),
                    so_phieu = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true, defaultValueSql: "getutcdate()"),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status_del = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_erp_nhap_kho", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "erp_nhap_kho_chi_tiet",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_phieu_nhap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_mat_hang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_don_vi_tinh = table.Column<long>(type: "bigint", nullable: true),
                    so_luong = table.Column<int>(type: "int", nullable: false),
                    don_gia = table.Column<int>(type: "int", nullable: false),
                    gia_tri = table.Column<int>(type: "int", nullable: false),
                    ngay_nhap = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    is_dinh_khoan = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    tai_khoan_co = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    tai_khoan_no = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    doi_tuong_no = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    doi_tuong_co = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    id_loai_nhap = table.Column<long>(type: "bigint", nullable: false),
                    id_kho = table.Column<long>(type: "bigint", nullable: false),
                    id_tai_san = table.Column<long>(type: "bigint", nullable: false),
                    is_chuyen_tai_san = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    is_vat = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    ty_suat_vat = table.Column<int>(type: "int", nullable: true, defaultValueSql: "0"),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true, defaultValueSql: "getutcdate()"),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status_del = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_erp_nhap_kho_chi_tiet", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "erp_phieu_chi",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    unsigned_name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ly_do_chinh_sua = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    nguon = table.Column<int>(type: "int", nullable: false),
                    id_loai_chi = table.Column<long>(type: "bigint", nullable: false),
                    id_don_hang_ban = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_don_hang_mua = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_don_hang_ban_thuc_hien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ngay_chi = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    phuong_thuc_thanh_toan = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    vi_dien_tu = table.Column<int>(type: "int", nullable: true),
                    id_tai_khoan_ngan_hang = table.Column<long>(type: "bigint", nullable: true),
                    ma_ngan_hang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ten_ngan_hang = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    so_tai_khoan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    id_doi_tuong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ten_doi_tuong = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ma_so_thue = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    dien_thoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    dia_chi_doi_tuong = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    so_tai_khoan_doi_tuong = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    id_so_quy_tien_mat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_nguoi_duyet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_dinh_khoan = table.Column<bool>(type: "bit", nullable: true),
                    tai_khoan_co = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    tai_khoan_no = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    doi_tuong_co = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    doi_tuong_no = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    so_tien = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    is_sinh_tu_dong = table.Column<bool>(type: "bit", nullable: true),
                    loai = table.Column<int>(type: "int", nullable: true),
                    so_phieu = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true, defaultValueSql: "getutcdate()"),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status_del = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_erp_phieu_chi", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "erp_phieu_chi_chi_tiet",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_phieu_chi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    noi_dung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    so_tien = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    is_dinh_khoan = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    tai_khoan_co = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    tai_khoan_no = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    doi_tuong_co = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    doi_tuong_no = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ngay_chi = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true, defaultValueSql: "getutcdate()"),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    status_del = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_erp_phieu_chi_chi_tiet", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "erp_phieu_chuyen_kho",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    unsigned_name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ly_do_chinh_sua = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    nguon = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1"),
                    id_loai_nhap = table.Column<long>(type: "bigint", nullable: false),
                    id_loai_xuat = table.Column<long>(type: "bigint", nullable: false),
                    ngay_du_kien_chuyen_di = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    ngay_du_kien_nhap_ve = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    id_kho_nhap = table.Column<long>(type: "bigint", nullable: false),
                    id_kho_xuat = table.Column<long>(type: "bigint", nullable: false),
                    id_phieu_nhap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_phieu_xuat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hinh_thuc_doi_tuong = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1"),
                    id_doi_tuong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ten_doi_tuong = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ma_so_thue = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    dien_thoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    dia_chi_doi_tuong = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    status_del = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_erp_phieu_chuyen_kho", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "erp_phieu_chuyen_kho_chi_tiet",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_phieu_xuat_kho = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_mat_hang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_loai_mat_hang = table.Column<long>(type: "bigint", nullable: false),
                    ma_vach = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    id_don_vi_tinh = table.Column<long>(type: "bigint", nullable: false),
                    so_luong = table.Column<int>(type: "int", nullable: false),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true, defaultValueSql: "getutcdate()"),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    status_del = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_erp_phieu_chuyen_kho_chi_tiet", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "erp_phieu_thu",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    unsigned_name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ly_do_chinh_sua = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    nguon = table.Column<int>(type: "int", nullable: true),
                    id_loai_thu = table.Column<long>(type: "bigint", nullable: false),
                    id_don_hang_ban = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_don_hang_mua = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_don_hang_ban_thuc_hien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ngay_thu = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    phuong_thuc_thanh_toan = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    vi_dien_tu = table.Column<int>(type: "int", nullable: true),
                    id_tai_khoan_ngan_hang = table.Column<long>(type: "bigint", nullable: true),
                    ma_ngan_hang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ten_ngan_hang = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    so_tai_khoan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    id_doi_tuong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ten_doi_tuong = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ma_so_thue = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    dien_thoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    dia_chi_doi_tuong = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    id_quy_doi_tien_mat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_nguoi_duyet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_dinh_khoan = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    tai_khoan_co = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    tai_khoan_no = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    doi_tuong_co = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    doi_tuong_no = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    so_tien = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    is_sinh_tu_dong = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    loai = table.Column<int>(type: "int", nullable: true),
                    so_phieu = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true, defaultValueSql: "getutcdate()"),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    status_del = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_erp_phieu_thu", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "erp_phieu_thu_chi_tiet",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_phieu_thu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    noi_dung = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    so_tien = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    is_dinh_khoan = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    tai_khoan_co = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    tai_khoan_no = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    doi_tuong_co = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    doi_tuong_no = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ngay_thu = table.Column<DateTime>(type: "datetime2", nullable: true),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true, defaultValueSql: "getutcdate()"),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    status_del = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_erp_phieu_thu_chi_tiet", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "erp_xuat_kho",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    unsigned_name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    id_don_hang_ban_thuc_hien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_don_hang_ban = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_don_hang_mua = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nguon = table.Column<int>(type: "int", nullable: true),
                    hinh_thuc_doi_tuong = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1"),
                    id_doi_tuong = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ten_doi_tuong = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ma_so_thue = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    dien_thoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    dia_chi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    id_loai_nhap = table.Column<long>(type: "bigint", nullable: true),
                    id_kho = table.Column<long>(type: "bigint", nullable: true),
                    ngay_xuat = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    id_phieu_chuyen_kho = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_sinh_tu_dong = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    loai = table.Column<int>(type: "int", nullable: true),
                    so_phieu = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true, defaultValueSql: "getutcdate()"),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status_del = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_erp_xuat_kho", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "erp_xuat_kho_chi_tiet",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_phieu_xuat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_mat_hang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_don_vi_tinh = table.Column<long>(type: "bigint", nullable: false),
                    so_luong = table.Column<int>(type: "int", nullable: false),
                    don_gia = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    gia_tri = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    don_gia_von = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    gia_tri_gia_von = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ngay_xuat = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    is_dinh_khoan = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    tai_khoan_co = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    tai_khoan_no = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    tai_khoan_co_gia_von = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    tai_khoan_no_gia_von = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    doi_tuong_no = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    doi_tuong_co = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    id_loai_xuat = table.Column<long>(type: "bigint", nullable: false),
                    id_kho = table.Column<long>(type: "bigint", nullable: false),
                    is_vat = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    ty_suat_vat = table.Column<int>(type: "int", nullable: true, defaultValueSql: "0"),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true, defaultValueSql: "getutcdate()"),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status_del = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_erp_xuat_kho_chi_tiet", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_banner",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_type = table.Column<int>(type: "int", nullable: false),
                    image_web = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    image_mobi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    link = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true, defaultValueSql: "getutcdate()"),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    status_del = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_banner", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_color",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true, defaultValueSql: "getutcdate()"),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    status_del = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_color", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_dieu_khoan",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    link = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    stt = table.Column<int>(type: "int", nullable: true, defaultValueSql: "0"),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true, defaultValueSql: "getutcdate()"),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    status_del = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_dieu_khoan", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_don_vi_tinh",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true, defaultValueSql: "getutcdate()"),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    status_del = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_don_vi_tinh", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_file_upload",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    controller = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    id_parent = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    file_type = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    file_name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    file_size = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "0"),
                    file_path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true, defaultValueSql: "getutcdate()"),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status_del = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_file_upload", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_group_user",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true, defaultValueSql: "getutcdate()"),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status_del = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1"),
                    type_user = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_group_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_group_user_detail",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_group_user = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_group_user_detail", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_group_user_role",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_group_user = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_controller_role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    controller_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_group_user_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_kho",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true, defaultValueSql: "getutcdate()"),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status_del = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_kho", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_lien_ket",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    link = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    stt = table.Column<int>(type: "int", nullable: true, defaultValueSql: "0"),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true, defaultValueSql: "getutcdate()"),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    status_del = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_lien_ket", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_loai_san_pham",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true, defaultValueSql: "getutcdate()"),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    status_del = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_loai_san_pham", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_ngan_hang",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    so_tai_khoan = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true, defaultValueSql: "getutcdate()"),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    status_del = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_ngan_hang", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_nhan_hieu",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    image = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true, defaultValueSql: "getutcdate()"),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    status_del = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_nhan_hieu", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_quan_huyen",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_quoc_gia = table.Column<long>(type: "bigint", nullable: false),
                    id_tinh = table.Column<long>(type: "bigint", nullable: false),
                    ten = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ten_khong_dau = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true, defaultValueSql: "getutcdate()"),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    status_del = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_quan_huyen", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_quoc_gia",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ten = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ten_khong_dau = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true, defaultValueSql: "getutcdate()"),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    status_del = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_quoc_gia", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_san_pham",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    id_loai_san_pham = table.Column<long>(type: "bigint", nullable: false),
                    id_nhan_hieu = table.Column<long>(type: "bigint", nullable: false),
                    id_don_vi_tinh = table.Column<long>(type: "bigint", nullable: false),
                    ten_san_pham = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ma_san_pham = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    hinh_anh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true, defaultValueSql: "getutcdate()"),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    status_del = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1"),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_san_pham", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_san_pham_chi_tiet",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_san_pham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_color = table.Column<long>(type: "bigint", nullable: false),
                    hinh_anh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mo_ta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gia_ban = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    is_noi_bac = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    is_khuyen_mai = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    qr_image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true, defaultValueSql: "getutcdate()"),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    status_del = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1"),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_san_pham_chi_tiet", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_size",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true, defaultValueSql: "getutcdate()"),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    status_del = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_size", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_sticker",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    avatar = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    loai = table.Column<int>(type: "int", nullable: false),
                    stt = table.Column<int>(type: "int", nullable: true, defaultValueSql: "0"),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true, defaultValueSql: "getutcdate()"),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    status_del = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_sticker", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_sticker_detail",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    file_path = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    file_size = table.Column<long>(type: "bigint", nullable: false),
                    file_type = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    id_sticker = table.Column<long>(type: "bigint", nullable: true),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true, defaultValueSql: "getutcdate()"),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    status_del = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_sticker_detail", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_tai_san",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    unsigned_name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    id_doi_tuong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nam_san_xuat = table.Column<int>(type: "int", nullable: false),
                    ngay_het_han = table.Column<DateTime>(type: "datetime2", nullable: false),
                    serial = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    id_don_vi_tinh = table.Column<long>(type: "bigint", nullable: false),
                    quy_cach_kich_thuoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    xuat_xu = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    id_nhan_hieu = table.Column<long>(type: "bigint", nullable: false),
                    don_gia = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    so_luong = table.Column<int>(type: "int", nullable: false),
                    thanh_tien = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true, defaultValueSql: "getutcdate()"),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    status_del = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1"),
                    ngay_bao = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    ly_do = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    so_tien_thanh_ly = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    id_loai_tai_san = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_phan_bo_su_dung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    loai_khai_bao = table.Column<int>(type: "int", nullable: true),
                    kh_ngay_tinh_khau_hao = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    kh_so_ky_khau_hao = table.Column<int>(type: "int", nullable: true),
                    kh_ngay_ket_thuc_khau_hao = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    kh_gia_tri_khau_hao_trong_mot_ky = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    kh_gia_tri_da_khau_hao = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    kh_gia_tri_con_lai = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    pb_gia_tri_phan_bo_trong_mot_ky = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    pb_gia_tri_da_phan_bo = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    pb_gia_tri_con_lai = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    pb_ngay_tinh_phan_bo = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    pb_so_ky_phan_bo = table.Column<int>(type: "int", nullable: true),
                    pb_ngay_ket_thuc_phan_bo = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    tai_khoan_chi_phi = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    tai_khoan_nguyen_gia = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    tai_khoan_khau_hao = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    tai_khoan_phan_bo = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    id_phieu_nhap_kho = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    id_don_hang_mua = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    id_phieu_nhap_kho_chi_tiet = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_tai_san", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_tai_san_lich_su_cap_nhat",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    id_tai_san = table.Column<long>(type: "bigint", nullable: false),
                    loai = table.Column<int>(type: "int", nullable: false),
                    id_nhan_vien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_phong_ban = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    so_luong = table.Column<int>(type: "int", nullable: false),
                    ly_do = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    dia_diem_ban_giao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true, defaultValueSql: "getutcdate()"),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    status_del = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_tai_san_lich_su_cap_nhat", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_template_mail",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_type = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    template = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true, defaultValueSql: "getutcdate()"),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    status_del = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_template_mail", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_thong_tin_website",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    image_logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    image_footer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dia_chi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    so_dien_thoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    link_facebook = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    link_youtube = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    link_linkedin = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    link_instagram = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    image_facebook = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    image_youtube = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    image_linkedin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    image_instagram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true, defaultValueSql: "getutcdate()"),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    status_del = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_thong_tin_website", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_tinh_thanh",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_quoc_gia = table.Column<long>(type: "bigint", nullable: true),
                    ten = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ten_khong_dau = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true, defaultValueSql: "getutcdate()"),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    status_del = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_tinh_thanh", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_type_mail",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true, defaultValueSql: "getutcdate()"),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    status_del = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_type_mail", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_user",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    phuong_thuc_thanh_toan = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1"),
                    full_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    user_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    token_reset_pass = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    expiration_date_reset_pass = table.Column<DateTime>(type: "datetime2", nullable: true),
                    id_department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true, defaultValueSql: "getutcdate()"),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    status_del = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_user_nhan_hang",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    id_tinh = table.Column<long>(type: "bigint", nullable: false),
                    id_quan = table.Column<long>(type: "bigint", nullable: false),
                    dia_chi_cu_the = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    id_user = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    full_name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true, defaultValueSql: "getutcdate()"),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    status_del = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_user_nhan_hang", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_vat",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    value = table.Column<long>(type: "bigint", nullable: false),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: true, defaultValueSql: "getutcdate()"),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    status_del = table.Column<int>(type: "int", nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_vat", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_erp_don_hang_ban_code",
                schema: "dbo",
                table: "erp_don_hang_ban",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_erp_don_hang_mua_code",
                schema: "dbo",
                table: "erp_don_hang_mua",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_erp_don_vi_van_chuyen_code",
                schema: "dbo",
                table: "erp_don_vi_van_chuyen",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_erp_loai_nhap_xuat_code",
                schema: "dbo",
                table: "erp_loai_nhap_xuat",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_erp_loai_thu_chi_code",
                schema: "dbo",
                table: "erp_loai_thu_chi",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_erp_mat_hang_code",
                schema: "dbo",
                table: "erp_mat_hang",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_erp_nhap_kho_code",
                schema: "dbo",
                table: "erp_nhap_kho",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_erp_nhap_kho_so_phieu",
                schema: "dbo",
                table: "erp_nhap_kho",
                column: "so_phieu",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_erp_phieu_chi_code",
                schema: "dbo",
                table: "erp_phieu_chi",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_erp_phieu_chuyen_kho_code",
                schema: "dbo",
                table: "erp_phieu_chuyen_kho",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_erp_phieu_thu_code",
                schema: "dbo",
                table: "erp_phieu_thu",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_erp_xuat_kho_code",
                schema: "dbo",
                table: "erp_xuat_kho",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_erp_xuat_kho_so_phieu",
                schema: "dbo",
                table: "erp_xuat_kho",
                column: "so_phieu",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sys_color_code",
                schema: "dbo",
                table: "sys_color",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sys_dieu_khoan_code",
                schema: "dbo",
                table: "sys_dieu_khoan",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sys_don_vi_tinh_code",
                schema: "dbo",
                table: "sys_don_vi_tinh",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sys_group_user_name",
                schema: "dbo",
                table: "sys_group_user",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sys_kho_code",
                schema: "dbo",
                table: "sys_kho",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sys_lien_ket_code",
                schema: "dbo",
                table: "sys_lien_ket",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sys_loai_san_pham_code",
                schema: "dbo",
                table: "sys_loai_san_pham",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sys_ngan_hang_code",
                schema: "dbo",
                table: "sys_ngan_hang",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sys_nhan_hieu_code",
                schema: "dbo",
                table: "sys_nhan_hieu",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sys_san_pham_ma_san_pham",
                schema: "dbo",
                table: "sys_san_pham",
                column: "ma_san_pham",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sys_size_code",
                schema: "dbo",
                table: "sys_size",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sys_sticker_code",
                schema: "dbo",
                table: "sys_sticker",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sys_sticker_detail_code",
                schema: "dbo",
                table: "sys_sticker_detail",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sys_tai_san_code",
                schema: "dbo",
                table: "sys_tai_san",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sys_tai_san_lich_su_cap_nhat_code",
                schema: "dbo",
                table: "sys_tai_san_lich_su_cap_nhat",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sys_tinh_thanh_id_quoc_gia",
                schema: "dbo",
                table: "sys_tinh_thanh",
                column: "id_quoc_gia",
                unique: true,
                filter: "[id_quoc_gia] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_sys_type_mail_code",
                schema: "dbo",
                table: "sys_type_mail",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sys_vat_code",
                schema: "dbo",
                table: "sys_vat",
                column: "code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "erp_don_hang_ban",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "erp_don_hang_ban_chi_tiet",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "erp_don_hang_mua",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "erp_don_hang_mua_chi_tiet",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "erp_don_vi_van_chuyen",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "erp_hoa_don_ban_hang",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "erp_hoa_don_ban_hang_chi_tiet",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "erp_loai_nhap_xuat",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "erp_loai_thu_chi",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "erp_mat_hang",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "erp_nhap_kho",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "erp_nhap_kho_chi_tiet",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "erp_phieu_chi",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "erp_phieu_chi_chi_tiet",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "erp_phieu_chuyen_kho",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "erp_phieu_chuyen_kho_chi_tiet",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "erp_phieu_thu",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "erp_phieu_thu_chi_tiet",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "erp_xuat_kho",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "erp_xuat_kho_chi_tiet",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "sys_banner",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "sys_color",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "sys_dieu_khoan",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "sys_don_vi_tinh",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "sys_file_upload",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "sys_group_user",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "sys_group_user_detail",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "sys_group_user_role",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "sys_kho",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "sys_lien_ket",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "sys_loai_san_pham",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "sys_ngan_hang",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "sys_nhan_hieu",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "sys_quan_huyen",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "sys_quoc_gia",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "sys_san_pham",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "sys_san_pham_chi_tiet",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "sys_size",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "sys_sticker",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "sys_sticker_detail",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "sys_tai_san",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "sys_tai_san_lich_su_cap_nhat",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "sys_template_mail",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "sys_thong_tin_website",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "sys_tinh_thanh",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "sys_type_mail",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "sys_user",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "sys_user_nhan_hang",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "sys_vat",
                schema: "dbo");
        }
    }
}
