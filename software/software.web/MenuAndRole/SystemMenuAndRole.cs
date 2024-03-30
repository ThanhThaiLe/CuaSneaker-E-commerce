using software.web.Controllers;
using System.Collections.Generic;

namespace software.web.MenuAndRole
{
    public static class SystemMenuAndRole
    {
        public static List<ControllerAppModel> list = new List<ControllerAppModel>()
        {
         sys_ngan_hangController.declare,
          sys_vatController.declare,
           sys_user_nhan_hangController.declare,
            sys_file_uploadController.declare,
            sys_khoController.declare,
            sys_colorController.declare,
            sys_sizeController.declare,
            sys_san_pham_chi_tietController.declare,
            sys_bannerController.declare,
            sys_san_phamController.declare,
            sys_quan_huyenController.declare,
            sys_template_mailController.declare,
            sys_type_mailController.declare,
            sys_quoc_giaController.declare,
            sys_tinh_thanhController.declare,
            sys_don_vi_tinhController.declare,
            sys_thong_tin_websiteController.declare,
            sys_dieu_khoanController.declare,
            sys_lien_ketController.declare,
            sys_loai_san_phamController.declare,
            sys_nhan_hieuController.declare,
            sys_userController.declare,
            sys_group_userController.declare,
            sys_khach_hangController.declare,
            sys_tag_userController.declare,
        };
    }
}
