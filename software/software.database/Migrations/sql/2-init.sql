IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [erp_don_hang_ban] (
    [id] bigint NOT NULL IDENTITY,
    [code] nvarchar(max) NULL,
    [name] nvarchar(max) NULL,
    [loai_don_hang] bigint NULL,
    [note] nvarchar(max) NULL,
    [ngay_dat_hang] datetime2 NULL,
    [phuong_thuc_thanh_toan] int NULL,
    [loai_chuyen_khoan] int NULL,
    [thanh_tien_truoc_thue] decimal(18,2) NULL,
    [thanh_tien_sau_thue] decimal(18,2) NULL,
    [tien_thue] decimal(18,2) NULL,
    [ty_le_vat] int NULL,
    [id_ty_le_vat] bigint NULL,
    [trang_thai_thanh_toan] bit NULL,
    [trang_thai_xuat_hang] bit NULL,
    [so_ngay_du_kien_giao] int NULL,
    [ngay_du_kien_giao] datetime2 NULL,
    [thanh_tien_van_chuyen_truoc_thue] decimal(18,2) NULL,
    [thanh_tien_van_chuyen_sau_thue] decimal(18,2) NULL,
    [tien_thue_van_chuyen] decimal(18,2) NULL,
    [ty_le_vat_van_chuyen] int NULL,
    [id_ty_le_vat_van_chuyen] bigint NULL,
    [id_don_vi_van_chuyen] bigint NULL,
    [ma_don_van_chuyen] nvarchar(max) NULL,
    [id_tinh_khach_hang_nhan] bigint NULL,
    [id_quan_khach_hang_nhan] bigint NULL,
    [dia_chi_cu_the_khach_hang_nhan] nvarchar(max) NULL,
    [full_name_khach_hang_nhan] nvarchar(max) NULL,
    [first_name_khach_hang_nhan] nvarchar(max) NULL,
    [last_name_khach_hang_nhan] nvarchar(max) NULL,
    [email_khach_hang_nhan] nvarchar(max) NULL,
    [phone_khach_hang_nhan] nvarchar(max) NULL,
    [id_quan_khach_hang_dat] bigint NULL,
    [id_tinh_khach_hang_dat] bigint NULL,
    [dia_chi_cu_the_khach_hang_dat] nvarchar(max) NULL,
    [full_name_khach_hang_dat] nvarchar(max) NULL,
    [first_name_khach_hang_dat] nvarchar(max) NULL,
    [last_name_khach_hang_dat] nvarchar(max) NULL,
    [email_khach_hang_dat] nvarchar(max) NULL,
    [phone_khach_hang_dat] nvarchar(max) NULL,
    [create_by] nvarchar(max) NULL,
    [create_date] datetime2 NULL,
    [update_by] nvarchar(max) NULL,
    [update_date] datetime2 NULL,
    [status_del] int NULL,
    CONSTRAINT [PK_erp_don_hang_ban] PRIMARY KEY ([id])
);

GO

CREATE TABLE [erp_don_hang_ban_chi_tiet] (
    [id] bigint NOT NULL IDENTITY,
    [id_don_hang] bigint NULL,
    [id_san_pham] bigint NOT NULL,
    [so_luong] bigint NOT NULL,
    [don_gia] decimal(18,2) NULL,
    [thanh_tien] decimal(18,2) NULL,
    [chiet_khau] int NULL,
    [id_chiet_khau] bigint NULL,
    [note] nvarchar(max) NULL,
    [create_by] nvarchar(max) NULL,
    [create_date] datetime2 NULL,
    [update_by] nvarchar(max) NULL,
    [update_date] datetime2 NULL,
    [status_del] int NULL,
    CONSTRAINT [PK_erp_don_hang_ban_chi_tiet] PRIMARY KEY ([id])
);

GO

