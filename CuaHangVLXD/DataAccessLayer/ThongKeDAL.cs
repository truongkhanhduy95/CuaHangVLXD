using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VatLieuXaydung.DataLayer;

namespace CuaHangVLXD.DataAccessLayer
{
    class ThongKeDAL
    {
        DataAccessHelper db = new DataAccessHelper();

        public DataTable ThongKeHoaDonByMonth()
        {
            string sql = "SELECT SUM(dnh.TongTien) as DonNhap,SUM(hd.TongTien) as DonXuat,MONTH(dnh.NgayNhap) as Thang FROM DonNhapHang dnh LEFT JOIN HoaDon hd ON MONTH(dnh.NgayNhap)=MONTH(hd.NgayLap) group by MONTH(dnh.NgayNhap) Union SELECT SUM(dnh.TongTien) as DonNhap,SUM(hd.TongTien) as DonXuat,MONTH(hd.NgayLap) as Thang FROM DonNhapHang dnh RIGHT JOIN HoaDon hd ON MONTH(dnh.NgayNhap)=MONTH(hd.NgayLap) group by MONTH(hd.NgayLap)";
            DataTable dt = db.GetDataTable(sql);
            return dt;
        }

        public DataTable ThongKeDoanhThuByMonth()
        {
            string sql = "SELECT - SUM(dnh.TongTien) + SUM(hd.TongTien) as DoanhThu,MONTH(dnh.NgayNhap) as Thang FROM DonNhapHang dnh LEFT JOIN HoaDon hd ON MONTH(dnh.NgayNhap)=MONTH(hd.NgayLap) group by MONTH(dnh.NgayNhap) Union SELECT - SUM(dnh.TongTien) + SUM(hd.TongTien) as DoanhThu,MONTH(hd.NgayLap) as Thang FROM DonNhapHang dnh RIGHT JOIN HoaDon hd ON MONTH(dnh.NgayNhap)=MONTH(hd.NgayLap) group by MONTH(hd.NgayLap)";
            DataTable dt = db.GetDataTable(sql);
            return dt;
        }

        public int ThongKeKhachHang()
        {
            //string sql = "SELECT - SUM(dnh.TongTien) + SUM(hd.TongTien) as DoanhThu,MONTH(dnh.NgayNhap) as Thang FROM DonNhapHang dnh LEFT JOIN HoaDon hd ON MONTH(dnh.NgayNhap)=MONTH(hd.NgayLap) group by MONTH(dnh.NgayNhap) Union SELECT - SUM(dnh.TongTien) + SUM(hd.TongTien) as DoanhThu,MONTH(hd.NgayLap) as Thang FROM DonNhapHang dnh RIGHT JOIN HoaDon hd ON MONTH(dnh.NgayNhap)=MONTH(hd.NgayLap) group by MONTH(hd.NgayLap)";
            //DataTable dt = db.GetDataTable(sql);
            //string kh=dt.Rows[0].f
            //int sumKH=int.Parse(());
            return 0;
        }

        public DataTable ThongKeTongDNH()
        {
            string sql = "SELECT - SUM(dnh.TongTien) + SUM(hd.TongTien) as DoanhThu,MONTH(dnh.NgayNhap) as Thang FROM DonNhapHang dnh LEFT JOIN HoaDon hd ON MONTH(dnh.NgayNhap)=MONTH(hd.NgayLap) group by MONTH(dnh.NgayNhap) Union SELECT - SUM(dnh.TongTien) + SUM(hd.TongTien) as DoanhThu,MONTH(hd.NgayLap) as Thang FROM DonNhapHang dnh RIGHT JOIN HoaDon hd ON MONTH(dnh.NgayNhap)=MONTH(hd.NgayLap) group by MONTH(hd.NgayLap)";
            DataTable dt = db.GetDataTable(sql);
            return dt;
        }

        public int ThongKeTongHoaDonBan()
        {
            string sql = "SELECT COUNT(MAHD) AS TongHD FROM HoaDon";
            DataTable dt = db.GetDataTable(sql);
            return dt.Rows[0].Field<int>(0);
        }

        public int ThongKeTongHoaDonNhap()
        {
            string sql = "SELECT COUNT(MaDNH) FROM DonNhapHang";
            DataTable dt = db.GetDataTable(sql);
            return dt.Rows[0].Field<int>(0);
        }
        public int ThongKeTongKhacHang()
        {
            string sql = "SELECT COUNT(MaKH) FROM KhachHang";
            DataTable dt = db.GetDataTable(sql);
            return dt.Rows[0].Field<int>(0);
        }

        public int ThongKeTongNhaCungCap()
        {
            string sql = "SELECT COUNT(MaNCC) FROM NhaCungCap";
            DataTable dt = db.GetDataTable(sql);
            return dt.Rows[0].Field<int>(0);
        }

        public int ThongKeTongHangHoa()
        {
            string sql = "SELECT COUNT(MaHH) FROM ThongTinHangHoa";
            DataTable dt = db.GetDataTable(sql);
            return dt.Rows[0].Field<int>(0);
        }

        public int ThongKeTongLoai()
        {
            string sql = "SELECT COUNT(id) FROM LoaiHang";
            DataTable dt = db.GetDataTable(sql);
            return dt.Rows[0].Field<int>(0);
        }

        public int TongNoHoaDon()
        {
            string sql = "SELECT SUM(TongTien) AS TONGNO FROM HoaDon WHERE ConLai>0";
            DataTable dt = db.GetDataTable(sql);
            return (int)dt.Rows[0].Field<long>(0);
        }

        public int TongNoDonNhapHang()
        {
            string sql = "SELECT SUM(TongTien) AS TONGNO FROM DonNhapHang WHERE ConLai>0";
            DataTable dt = db.GetDataTable(sql);
            return (int)dt.Rows[0].Field<long>(0);
        }


        public DataTable ThongKePhanTramLoai()
        {
            string sql = "SELECT LH.TenLoai,sum(hd.SoLuong) as PhanTram FROM ChiTietHD hd Join ThongTinHangHoa hh on hh.MaHH=hd.MaHH join LoaiHang lh on hh.LoaiHang=lh.ID GROUP BY LH.TenLoai ORDER BY SUM(hd.SoLuong) DESC";
            DataTable dt = db.GetDataTable(sql);
            return dt;
        }

        public DataTable ThongKeTop10HangHoa()
        {
            string sql = "SELECT TOP 9 HH.TenHH, SUM(HD.soluong) AS SOLUONG FROM ChiTietHD HD JOIN ThongTinHangHoa HH ON HH.MaHH=HD.MaHH GROUP BY HH.TenHH ORDER BY SUM(HD.soluong) DESC";
            DataTable dt = db.GetDataTable(sql);
            return dt;
        }
    }
}
