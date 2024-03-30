using Microsoft.EntityFrameworkCore;
using software.database.Provider;
using software.repo.DataAccess;
using System.Linq;
using System.Threading.Tasks;

namespace software.repo.Repo
{
    public class sys_khach_hang_repo
    {
        public SoftwareDefautTable _context;
        public sys_khach_hang_repo(SoftwareDefautTable context)
        {
            _context = context;
        }
        public async Task<int> insert(sys_khach_hang_model model)
        {

            //await _context.sys_users.AddAsync(model.db);
            _context.SaveChanges();
            return 1;
        }
        public async Task<int> update(sys_khach_hang_model model)
        {
            //var db = await _context.sys_users.Where(q => q.id == model.db.id).SingleOrDefaultAsync();
            //db.email = model.db.email;
            //db.last_name = model.db.last_name;
            //db.first_name = model.db.first_name;
            //db.full_name = model.db.last_name + " " + model.db.first_name;
            _context.SaveChanges();
            return 1;
        }
        public IQueryable<sys_khach_hang_model> FindAll()
        {
            var result = _context.sys_users.Select(q => new sys_khach_hang_model()
            {
            });
            return result;
        }
        public async Task<int> delete(string id, int status_del)
        {
            var db = await _context.sys_users.Where(q => q.id == id).SingleOrDefaultAsync();
            db.status_del = status_del;
            _context.SaveChanges();
            return 1;
        }
    }
}
