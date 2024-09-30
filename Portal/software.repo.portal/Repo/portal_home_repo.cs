using software.database.Provider;
using software.repo.DataAccess;
using software.repo.portal.DataAccess;

namespace software.repo.portal.Repo
{
    public class portal_home_repo
    {
        public SoftwareDefautTable _context;
        public portal_home_repo(SoftwareDefautTable context)
        {
            _context = context;
        }
        public IQueryable<portal_san_pham_model> FindAllSanPham()
        {
            var result = _context.sys_san_phams.Select(q => new portal_san_pham_model()
            {
                id = q.id,
                ten_san_pham = q.ten_san_pham,
                id_loai_san_pham = q.id_loai_san_pham,
                loai_san_pham = _context.sys_loai_san_phams.Where(d => d.id == q.id_loai_san_pham).Select(q => q.name).SingleOrDefault(),
                nhan_hieu = _context.sys_nhan_hieus.Where(d => d.id == q.id_nhan_hieu).Select(q => q.name).SingleOrDefault(),
                ma_san_pham = q.ma_san_pham,
                hinh_anh = q.hinh_anh,
            });
            return result;
        }
        public IQueryable<portal_san_pham_chi_tiet_model> FindAllSanPhamDetail()
        {
            var result = _context.sys_san_pham_chi_tiets.Select(q => new portal_san_pham_chi_tiet_model()
            {
                id = q.id,
                id_san_pham = q.id_san_pham,
                id_size = q.id_size,
                id_color = q.id_color,
                hinh_anh = q.hinh_anh,
                gia_ban = q.gia_ban,
                mo_ta = q.mo_ta,
                ma_san_pham = _context.sys_san_phams.Where(d => d.id == q.id_san_pham).Select(q => q.ma_san_pham).SingleOrDefault(),
                ten_san_pham = _context.sys_san_phams.Where(d => d.id == q.id_san_pham).Select(q => q.ten_san_pham).SingleOrDefault(),
                color = _context.sys_colors.Where(d => d.id == q.id_color).Select(q => q.name).SingleOrDefault(),
                color_code = _context.sys_colors.Where(d => d.id == q.id_color).Select(q => q.code).SingleOrDefault(),
            });
            return result;
        }
        public IQueryable<sys_file_upload_model> FindAllFileSanPham()
        {
            var result = _context.sys_file_uploads.Select(q => new sys_file_upload_model()
            {
                db = q,
            });
            return result;
        }
    }
}
