using software.database.Provider;
using software.repo.erp.DataAccess;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace software.repo.erp.Repo
{
    public class erp_don_hang_ban_chi_tiet_repo
    {
        public SoftwareDefautTable _context;
        public erp_don_hang_ban_chi_tiet_repo(SoftwareDefautTable context)
        {
            _context = context;
        }
        public async Task<erp_don_hang_ban_chi_tiet_model> getElementById(string id)
        {
            var model = await FindAll().FirstOrDefaultAsync(q => q.db.id == long.Parse(id));
            return model;
        }
        public async Task<int> insert(erp_don_hang_ban_chi_tiet_model model)
        {
            _context.erp_don_hang_ban_chi_tiets.Add(model.db);
            _context.SaveChanges();
            await getElementById(model.db.id + "");
            return 1;
        }
        public async Task<int> update(erp_don_hang_ban_chi_tiet_model model)
        {
            var db = await _context.erp_don_hang_ban_chi_tiets.Where(q => q.id == model.db.id).FirstOrDefaultAsync();
            db.status_del = model.db.status_del;
            db.note = model.db.note;
            db.update_date = model.db.update_date;
            db.update_by = model.db.update_by;
            _context.SaveChanges();
            return 1;
        }
        public IQueryable<erp_don_hang_ban_chi_tiet_model> FindAll()
        {
            var result = _context.erp_don_hang_ban_chi_tiets.Select(q => new erp_don_hang_ban_chi_tiet_model()
            {
                db = q,
                create_name = _context.sys_users.Where(d => d.id == q.create_by).Select(q => q.full_name).SingleOrDefault(),
                update_name = _context.sys_users.Where(d => d.id == q.update_by).Select(q => q.full_name).SingleOrDefault(),
            });
            return result;
        }
        public async Task<int> delete(string id, int status_del)
        {
            var db = await _context.erp_don_hang_ban_chi_tiets.Where(q => q.id == long.Parse(id)).SingleOrDefaultAsync();
            db.status_del = status_del;
            _context.SaveChanges();
            return 1;
        }
    }
}
