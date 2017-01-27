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
    class HoaDonDAL
    {
        DataAccessHelper db = new DataAccessHelper();
        private List<HoaDon> list;

        public HoaDonDAL()
        {
            list = GetList();
        }
        public DataTable LoadAll()
        {
            DataAccessHelper db = new DataAccessHelper();
            // string sql = "select LoaiHangID,TenLoaiHang from tblLoaiHang";
            string sql = "select * from HoaDon";
            DataTable dt = db.GetDataTable(sql);
            return dt;
        }

        public DataTable LoadAllDanhSach()
        {
            DataAccessHelper db = new DataAccessHelper();
            // string sql = "select LoaiHangID,TenLoaiHang from tblLoaiHang";
            string sql = "SELECT MaHD,kh.TenKH,FORMAT(hd.NgayLap, 'yyyy-MM-dd') as NgayLap,hd.TongTien FROM HoaDon hd join KhachHang kh on hd.MaKH=kh.MaKH";
            DataTable dt = db.GetDataTable(sql);
            return dt;
        }

        public DataTable SearchByDate(DateTime fromDate, DateTime toDate)
        {
            DataAccessHelper db = new DataAccessHelper();
            // string sql = "select LoaiHangID,TenLoaiHang from tblLoaiHang";
            string sql = "SELECT MaHD,kh.TenKH,FORMAT(hd.NgayLap, 'yyyy-MM-dd') as NgayLap,hd.TongTien FROM HoaDon hd join KhachHang kh on hd.MaKH=kh.MaKH WHERE NgayLap between '" + fromDate.ToString() + "' and '" + toDate.ToString() + "'";
            DataTable dt = db.GetDataTable(sql);
            return dt;
        }

        public HoaDon GetHoaDonByID(string id)
        {
            HoaDon lh = new HoaDon();
            
            foreach (HoaDon hd in list)
            {
                if (hd.MaHD == id)
                {
                    lh = hd;
                    break;
                }
            }
            return lh;
        }

        public DataTable GetHDFromKhachHang(string maKH)
        {
            DataAccessHelper db = new DataAccessHelper();
            // string sql = "select LoaiHangID,TenLoaiHang from tblLoaiHang";
            string sql = "SELECT MaHD,kh.TenKH,FORMAT(hd.NgayLap, 'yyyy-MM-dd') as NgayLap,hd.TongTien FROM HoaDon hd join KhachHang kh on hd.MaKH=kh.MaKH where hd.MaKH='"+maKH+"'";
            DataTable dt = db.GetDataTable(sql);
            return dt;
        }

        public DataTable GetHDFromTenKhachHang(string tenKH)
        {
            DataAccessHelper db = new DataAccessHelper();
            // string sql = "select LoaiHangID,TenLoaiHang from tblLoaiHang";
            string sql = "SELECT MaHD,kh.TenKH,FORMAT(hd.NgayLap, 'yyyy-MM-dd') as NgayLap,hd.TongTien FROM HoaDon hd join KhachHang kh on hd.MaKH=kh.MaKH where kh.tenKH LIKE N'%" + tenKH + "%'";
            DataTable dt = db.GetDataTable(sql);
            return dt;
        }

        public static List<HoaDon> GetList()
        {
            DataAccessHelper db = new DataAccessHelper();
            DataTable dt = db.GetDataTable("SELECT * FROM HoaDon");
            List<HoaDon> list = new List<HoaDon>();
            foreach (DataRow item in dt.Rows)
            {
                HoaDon hd = new HoaDon(item);
                hd.DSHangHoa = GetHangHoaTrongHoaDon(hd.MaHD);
                list.Add(hd);
            }
            return list;
        }

        public static List<HangHoa> GetHangHoaTrongHoaDon(string maHD)
        {
            DataAccessHelper db = new DataAccessHelper();
            DataTable dt = db.GetDataTable("SELECT * FROM ChiTietHD where MaHD='"+maHD+"'");
            List<HangHoa> list = new List<HangHoa>();
            foreach (DataRow item in dt.Rows)
            {
                HangHoa hh=new HangHoa();
                hh.MaHH = item["MaHH"].ToString();
                DataTable table = db.GetDataTable("SELECT * FROM ThongTinHangHoa where MaHH='" + hh.MaHH + "'");
                DataRow row=table.Rows[0];
                hh.GiaBan = int.Parse(row["GiaBan"].ToString());
                hh.SoLuong = int.Parse(item["SoLuong"].ToString());
                list.Add(hh);
            }
            return list;
        }

        public string GetMaHDLastest(string maKH,DateTime ngayLap)
        {
            DataAccessHelper db = new DataAccessHelper();
            string query = "SELECT * FROM HoaDon where MaKH='" + maKH + "' and ngayLap='" + ngayLap.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'";
            DataTable dt = db.GetDataTable(query);
            List<HoaDon> list = new List<HoaDon>();
            DataRow item = dt.Rows[0];
            return item["MaHD"].ToString();
        }

        public bool AddNewHoaDon(HoaDon hd)
        {
            string spName = "Insert_HoaDon";
            string[] pNames = { "@MaKH", "@NgayNhap", "@TongTien", "@DaTra"};
            object[] pValues = { hd.MaKH,hd.NgayLap,hd.TongTien,hd.DaTra};

            int count = db.ExecuteStoredProcedure(spName, pNames, pValues);
            if (count>0)
                return AddNewChiTietHoaDon(hd);
            else
                return false;
        }

        public bool AddNewChiTietHoaDon(HoaDon hd)
        {
            int count = 1;
            string spName = "Insert_CTHD";
            string maHD=GetMaHDLastest(hd.MaKH,hd.NgayLap);
            foreach (var hh in hd.DSHangHoa)
            {
                string[] pNames = { "@MaHD", "@MaHH", "@SoLuong" };
                object[] pValues = { maHD, hh.MaHH, hh.SoLuong };

                count *= db.ExecuteStoredProcedure(spName, pNames, pValues);
            }
            
            return count > 0;
        }

        public DataTable TableInHoaDon(string maHD)
        {
            DataAccessHelper db = new DataAccessHelper();
            // string sql = "select LoaiHangID,TenLoaiHang from tblLoaiHang";
            string sql = "SELECT HoaDon.MaHD, HoaDon.NgayLap, KhachHang.TenKH, KhachHang.SoDienThoai, KhachHang.Email, KhachHang.DiaChi, ThongTinHangHoa.MaHH, ThongTinHangHoa.TenHH, LoaiHang.TenLoai, ThongTinHangHoa.GiaBan, ChiTietHD.SoLuong, ThongTinHangHoa.DonViTinh, HoaDon.TongTien, HoaDon.ConLai, HoaDon.DaTra FROM   ChiTietHD INNER JOIN HoaDon ON ChiTietHD.MaHD = HoaDon.MaHD INNER JOIN KhachHang ON HoaDon.MaKH = KhachHang.MaKH INNER JOIN ThongTinHangHoa ON ChiTietHD.MaHH = ThongTinHangHoa.MaHH INNER JOIN LoaiHang ON ThongTinHangHoa.LoaiHang = LoaiHang.ID WHERE HoaDon.MaHD='"+maHD+"'";
            DataTable dt = db.GetDataTable(sql);
            return dt;
        }

        public string GetMaHDLastest()
        {
            DataAccessHelper db = new DataAccessHelper();
            string query = "SELECT TOP 1 MaHD FROM HoaDon ORDER BY NgayLap DESC";
            DataTable dt = db.GetDataTable(query);
            List<HoaDon> list = new List<HoaDon>();
            DataRow item = dt.Rows[0];
            return item["MaHD"].ToString();
        }
    }
}
