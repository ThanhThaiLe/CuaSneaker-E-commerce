using Microsoft.EntityFrameworkCore;
using software.database.Provider;
using software.entity.system;
using software.repo.DataAccess;

namespace software.repo.Repo
{
    public class sys_file_upload_repo
    {
        public SoftwareDefautTable _context;
        public sys_file_upload_repo(SoftwareDefautTable context)
        {
            _context = context;
        }
        public async Task<sys_file_upload_model> getElementById(string id)
        {
            var model = await FindAll().FirstOrDefaultAsync(q => q.db.id == long.Parse(id));
            return model;
        }
        public int insert_list(List<sys_file_upload_db> list_item, string id_parent)
        {
            var list_file = _context.sys_file_uploads.Where(q => q.id_parent == id_parent).ToList();
            _context.RemoveRange(list_file);
            _context.SaveChanges();
            foreach (var item in list_file)
            {
                item.id = 0;
                _context.Add(item);
                _context.SaveChanges();
            }
            return 1;
        }
        public async Task<int> insert(sys_file_upload_db db)
        {
            await _context.sys_file_uploads.AddAsync(db);
            _context.SaveChanges();
            return 1;
        }
        public async Task<int> update(sys_file_upload_model model)
        {
            var db = await _context.sys_file_uploads.Where(q => q.id == model.db.id).SingleOrDefaultAsync();
            _context.SaveChanges();
            return 1;
        }
        public IQueryable<sys_file_upload_model> FindAll()
        {
            var result = _context.sys_file_uploads.Select(q => new sys_file_upload_model()
            {
                db = q,
                create_name = _context.sys_users.Where(d => d.id == q.create_by).Select(q => q.full_name).SingleOrDefault(),
                update_name = _context.sys_users.Where(d => d.id == q.update_by).Select(q => q.full_name).SingleOrDefault(),
            });
            return result;
        }
        public async Task<int> delete(string id, int status_del)
        {
            var db = await _context.sys_file_uploads.Where(q => q.id == long.Parse(id)).SingleOrDefaultAsync();
            _context.Remove(db);
            _context.SaveChanges();
            return 1;
        }
    }
}
