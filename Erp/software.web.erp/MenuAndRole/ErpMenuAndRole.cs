using software.common.Model;
using software.web.erp.Controllers;

namespace software.web.erp.MenuAndRole
{
    public static class ErpMenuAndRole
    {
        public static List<ControllerAppModel> list = new List<ControllerAppModel>()
        {
            erp_nhap_khoController.declare,
            erp_nhap_kho_chi_tietController.declare,
            erp_xuat_khoController.declare,
            erp_xuat_kho_chi_tietController.declare,
            erp_don_hang_muaController.declare,
            erp_don_hang_mua_chi_tietController.declare,
            erp_don_hang_banController.declare,
            erp_don_hang_ban_chi_tietController.declare,
            erp_loai_nhap_xuatController.declare,
           erp_don_vi_van_chuyenController.declare,
        };
    }
}