CREATE TABLE [erp_don_hang_mua] (
    [id] bigint NOT NULL IDENTITY,
    [code] nvarchar(max) NULL,
    [name] nvarchar(max) NULL,
    [loai_don_hang] bigint NULL,
    [note] nvarchar(max) NULL,
    [ngay_dat_hang] datetime2 NULL,
    [phuong_thuc_thanh_toan] int NULL,
    [thanh_tien_truoc_thue] decimal(18,2) NULL,
    [thanh_tien_sau_thue] decimal(18,2) NULL,
    [tien_thue] decimal(18,2) NULL,
    [ty_le_vat] int NULL,
    [id_ty_le_vat] bigint NULL,
    [trang_thai_thanh_toan] bit NULL,
    [trang_thai_xuat_hang] bit NULL,
    [so_ngay_du_kien_giao] int NULL,
    [ngay_du_kien_giao] datetime2 NULL,
    [thanh_tien_van_chuyen_truoc_thue] decimal(18,2) NULL,
    [thanh_tien_van_chuyen_sau_thue] decimal(18,2) NULL,
    [tien_thue_van_chuyen] decimal(18,2) NULL,
    [ty_le_vat_van_chuyen] int NULL,
    [id_ty_le_vat_van_chuyen] bigint NULL,
    [id_tinh_khach_hang_nhan] bigint NULL,
    [id_quan_khach_hang_nhan] bigint NULL,
    [dia_chi_cu_the_khach_hang_nhan] nvarchar(max) NULL,
    [full_name_khach_hang_nhan] nvarchar(max) NULL,
    [first_name_khach_hang_nhan] nvarchar(max) NULL,
    [last_name_khach_hang_nhan] nvarchar(max) NULL,
    [email_khach_hang_nhan] nvarchar(max) NULL,
    [phone_khach_hang_nhan] nvarchar(max) NULL,
    [id_quan_khach_hang_dat] bigint NULL,
    [id_tinh_khach_hang_dat] bigint NULL,
    [dia_chi_cu_the_khach_hang_dat] nvarchar(max) NULL,
    [full_name_khach_hang_dat] nvarchar(max) NULL,
    [first_name_khach_hang_dat] nvarchar(max) NULL,
    [last_name_khach_hang_dat] nvarchar(max) NULL,
    [email_khach_hang_dat] nvarchar(max) NULL,
    [phone_khach_hang_dat] nvarchar(max) NULL,
    [create_by] nvarchar(max) NULL,
    [create_date] datetime2 NULL,
    [update_by] nvarchar(max) NULL,
    [update_date] datetime2 NULL,
    [status_del] int NULL,
    CONSTRAINT [PK_erp_don_hang_mua] PRIMARY KEY ([id])
);

GO

CREATE TABLE [erp_don_hang_mua_chi_tiet] (
    [id] bigint NOT NULL IDENTITY,
    [id_don_hang] bigint NULL,
    [id_san_pham] bigint NOT NULL,
    [so_luong] bigint NOT NULL,
    [don_gia] decimal(18,2) NULL,
    [thanh_tien] decimal(18,2) NULL,
    [chiet_khau] int NULL,
    [id_chiet_khau] bigint NULL,
    [note] nvarchar(max) NULL,
    [create_by] nvarchar(max) NULL,
    [create_date] datetime2 NULL,
    [update_by] nvarchar(max) NULL,
    [update_date] datetime2 NULL,
    [status_del] int NULL,
    CONSTRAINT [PK_erp_don_hang_mua_chi_tiet] PRIMARY KEY ([id])
);

GO

CREATE TABLE [erp_don_vi_van_chuyen] (
    [id] bigint NOT NULL IDENTITY,
    [code] nvarchar(max) NULL,
    [name] nvarchar(max) NULL,
    [note] nvarchar(max) NULL,
    [create_by] nvarchar(max) NULL,
    [create_date] datetime2 NULL,
    [update_by] nvarchar(max) NULL,
    [update_date] datetime2 NULL,
    [status_del] int NULL,
    CONSTRAINT [PK_erp_don_vi_van_chuyen] PRIMARY KEY ([id])
);

GO

