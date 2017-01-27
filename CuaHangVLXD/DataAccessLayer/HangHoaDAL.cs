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
    class HangHoaDAL
    {
        DataAccessHelper db = new DataAccessHelper();

        public static List<HangHoa> GetList()
        {
            DataAccessHelper db = new DataAccessHelper();
            DataTable dt = db.GetDataTable("select MaHH,TenHH,lh.TenLoai as LoaiHang,GiaGoc,GiaBan,SoLuong,DonViTinh from ThongTinHangHoa hh join LoaiHang lh on hh.LoaiHang=lh.ID");
            List<HangHoa> list = new List<HangHoa>();
            foreach (DataRow item in dt.Rows)
            {
                list.Add(new HangHoa(item));
            }
            return list;
        }

        public DataTable LoadDanhSachHH(bool all)
        {
            string sql = "select hh.MaHH,hh.TenHH, lh.TenLoai,hh.GiaBan,hh.SoLuong from ThongTinHangHoa hh, LoaiHang lh where hh.LoaiHang=lh.ID and hh.TrangThai=0";
            if(all)
                 sql = "select hh.MaHH,hh.TenHH, lh.TenLoai,hh.GiaGoc,hh.GiaBan,hh.SoLuong,hh.DonViTinh from ThongTinHangHoa hh, LoaiHang lh where hh.LoaiHang=lh.ID and hh.TrangThai=0";

            DataTable dt = db.GetDataTable(sql);
            return dt;
        }

        public DataTable LoadDanhSachHHCungCap()
        {
            string sql = "select hh.MaHH,hh.TenHH, lh.TenLoai,hh.GiaGoc,hh.SoLuong from ThongTinHangHoa hh, LoaiHang lh where hh.LoaiHang=lh.ID and hh.TrangThai=0";
            DataTable dt = db.GetDataTable(sql);
            return dt;
        }

        public DataTable SearchByLoaiHang(string maLoai)
        {
            string sql = "select hh.MaHH,hh.TenHH, lh.TenLoai,hh.GiaBan,hh.SoLuong,hh.DonViTinh from ThongTinHangHoa hh, LoaiHang lh where hh.LoaiHang=lh.ID and hh.TrangThai=0 and hh.LoaiHang="+maLoai+"";

            DataTable dt = db.GetDataTable(sql);
            return dt;
        }

        public DataTable SearchByTen(string search)
        {
            string sql = "select hh.MaHH,hh.TenHH, lh.TenLoai,hh.GiaBan,hh.SoLuong,hh.DonViTinh from ThongTinHangHoa hh, LoaiHang lh where hh.LoaiHang=lh.ID and hh.TrangThai=0 and hh.TenHH LIKE N'%"+search+"%'";

            DataTable dt = db.GetDataTable(sql);
            return dt;
        }

        

        public bool Update(HangHoa hh)
        {
            string spName = "Update_HH";
            string[] pNames = { "@MaHH", "@Tenhh","@LoaiHang", "@GiaGoc", "@GiaBan", "@SoLuong", "@DonViTinh" };
            object[] pValues = { hh.MaHH, hh.TenHH,hh.LoaiHang, hh.GiaGoc, hh.GiaBan, hh.SoLuong, hh.DonViTinh };

            int count = db.ExecuteStoredProcedure(spName, pNames, pValues);
            return count > 0;
        }

        public bool Delete(HangHoa hh)
        {
            string spName = "Delete_HH";
            string[] pNames = { "@MaHH"};
            object[] pValues = { hh.MaHH};

            int count = db.ExecuteStoredProcedure(spName, pNames, pValues);
            return count > 0;
        }

        public HangHoa GetHangHoaByID(string id)
        {
            HangHoa hh = new HangHoa();
            List<HangHoa> list = GetList();
            foreach (HangHoa item in list)
            {
                if (item.MaHH == id)
                {
                    hh = item;
                    break;
                }
            }
            return hh;
        }

        public bool Insert(HangHoa hh)
        {
            string spName = "Insert_HH";
            string[] pNames = { "@TenHang", "@LoaiHang", "@GiaGoc", "@GiaBan","@SoLuong","@DonViTinh" };
            object[] pValues = { hh.TenHH, hh.LoaiHang, hh.GiaGoc, hh.GiaBan,hh.SoLuong,hh.DonViTinh };

            int count = db.ExecuteStoredProcedure(spName, pNames, pValues);
            return count > 0;
        }
    }
}
