using software.database.Provider;
using software.repo.erp.DataAccess;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace software.repo.erp.Repo
{
    public class erp_nhap_kho_repo
    {
        public SoftwareDefautTable _context;
        public erp_nhap_kho_chi_tiet_repo _erp_nhap_kho_chi_tiet_repo;
        public erp_nhap_kho_repo(SoftwareDefautTable context)
        {
            _context = context;
            _erp_nhap_kho_chi_tiet_repo = new erp_nhap_kho_chi_tiet_repo(context);
        }
        public string getCode(string preFix, int numIncrease)
        {
            var max = "";
            var max_query = _context.erp_nhap_khos
                .Where(q => q.code.StartsWith(preFix))
                .Where(q => q.code.Length == preFix.Length + numIncrease)
                .Select(q => q.code);
            if (max_query.Count() > 0)
            {
                max = max_query.Max();
            }
            var code = generateCode(preFix, numIncrease, max);
            return code;
        }
        public string generateCode(string preFix, int Num, string max)
        {
            var result = preFix;
            int numGenerate = 1;
            for (int i = 0; i < Num; i++)
            {
                numGenerate = numGenerate * 10;
            }
            if (string.IsNullOrEmpty(max))
            {
                result += ((numGenerate + 1) + "").Remove(0, 1);
            }
            else
            {
                var count = int.Parse(max.Replace(preFix, ""));
                result += ((numGenerate + (count + 1)) + "").Remove(0, 1);
            }
            return result;
        }
        public string generateName(erp_nhap_kho_model model)
        {
            var ngay = model.db.ngay_nhap.Value.ToString("dd/MM/yyyy");
            var loai_nhap_xuat = _context.erp_loai_nhap_xuats.Where(q => q.id == model.db.id_loai_nhap).SingleOrDefault();
            var kho = _context.sys_khos.Where(q => q.id == model.db.id_kho).SingleOrDefault();
            string name = "Phiếu nhập " + kho.name + "(" + kho.code + ")" + " ngày " + ngay;

            if (loai_nhap_xuat.nguon == 1)
            {
                // thêm thông tin đơn hàng và đối tượng mua
            }
            else if (loai_nhap_xuat.nguon == 2)
            {
                // thêm thông tin đơn hàng và đối tượng mua
            }
            name += ", " + loai_nhap_xuat.name + "(" + loai_nhap_xuat.code + ")";
            return name;
        }
        public async Task<erp_nhap_kho_model> getElementById(string id)
        {
            var model = await FindAll().FirstOrDefaultAsync(q => q.db.id == id);
            return model;
        }
        public async Task<int> insert(erp_nhap_kho_model model)
        {
            model.db.code = getCode("PNK", 6);
            model.db.name = generateName(model);
            //model.db.ten_khong_dau = Regex.Replace(StringFunctions);
            await _context.erp_nhap_khos.AddAsync(model.db);
            _context.SaveChanges();
            return 1;
        }
        public async Task<int> update(erp_nhap_kho_model model)
        {
            var db = await _context.erp_nhap_khos.Where(q => q.id == model.db.id).FirstOrDefaultAsync();
            db.name = model.db.name;
            db.code = model.db.code;
            db.status_del = model.db.status_del;
            db.note = model.db.note;
            db.update_date = model.db.update_date;
            db.update_by = model.db.update_by;
            _context.SaveChanges();
            return 1;
        }
        public IQueryable<erp_nhap_kho_model> FindAll()
        {
            var result = _context.erp_nhap_khos.Select(q => new erp_nhap_kho_model()
            {
                db = q,
                create_name = _context.sys_users.Where(d => d.id == q.create_by).Select(q => q.full_name).SingleOrDefault(),
                update_name = _context.sys_users.Where(d => d.id == q.update_by).Select(q => q.full_name).SingleOrDefault(),
            });
            return result;
        }
        public async Task<int> delete(string id, int status_del)
        {
            var db = await _context.erp_nhap_khos.Where(q => q.id == id).SingleOrDefaultAsync();
            db.status_del = status_del;
            _context.SaveChanges();
            return 1;
        }
    }
}
