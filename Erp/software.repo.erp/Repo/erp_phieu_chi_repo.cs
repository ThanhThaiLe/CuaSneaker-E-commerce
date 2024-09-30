using software.database.Provider;
using software.repo.erp.DataAccess;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace software.repo.erp.Repo
{
    public class erp_phieu_chi_repo
    {
        public SoftwareDefautTable _context;
        public erp_phieu_chi_repo(SoftwareDefautTable context)
        {
            _context = context;
        }
        public async Task<erp_phieu_chi_model> getElementById(string id)
        {
            var model = await FindAll().FirstOrDefaultAsync(q => q.db.id == id);
            return model;
        }
        public async Task<int> insert(erp_phieu_chi_model model)
        {
            await _context.erp_phieu_chis.AddAsync(model.db);
            _context.SaveChanges();
            return 1;
        }
        public async Task<int> update(erp_phieu_chi_model model)
        {
            var db = await _context.erp_phieu_chis.Where(q => q.id == model.db.id).FirstOrDefaultAsync();
            db.name = model.db.name;
            db.code = model.db.code;
            db.status_del = model.db.status_del;
            db.note = model.db.note;
            db.update_date = model.db.update_date;
            db.update_by = model.db.update_by;
            _context.SaveChanges();
            return 1;
        }
        public IQueryable<erp_phieu_chi_model> FindAll()
        {
            var result = _context.erp_phieu_chis.Select(q => new erp_phieu_chi_model()
            {
                db = q,
                create_name = _context.sys_users.Where(d => d.id == q.create_by).Select(q => q.full_name).SingleOrDefault(),
                update_name = _context.sys_users.Where(d => d.id == q.update_by).Select(q => q.full_name).SingleOrDefault(),
            });
            return result;
        }
        public async Task<int> delete(string id, int status_del)
        {
            var db = await _context.erp_phieu_chis.Where(q => q.id == id).SingleOrDefaultAsync();
            db.status_del = status_del;
            _context.SaveChanges();
            return 1;
        }
    }
}
