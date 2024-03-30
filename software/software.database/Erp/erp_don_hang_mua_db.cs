﻿using software.database.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace software.database.System
{
    [Table("erp_don_hang_mua")]
    public class erp_don_hang_mua_db : IBaseCommon
    {
        public long id { get; set; }
        // thông tin đơn hàng
        public string code { get; set; }
        public string name { get; set; }
        /// <summary>
        /// 1: hàng hóa
        /// 2: dịch vụ
        /// </summary>
        public long? loai_don_hang { get; set; }
        public string note { get; set; }
        public DateTime? ngay_dat_hang { get; set; }
        /// <summary>
        /// 1: tiền mặt
        /// 2: chuyển khoản
        /// </summary>
        public int? phuong_thuc_thanh_toan { get; set; }
        // chiết khấu đơn hàng hoặc voucher hoặc mã giảm giá hoặc khuyến mãi

        // thành tiền đơn hàng
        public decimal? thanh_tien_truoc_thue { get; set; }
        public decimal? thanh_tien_sau_thue { get; set; }
        public decimal? tien_thue { get; set; }
        public int? ty_le_vat { get; set; }
        public long? id_ty_le_vat { get; set; }
        // trạng thái đơn hàng
        public bool? trang_thai_thanh_toan { get; set; }
        public bool? trang_thai_xuat_hang { get; set; }
        // thông tin giao hàng
        public int? so_ngay_du_kien_giao { get; set; }
        public DateTime? ngay_du_kien_giao { get; set; }
        public decimal? thanh_tien_van_chuyen_truoc_thue { get; set; }
        public decimal? thanh_tien_van_chuyen_sau_thue { get; set; }
        public decimal? tien_thue_van_chuyen { get; set; }
        public int? ty_le_vat_van_chuyen { get; set; }
        public long? id_ty_le_vat_van_chuyen { get; set; }
        // thông tin khách hàng đặt
        public long? id_tinh_khach_hang_nhan { get; set; }
        public long? id_quan_khach_hang_nhan { get; set; }
        public string dia_chi_cu_the_khach_hang_nhan { get; set; }
        public string full_name_khach_hang_nhan { get; set; }
        public string first_name_khach_hang_nhan { get; set; }
        public string last_name_khach_hang_nhan { get; set; }
        public string email_khach_hang_nhan { get; set; }
        public string phone_khach_hang_nhan { get; set; }
        // thông tin khách hàng nhận
        public long? id_quan_khach_hang_dat { get; set; }
        public long? id_tinh_khach_hang_dat { get; set; }
        public string dia_chi_cu_the_khach_hang_dat { get; set; }
        public string full_name_khach_hang_dat { get; set; }
        public string first_name_khach_hang_dat { get; set; }
        public string last_name_khach_hang_dat { get; set; }
        public string email_khach_hang_dat { get; set; }
        public string phone_khach_hang_dat { get; set; }
        public string create_by { get; set; }
        public DateTime? create_date { get; set; }
        public string update_by { get; set; }
        public DateTime? update_date { get; set; }
        public int? status_del { get; set; }
    }
}
