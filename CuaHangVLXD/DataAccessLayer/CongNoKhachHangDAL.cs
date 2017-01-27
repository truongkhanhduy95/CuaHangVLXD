using CuaHangVLXD.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VatLieuXaydung.DataLayer;

namespace CuaHangVLXD.DataAccessLayer
{
    class CongNoKhachHangDAL 
    {
        DataAccessHelper db = new DataAccessHelper();

        public long GetTongCongNoKhachHang()
        {
            DataAccessHelper db = new DataAccessHelper();
            string sql = "SELECT SUM(ConLai) FROM HoaDon where ConLai>0";
            DataTable dt = db.GetDataTable(sql);
            return dt.Rows[0].Field<long>(0);
        }

        public int GetTongKhachHangNo()
        {
            DataAccessHelper db = new DataAccessHelper();
            string sql = "SELECT SUM(ConLai) FROM HoaDon where ConLai>0";
            DataTable dt = db.GetDataTable(sql);
            return dt.Rows[0].Field<int>(0);
        }
        
        public DataTable GetDanhSachCongNoKhachHang()
        {
            DataAccessHelper db = new DataAccessHelper();
            string sql = "SELECT kh.MaKH, kh.TenKH, SUM(hd.ConLai) as 'TongNo' FROM HoaDon hd Join KhachHang kh on hd.MaKH=kh.MaKH where hd.ConLai>0 group by kh.MaKH,kh.TenKH";
            DataTable dt = db.GetDataTable(sql);
            return dt;
        }

        public DataTable TimKhachHang(string tenKH)
        {
            DataAccessHelper db = new DataAccessHelper();
            string sql = "SELECT kh.MaKH, kh.TenKH, SUM(hd.ConLai) as 'TongNo' FROM HoaDon hd Join KhachHang kh on hd.MaKH=kh.MaKH where hd.ConLai>0 group by kh.MaKH,kh.TenKH having TenKH LIKE N'%"+tenKH+"%'";
            DataTable dt = db.GetDataTable(sql);
            return dt;
        }


        public DataTable GetThongTinHoaDonNo(string makh)
        {
            DataAccessHelper db = new DataAccessHelper();
            string sql = "SELECT hd.MaHD,kh.TenKH,hd.NgayLap,hd.TongTien,ConLai FROM HoaDon hd join KhachHang kh on hd.MaKH=kh.MaKH where hd.ConLai>0 AND hd.MaKH='" + makh + "'";
            DataTable dt = db.GetDataTable(sql);
            return dt;
        }

        public bool CapNhatCongNo(HoaDon hd,int traThem)
        {
            string spName = "UPDATE_HOADON";
            string[] pNames = { "@MAHD", "@MAKH", "@NGAYNHAP", "@TONGTIEN", "@DATRA"};
            object[] pValues = { hd.MaHD, hd.MaKH, hd.NgayLap, hd.TongTien, hd.DaTra + traThem };

            int count = db.ExecuteStoredProcedure(spName, pNames, pValues);
            return count > 0;
        }



    }
}
