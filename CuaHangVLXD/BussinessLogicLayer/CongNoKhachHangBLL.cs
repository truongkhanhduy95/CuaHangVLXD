using CuaHangVLXD.DataAccessLayer;
using CuaHangVLXD.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangVLXD.BussinessLogicLayer
{
    class CongNoKhachHangBLL
    {
        CongNoKhachHangDAL dal = new CongNoKhachHangDAL();
        public long GetTongCongNoKhachHang() { return dal.GetTongCongNoKhachHang(); }
        public DataTable GetDanhSachCongNoKhachHang() { return dal.GetDanhSachCongNoKhachHang();}
        public DataTable GetThongTinHoaDonNo(string makh) { return dal.GetThongTinHoaDonNo(makh); }
        public bool CapNhatCongNo(HoaDon hd, int traThem) { return dal.CapNhatCongNo(hd, traThem); }
        public DataTable TimKhachHang(string tenKH) { return dal.TimKhachHang(tenKH); }

    }
}
