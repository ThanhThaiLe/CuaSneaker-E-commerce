using Microsoft.EntityFrameworkCore;
using software.database.Provider;
using software.repo.DataAccess;
using System.Linq;
using System.Threading.Tasks;

namespace software.repo.Repo
{
    public class sys_banner_repo
    {
        public SoftwareDefautTable _context;
        public sys_banner_repo(SoftwareDefautTable context)
        {
            _context = context;
        }
        public async Task<sys_banner_model> getElementById(string id)
        {
            var model = await FindAll().FirstOrDefaultAsync(q => q.db.id == long.Parse(id));
            return model;
        }
        public async Task<int> insert(sys_banner_model model)
        {
            await _context.sys_banners.AddAsync(model.db);
            _context.SaveChanges();
            return 1;
        }
        public async Task<int> update(sys_banner_model model)
        {
            var db = await _context.sys_banners.Where(q => q.id == model.db.id).SingleOrDefaultAsync();
            db.image_mobi = model.db.image_mobi;
            db.image_web = model.db.image_web;
            db.id_type = model.db.id_type;
            db.status_del = model.db.status_del;
            db.link = model.db.link;
            db.update_date = model.db.update_date;
            db.update_by = model.db.update_by;
            _context.SaveChanges();
            return 1;
        }
        public IQueryable<sys_banner_model> FindAll()
        {
            var result = _context.sys_banners.Select(q => new sys_banner_model()
            {
                db = q,
                create_name = _context.sys_users.Where(d => d.id == q.create_by).Select(q => q.full_name).SingleOrDefault(),
                update_name = _context.sys_users.Where(d => d.id == q.update_by).Select(q => q.full_name).SingleOrDefault(),
            });
            return result;
        }
        public async Task<int> delete(string id, int status_del)
        {
            var db = await _context.sys_banners.Where(q => q.id == long.Parse(id)).SingleOrDefaultAsync();
            db.status_del = status_del;
            _context.SaveChanges();
            return 1;
        }
    }
}
