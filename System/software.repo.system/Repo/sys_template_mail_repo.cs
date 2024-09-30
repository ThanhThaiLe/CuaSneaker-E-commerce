using Microsoft.EntityFrameworkCore;
using software.database.Provider;
using software.repo.DataAccess;
using System.Linq;
using System.Threading.Tasks;

namespace software.repo.Repo
{
    public class sys_template_mail_repo
    {
        public SoftwareDefautTable _context;
        public sys_template_mail_repo(SoftwareDefautTable context)
        {
            _context = context;
        }
        public async Task<sys_template_mail_model> getElementById(string id)
        {
            var model = await FindAll().FirstOrDefaultAsync(q => q.db.id == long.Parse(id));
            return model;
        }
        public async Task<int> insert(sys_template_mail_model model)
        {
            await _context.sys_template_mails.AddAsync(model.db);
            _context.SaveChanges();
            return 1;
        }
        public async Task<int> update(sys_template_mail_model model)
        {
            var db = await _context.sys_template_mails.Where(q => q.id == model.db.id).FirstOrDefaultAsync();
            db.id_type = model.db.id_type;
            db.name = model.db.name;
            db.template = model.db.template;
            db.status_del = model.db.status_del;
            db.note = model.db.note;
            db.update_date = model.db.update_date;
            db.update_by = model.db.update_by;
            _context.SaveChanges();
            return 1;
        }
        public IQueryable<sys_template_mail_model> FindAll()
        {
            var result = _context.sys_template_mails.Select(q => new sys_template_mail_model()
            {
                db = q,
                type_code_mail = _context.sys_type_mails.Where(d => d.id == q.id_type).Select(q => q.code).SingleOrDefault(),
                type_name_mail = _context.sys_type_mails.Where(d => d.id == q.id_type).Select(q => q.name).SingleOrDefault(),
                create_name = _context.sys_users.Where(d => d.id == q.create_by).Select(q => q.full_name).SingleOrDefault(),
                update_name = _context.sys_users.Where(d => d.id == q.update_by).Select(q => q.full_name).SingleOrDefault(),
            });
            return result;
        }
        public async Task<int> delete(string id, int status_del)
        {
            var db = await _context.sys_template_mails.Where(q => q.id == long.Parse(id)).SingleOrDefaultAsync();
            db.status_del = status_del;
            _context.SaveChanges();
            return 1;
        }
    }
}
