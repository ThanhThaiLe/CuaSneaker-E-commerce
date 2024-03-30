using software.database.Provider;
using software.repo.erp.DataAccess;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace software.repo.erp.Repo
{
    public class erp_xuat_kho_repo
    {
        public SoftwareDefautTable _context;
        public erp_xuat_kho_chi_tiet_repo _erp_xuat_kho_chi_tiet_repo;
        public erp_xuat_kho_repo(SoftwareDefautTable context)
        {
            _context = context;
            _erp_xuat_kho_chi_tiet_repo = new erp_xuat_kho_chi_tiet_repo(context);
        }
        public async Task<erp_xuat_kho_model> getElementById(string id)
        {
            var model = await FindAll().FirstOrDefaultAsync(q => q.db.id == long.Parse(id));
            return model;
        }
        public async Task<int> insert(erp_xuat_kho_model model)
        {
            await _context.erp_xuat_khos.AddAsync(model.db);
            _context.SaveChanges();
            return 1;
        }
        public async Task<int> update(erp_xuat_kho_model model)
        {
            var db = await _context.erp_xuat_khos.Where(q => q.id == model.db.id).FirstOrDefaultAsync();
            db.name = model.db.name;
            db.code = model.db.code;
            db.status_del = model.db.status_del;
            db.note = model.db.note;
            db.update_date = model.db.update_date;
            db.update_by = model.db.update_by;
            _context.SaveChanges();
            return 1;
        }
        public IQueryable<erp_xuat_kho_model> FindAll()
        {
            var result = _context.erp_xuat_khos.Select(q => new erp_xuat_kho_model()
            {
                db = q,
                create_name = _context.sys_users.Where(d => d.id == q.create_by).Select(q => q.full_name).SingleOrDefault(),
                update_name = _context.sys_users.Where(d => d.id == q.update_by).Select(q => q.full_name).SingleOrDefault(),
            });
            return result;
        }
        public async Task<int> delete(string id, int status_del)
        {
            var db = await _context.erp_xuat_khos.Where(q => q.id == long.Parse(id)).SingleOrDefaultAsync();
            db.status_del = status_del;
            _context.SaveChanges();
            return 1;
        }
    }
}
