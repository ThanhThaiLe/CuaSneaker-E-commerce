using Microsoft.EntityFrameworkCore;
using software.database.Provider;
using software.repo.DataAccess;
using System.Linq;
using System.Threading.Tasks;

namespace software.repo.Repo
{
    public class sys_loai_san_pham_repo
    {
        public SoftwareDefautTable _context;
        public sys_loai_san_pham_repo(SoftwareDefautTable context)
        {
            _context = context;
        }
        public async Task<sys_loai_san_pham_model> getElementById(string id)
        {
            var model = await FindAll().FirstOrDefaultAsync(q => q.db.id == long.Parse(id));
            return model;
        }
        public async Task<int> insert(sys_loai_san_pham_model model)
        {
            await _context.sys_loai_san_phams.AddAsync(model.db);
            _context.SaveChanges();
            return 1;
        }
        public async Task<int> update(sys_loai_san_pham_model model)
        {
            var db = await _context.sys_loai_san_phams.Where(q => q.id == model.db.id).SingleOrDefaultAsync();
            db.code = model.db.code;
            db.name = model.db.name;
            db.note = model.db.note;
            db.status_del = model.db.status_del;
            db.update_date = model.db.update_date;
            db.update_by = model.db.update_by;
            _context.SaveChanges();
            return 1;
        }
        public IQueryable<sys_loai_san_pham_model> FindAll()
        {
            var result = _context.sys_loai_san_phams.Select(q => new sys_loai_san_pham_model()
            {
                db = q,
                create_name = _context.sys_users.Where(d => d.id == q.create_by).Select(q => q.full_name).SingleOrDefault(),
                update_name = _context.sys_users.Where(d => d.id == q.update_by).Select(q => q.full_name).SingleOrDefault(),
            });
            return result;
        }
        public async Task<int> delete(string id, int status_del)
        {
            var db = await _context.sys_loai_san_phams.Where(q => q.id == long.Parse(id)).SingleOrDefaultAsync();
            db.status_del = status_del;
            _context.SaveChanges();
            return 1;
        }
    }
}
