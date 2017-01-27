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
    class HangHoaBLL
    {
        HangHoaDAL dal = new HangHoaDAL();

        public DataTable LoadDanhSachHH(bool all) { return dal.LoadDanhSachHH(all); }
        public DataTable LoadDanhSachHHCungCap() { return dal.LoadDanhSachHHCungCap(); }

        public HangHoa GetHangHoaByID(string id) { return dal.GetHangHoaByID(id); }
        public DataTable SearchByTen(string ten) { return dal.SearchByTen(ten); }
        public bool UpdateHH(HangHoa hh) { return dal.Update(hh); }
        public bool DeleteHH(HangHoa hh) { return dal.Delete(hh); }

        public DataTable SearchByLoaiHang(string loai) { return dal.SearchByLoaiHang(loai); }
        public bool Insert(HangHoa hh) { return dal.Insert(hh); }
    }
}
