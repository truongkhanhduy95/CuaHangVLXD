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
    class NhaCungCapBLL
    {
        NhaCungCapDAL dal = new NhaCungCapDAL();

        public DataTable LoadDanhSachNCC() { return dal.LoadDanhSachNCC(); }
        public DataTable SearchNhaCungCap(string search) { return dal.SearchNhaCungCap(search); }
        public NhaCungCap GetNhaCungCapByID(string id) { return dal.GetNhaCungCapByID(id); }
        public NhaCungCap Contains(NhaCungCap ncc) { return dal.Contains(ncc); }
    
        public bool Update(NhaCungCap ncc) { return dal.Update(ncc); }
        public bool Insert(NhaCungCap ncc) { return dal.Insert(ncc); }
    }
}
