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
    class LoaiHangBLL
    {
        LoaiHangDAL dal = new LoaiHangDAL();

        public DataTable LoadAll() { return dal.LoadAll(); }
        public DataTable SearchByTen(string search) { return dal.SearchByTen(search); }
        public bool Insert(LoaiHang lh) { return dal.Insert(lh); }
        public bool Update(LoaiHang lh) { return dal.Update(lh); }
        public bool Delete(LoaiHang lh) { return dal.Delete(lh); }

        public LoaiHang GetLoaiHangByID(string id) { return dal.GetLoaiHangByID(id); }
    }
}
