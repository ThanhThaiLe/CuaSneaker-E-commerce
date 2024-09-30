using Microsoft.EntityFrameworkCore;
using software.database.Provider;
using software.repo.erp.DataAccess;

namespace software.repo.erp.Repo
{
    public class erp_don_hang_ban_repo
    {
        public SoftwareDefautTable _context;
        public erp_don_hang_ban_chi_tiet_repo _erp_don_hang_ban_chi_tiet_repo;
        public erp_don_hang_ban_repo(SoftwareDefautTable context)
        {
            _context = context;
            _erp_don_hang_ban_chi_tiet_repo = new erp_don_hang_ban_chi_tiet_repo(context);
        }
        public async Task<erp_don_hang_ban_model> getElementById(string id)
        {
            var model = await FindAll().FirstOrDefaultAsync(q => q.db.id == id);
            return model;
        }
        public string getPhuongThucThanhToan(erp_don_hang_ban_model model)
        {
            string name = "";

            switch (model.db.phuong_thuc_thanh_toan)
            {
                case 1:
                    name = "Tiền mặt";
                    break;
                case 2:
                    var ngan_hang = _context.sys_ngan_hangs.Where(q => q.id == model.db.id_ngan_hang).SingleOrDefault();
                    name = "Chuyển khoản " + ngan_hang.code + " " + ngan_hang.name + " " + ngan_hang.so_tai_khoan;
                    break;
                default:
                    name = "No data";
                    break;
            }
            return name;
        }
        public string getNameDonViVanChuyen(erp_don_hang_ban_model model)
        {
            string name = "";
            switch (model.db.id_don_vi_van_chuyen)
            {
                case null:
                    name = "Không giao_hang";
                    break;
                case 2:
                    var don_vi_van_chuyen = _context.erp_don_vi_van_chuyens.Where(q => q.id == model.db.id_don_vi_van_chuyen).SingleOrDefault();
                    name = don_vi_van_chuyen.code + " " + don_vi_van_chuyen.name + " " + model.db.thanh_tien_van_chuyen_sau_thue.ToString();
                    break;
                default:
                    break;
            }
            return name;
        }
        public string getNameDonHang(erp_don_hang_ban_model model)
        {
            string name = "";
            string loai_don_hang = "Đơn hàng bán ";
            string ten_khach_hang_dat = "Người đặt " + model.db.full_name_khach_hang_dat + " ";
            string ten_khach_hang_nhan = "Người nhận " + model.db.full_name_khach_hang_nhan + " ";
            string phuong_thuc_thanh_toan = getPhuongThucThanhToan(model) + " ";
            string don_vi_van_chuyen = getNameDonViVanChuyen(model) + " ";
            name = loai_don_hang + model.db.code + " " + model.db.ngay_dat_hang.Value.ToString("ddMMyyyy") + " " + ten_khach_hang_dat + ten_khach_hang_nhan + don_vi_van_chuyen + phuong_thuc_thanh_toan + model.db.thanh_tien_sau_thue.ToString();
            return name;
        }
        public async Task<int> insert(erp_don_hang_ban_model model)
        {
            model.db.full_name_khach_hang_dat = model.db.first_name_khach_hang_dat + " " + model.db.last_name_khach_hang_dat;
            model.db.full_name_khach_hang_nhan = model.db.first_name_khach_hang_nhan + " " + model.db.last_name_khach_hang_nhan;
            model.db.name = getNameDonHang(model);
            _context.erp_don_hang_bans.Add(model.db);
            _context.SaveChanges();
            return 1;
        }
        public async Task<int> update(erp_don_hang_ban_model model)
        {
            var db = await _context.erp_don_hang_bans.Where(q => q.id == model.db.id).FirstOrDefaultAsync();
            db.name = model.db.name;
            db.code = model.db.code;
            db.status_del = model.db.status_del;
            db.note = model.db.note;
            db.update_date = model.db.update_date;
            db.update_by = model.db.update_by;
            _context.SaveChanges();
            return 1;
        }
        public IQueryable<erp_don_hang_ban_model> FindAll()
        {
            var result = _context.erp_don_hang_bans.Select(q => new erp_don_hang_ban_model()
            {
                db = q,
                tinh_thanh_khach_hang_dat = _context.sys_tinh_thanhs.Where(d => d.id == q.id_tinh_khach_hang_dat).Select(q => q.ten).SingleOrDefault(),
                tinh_thanh_khach_hang_nhan = _context.sys_tinh_thanhs.Where(d => d.id == q.id_tinh_khach_hang_nhan).Select(q => q.ten).SingleOrDefault(),
                quan_huyen_khach_hang_dat = _context.sys_quan_huyens.Where(d => d.id == q.id_quan_khach_hang_dat).Select(q => q.ten).SingleOrDefault(),
                quan_huyen_khach_hang_nhan = _context.sys_quan_huyens.Where(d => d.id == q.id_quan_khach_hang_nhan).Select(q => q.ten).SingleOrDefault(),


                ten_ngan_hang = _context.sys_ngan_hangs.Where(d => d.id == q.id_ngan_hang).Select(q => q.name).SingleOrDefault(),
                so_tai_khoan = _context.sys_ngan_hangs.Where(d => d.id == q.id_ngan_hang).Select(q => q.so_tai_khoan).SingleOrDefault(),


                create_name = _context.sys_users.Where(d => d.id == q.create_by).Select(q => q.full_name).SingleOrDefault(),
                update_name = _context.sys_users.Where(d => d.id == q.update_by).Select(q => q.full_name).SingleOrDefault(),
            });
            return result;
        }
        public async Task<int> delete(string id, int status_del)
        {
            var db = await _context.erp_don_hang_bans.Where(q => q.id == id).SingleOrDefaultAsync();
            db.status_del = status_del;
            _context.SaveChanges();
            return 1;
        }
    }
}
