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
    class CongNoNhaCungCapBLL
    {
        CongNoNhaCungCapDAL dal = new CongNoNhaCungCapDAL();
        public long GetTongCongNoNhaCungCap() { return dal.GetTongCongNoNhaCungCap(); }
        public DataTable GetDanhSachCongNoNhaCungCap() { return dal.GetDanhSachCongNoNhaCungCap(); }
        public DataTable GetThongTinHoaDonNo(string makh) { return dal.GetThongTinHoaDonNo(makh); }
        public bool CapNhatCongNo(DonNhapHang dnh, int traThem) { return dal.CapNhatCongNo(dnh, traThem); }
    }
}
