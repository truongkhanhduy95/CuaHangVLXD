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
    class KhachHangDAL
    {
        DataAccessHelper db = new DataAccessHelper();

        public static List<KhachHang> GetList()
        {
            DataAccessHelper db = new DataAccessHelper();
            DataTable dt = db.GetDataTable("select * from KhachHang");
            List<KhachHang> list = new List<KhachHang>();
            foreach (DataRow item in dt.Rows)
            {
                list.Add(new KhachHang(item));
            }
            return list;
        }

        public DataTable LoadDanhSachKH()
        {
            string sql = "select * from KhachHang";
            DataTable dt = db.GetDataTable(sql);
            return dt;
        }

        public DataTable SearchKhachHang(string search)
        {
            string sql = "select * from KhachHang where TenKH LIKE N'%"+search+"%'";
            DataTable dt = db.GetDataTable(sql);
            return dt;
        }

        public DataTable SearchKhachHangBySDT(string sdt)
        {
            string sql = "select * from KhachHang where SoDienThoai ='" + sdt + "'";
            DataTable dt = db.GetDataTable(sql);
            return dt;
        }

        public KhachHang GetKhachHangByID(string id)
        {
            KhachHang kh = new KhachHang();
            List<KhachHang> list = GetList();
            foreach (KhachHang item in list)
            {
                if (item.Ma == id)
                {
                    kh = item;
                    break;
                }
            }
            return kh;
        }

        public KhachHang Contains(KhachHang khachHang)
        {
            KhachHang kh = new KhachHang();
            List<KhachHang> list = GetList();
            foreach (KhachHang item in list)
            {
                if (item.Ten == khachHang.Ten && item.DiaChi == khachHang.DiaChi)
                {
                    kh = item;
                    break;
                }
            }
            return kh;
        }

        public bool Update(KhachHang kh)
        {
            string spName = "Update_KH";
            string[] pNames = { "@MaKH", "@TenKH", "@SDT", "@Email", "@DiaCHI" };
            object[] pValues = { kh.Ma,kh.Ten, kh.SoDienThoai,kh.Email,kh.DiaChi };

            int count = db.ExecuteStoredProcedure(spName, pNames, pValues);
            return count > 0;
        }

        public bool Insert(KhachHang kh)
        {
            string spName = "Insert_KH";
            string[] pNames = {"@TenKH", "@SDT", "@Email", "@DiaCHI" };
            object[] pValues = {kh.Ten, kh.SoDienThoai, kh.Email, kh.DiaChi };

            int count = db.ExecuteStoredProcedure(spName, pNames, pValues);
            return count > 0;
        }
        

        
    }
}
