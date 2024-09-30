using AutoMapper;
using Microsoft.EntityFrameworkCore;
using software.database.Provider;
using software.entity.system;
using software.repo.DataAccess;

namespace software.repo.Repo
{
    public class portal_user_repo
    {
        public SoftwareDefautTable _context;
        private readonly IMapper mapper;
        public portal_user_repo(SoftwareDefautTable context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }
        public async Task<portal_user_model> getElementById(string id)
        {
            var model = await FindAll().FirstOrDefaultAsync(q => q.id == id);
            return model;
        }
        public async Task<int> insert(portal_user_model model)
        {
            model.update_date = DateTime.Now;
            model.update_by = model.create_by;
            sys_user_db user = mapper.Map<sys_user_db>(model);
            await _context.sys_users.AddAsync(user);
            _context.SaveChanges();
            return 1;
        }
        //public async Task<int> update(portal_user_model model)
        //{
        //    var db = await _context.sys_users.Where(q => q.id == model.db.id).SingleOrDefaultAsync();
        //    db.email = model.email;
        //    db.last_name = model.last_name;
        //    db.first_name = model.first_name;
        //    db.full_name = model.last_name + " " + model.first_name;
        //    db.update_date = model.update_date;
        //    db.update_by = model.update_by;
        //    _context.SaveChanges();
        //    return 1;
        //}
        //public async Task<int> updatePass(portal_user_model model)
        //{
        //    var db = await _context.sys_users.Where(q => q.id == model.db.id).SingleOrDefaultAsync();

        //    db.PasswordHash = model.db.PasswordHash;
        //    db.PasswordSalt = model.db.PasswordSalt;
        //    db.token_reset_pass = null;
        //    db.expiration_date_reset_pass = null;

        //    _context.SaveChanges();
        //    return 1;
        //}
        public IQueryable<portal_user_model> FindAll()
        {
            var result = _context.sys_users.Select(q => new portal_user_model()
            {
                create_name = _context.sys_users.Where(d => d.id == q.create_by).Select(q => q.full_name).SingleOrDefault(),
                update_name = _context.sys_users.Where(d => d.id == q.update_by).Select(q => q.full_name).SingleOrDefault(),
            });
            return result;
        }
        //public async Task<int> delete(string id, int status_del)
        //{
        //    var db = await _context.sys_users.Where(q => q.id == id).SingleOrDefaultAsync();
        //    db.status_del = status_del;
        //    _context.SaveChanges();
        //    return 1;
        //}
        //public async Task<int> updatePassword(portal_user_model model)
        //{
        //    var db = await _context.sys_users.Where(q => q.id == model.db.id).SingleOrDefaultAsync();
        //    if (!string.IsNullOrWhiteSpace(model.password))
        //    {
        //        db.PasswordHash = model.PasswordHash;
        //        db.PasswordSalt = model.PasswordSalt;
        //        db.token_reset_pass = null;
        //        db.expiration_date_reset_pass = null;
        //    }

        //    _context.SaveChanges();

        //    return 1;
        //}
    }
}
