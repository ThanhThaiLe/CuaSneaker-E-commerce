using Microsoft.EntityFrameworkCore;
using software.database.Provider;
using software.repo.DataAccess;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace software.repo.Repo
{
    public class sys_user_nhan_hang_repo
    {
        public SoftwareDefautTable _context;
        public sys_user_nhan_hang_repo(SoftwareDefautTable context)
        {
            _context = context;
        }
        public async Task<sys_user_nhan_hang_model> getElementById(string id)
        {
            var model = await FindAll().FirstOrDefaultAsync(q => q.db.id == id);
            return model;
        }
        public async Task<int> insert(sys_user_nhan_hang_model model)
        {
            model.db.update_date = DateTime.Now;
            model.db.update_by = model.db.create_by;
            await _context.sys_user_nhan_hangs.AddAsync(model.db);
            _context.SaveChanges();
            return 1;
        }
        public async Task<int> update(sys_user_nhan_hang_model model)
        {
            var db = await _context.sys_user_nhan_hangs.Where(q => q.id == model.db.id).SingleOrDefaultAsync();
            db.email = model.db.email;
            db.last_name = model.db.last_name;
            db.first_name = model.db.first_name;
            db.full_name = model.db.last_name + " " + model.db.first_name;
            db.update_date = model.db.update_date;
            db.update_by = model.db.update_by;
            _context.SaveChanges();
            return 1;
        }
        public IQueryable<sys_user_nhan_hang_model> FindAll()
        {
            var result = _context.sys_user_nhan_hangs.Select(q => new sys_user_nhan_hang_model()
            {
                db = q,
            });
            return result;
        }
        public async Task<int> delete(string id, int status_del)
        {
            var db = await _context.sys_user_nhan_hangs.Where(q => q.id == id).SingleOrDefaultAsync();
            db.status_del = status_del;
            _context.SaveChanges();
            return 1;
        }

    }
}