CREATE TABLE [erp_loai_nhap_xuat] (
    [id] bigint NOT NULL IDENTITY,
    [code] nvarchar(max) NULL,
    [name] nvarchar(max) NULL,
    [loai_nhap_xuat] nvarchar(max) NULL,
    [nguon] int NOT NULL,
    [note] nvarchar(max) NULL,
    [create_by] nvarchar(max) NULL,
    [create_date] datetime2 NULL,
    [update_by] nvarchar(max) NULL,
    [update_date] datetime2 NULL,
    [status_del] int NULL,
    CONSTRAINT [PK_erp_loai_nhap_xuat] PRIMARY KEY ([id])
);

GO

CREATE TABLE [erp_nhap_kho] (
    [id] bigint NOT NULL IDENTITY,
    [code] nvarchar(max) NULL,
    [name] nvarchar(max) NULL,
    [loai_nhap] bigint NULL,
    [id_kho] bigint NULL,
    [ngay_nhap] datetime2 NULL,
    [note] nvarchar(max) NULL,
    [create_by] nvarchar(max) NULL,
    [create_date] datetime2 NULL,
    [update_by] nvarchar(max) NULL,
    [update_date] datetime2 NULL,
    [status_del] int NULL,
    CONSTRAINT [PK_erp_nhap_kho] PRIMARY KEY ([id])
);

GO

CREATE TABLE [erp_nhap_kho_chi_tiet] (
    [id] bigint NOT NULL IDENTITY,
    [id_phieu_nhap] bigint NULL,
    [id_san_pham] bigint NULL,
    [so_luong] bigint NOT NULL,
    [note] nvarchar(max) NULL,
    [create_by] nvarchar(max) NULL,
    [create_date] datetime2 NULL,
    [update_by] nvarchar(max) NULL,
    [update_date] datetime2 NULL,
    [status_del] int NULL,
    CONSTRAINT [PK_erp_nhap_kho_chi_tiet] PRIMARY KEY ([id])
);

GO

CREATE TABLE [erp_xuat_kho] (
    [id] bigint NOT NULL IDENTITY,
    [code] nvarchar(max) NULL,
    [name] nvarchar(max) NULL,
    [loai_xuat] bigint NULL,
    [id_kho] bigint NULL,
    [ngay_xuat] datetime2 NULL,
    [note] nvarchar(max) NULL,
    [create_by] nvarchar(max) NULL,
    [create_date] datetime2 NULL,
    [update_by] nvarchar(max) NULL,
    [update_date] datetime2 NULL,
    [status_del] int NULL,
    CONSTRAINT [PK_erp_xuat_kho] PRIMARY KEY ([id])
);

GO

CREATE TABLE [erp_xuat_kho_chi_tiet] (
    [id] bigint NOT NULL IDENTITY,
    [id_phieu_xuat] bigint NULL,
    [id_san_pham] bigint NOT NULL,
    [so_luong] bigint NOT NULL,
    [note] nvarchar(max) NULL,
    [create_by] nvarchar(max) NULL,
    [create_date] datetime2 NULL,
    [update_by] nvarchar(max) NULL,
    [update_date] datetime2 NULL,
    [status_del] int NULL,
    CONSTRAINT [PK_erp_xuat_kho_chi_tiet] PRIMARY KEY ([id])
);

GO

CREATE TABLE [sys_banner] (
    [id] bigint NOT NULL IDENTITY,
    [id_type] nvarchar(max) NULL,
    [image_web] nvarchar(max) NULL,
    [image_mobi] nvarchar(max) NULL,
    [link] nvarchar(max) NULL,
    [note] nvarchar(max) NULL,
    [create_by] nvarchar(max) NULL,
    [create_date] datetime2 NULL,
    [update_by] nvarchar(max) NULL,
    [update_date] datetime2 NULL,
    [status_del] int NULL,
    CONSTRAINT [PK_sys_banner] PRIMARY KEY ([id])
);

GO

CREATE TABLE [sys_color] (
    [id] bigint NOT NULL IDENTITY,
    [code] nvarchar(max) NULL,
    [name] nvarchar(max) NULL,
    [note] nvarchar(max) NULL,
    [create_by] nvarchar(max) NULL,
    [create_date] datetime2 NULL,
    [update_by] nvarchar(max) NULL,
    [update_date] datetime2 NULL,
    [status_del] int NULL,
    CONSTRAINT [PK_sys_color] PRIMARY KEY ([id])
);

