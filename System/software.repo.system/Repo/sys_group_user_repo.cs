using Microsoft.EntityFrameworkCore;
using software.database.Provider;
using software.entity.system;
using software.repo.DataAccess;

namespace software.repo.Repo
{
    public class sys_group_user_repo
    {
        public SoftwareDefautTable _context;
        public sys_group_user_repo(SoftwareDefautTable context)
        {
            _context = context;
        }
        public async Task<sys_group_user_model> getElementById(string id)
        {
            var model = await FindAll().FirstOrDefaultAsync(q => q.db.id == id);
            return model;
        }
        public async Task<int> insert(sys_group_user_model model)
        {
            await _context.sys_group_users.AddAsync(model.db);
            saveDetail(model);
            _context.SaveChanges();
            return 1;
        }
        public async Task<int> update(sys_group_user_model model)
        {
            var db = await _context.sys_group_users.Where(q => q.id == model.db.id).FirstOrDefaultAsync();
            db.note = model.db.note;
            db.status_del = model.db.status_del;
            db.name = model.db.name;
            db.update_by = model.db.update_by;
            db.update_date = model.db.update_date;
            db.note = model.db.note;
            _context.SaveChanges();
            saveDetail(model);
            return 1;
        }
        public void saveDetail(sys_group_user_model model)
        {
            var delete1 = _context.sys_group_user_details
                .Where(q => q.id_group_user == model.db.id);
            _context.RemoveRange(delete1);
            _context.SaveChanges();
            var list_detail = model.list_item.Where(q => q.isCheck == true).ToList();
            var list_insert = new List<sys_group_user_detail_db>();
            foreach (var item in list_detail)
            {
                var db = new sys_group_user_detail_db()
                {
                    id = 0,
                    id_group_user = model.db.id,
                    user_id = item.user_id,
                };
                list_insert.Add(db);
            }
            _context.sys_group_user_details.AddRange(list_insert);
            _context.SaveChanges();

            var delete = _context.sys_group_user_rolers.Where(q => q.id_group_user == model.db.id);
            _context.RemoveRange(delete);
            _context.SaveChanges();

            model.list_role.ForEach(q =>
            {
                q.db.id = 0;
                q.db.id_group_user = model.db.id;
            });
            var listInsert = model.list_role.Select(q => q.db).ToList();
            _context.sys_group_user_rolers.AddRange(listInsert);
            _context.SaveChanges();
        }
        public IQueryable<sys_group_user_model> FindAll()
        {
            var result = _context.sys_group_users.Select(q => new sys_group_user_model
            {
                db = q,
                createby_name = _context.sys_users.Where(d => d.id == q.create_by).Select(q => q.full_name).SingleOrDefault(),
                count_user = _context.sys_group_user_details.Where(d => d.id_group_user == q.id).Count()
            });
            return result;
        }
        public IQueryable<sys_group_user_role_model> FindAllRole(string id)
        {
            var result = _context.sys_group_user_rolers
                .Where(q => q.id_group_user == id)
                .Select(q => new sys_group_user_role_model() { db = q });

            return result;
        }
        public IQueryable<sys_group_user_detail_model> FindAllItem(string id)
        {
            var result = _context.sys_users
                .Where(q => q.status_del == 1 && q.type == 1)
                .OrderBy(q => q.id_department)
                .Select(q => new sys_group_user_detail_model()
                {
                    user_id = q.id,
                    isCheck = _context.sys_group_user_details
                   .Where(d => d.user_id == q.id && d.id_group_user == id).Count() > 0,
                    user_name = q.user_name,
                    type_user = q.type,
                });
            return result;
        }
        public int delete_status(string id, string user_id, int status)
        {
            var model = _context.sys_group_users.Where(q => q.id == id).SingleOrDefault();
            model.status_del = status;
            model.update_by = user_id;
            model.update_date = DateTime.Now;
            _context.SaveChanges();
            return 1;
        }

    }
}
