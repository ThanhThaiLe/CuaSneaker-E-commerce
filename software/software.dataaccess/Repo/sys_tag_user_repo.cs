using Microsoft.EntityFrameworkCore;
using software.database.Provider;
using software.database.System;
using software.repo.DataAccess;
using System.Linq;
using System.Threading.Tasks;

namespace software.repo.Repo
{
    public class sys_tag_user_repo
    {
        public SoftwareDefautTable _context;
        public sys_tag_user_repo(SoftwareDefautTable context)
        {
            _context = context;
        }
        public async Task<sys_tag_user_model> getElementById(string id)
        {
            var model = await FindAll().FirstOrDefaultAsync(q => q.db.id == id);
            return model;
        }
        public async Task<int> insert(sys_tag_user_db model)
        {
            await _context.sys_tag_users.AddAsync(model);
            _context.SaveChanges();
            return 1;
        }
        public async Task<int> update(sys_tag_user_db model)
        {
            var db = await _context.sys_tag_users.Where(q => q.id == model.id).SingleOrDefaultAsync();
            db.title = model.title;
            _context.SaveChanges();
            return 1;
        }
        public IQueryable<sys_tag_user_model> FindAll()
        {
            var result = _context.sys_tag_users.Select(q => new sys_tag_user_model()
            {
                db = q,
                create_name = _context.sys_users.Where(d => d.id == q.create_by).Select(q => q.full_name).SingleOrDefault(),
                update_name = _context.sys_users.Where(d => d.id == q.update_by).Select(q => q.full_name).SingleOrDefault(),
            });
            return result;
        }
        public async Task<int> delete(string id, int status_del)
        {
            var db = await _context.sys_tag_users.Where(q => q.id == id).SingleOrDefaultAsync();
            db.status_del = status_del;
            _context.SaveChanges();
            return 1;
        }
    }
}
