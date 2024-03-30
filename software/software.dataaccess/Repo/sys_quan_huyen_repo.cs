﻿using Microsoft.EntityFrameworkCore;
using software.database.Provider;
using software.repo.DataAccess;
using System.Linq;
using System.Threading.Tasks;

namespace software.repo.Repo
{
    public class sys_quan_huyen_repo
    {
        public SoftwareDefautTable _context;
        public sys_quan_huyen_repo(SoftwareDefautTable context)
        {
            _context = context;
        }
        public async Task<sys_quan_huyen_model> getElementById(string id)
        {
            var model = await FindAll().FirstOrDefaultAsync(q => q.db.id == long.Parse(id));
            return model;
        }
        public async Task<int> insert(sys_quan_huyen_model model)
        {
            await _context.sys_quan_huyens.AddAsync(model.db);
            _context.SaveChanges();
            return 1;
        }
        public async Task<int> update(sys_quan_huyen_model model)
        {
            var db = await _context.sys_quan_huyens.Where(q => q.id == model.db.id).FirstOrDefaultAsync();
            db.id_tinh = model.db.id_tinh;
            db.id_quoc_gia = model.db.id_quoc_gia;
            db.ten_khong_dau = model.db.ten_khong_dau;
            db.ten = model.db.ten;
            db.status_del = model.db.status_del;
            db.note = model.db.note;
            db.update_date = model.db.update_date;
            db.update_by = model.db.update_by;
            _context.SaveChanges();
            return 1;
        }
        public IQueryable<sys_quan_huyen_model> FindAll()
        {
            var result = _context.sys_quan_huyens.Select(q => new sys_quan_huyen_model()
            {
                db = q,
                create_name = _context.sys_users.Where(d => d.id == q.create_by).Select(q => q.full_name).SingleOrDefault(),
                update_name = _context.sys_users.Where(d => d.id == q.update_by).Select(q => q.full_name).SingleOrDefault(),
                quoc_gia = _context.sys_quoc_gias.Where(d => d.id == q.id_quoc_gia).Select(q => q.ten).SingleOrDefault(),
                tinh_thanh = _context.sys_tinh_thanhs.Where(d => d.id == q.id_tinh).Select(q => q.ten).SingleOrDefault(),
            });
            return result;
        }
        public async Task<int> delete(string id, int status_del)
        {
            var db = await _context.sys_quan_huyens.Where(q => q.id == long.Parse(id)).SingleOrDefaultAsync();
            db.status_del = status_del;
            _context.SaveChanges();
            return 1;
        }
    }
}
