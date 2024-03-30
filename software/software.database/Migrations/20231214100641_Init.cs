using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace software.database.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "erp_don_hang_ban",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    loai_don_hang = table.Column<long>(nullable: true),
                    note = table.Column<string>(nullable: true),
                    ngay_dat_hang = table.Column<DateTime>(nullable: true),
                    phuong_thuc_thanh_toan = table.Column<int>(nullable: true),
                    loai_chuyen_khoan = table.Column<int>(nullable: true),
                    thanh_tien_truoc_thue = table.Column<decimal>(nullable: true),
                    thanh_tien_sau_thue = table.Column<decimal>(nullable: true),
                    tien_thue = table.Column<decimal>(nullable: true),
                    ty_le_vat = table.Column<int>(nullable: true),
                    id_ty_le_vat = table.Column<long>(nullable: true),
                    trang_thai_thanh_toan = table.Column<bool>(nullable: true),
                    trang_thai_xuat_hang = table.Column<bool>(nullable: true),
                    so_ngay_du_kien_giao = table.Column<int>(nullable: true),
                    ngay_du_kien_giao = table.Column<DateTime>(nullable: true),
                    thanh_tien_van_chuyen_truoc_thue = table.Column<decimal>(nullable: true),
                    thanh_tien_van_chuyen_sau_thue = table.Column<decimal>(nullable: true),
                    tien_thue_van_chuyen = table.Column<decimal>(nullable: true),
                    ty_le_vat_van_chuyen = table.Column<int>(nullable: true),
                    id_ty_le_vat_van_chuyen = table.Column<long>(nullable: true),
                    id_don_vi_van_chuyen = table.Column<long>(nullable: true),
                    ma_don_van_chuyen = table.Column<string>(nullable: true),
                    id_tinh_khach_hang_nhan = table.Column<long>(nullable: true),
                    id_quan_khach_hang_nhan = table.Column<long>(nullable: true),
                    dia_chi_cu_the_khach_hang_nhan = table.Column<string>(nullable: true),
                    full_name_khach_hang_nhan = table.Column<string>(nullable: true),
                    first_name_khach_hang_nhan = table.Column<string>(nullable: true),
                    last_name_khach_hang_nhan = table.Column<string>(nullable: true),
                    email_khach_hang_nhan = table.Column<string>(nullable: true),
                    phone_khach_hang_nhan = table.Column<string>(nullable: true),
                    id_quan_khach_hang_dat = table.Column<long>(nullable: true),
                    id_tinh_khach_hang_dat = table.Column<long>(nullable: true),
                    dia_chi_cu_the_khach_hang_dat = table.Column<string>(nullable: true),
                    full_name_khach_hang_dat = table.Column<string>(nullable: true),
                    first_name_khach_hang_dat = table.Column<string>(nullable: true),
                    last_name_khach_hang_dat = table.Column<string>(nullable: true),
                    email_khach_hang_dat = table.Column<string>(nullable: true),
                    phone_khach_hang_dat = table.Column<string>(nullable: true),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: true),
                    update_by = table.Column<string>(nullable: true),
                    update_date = table.Column<DateTime>(nullable: true),
                    status_del = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_erp_don_hang_ban", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "erp_don_hang_ban_chi_tiet",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_don_hang = table.Column<long>(nullable: true),
                    id_san_pham = table.Column<long>(nullable: false),
                    so_luong = table.Column<long>(nullable: false),
                    don_gia = table.Column<decimal>(nullable: true),
                    thanh_tien = table.Column<decimal>(nullable: true),
                    chiet_khau = table.Column<int>(nullable: true),
                    id_chiet_khau = table.Column<long>(nullable: true),
                    note = table.Column<string>(nullable: true),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: true),
                    update_by = table.Column<string>(nullable: true),
                    update_date = table.Column<DateTime>(nullable: true),
                    status_del = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_erp_don_hang_ban_chi_tiet", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "erp_don_hang_mua",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    loai_don_hang = table.Column<long>(nullable: true),
                    note = table.Column<string>(nullable: true),
                    ngay_dat_hang = table.Column<DateTime>(nullable: true),
                    phuong_thuc_thanh_toan = table.Column<int>(nullable: true),
                    thanh_tien_truoc_thue = table.Column<decimal>(nullable: true),
                    thanh_tien_sau_thue = table.Column<decimal>(nullable: true),
                    tien_thue = table.Column<decimal>(nullable: true),
                    ty_le_vat = table.Column<int>(nullable: true),
                    id_ty_le_vat = table.Column<long>(nullable: true),
                    trang_thai_thanh_toan = table.Column<bool>(nullable: true),
                    trang_thai_xuat_hang = table.Column<bool>(nullable: true),
                    so_ngay_du_kien_giao = table.Column<int>(nullable: true),
                    ngay_du_kien_giao = table.Column<DateTime>(nullable: true),
                    thanh_tien_van_chuyen_truoc_thue = table.Column<decimal>(nullable: true),
                    thanh_tien_van_chuyen_sau_thue = table.Column<decimal>(nullable: true),
                    tien_thue_van_chuyen = table.Column<decimal>(nullable: true),
                    ty_le_vat_van_chuyen = table.Column<int>(nullable: true),
                    id_ty_le_vat_van_chuyen = table.Column<long>(nullable: true),
                    id_tinh_khach_hang_nhan = table.Column<long>(nullable: true),
                    id_quan_khach_hang_nhan = table.Column<long>(nullable: true),
                    dia_chi_cu_the_khach_hang_nhan = table.Column<string>(nullable: true),
                    full_name_khach_hang_nhan = table.Column<string>(nullable: true),
                    first_name_khach_hang_nhan = table.Column<string>(nullable: true),
                    last_name_khach_hang_nhan = table.Column<string>(nullable: true),
                    email_khach_hang_nhan = table.Column<string>(nullable: true),
                    phone_khach_hang_nhan = table.Column<string>(nullable: true),
                    id_quan_khach_hang_dat = table.Column<long>(nullable: true),
                    id_tinh_khach_hang_dat = table.Column<long>(nullable: true),
                    dia_chi_cu_the_khach_hang_dat = table.Column<string>(nullable: true),
                    full_name_khach_hang_dat = table.Column<string>(nullable: true),
                    first_name_khach_hang_dat = table.Column<string>(nullable: true),
                    last_name_khach_hang_dat = table.Column<string>(nullable: true),
                    email_khach_hang_dat = table.Column<string>(nullable: true),
                    phone_khach_hang_dat = table.Column<string>(nullable: true),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: true),
                    update_by = table.Column<string>(nullable: true),
                    update_date = table.Column<DateTime>(nullable: true),
                    status_del = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_erp_don_hang_mua", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "erp_don_hang_mua_chi_tiet",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_don_hang = table.Column<long>(nullable: true),
                    id_san_pham = table.Column<long>(nullable: false),
                    so_luong = table.Column<long>(nullable: false),
                    don_gia = table.Column<decimal>(nullable: true),
                    thanh_tien = table.Column<decimal>(nullable: true),
                    chiet_khau = table.Column<int>(nullable: true),
                    id_chiet_khau = table.Column<long>(nullable: true),
                    note = table.Column<string>(nullable: true),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: true),
                    update_by = table.Column<string>(nullable: true),
                    update_date = table.Column<DateTime>(nullable: true),
                    status_del = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_erp_don_hang_mua_chi_tiet", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "erp_don_vi_van_chuyen",
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
                    table.PrimaryKey("PK_erp_don_vi_van_chuyen", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "erp_loai_nhap_xuat",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    loai_nhap_xuat = table.Column<string>(nullable: true),
                    nguon = table.Column<int>(nullable: false),
                    note = table.Column<string>(nullable: true),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: true),
                    update_by = table.Column<string>(nullable: true),
                    update_date = table.Column<DateTime>(nullable: true),
                    status_del = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_erp_loai_nhap_xuat", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "erp_nhap_kho",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    loai_nhap = table.Column<long>(nullable: true),
                    id_kho = table.Column<long>(nullable: true),
                    ngay_nhap = table.Column<DateTime>(nullable: true),
                    note = table.Column<string>(nullable: true),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: true),
                    update_by = table.Column<string>(nullable: true),
                    update_date = table.Column<DateTime>(nullable: true),
                    status_del = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_erp_nhap_kho", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "erp_nhap_kho_chi_tiet",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_phieu_nhap = table.Column<long>(nullable: true),
                    id_san_pham = table.Column<long>(nullable: true),
                    so_luong = table.Column<long>(nullable: false),
                    note = table.Column<string>(nullable: true),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: true),
                    update_by = table.Column<string>(nullable: true),
                    update_date = table.Column<DateTime>(nullable: true),
                    status_del = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_erp_nhap_kho_chi_tiet", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "erp_xuat_kho",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    loai_xuat = table.Column<long>(nullable: true),
                    id_kho = table.Column<long>(nullable: true),
                    ngay_xuat = table.Column<DateTime>(nullable: true),
                    note = table.Column<string>(nullable: true),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: true),
                    update_by = table.Column<string>(nullable: true),
                    update_date = table.Column<DateTime>(nullable: true),
                    status_del = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_erp_xuat_kho", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "erp_xuat_kho_chi_tiet",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_phieu_xuat = table.Column<long>(nullable: true),
                    id_san_pham = table.Column<long>(nullable: false),
                    so_luong = table.Column<long>(nullable: false),
                    note = table.Column<string>(nullable: true),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: true),
                    update_by = table.Column<string>(nullable: true),
                    update_date = table.Column<DateTime>(nullable: true),
                    status_del = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_erp_xuat_kho_chi_tiet", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_banner",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_type = table.Column<string>(nullable: true),
                    image_web = table.Column<string>(nullable: true),
                    image_mobi = table.Column<string>(nullable: true),
                    link = table.Column<string>(nullable: true),
                    note = table.Column<string>(nullable: true),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: true),
                    update_by = table.Column<string>(nullable: true),
                    update_date = table.Column<DateTime>(nullable: true),
                    status_del = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_banner", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_color",
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
                    table.PrimaryKey("PK_sys_color", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_dieu_khoan",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    link = table.Column<string>(nullable: true),
                    stt = table.Column<int>(nullable: true),
                    note = table.Column<string>(nullable: true),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: true),
                    update_by = table.Column<string>(nullable: true),
                    update_date = table.Column<DateTime>(nullable: true),
                    status_del = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_dieu_khoan", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_don_vi_tinh",
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
                    table.PrimaryKey("PK_sys_don_vi_tinh", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_file_upload",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    controller = table.Column<string>(nullable: true),
                    id_parent = table.Column<string>(nullable: true),
                    file_type = table.Column<string>(nullable: true),
                    file_name = table.Column<string>(nullable: true),
                    file_size = table.Column<long>(nullable: false),
                    file_path = table.Column<string>(nullable: true),
                    note = table.Column<string>(nullable: true),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: true),
                    update_by = table.Column<string>(nullable: true),
                    update_date = table.Column<DateTime>(nullable: true),
                    status_del = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_file_upload", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_group_user",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    note = table.Column<string>(nullable: true),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: true),
                    update_by = table.Column<string>(nullable: true),
                    update_date = table.Column<DateTime>(nullable: true),
                    status_del = table.Column<int>(nullable: true),
                    type_user = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_group_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_group_user_detail",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_group_user = table.Column<string>(nullable: true),
                    user_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_group_user_detail", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_group_user_role",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_group_user = table.Column<string>(nullable: true),
                    id_controller_role = table.Column<string>(nullable: true),
                    controller_name = table.Column<string>(nullable: true),
                    role_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_group_user_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_kho",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    note = table.Column<string>(nullable: true),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: true),
                    update_by = table.Column<string>(nullable: true),
                    update_date = table.Column<DateTime>(nullable: true),
                    status_del = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_kho", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_lien_ket",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    link = table.Column<string>(nullable: true),
                    stt = table.Column<int>(nullable: true),
                    note = table.Column<string>(nullable: true),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: true),
                    update_by = table.Column<string>(nullable: true),
                    update_date = table.Column<DateTime>(nullable: true),
                    status_del = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_lien_ket", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_loai_san_pham",
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
                    table.PrimaryKey("PK_sys_loai_san_pham", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_ngan_hang",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    so_tai_khoan = table.Column<string>(nullable: true),
                    note = table.Column<string>(nullable: true),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: true),
                    update_by = table.Column<string>(nullable: true),
                    update_date = table.Column<DateTime>(nullable: true),
                    status_del = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_ngan_hang", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_nhan_hieu",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    image = table.Column<string>(nullable: true),
                    note = table.Column<string>(nullable: true),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: true),
                    update_by = table.Column<string>(nullable: true),
                    update_date = table.Column<DateTime>(nullable: true),
                    status_del = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_nhan_hieu", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_quan_huyen",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_quoc_gia = table.Column<long>(nullable: true),
                    id_tinh = table.Column<long>(nullable: true),
                    ten = table.Column<string>(nullable: true),
                    ten_khong_dau = table.Column<string>(nullable: true),
                    note = table.Column<string>(nullable: true),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: true),
                    update_by = table.Column<string>(nullable: true),
                    update_date = table.Column<DateTime>(nullable: true),
                    status_del = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_quan_huyen", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_quoc_gia",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ten = table.Column<string>(nullable: true),
                    ten_khong_dau = table.Column<string>(nullable: true),
                    note = table.Column<string>(nullable: true),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: true),
                    update_by = table.Column<string>(nullable: true),
                    update_date = table.Column<DateTime>(nullable: true),
                    status_del = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_quoc_gia", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_san_pham",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    id_loai_san_pham = table.Column<long>(nullable: true),
                    id_nhan_hieu = table.Column<long>(nullable: true),
                    id_don_vi_tinh = table.Column<long>(nullable: true),
                    ten_san_pham = table.Column<string>(nullable: true),
                    ma_san_pham = table.Column<string>(nullable: true),
                    hinh_anh = table.Column<string>(nullable: true),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: true),
                    update_by = table.Column<string>(nullable: true),
                    update_date = table.Column<DateTime>(nullable: true),
                    status_del = table.Column<int>(nullable: true),
                    note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_san_pham", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_san_pham_chi_tiet",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_san_pham = table.Column<string>(nullable: true),
                    id_size = table.Column<string>(nullable: true),
                    id_color = table.Column<long>(nullable: true),
                    hinh_anh = table.Column<string>(nullable: true),
                    mo_ta = table.Column<string>(nullable: true),
                    gia_ban = table.Column<decimal>(nullable: true),
                    is_noi_bac = table.Column<bool>(nullable: true),
                    is_khuyen_mai = table.Column<bool>(nullable: true),
                    qr_image = table.Column<string>(nullable: true),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: true),
                    update_by = table.Column<string>(nullable: true),
                    update_date = table.Column<DateTime>(nullable: true),
                    status_del = table.Column<int>(nullable: true),
                    note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_san_pham_chi_tiet", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_size",
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
                    table.PrimaryKey("PK_sys_size", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_tag_user",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    id_user = table.Column<string>(nullable: true),
                    title = table.Column<string>(nullable: true),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: true),
                    update_by = table.Column<string>(nullable: true),
                    update_date = table.Column<DateTime>(nullable: true),
                    status_del = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_tag_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_template_mail",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    id_type = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    template = table.Column<string>(nullable: true),
                    note = table.Column<string>(nullable: true),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: true),
                    update_by = table.Column<string>(nullable: true),
                    update_date = table.Column<DateTime>(nullable: true),
                    status_del = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_template_mail", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_thong_tin_website",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    image_logo = table.Column<string>(nullable: true),
                    image_footer = table.Column<string>(nullable: true),
                    dia_chi = table.Column<string>(nullable: true),
                    so_dien_thoai = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    link_facebook = table.Column<string>(nullable: true),
                    link_youtube = table.Column<string>(nullable: true),
                    link_linkedin = table.Column<string>(nullable: true),
                    link_instagram = table.Column<string>(nullable: true),
                    image_facebook = table.Column<string>(nullable: true),
                    image_youtube = table.Column<string>(nullable: true),
                    image_linkedin = table.Column<string>(nullable: true),
                    image_instagram = table.Column<string>(nullable: true),
                    note = table.Column<string>(nullable: true),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: true),
                    update_by = table.Column<string>(nullable: true),
                    update_date = table.Column<DateTime>(nullable: true),
                    status_del = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_thong_tin_website", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_tinh_thanh",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_quoc_gia = table.Column<long>(nullable: true),
                    ten = table.Column<string>(nullable: true),
                    ten_khong_dau = table.Column<string>(nullable: true),
                    note = table.Column<string>(nullable: true),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: true),
                    update_by = table.Column<string>(nullable: true),
                    update_date = table.Column<DateTime>(nullable: true),
                    status_del = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_tinh_thanh", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_type_mail",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
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
                    table.PrimaryKey("PK_sys_type_mail", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_user",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    type = table.Column<int>(nullable: true),
                    phuong_thuc_thanh_toan = table.Column<int>(nullable: true),
                    full_name = table.Column<string>(nullable: true),
                    first_name = table.Column<string>(nullable: true),
                    last_name = table.Column<string>(nullable: true),
                    user_name = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    token_reset_pass = table.Column<string>(nullable: true),
                    expiration_date_reset_pass = table.Column<DateTime>(nullable: true),
                    id_department = table.Column<string>(nullable: true),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: true),
                    update_by = table.Column<string>(nullable: true),
                    update_date = table.Column<DateTime>(nullable: true),
                    status_del = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_user_nhan_hang",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    id_tinh = table.Column<long>(nullable: true),
                    id_quan = table.Column<long>(nullable: true),
                    dia_chi_cu_the = table.Column<string>(nullable: true),
                    id_user = table.Column<string>(nullable: true),
                    full_name = table.Column<string>(nullable: true),
                    first_name = table.Column<string>(nullable: true),
                    last_name = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    note = table.Column<string>(nullable: true),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: true),
                    update_by = table.Column<string>(nullable: true),
                    update_date = table.Column<DateTime>(nullable: true),
                    status_del = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_user_nhan_hang", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_vat",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    value = table.Column<long>(nullable: true),
                    note = table.Column<string>(nullable: true),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: true),
                    update_by = table.Column<string>(nullable: true),
                    update_date = table.Column<DateTime>(nullable: true),
                    status_del = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_vat", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "erp_don_hang_ban");

            migrationBuilder.DropTable(
                name: "erp_don_hang_ban_chi_tiet");

            migrationBuilder.DropTable(
                name: "erp_don_hang_mua");

            migrationBuilder.DropTable(
                name: "erp_don_hang_mua_chi_tiet");

            migrationBuilder.DropTable(
                name: "erp_don_vi_van_chuyen");

            migrationBuilder.DropTable(
                name: "erp_loai_nhap_xuat");

            migrationBuilder.DropTable(
                name: "erp_nhap_kho");

            migrationBuilder.DropTable(
                name: "erp_nhap_kho_chi_tiet");

            migrationBuilder.DropTable(
                name: "erp_xuat_kho");

            migrationBuilder.DropTable(
                name: "erp_xuat_kho_chi_tiet");

            migrationBuilder.DropTable(
                name: "sys_banner");

            migrationBuilder.DropTable(
                name: "sys_color");

            migrationBuilder.DropTable(
                name: "sys_dieu_khoan");

            migrationBuilder.DropTable(
                name: "sys_don_vi_tinh");

            migrationBuilder.DropTable(
                name: "sys_file_upload");

            migrationBuilder.DropTable(
                name: "sys_group_user");

            migrationBuilder.DropTable(
                name: "sys_group_user_detail");

            migrationBuilder.DropTable(
                name: "sys_group_user_role");

            migrationBuilder.DropTable(
                name: "sys_kho");

            migrationBuilder.DropTable(
                name: "sys_lien_ket");

            migrationBuilder.DropTable(
                name: "sys_loai_san_pham");

            migrationBuilder.DropTable(
                name: "sys_ngan_hang");

            migrationBuilder.DropTable(
                name: "sys_nhan_hieu");

            migrationBuilder.DropTable(
                name: "sys_quan_huyen");

            migrationBuilder.DropTable(
                name: "sys_quoc_gia");

            migrationBuilder.DropTable(
                name: "sys_san_pham");

            migrationBuilder.DropTable(
                name: "sys_san_pham_chi_tiet");

            migrationBuilder.DropTable(
                name: "sys_size");

            migrationBuilder.DropTable(
                name: "sys_tag_user");

            migrationBuilder.DropTable(
                name: "sys_template_mail");

            migrationBuilder.DropTable(
                name: "sys_thong_tin_website");

            migrationBuilder.DropTable(
                name: "sys_tinh_thanh");

            migrationBuilder.DropTable(
                name: "sys_type_mail");

            migrationBuilder.DropTable(
                name: "sys_user");

            migrationBuilder.DropTable(
                name: "sys_user_nhan_hang");

            migrationBuilder.DropTable(
                name: "sys_vat");
        }
    }
}
