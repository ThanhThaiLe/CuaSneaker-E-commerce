using Microsoft.EntityFrameworkCore;
using software.database.Provider;
using software.repo.DataAccess;
using System.Linq;
using System.Threading.Tasks;

namespace software.repo.Repo
{
    public class sys_thong_tin_website_repo
    {
        public SoftwareDefautTable _context;
        public sys_thong_tin_website_repo(SoftwareDefautTable context)
        {
            _context = context;
        }
        public async Task<sys_thong_tin_website_model> getElementById(string id)
        {
            var model = await FindAll().FirstOrDefaultAsync(q => q.db.id == long.Parse(id));
            return model;
        }
        public async Task<int> insert(sys_thong_tin_website_model model)
        {
            await _context.sys_thong_tin_websites.AddAsync(model.db);
            _context.SaveChanges();
            return 1;
        }
        public async Task<int> update(sys_thong_tin_website_model model)
        {
            var db = await _context.sys_thong_tin_websites.Where(q => q.id == model.db.id).FirstOrDefaultAsync();
            db.image_logo = model.db.image_logo;
            db.image_footer = model.db.image_footer;
            db.dia_chi = model.db.dia_chi;
            db.so_dien_thoai = model.db.so_dien_thoai;
            db.email = model.db.email;
            db.link_facebook = model.db.link_facebook;
            db.link_youtube = model.db.link_youtube;
            db.link_linkedin = model.db.link_linkedin;
            db.link_instagram = model.db.link_instagram;
            db.image_facebook = model.db.image_facebook;
            db.image_youtube = model.db.image_youtube;
            db.image_linkedin = model.db.image_linkedin;
            db.image_instagram = model.db.image_instagram;
            db.status_del = model.db.status_del;
            db.note = model.db.note;
            db.update_date = model.db.update_date;
            db.update_by = model.db.update_by;
            _context.SaveChanges();
            return 1;
        }
        public IQueryable<sys_thong_tin_website_model> FindAll()
        {
            var result = _context.sys_thong_tin_websites.Select(q => new sys_thong_tin_website_model()
            {
                db = q,
                create_name = _context.sys_users.Where(d => d.id == q.create_by).Select(q => q.full_name).SingleOrDefault(),
                update_name = _context.sys_users.Where(d => d.id == q.update_by).Select(q => q.full_name).SingleOrDefault(),
            });
            return result;
        }
        public async Task<int> delete(string id, int status_del)
        {
            var db = await _context.sys_thong_tin_websites.Where(q => q.id == long.Parse(id)).SingleOrDefaultAsync();
            db.status_del = status_del;
            _context.SaveChanges();
            return 1;
        }
    }
}
