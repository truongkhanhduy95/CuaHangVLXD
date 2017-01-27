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
    class CongNoNhaCungCapDAL
    {
        DataAccessHelper db = new DataAccessHelper();

        public long GetTongCongNoNhaCungCap()
        {
            DataAccessHelper db = new DataAccessHelper();
            string sql = "SELECT SUM(ConLai) FROM DonNhapHang where ConLai>0";
            DataTable dt = db.GetDataTable(sql);
            return dt.Rows[0].Field<long>(0);
        }

        public int GetTongNhaCungCapNo()
        {
            DataAccessHelper db = new DataAccessHelper();
            string sql = "SELECT SUM(ConLai) FROM DonNhapHang where ConLai>0";
            DataTable dt = db.GetDataTable(sql);
            return dt.Rows[0].Field<int>(0);
        }

        public DataTable GetDanhSachCongNoNhaCungCap()
        {
            DataAccessHelper db = new DataAccessHelper();
            string sql = "SELECT  ncc.MaNCC,ncc.TenNCC, SUM(dnh.ConLai) as 'TongNo' FROM DonNhapHang dnh Join NhaCungCap ncc on DNH.MaNCC=ncc.MaNCC where dnh.ConLai>0 group by ncc.MaNCC,ncc.TenNCC";
            DataTable dt = db.GetDataTable(sql);
            return dt;
        }


        public DataTable GetThongTinHoaDonNo(string mancc)
        {
            DataAccessHelper db = new DataAccessHelper();
            string sql = "SELECT dnh.MaDNH,ncc.TenNCC,dnh.NgayNhap,dnh.TongTien,ConLai FROM DonNhapHang dnh join NhaCungCap ncc on dnh.MaNCC=ncc.MaNCC where dnh.ConLai>0 AND ncc.MaNCC='" + mancc + "'";
            DataTable dt = db.GetDataTable(sql);
            return dt;
        }

        public bool CapNhatCongNo(DonNhapHang dnh, int traThem)
        {
            string spName = "UPDATE_DONNHAPHANG";
            string[] pNames = { "@MADNH", "@MANCC", "@NGAYNHAP", "@TONGTIEN", "@DATRA" };
            object[] pValues = { dnh.MaDNH, dnh.MaNCC, dnh.NgayLap, dnh.TongTien, dnh.DaTra + traThem };

            int count = db.ExecuteStoredProcedure(spName, pNames, pValues);
            return count > 0;
        }
    }
}
