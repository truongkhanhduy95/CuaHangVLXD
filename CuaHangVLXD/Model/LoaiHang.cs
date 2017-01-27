using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangVLXD.Model
{
    class LoaiHang
    {
        #region Properties
        private string _maLoai;

        public string MaLoai
        {
            get { return _maLoai; }
            set { _maLoai = value; }
        }

        private string _tenLoai;

        public string TenLoai
        {
            get { return _tenLoai; }
            set { _tenLoai = value; }
        }

        #endregion

        #region Contructor
        public LoaiHang(string maLoai, string tenLoai)
        {
            this._maLoai = maLoai;
            this._tenLoai = tenLoai;
        }

        public LoaiHang()
        {

        }

        public LoaiHang(System.Data.DataRow item)
        {
            this._maLoai = item["ID"].ToString();
            this._tenLoai = item["TenLoai"].ToString();
        }
        #endregion
      
    }
}
