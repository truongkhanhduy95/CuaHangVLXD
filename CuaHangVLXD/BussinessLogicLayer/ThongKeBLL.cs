using CuaHangVLXD.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangVLXD.BussinessLogicLayer
{
    class ThongKeBLL
    {
        ThongKeDAL dal = new ThongKeDAL();

        public DataTable ThongKeHoaDonByMonth() { return dal.ThongKeHoaDonByMonth(); }

        public DataTable ThongKeDoanhThuByMonth() { return dal.ThongKeDoanhThuByMonth(); }

        public int ThongKeTongHoaDonBan() { return dal.ThongKeTongHoaDonBan(); }
        public int ThongKeTongHoaDonNhap() { return dal.ThongKeTongHoaDonNhap(); }
        public int ThongKeTongHangHoa() { return dal.ThongKeTongHangHoa(); }
        public int ThongKeTongKhachHang() { return dal.ThongKeTongKhacHang(); }
        public int ThongKeTongNhaCungCap() { return dal.ThongKeTongNhaCungCap(); }
        public int ThongKeTongLoai() { return dal.ThongKeTongLoai(); }
        public DataTable ThongKePhanTramLoai() { return dal.ThongKePhanTramLoai(); }
        public DataTable ThongKeTop10HangHoa() { return dal.ThongKeTop10HangHoa(); }
        public int TongNoHoaDon() { return dal.TongNoHoaDon(); }
        public int TongNoDonNhapHang() { return dal.TongNoDonNhapHang(); }










    }

}
