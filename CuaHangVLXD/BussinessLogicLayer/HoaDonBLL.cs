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
    class HoaDonBLL
    {
        HoaDonDAL dal = new HoaDonDAL();

        public DataTable LoadAllDanhSach() { return dal.LoadAllDanhSach(); }
        public DataTable LoadAll() { return dal.LoadAll(); }
        public DataTable GetHDFromKhachHang(string maKH) { return dal.GetHDFromKhachHang(maKH); }
        public DataTable GetHDFromTenKhachHang(string tenKH) { return dal.GetHDFromTenKhachHang(tenKH); }

        public HoaDon GetHoaDonByID(string id) { return dal.GetHoaDonByID(id); }
        public bool AddNewHoaDon(HoaDon hoadon) { return dal.AddNewHoaDon(hoadon); }
        public DataTable TableInHoaDon(string maHD) { return dal.TableInHoaDon(maHD); }
        public string GetMaHDLastest() { return dal.GetMaHDLastest(); }

        public DataTable SearchByDate(DateTime fromDate, DateTime toDate) { return dal.SearchByDate(fromDate, toDate); }
    }
}
