using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangVLXD.Model
{
    public abstract class DoiTac
    {
        #region Properties
        private string _ma;

        public string Ma
        {
            get { return _ma; }
            set { _ma = value; }
        }

        private string _ten;

        public string Ten
        {
            get { return _ten; }
            set { _ten = value; }
        }

        private string _soDienThoai;

        public string SoDienThoai
        {
            get { return _soDienThoai; }
            set { _soDienThoai = value; }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _diaChi;

        public string DiaChi
        {
            get { return _diaChi; }
            set { _diaChi = value; }
        }
        #endregion

        #region Contructor
        public DoiTac(string ma, string ten,string sdt, string email, string diaChi)
        {
            this.Ma = ma;
            this.Ten = ten;
            this.SoDienThoai = sdt;
            this.Email = email;
            this.DiaChi = diaChi;
        }

        public DoiTac()
        {

        }

        public DoiTac(string ten, string diachi)
        {
            this.Ten = ten;
            this.DiaChi = diachi;
        }
        #endregion
    }
}
