using Microsoft.EntityFrameworkCore;
using software.database.Provider;
using software.repo.DataAccess;
using System.Linq;
using System.Threading.Tasks;

namespace software.repo.Repo
{
    public class sys_san_pham_repo
    {
        public SoftwareDefautTable _context;
        private readonly sys_san_pham_chi_tiet_repo repo;
        public sys_san_pham_repo(SoftwareDefautTable context)
        {
            repo = new sys_san_pham_chi_tiet_repo(context);
            _context = context;
        }
        public async Task<sys_san_pham_model> getElementById(string id)
        {
            var model = await FindAll().FirstOrDefaultAsync(q => q.db.id == id);
            return model;
        }
        public async Task<int> insert(sys_san_pham_model model)
        {
            await _context.sys_san_phams.AddAsync(model.db);
            _context.SaveChanges();
            return 1;
        }
        public async Task<int> update(sys_san_pham_model model)
        {
            var db = await _context.sys_san_phams.Where(q => q.id == model.db.id).SingleOrDefaultAsync();
            db.ten_san_pham = model.db.ten_san_pham;
            db.id_don_vi_tinh = model.db.id_don_vi_tinh;
            db.id_nhan_hieu = model.db.id_nhan_hieu;
            db.id_loai_san_pham = model.db.id_loai_san_pham;
            db.hinh_anh = model.db.hinh_anh;
            db.note = model.db.note;
            db.update_date = model.db.update_date;
            db.update_by = model.db.update_by;
            _context.SaveChanges();
            return 1;
        }
        public IQueryable<sys_san_pham_model> FindAll()
        {
            var result = _context.sys_san_phams.Select(q => new sys_san_pham_model()
            {
                db = q,
                create_name = _context.sys_users.Where(d => d.id == q.create_by).Select(q => q.full_name).SingleOrDefault(),
                update_name = _context.sys_users.Where(d => d.id == q.update_by).Select(q => q.full_name).SingleOrDefault(),
                ten_don_vi_tinh = _context.sys_don_vi_tinhs.Where(d => d.id == q.id_don_vi_tinh).Select(q => q.name).SingleOrDefault(),
                ten_loai_san_pham = _context.sys_loai_san_phams.Where(d => d.id == q.id_loai_san_pham).Select(q => q.name).SingleOrDefault(),
                ten_nhan_hieu = _context.sys_nhan_hieus.Where(d => d.id == q.id_nhan_hieu).Select(q => q.name).SingleOrDefault(),
                list_detail = repo.FindAll().ToList(),
            });
            return result;
        }
        public async Task<int> delete(string id, int status_del)
        {
            var db = await _context.sys_san_phams.Where(q => q.id == id).SingleOrDefaultAsync();
            db.status_del = status_del;
            _context.SaveChanges();
            return 1;
        }
    }
}