GO

CREATE TABLE [sys_dieu_khoan] (
    [id] bigint NOT NULL IDENTITY,
    [code] nvarchar(max) NULL,
    [name] nvarchar(max) NULL,
    [link] nvarchar(max) NULL,
    [stt] int NULL,
    [note] nvarchar(max) NULL,
    [create_by] nvarchar(max) NULL,
    [create_date] datetime2 NULL,
    [update_by] nvarchar(max) NULL,
    [update_date] datetime2 NULL,
    [status_del] int NULL,
    CONSTRAINT [PK_sys_dieu_khoan] PRIMARY KEY ([id])
);

GO

CREATE TABLE [sys_don_vi_tinh] (
    [id] bigint NOT NULL IDENTITY,
    [code] nvarchar(max) NULL,
    [name] nvarchar(max) NULL,
    [note] nvarchar(max) NULL,
    [create_by] nvarchar(max) NULL,
    [create_date] datetime2 NULL,
    [update_by] nvarchar(max) NULL,
    [update_date] datetime2 NULL,
    [status_del] int NULL,
    CONSTRAINT [PK_sys_don_vi_tinh] PRIMARY KEY ([id])
);

GO

CREATE TABLE [sys_file_upload] (
    [id] bigint NOT NULL IDENTITY,
    [controller] nvarchar(max) NULL,
    [id_parent] nvarchar(max) NULL,
    [file_type] nvarchar(max) NULL,
    [file_name] nvarchar(max) NULL,
    [file_size] bigint NOT NULL,
    [file_path] nvarchar(max) NULL,
    [note] nvarchar(max) NULL,
    [create_by] nvarchar(max) NULL,
    [create_date] datetime2 NULL,
    [update_by] nvarchar(max) NULL,
    [update_date] datetime2 NULL,
    [status_del] int NULL,
    CONSTRAINT [PK_sys_file_upload] PRIMARY KEY ([id])
);

GO

CREATE TABLE [sys_group_user] (
    [id] nvarchar(450) NOT NULL,
    [name] nvarchar(max) NULL,
    [note] nvarchar(max) NULL,
    [create_by] nvarchar(max) NULL,
    [create_date] datetime2 NULL,
    [update_by] nvarchar(max) NULL,
    [update_date] datetime2 NULL,
    [status_del] int NULL,
    [type_user] int NULL,
    CONSTRAINT [PK_sys_group_user] PRIMARY KEY ([id])
);

GO

CREATE TABLE [sys_group_user_detail] (
    [id] bigint NOT NULL IDENTITY,
    [id_group_user] nvarchar(max) NULL,
    [user_id] nvarchar(max) NULL,
    CONSTRAINT [PK_sys_group_user_detail] PRIMARY KEY ([id])
);

GO

CREATE TABLE [sys_group_user_role] (
    [id] bigint NOT NULL IDENTITY,
    [id_group_user] nvarchar(max) NULL,
    [id_controller_role] nvarchar(max) NULL,
    [controller_name] nvarchar(max) NULL,
    [role_name] nvarchar(max) NULL,
    CONSTRAINT [PK_sys_group_user_role] PRIMARY KEY ([id])
);

GO

CREATE TABLE [sys_kho] (
    [id] bigint NOT NULL IDENTITY,
    [code] nvarchar(max) NULL,
    [name] nvarchar(max) NULL,
    [address] nvarchar(max) NULL,
    [note] nvarchar(max) NULL,
    [create_by] nvarchar(max) NULL,
    [create_date] datetime2 NULL,
    [update_by] nvarchar(max) NULL,
    [update_date] datetime2 NULL,
    [status_del] int NULL,
    CONSTRAINT [PK_sys_kho] PRIMARY KEY ([id])
);

GO

