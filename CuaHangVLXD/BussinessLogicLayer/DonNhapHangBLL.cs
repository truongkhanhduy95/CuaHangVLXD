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
    class DonNhapHangBLL
    {
        DonNhapHangDAL dal = new DonNhapHangDAL();

        public DataTable LoadAllDanhSach() { return dal.LoadAllDanhSach(); }
        public DataTable LoadAll() { return dal.LoadAll(); }
        public DataTable GetDNHFromNhaCungCap(string maNCC) { return dal.GetDNHFromNhaCungCap(maNCC); }
        public DataTable GetDNHFromTenNhaCungCap(string tenNCC) { return dal.GetDNHFromTenNhaCungCap(tenNCC); }

        public DonNhapHang GetDonNhapHangByID(string id) { return dal.GetDonNhapHangByID(id); }
        public bool AddNewHoaDon(DonNhapHang dnh) { return dal.AddNewDonNhapHang(dnh); }

        public DataTable SearchByDate(DateTime fromDate, DateTime toDate) { return dal.SearchByDate(fromDate, toDate); }
    }
}
