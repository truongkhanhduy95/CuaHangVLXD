using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangVLXD.Model
{
    public class KhachHang:DoiTac
    {

        #region Contructor
        public KhachHang():base()
        {
        }

        public KhachHang(string maKH, string tenKH, string sdt, string email, string diaChi):base(maKH,tenKH,sdt,email,diaChi)
        {
        }

        public KhachHang(string tenKH, string diaChi):base(tenKH,diaChi)
        {
        }

        public KhachHang(System.Data.DataRow item)
        {
            this.Ma = item["MaKH"].ToString();
            this.Ten  = item["TenKH"].ToString();
            this.SoDienThoai = item["SoDienThoai"].ToString();
            this.Email = item["Email"].ToString();
            this.DiaChi = item["DiaChi"].ToString();
        }
        #endregion

    }
}
