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
    class DonNhapHangDAL
    {
        DataAccessHelper db = new DataAccessHelper();
        private List<DonNhapHang> list;

        public DonNhapHangDAL()
        {
            list = GetList();
        }
        public DataTable LoadAll()
        {
            DataAccessHelper db = new DataAccessHelper();
            // string sql = "select LoaiHangID,TenLoaiHang from tblLoaiHang";
            string sql = "select * from DonNhapHang";
            DataTable dt = db.GetDataTable(sql);
            return dt;
        }

        public DataTable LoadAllDanhSach()
        {
            DataAccessHelper db = new DataAccessHelper();
            // string sql = "select LoaiHangID,TenLoaiHang from tblLoaiHang";
            string sql = "SELECT MaDNH,kh.TenNCC,FORMAT(hd.NgayNhap, 'yyyy-MM-dd') as NgayNhap,hd.TongTien FROM DonNhapHang hd join NhaCungCap kh on hd.MaNCC=kh.MaNCC";
            DataTable dt = db.GetDataTable(sql);
            return dt;
        }

        public DonNhapHang GetDonNhapHangByID(string id)
        {
            DonNhapHang lh = new DonNhapHang();

            foreach (DonNhapHang hd in list)
            {
                if (hd.MaDNH == id)
                {
                    lh = hd;
                    break;
                }
            }
            return lh;
        }

        public DataTable GetDNHFromNhaCungCap(string maNCC)
        {
            DataAccessHelper db = new DataAccessHelper();
            // string sql = "select LoaiHangID,TenLoaiHang from tblLoaiHang";
            string sql = "SELECT MaDNH,kh.TenNCC,FORMAT(hd.NgayNhap, 'yyyy-MM-dd') as NgayNhap,hd.TongTien FROM DonNhapHang hd join NhaCungCap kh on hd.MaNCC=kh.MaNCC where hd.MaNCC='" + maNCC + "'";
            DataTable dt = db.GetDataTable(sql);
            return dt;
        }

        public DataTable GetDNHFromTenNhaCungCap(string tenNCC)
        {
            DataAccessHelper db = new DataAccessHelper();
            // string sql = "select LoaiHangID,TenLoaiHang from tblLoaiHang";
            string sql = "SELECT MaDNH,kh.TenNCC,FORMAT(hd.NgayNhap, 'yyyy-MM-dd') as NgayNhap,hd.TongTien FROM DonNhapHang hd join NhaCungCap kh on hd.MaNCC=kh.MaNCC where kh.tenNCC LIKE N'%" + tenNCC + "%'";
            DataTable dt = db.GetDataTable(sql);
            return dt;
        }

        public static List<DonNhapHang> GetList()
        {
            DataAccessHelper db = new DataAccessHelper();
            DataTable dt = db.GetDataTable("SELECT * FROM DonNhapHang");
            List<DonNhapHang> list = new List<DonNhapHang>();
            foreach (DataRow item in dt.Rows)
            {
                DonNhapHang hd = new DonNhapHang(item);
                hd.DSHangHoa = GetHangHoaTrongDonNhapHang(hd.MaDNH);
                list.Add(hd);
            }
            return list;
        }

        public static List<HangHoa> GetHangHoaTrongDonNhapHang(string maDNH)
        {
            DataAccessHelper db = new DataAccessHelper();
            DataTable dt = db.GetDataTable("SELECT * FROM ChiTietDNH where MaDNH='" + maDNH + "'");
            List<HangHoa> list = new List<HangHoa>();
            foreach (DataRow item in dt.Rows)
            {
                HangHoa hh=new HangHoa();
                hh.MaHH = item["MaHH"].ToString();
                DataTable table = db.GetDataTable("SELECT * FROM ThongTinHangHoa where MaHH='" + hh.MaHH + "'");
                DataRow row=table.Rows[0];
                hh.GiaGoc = int.Parse(row["GiaGoc"].ToString());
                hh.SoLuong = int.Parse(item["SoLuong"].ToString());
                list.Add(hh);
            }
            return list;
        }

        private string GetMaDNHLastest(string maNCC,DateTime ngayLap)
        {
            DataAccessHelper db = new DataAccessHelper();
            string query = "SELECT TOP 1 MaDNH FROM DonNhapHang ORDER BY NgayNhap DESC";
            DataTable dt = db.GetDataTable(query);
            List<HoaDon> list = new List<HoaDon>();
            DataRow item = dt.Rows[0];
            return item["MaDNH"].ToString();
        }

        public bool AddNewDonNhapHang(DonNhapHang dnh)
        {
            string spName = "Insert_DonNhapHang";
            string[] pNames = { "@MaNCC", "@NgayNhap", "@TongTien", "@DaTra"};
            object[] pValues = { dnh.MaNCC, dnh.NgayLap, dnh.TongTien, dnh.DaTra };

            int count = db.ExecuteStoredProcedure(spName, pNames, pValues);
            if (count>0)
                return AddNewChiTietDNH(dnh);
            else
                return false;
        }

        public bool AddNewChiTietDNH(DonNhapHang dnh)
        {
            int count = 1;
            string spName = "Insert_CTDNH";
            string maHD=GetMaDNHLastest(dnh.MaNCC,dnh.NgayLap);
            foreach (var hh in dnh.DSHangHoa)
            {
                string[] pNames = { "@MaDNH", "@MaHH", "@SoLuong" };
                object[] pValues = { maHD, hh.MaHH, hh.SoLuong };

                count *= db.ExecuteStoredProcedure(spName, pNames, pValues);
            }
            
            return count > 0;
        }

        public DataTable SearchByDate(DateTime fromDate, DateTime toDate)
        {
            DataAccessHelper db = new DataAccessHelper();
            // string sql = "select LoaiHangID,TenLoaiHang from tblLoaiHang";
            string sql = "SELECT MaDNH,ncc.TenNCC,FORMAT(dnh.NgayNhap, 'yyyy-MM-dd') as NgayLap,dnh.TongTien FROM DonNhapHang dnh join NhaCungCap ncc on dnh.MaNCC=ncc.MaNCC WHERE NgayNhap between '" + fromDate.ToString() + "' and '" + toDate.ToString() + "'";
            DataTable dt = db.GetDataTable(sql);
            return dt;
        }
    }
}
