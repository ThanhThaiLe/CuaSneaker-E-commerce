using Microsoft.EntityFrameworkCore;
using software.database.Provider;
using software.repo.DataAccess;
using System.Linq;
using System.Threading.Tasks;

namespace software.repo.Repo
{
    public class sys_san_pham_chi_tiet_repo
    {
        public SoftwareDefautTable _context;
        public sys_file_upload_repo _repo;
        public sys_san_pham_chi_tiet_repo(SoftwareDefautTable context)
        {
            _context = context;
            _repo = new sys_file_upload_repo(context);
        }
        public async Task<sys_san_pham_chi_tiet_model> getElementById(string id)
        {
            var model = await FindAll().FirstOrDefaultAsync(q => q.db.id == long.Parse(id));
            return model;
        }
        public async Task<int> insert(sys_san_pham_chi_tiet_model model)
        {
            model.db.id = 0;
            model.db.id_size = string.Join(",", model.list_id_size);
            await _context.sys_san_pham_chi_tiets.AddAsync(model.db);
            _context.SaveChanges();
            _repo.insert_list(model.list_file, model.db.id.ToString());

            return 1;
        }
        public async Task<int> update(sys_san_pham_chi_tiet_model model)
        {
            var db = await _context.sys_san_pham_chi_tiets.Where(q => q.id == model.db.id).SingleOrDefaultAsync();
            db.id_size = string.Join(",", model.list_id_size);
            db.is_noi_bac = model.db.is_noi_bac;
            db.is_khuyen_mai = model.db.is_khuyen_mai;
            db.hinh_anh = model.db.hinh_anh;
            db.note = model.db.note;
            db.mo_ta = model.db.mo_ta;
            db.update_date = model.db.update_date;
            db.update_by = model.db.update_by;
            _context.SaveChanges();
            _repo.insert_list(model.list_file, model.db.id.ToString());
            return 1;
        }
        public IQueryable<sys_san_pham_chi_tiet_model> FindAll()
        {
            var result = _context.sys_san_pham_chi_tiets.Select(q => new sys_san_pham_chi_tiet_model()
            {
                db = q,
                ma_san_pham = _context.sys_san_phams.Where(d => d.id == q.id_san_pham).Select(q => q.ma_san_pham).SingleOrDefault(),
                ten_san_pham = _context.sys_san_phams.Where(d => d.id == q.id_san_pham).Select(q => q.ten_san_pham).SingleOrDefault(),
                size = string.Join(",", _context.sys_sizes.Where(d => q.id_size.Contains(d.id + "")).Select(q => q.name + "(" + q.code + ")").ToList()),
                list_code_size = _context.sys_sizes.Where(d => q.id_size.Contains(d.id + "")).Select(q => q.name + "(" + q.code + ")").ToList(),
                list_id_size = _context.sys_sizes.Where(d => q.id_size.Contains(d.id + "")).Select(q => q.id).ToList(),
                color = _context.sys_colors.Where(d => d.id == q.id_color).Select(q => q.name).SingleOrDefault(),
                color_code = _context.sys_colors.Where(d => d.id == q.id_color).Select(q => q.code).SingleOrDefault(),
                create_name = _context.sys_users.Where(d => d.id == q.create_by).Select(q => q.full_name).SingleOrDefault(),
                update_name = _context.sys_users.Where(d => d.id == q.update_by).Select(q => q.full_name).SingleOrDefault(),
                list_file = _context.sys_file_uploads.Where(d => d.id_parent == q.id + "").ToList()
            });
            return result;
        }
        public IQueryable<sys_file_upload_model> FindAllFile()
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
            var db = await _context.sys_san_pham_chi_tiets.Where(q => q.id == long.Parse(id)).SingleOrDefaultAsync();
            db.status_del = status_del;
            _context.SaveChanges();
            return 1;
        }
    }
}
