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
    class NhaCungCapDAL
    {
        DataAccessHelper db = new DataAccessHelper();

        public static List<NhaCungCap> GetList()
        {
            DataAccessHelper db = new DataAccessHelper();
            DataTable dt = db.GetDataTable("select * from NhaCungCap");
            List<NhaCungCap> list = new List<NhaCungCap>();
            foreach (DataRow item in dt.Rows)
            {
                list.Add(new NhaCungCap(item));
            }
            return list;
        }

        public DataTable LoadDanhSachNCC()
        {
            string sql = "select * from NhaCungCap";
            DataTable dt = db.GetDataTable(sql);
            return dt;
        }

        public DataTable SearchNhaCungCap(string search)
        {
            string sql = "select * from NhaCungCap where TenNCC LIKE N'%" + search + "%'";
            DataTable dt = db.GetDataTable(sql);
            return dt;
        }

        public NhaCungCap GetNhaCungCapByID(string id)
        {
            NhaCungCap kh = new NhaCungCap();
            List<NhaCungCap> list = GetList();
            foreach (NhaCungCap item in list)
            {
                if (item.Ma == id)
                {
                    kh = item;
                    break;
                }
            }
            return kh;
        }

        public NhaCungCap Contains(NhaCungCap ncc)
        {
            NhaCungCap kh = new NhaCungCap();
            List<NhaCungCap> list = GetList();
            foreach (NhaCungCap item in list)
            {
                if (item.Ten == ncc.Ten && item.DiaChi == ncc.DiaChi)
                {
                    kh = item;
                    break;
                }
            }
            return kh;
        }

        public bool Update(NhaCungCap ncc)
        {
            string spName = "Update_NHACUNGCAP";
            string[] pNames = { "@MaNCC", "@TenNCC", "@SoDienThoai", "@Email", "@DiaCHI" };
            object[] pValues = { ncc.Ma, ncc.Ten, ncc.SoDienThoai, ncc.Email, ncc.DiaChi };

            int count = db.ExecuteStoredProcedure(spName, pNames, pValues);
            return count > 0;
        }

        public bool Insert(NhaCungCap ncc)
        {
            string spName = "Insert_NHACUNGCAP";
            string[] pNames = { "@TenNCC", "@SoDienThoai", "@Email", "@DiaCHI" };
            object[] pValues = { ncc.Ten, ncc.SoDienThoai, ncc.Email, ncc.DiaChi };

            int count = db.ExecuteStoredProcedure(spName, pNames, pValues);
            return count > 0;
        }
    }
}
