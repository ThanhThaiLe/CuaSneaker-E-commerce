using software.database.Provider;
using software.repo.kho.DataAccess;
using System.Linq;

namespace software.repo.kho.Repo
{
    public class kho_home_repo
    {
        public SoftwareDefautTable _context;
        public kho_home_repo(SoftwareDefautTable context)
        {
            _context = context;
        }
        public IQueryable<portal_san_pham_model> FindAllSanPham()
        {
            var result = _context.sys_san_phams.Where(q => q.status_del == 1).Select(q => new portal_san_pham_model()
            {
                id = q.id,
                ten_san_pham = q.ten_san_pham,
                id_loai_san_pham = q.id_loai_san_pham,
                loai_san_pham = _context.sys_loai_san_phams.Where(d => d.id == q.id_loai_san_pham).Select(q => q.name).SingleOrDefault(),
                ma_san_pham = q.ma_san_pham,
                mo_ta = q.mo_ta,
                hinh_anh = q.hinh_anh,
                is_khuyen_mai = q.is_khuyen_mai ?? false,
                is_noi_bac = q.is_noi_bac ?? false,
                gia_ban = q.gia_ban,
                gia_khuyen_mai = q.gia_khuyen_mai,
            });
            return result;
        }
    }
}
