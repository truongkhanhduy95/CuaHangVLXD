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
    class KhachHangBLL
    {
        KhachHangDAL dal = new KhachHangDAL();

        public DataTable LoadDanhSachKH() { return dal.LoadDanhSachKH(); }
        public DataTable SearchKH(string search) { return dal.SearchKhachHang(search); }

        public DataTable SearchKhachHangBySDT(string sdt) { return dal.SearchKhachHangBySDT(sdt); }
        public KhachHang GetKhachHangByID(string id) { return dal.GetKhachHangByID(id); }
        public KhachHang Contains(KhachHang kh) { return dal.Contains(kh); }

        public bool Update(KhachHang kh) { return dal.Update(kh); }
        public bool Insert(KhachHang kh) { return dal.Insert(kh); }


    }
}
