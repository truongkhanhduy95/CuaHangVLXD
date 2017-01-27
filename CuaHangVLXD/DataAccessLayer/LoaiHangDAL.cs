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
    class LoaiHangDAL
    {
        DataAccessHelper db = new DataAccessHelper();

        public DataTable LoadAll()
        {
            DataAccessHelper db = new DataAccessHelper();
            // string sql = "select LoaiHangID,TenLoaiHang from tblLoaiHang";
            string sql = "select ID,TenLoai from LoaiHang where TrangThai=0";
            DataTable dt = db.GetDataTable(sql);
            return dt;
        }

        public bool Update(LoaiHang lh)
        {
            string spName = "Update_LoaiHang";
            string[] pNames = { "@ID", "@TenLoai"};
            object[] pValues = {lh.MaLoai,lh.TenLoai};
            int count = db.ExecuteStoredProcedure(spName, pNames, pValues);
            return count > 0;
        }

        public LoaiHang GetLoaiHangByID(string id)
        {
            LoaiHang lh = new LoaiHang();
            List<LoaiHang> list = GetList();
            foreach (LoaiHang item in list)
            {
                if (item.MaLoai == id)
                {
                    lh = item;
                    break;
                }
            }
            return lh;
        }

        public DataTable SearchByTen(string search)
        {
            string sql = "select ID,TenLoai from LoaiHang where TrangThai = 0 and TenLoai LIKE N'%" + search + "%'";

            DataTable dt = db.GetDataTable(sql);
            return dt;
        }

        public static List<LoaiHang> GetList()
        {
            DataAccessHelper db = new DataAccessHelper();
            DataTable dt = db.GetDataTable("SELECT * FROM LoaiHang");
            List<LoaiHang> list = new List<LoaiHang>();
            foreach (DataRow item in dt.Rows)
            {
                list.Add(new LoaiHang(item));
            }
            return list;
        }

        public bool Insert(LoaiHang lh)
        {
            string spName = "Insert_LOAIHANG";
            string[] pNames = { "@TenLoai"};
            object[] pValues = { lh.TenLoai };

            int count = db.ExecuteStoredProcedure(spName, pNames, pValues);
            return count > 0;
        }

        public bool Delete(LoaiHang lh)
        {
            string spName = "Delete_LOAIHANG";
            string[] pNames = { "@ID" };
            object[] pValues = { lh.MaLoai };

            int count = db.ExecuteStoredProcedure(spName, pNames, pValues);
            return count > 0;
        }
    }
}