CREATE TABLE [sys_lien_ket] (
    [id] bigint NOT NULL IDENTITY,
    [code] nvarchar(max) NULL,
    [name] nvarchar(max) NULL,
    [link] nvarchar(max) NULL,
    [stt] int NULL,
    [note] nvarchar(max) NULL,
    [create_by] nvarchar(max) NULL,
    [create_date] datetime2 NULL,
    [update_by] nvarchar(max) NULL,
    [update_date] datetime2 NULL,
    [status_del] int NULL,
    CONSTRAINT [PK_sys_lien_ket] PRIMARY KEY ([id])
);

GO

CREATE TABLE [sys_loai_san_pham] (
    [id] bigint NOT NULL IDENTITY,
    [code] nvarchar(max) NULL,
    [name] nvarchar(max) NULL,
    [note] nvarchar(max) NULL,
    [create_by] nvarchar(max) NULL,
    [create_date] datetime2 NULL,
    [update_by] nvarchar(max) NULL,
    [update_date] datetime2 NULL,
    [status_del] int NULL,
    CONSTRAINT [PK_sys_loai_san_pham] PRIMARY KEY ([id])
);

GO

CREATE TABLE [sys_ngan_hang] (
    [id] bigint NOT NULL IDENTITY,
    [code] nvarchar(max) NULL,
    [name] nvarchar(max) NULL,
    [so_tai_khoan] nvarchar(max) NULL,
    [note] nvarchar(max) NULL,
    [create_by] nvarchar(max) NULL,
    [create_date] datetime2 NULL,
    [update_by] nvarchar(max) NULL,
    [update_date] datetime2 NULL,
    [status_del] int NULL,
    CONSTRAINT [PK_sys_ngan_hang] PRIMARY KEY ([id])
);

GO

CREATE TABLE [sys_nhan_hieu] (
    [id] bigint NOT NULL IDENTITY,
    [code] nvarchar(max) NULL,
    [name] nvarchar(max) NULL,
    [image] nvarchar(max) NULL,
    [note] nvarchar(max) NULL,
    [create_by] nvarchar(max) NULL,
    [create_date] datetime2 NULL,
    [update_by] nvarchar(max) NULL,
    [update_date] datetime2 NULL,
    [status_del] int NULL,
    CONSTRAINT [PK_sys_nhan_hieu] PRIMARY KEY ([id])
);

GO

CREATE TABLE [sys_quan_huyen] (
    [id] bigint NOT NULL IDENTITY,
    [id_quoc_gia] bigint NULL,
    [id_tinh] bigint NULL,
    [ten] nvarchar(max) NULL,
    [ten_khong_dau] nvarchar(max) NULL,
    [note] nvarchar(max) NULL,
    [create_by] nvarchar(max) NULL,
    [create_date] datetime2 NULL,
    [update_by] nvarchar(max) NULL,
    [update_date] datetime2 NULL,
    [status_del] int NULL,
    CONSTRAINT [PK_sys_quan_huyen] PRIMARY KEY ([id])
);

GO

CREATE TABLE [sys_quoc_gia] (
    [id] bigint NOT NULL IDENTITY,
    [ten] nvarchar(max) NULL,
    [ten_khong_dau] nvarchar(max) NULL,
    [note] nvarchar(max) NULL,
    [create_by] nvarchar(max) NULL,
    [create_date] datetime2 NULL,
    [update_by] nvarchar(max) NULL,
    [update_date] datetime2 NULL,
    [status_del] int NULL,
    CONSTRAINT [PK_sys_quoc_gia] PRIMARY KEY ([id])
);

GO

CREATE TABLE [sys_san_pham] (
    [id] nvarchar(450) NOT NULL,
    [id_loai_san_pham] bigint NULL,
    [id_nhan_hieu] bigint NULL,
    [id_don_vi_tinh] bigint NULL,
    [ten_san_pham] nvarchar(max) NULL,
    [ma_san_pham] nvarchar(max) NULL,
    [hinh_anh] nvarchar(max) NULL,
    [create_by] nvarchar(max) NULL,
    [create_date] datetime2 NULL,
    [update_by] nvarchar(max) NULL,
    [update_date] datetime2 NULL,
    [status_del] int NULL,
    [note] nvarchar(max) NULL,
    CONSTRAINT [PK_sys_san_pham] PRIMARY KEY ([id])
);

GO

CREATE TABLE [sys_san_pham_chi_tiet] (
    [id] bigint NOT NULL IDENTITY,
    [id_san_pham] nvarchar(max) NULL,
    [id_size] nvarchar(max) NULL,
    [id_color] bigint NULL,
    [hinh_anh] nvarchar(max) NULL,
    [mo_ta] nvarchar(max) NULL,
    [gia_ban] decimal(18,2) NULL,
    [is_noi_bac] bit NULL,
    [is_khuyen_mai] bit NULL,
    [qr_image] nvarchar(max) NULL,
    [create_by] nvarchar(max) NULL,
    [create_date] datetime2 NULL,
    [update_by] nvarchar(max) NULL,
    [update_date] datetime2 NULL,
    [status_del] int NULL,
    [note] nvarchar(max) NULL,
    CONSTRAINT [PK_sys_san_pham_chi_tiet] PRIMARY KEY ([id])
);

GO

CREATE TABLE [sys_size] (
    [id] bigint NOT NULL IDENTITY,
    [code] nvarchar(max) NULL,
    [name] nvarchar(max) NULL,
    [note] nvarchar(max) NULL,
    [create_by] nvarchar(max) NULL,
    [create_date] datetime2 NULL,
    [update_by] nvarchar(max) NULL,
    [update_date] datetime2 NULL,
    [status_del] int NULL,
    CONSTRAINT [PK_sys_size] PRIMARY KEY ([id])
);

GO

CREATE TABLE [sys_tag_user] (
    [id] nvarchar(450) NOT NULL,
    [id_user] nvarchar(max) NULL,
    [title] nvarchar(max) NULL,
    [create_by] nvarchar(max) NULL,
    [create_date] datetime2 NULL,
    [update_by] nvarchar(max) NULL,
    [update_date] datetime2 NULL,
    [status_del] int NULL,
    CONSTRAINT [PK_sys_tag_user] PRIMARY KEY ([id])
);

GO

CREATE TABLE [sys_template_mail] (
    [id] nvarchar(450) NOT NULL,
    [id_type] nvarchar(max) NULL,
    [name] nvarchar(max) NULL,
    [template] nvarchar(max) NULL,
    [note] nvarchar(max) NULL,
    [create_by] nvarchar(max) NULL,
    [create_date] datetime2 NULL,
    [update_by] nvarchar(max) NULL,
    [update_date] datetime2 NULL,
    [status_del] int NULL,
    CONSTRAINT [PK_sys_template_mail] PRIMARY KEY ([id])
);

GO

CREATE TABLE [sys_thong_tin_website] (
    [id] bigint NOT NULL IDENTITY,
    [image_logo] nvarchar(max) NULL,
    [image_footer] nvarchar(max) NULL,
    [dia_chi] nvarchar(max) NULL,
    [so_dien_thoai] nvarchar(max) NULL,
    [email] nvarchar(max) NULL,
    [link_facebook] nvarchar(max) NULL,
    [link_youtube] nvarchar(max) NULL,
    [link_linkedin] nvarchar(max) NULL,
    [link_instagram] nvarchar(max) NULL,
    [image_facebook] nvarchar(max) NULL,
    [image_youtube] nvarchar(max) NULL,
    [image_linkedin] nvarchar(max) NULL,
    [image_instagram] nvarchar(max) NULL,
    [note] nvarchar(max) NULL,
    [create_by] nvarchar(max) NULL,
    [create_date] datetime2 NULL,
    [update_by] nvarchar(max) NULL,
    [update_date] datetime2 NULL,
    [status_del] int NULL,
    CONSTRAINT [PK_sys_thong_tin_website] PRIMARY KEY ([id])
);

GO

CREATE TABLE [sys_tinh_thanh] (
    [id] bigint NOT NULL IDENTITY,
    [id_quoc_gia] bigint NULL,
    [ten] nvarchar(max) NULL,
    [ten_khong_dau] nvarchar(max) NULL,
    [note] nvarchar(max) NULL,
    [create_by] nvarchar(max) NULL,
    [create_date] datetime2 NULL,
    [update_by] nvarchar(max) NULL,
    [update_date] datetime2 NULL,
    [status_del] int NULL,
    CONSTRAINT [PK_sys_tinh_thanh] PRIMARY KEY ([id])
);

GO

CREATE TABLE [sys_type_mail] (
    [id] nvarchar(450) NOT NULL,
    [code] nvarchar(max) NULL,
    [name] nvarchar(max) NULL,
    [note] nvarchar(max) NULL,
    [create_by] nvarchar(max) NULL,
    [create_date] datetime2 NULL,
    [update_by] nvarchar(max) NULL,
    [update_date] datetime2 NULL,
    [status_del] int NULL,
    CONSTRAINT [PK_sys_type_mail] PRIMARY KEY ([id])
);

GO

CREATE TABLE [sys_user] (
    [id] nvarchar(450) NOT NULL,
    [type] int NULL,
    [phuong_thuc_thanh_toan] int NULL,
    [full_name] nvarchar(max) NULL,
    [first_name] nvarchar(max) NULL,
    [last_name] nvarchar(max) NULL,
    [user_name] nvarchar(max) NULL,
    [email] nvarchar(max) NULL,
    [phone] nvarchar(max) NULL,
    [PasswordHash] varbinary(max) NULL,
    [PasswordSalt] varbinary(max) NULL,
    [token_reset_pass] nvarchar(max) NULL,
    [expiration_date_reset_pass] datetime2 NULL,
    [id_department] nvarchar(max) NULL,
    [create_by] nvarchar(max) NULL,
    [create_date] datetime2 NULL,
    [update_by] nvarchar(max) NULL,
    [update_date] datetime2 NULL,
    [status_del] int NULL,
    CONSTRAINT [PK_sys_user] PRIMARY KEY ([id])
);

GO

CREATE TABLE [sys_user_nhan_hang] (
    [id] nvarchar(450) NOT NULL,
    [id_tinh] bigint NULL,
    [id_quan] bigint NULL,
    [dia_chi_cu_the] nvarchar(max) NULL,
    [id_user] nvarchar(max) NULL,
    [full_name] nvarchar(max) NULL,
    [first_name] nvarchar(max) NULL,
    [last_name] nvarchar(max) NULL,
    [email] nvarchar(max) NULL,
    [phone] nvarchar(max) NULL,
    [note] nvarchar(max) NULL,
    [create_by] nvarchar(max) NULL,
    [create_date] datetime2 NULL,
    [update_by] nvarchar(max) NULL,
    [update_date] datetime2 NULL,
    [status_del] int NULL,
    CONSTRAINT [PK_sys_user_nhan_hang] PRIMARY KEY ([id])
);

GO

CREATE TABLE [sys_vat] (
    [id] bigint NOT NULL IDENTITY,
    [code] nvarchar(max) NULL,
    [name] nvarchar(max) NULL,
    [value] bigint NULL,
    [note] nvarchar(max) NULL,
    [create_by] nvarchar(max) NULL,
    [create_date] datetime2 NULL,
    [update_by] nvarchar(max) NULL,
    [update_date] datetime2 NULL,
    [status_del] int NULL,
    CONSTRAINT [PK_sys_vat] PRIMARY KEY ([id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231214100641_Init', N'3.1.1');

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231214102441_Init2', N'3.1.1');

GO

ALTER TABLE [erp_don_hang_ban] ADD [id_ngan_hang] bigint NULL;

GO

CREATE TABLE [sys_tai_san] (
    [id] bigint NOT NULL IDENTITY,
    [code] nvarchar(max) NULL,
    [name] nvarchar(max) NULL,
    [note] nvarchar(max) NULL,
    [create_by] nvarchar(max) NULL,
    [create_date] datetime2 NULL,
    [update_by] nvarchar(max) NULL,
    [update_date] datetime2 NULL,
    [status_del] int NULL,
    CONSTRAINT [PK_sys_tai_san] PRIMARY KEY ([id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231216082046_Init3', N'3.1.1');

GO

